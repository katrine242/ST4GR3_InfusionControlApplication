using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO_Library;

namespace ICA_BusinessLogicLayer
{
    public interface IInfusionPlanBook
    {

        public Task<IEnumerable<InfusionPlan>> GetAllInfusionPlans();

        public Task AddInfusionPlan(InfusionPlan infusionPlan);
        public DTO_InfusionPlan GetOneInfusionPlan(string WantedCPR);
    }
}
