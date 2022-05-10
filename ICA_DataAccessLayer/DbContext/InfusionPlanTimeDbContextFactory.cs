using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace ICA_DataAccessLayer.DbContext
{
    public class InfusionPlanTimeDbContextFactory
    {
        public InfusionPlanDbContext CreateDbContext(string[] args)
        {
            DbContextOptions options = new DbContextOptionsBuilder().UseSqlite("Data Source=InfusionPlan.db").Options;

            return new InfusionPlanDbContext(options);
        }
    }
}
