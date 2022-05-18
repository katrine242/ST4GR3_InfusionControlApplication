using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO_Library;

namespace ICA_BusinessLogicLayer.Services.InfusionPlanProvider
{
    public interface IInfusionPlanProvider
    {
        Task<IEnumerable<InfusionPlan>> GetAllInfusionPlans();
        public DTO_InfusionPlan GetOneInfusionPlan(string WantedCPR);
    }
}
