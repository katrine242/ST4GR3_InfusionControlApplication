using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO_Library;
using ICA_Model.Services.InfusionPlanProvider;
using ICA_Model.Services.InfusionPlanCreator;

namespace ICA_Model
{
    public class InfusionPlanBook
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
