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
        public DbSet<DTO_Infusionplan> InfusionPlan { get; set; }
        public InfusionPlanDbContext() { }

        public InfusionPlanDbContext(DbContextOptions options) : base(options) { }

     





        //Det her skal nok væk: 
        //private readonly string _connectingString;

        //public InfusionPlanDbContext(string connectingString)
        //{
        //    _connectingString = connectingString;
        //}
        //public InfusionPlanDbContext CreateDbContext()
        //{
        //    DbContextOptions options = new DbContextOptionsBuilder().UseSqlite(_connectingString).Options;

        //    return new InfusionPlanDbContext(options);
        //}
    }
}
