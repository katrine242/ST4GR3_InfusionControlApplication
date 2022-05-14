using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO_Library;

namespace ICA_BusinessLogicLayer
{
   public class InfusionOverview //Denne her klasse skal muligvis slettes. Vi ser lige på det når vi har oprettet ViewModel
   {
      private readonly InfusionPlanBook _infusionPlanBook;
      public List<Medicine_config> Configlist { get; set; }
      public InfusionOverview(InfusionPlanBook infusionPlanBook, List<Medicine_config> configlist)
      {
         _infusionPlanBook = infusionPlanBook;
         Configlist = configlist;
      }


      public async Task<IEnumerable<InfusionPlan>> GetAllInfusionPlans()
      {

         return await _infusionPlanBook.GetAllInfusionPlans();
      }

        public async Task CreateInfusionPlan(InfusionPlan infusionPlan)
        {
            await _infusionPlanBook.AddInfusionPlan(infusionPlan);
        }
    }
}
