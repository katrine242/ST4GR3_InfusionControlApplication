using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO_Library;
using ICA_BusinessLogicLayer.Services.InfusionPlanCreator;
using ICA_BusinessLogicLayer.Services.InfusionPlanProvider;

namespace ICA_BusinessLogicLayer
{
    public class InfusionPlanBook:IInfusionPlanBook
    {
        private readonly IInfusionPlanProvider _infusionPlanProvider;
        private readonly IInfusionPlanCreator _infusionPlanCreator;

        public InfusionPlanBook(IInfusionPlanProvider infusionPlanProvider, IInfusionPlanCreator infusionPlanCreator)
        {
            _infusionPlanProvider = infusionPlanProvider;
            _infusionPlanCreator = infusionPlanCreator;
        }
        public async Task<IEnumerable<InfusionPlan>> GetAllInfusionPlans() //På den her måde kan man hente en infusionsplan fra databasen efter de er oprettet
        {
            return await _infusionPlanProvider.GetAllInfusionPlans();
        }

        public async Task AddInfusionPlan(InfusionPlan infusionPlan)
        {
            await _infusionPlanCreator.CreateInfusionPlan(infusionPlan);
        }
    }
}
