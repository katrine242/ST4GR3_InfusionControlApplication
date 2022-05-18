using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace ICA_DataAccessLayer.DbContexts
{
    public interface IInfusionPlanDbContextFactory
    {
        //public ServiceProvider CreateServiceProvider();

        public InfusionPlanDbContext CreateDbContext();

    }
}
