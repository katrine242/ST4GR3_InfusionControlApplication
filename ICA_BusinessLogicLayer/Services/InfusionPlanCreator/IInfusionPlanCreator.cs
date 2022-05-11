using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO_Library;
using Microsoft.Extensions.DependencyInjection;

namespace ICA_BusinessLogicLayer.Services.InfusionPlanCreator
{
    public interface IInfusionPlanCreator
    {
        Task CreateInfusionPlan(InfusionPlan infusionPlan);
        void MigrateToDataBase();
    }
}
