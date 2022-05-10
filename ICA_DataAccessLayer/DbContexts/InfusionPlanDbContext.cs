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

        public InfusionPlanDbContext(DbContextOptions options) : base(options) { }
    }
}
