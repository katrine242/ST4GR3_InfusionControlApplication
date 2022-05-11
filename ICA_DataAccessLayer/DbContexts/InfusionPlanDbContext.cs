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
        public DbSet<DTO_TimeFlowList> TimeFlowLists { get; set; }

        public DbSet<DTO_TimeFlowListItem> TimeFlowListItems { get; set; }
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
            modelBuilder.Entity<DTO_InfusionPlan>().HasKey(i => i.CPR);
            modelBuilder.Entity<DTO_TimeFlowList>().HasKey(i => new {i.Id, i.DtoInfusionPlanCpr});
            modelBuilder.Entity<DTO_TimeFlowListItem>()
                .HasKey(i => new {i.Id, i.DtoTimeFlowListId, i.DtoTimeFlowListDtoInfusionPlanCpr});

            modelBuilder.Entity<DTO_InfusionPlan>().HasMany(i => i.TimeFlowLists)
                .WithOne(i => i.DtoInfusionPlan)
                .HasForeignKey(i => i.DtoInfusionPlanCpr)
                .IsRequired();

            modelBuilder.Entity<DTO_TimeFlowList>().HasMany(i => i.TimeFlowListItems)
                .WithOne(i => i.DtoTimeFlowList)
                .HasForeignKey(i => new {i.DtoTimeFlowListId, i.DtoTimeFlowListDtoInfusionPlanCpr})
                .IsRequired();


        }
    }
}
