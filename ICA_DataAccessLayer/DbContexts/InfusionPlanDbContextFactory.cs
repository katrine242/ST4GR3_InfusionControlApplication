using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ICA_DataAccessLayer.DbContexts
{
    public class InfusionPlanDbContextFactory
    {
        private readonly string _connectingString;

        public InfusionPlanDbContextFactory(string connectingString)
        {
            _connectingString = connectingString;
        }
        public InfusionPlanDbContext CreateDbContext()
        {
            DbContextOptions options = new DbContextOptionsBuilder().UseSqlite(_connectingString).Options;

            return new InfusionPlanDbContext(options);
        }
    }
}
