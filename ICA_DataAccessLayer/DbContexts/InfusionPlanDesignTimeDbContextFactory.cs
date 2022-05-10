using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace ICA_DataAccessLayer.DbContexts
{
    public class InfusionPlanDesignTimeDbContextFactory: IDesignTimeDbContextFactory<InfusionPlanDbContext>
    {
        public InfusionPlanDbContext CreateDbContext(string[] args)
        {
            DbContextOptions options = new DbContextOptionsBuilder().UseSqlite("Data Source=infusionPlan.db").Options;

            return new InfusionPlanDbContext(options);
        }
    }
}
