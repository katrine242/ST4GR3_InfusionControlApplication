using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace ICA_DataAccessLayer.DbContexts
{
    public class InfusionPlanDbContextFactory:IInfusionPlanDbContextFactory
    {
        private readonly string _connectingString;

        public InfusionPlanDbContextFactory(string connectingString)
        {
            _connectingString = connectingString;
        }

        public ServiceProvider CreateServiceProvider()
        {
            var services = new ServiceCollection();
            services.AddDbContext<InfusionPlanDbContext>(opt => opt.UseSqlite(_connectingString));
            var serviceCollection = services.BuildServiceProvider();
            return serviceCollection;
        }
        public InfusionPlanDbContext CreateDbContext()
        {
            DbContextOptions options = new DbContextOptionsBuilder().UseSqlite(_connectingString).Options;

            return new InfusionPlanDbContext(options);
        }
    }
}
