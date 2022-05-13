using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using DTO_Library;

namespace ICA_DataAccessLayer.DbContexts
{
    public class InfusionPlanDbContext : DbContext
    {
        public DbSet<DTO_InfusionPlan> InfusionPlans { get; set; }
        public DbSet<DTO_TimeFlow> TimeFlows { get; set; }

        public InfusionPlanDbContext()
        {

        }

        public InfusionPlanDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlite("Data Source=infusionPlan.db");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) //Her siger jeg hvad de forskellige DTOs primary key er og nedenunder hvad deres forerign key er. 
        {
            modelBuilder.Entity<DTO_InfusionPlan>().HasKey(i => i.MachineID);

            modelBuilder.Entity<DTO_TimeFlow>().HasKey(i => new {i.Id, DtoInfusionPlanMachineID = i.DtoInfusionPlanMachineId});

            modelBuilder.Entity<DTO_InfusionPlan>().HasMany(i => i.DtoTimeFlowList)
                .WithOne(i=>i.DtoInfusionPlan)
                .HasForeignKey(i=>i.DtoInfusionPlanMachineId).IsRequired();

            //https://stackoverflow.com/questions/48435542/entity-framework-core-fluent-api-one-to-many-and-one-to-one-produces-duplicate-f 
        }
    }
}
