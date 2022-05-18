using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using ICA_BusinessLogicLayer;
using ICA_BusinessLogicLayer.Exception;
using ST4GR3_InfusionControlApplication.ViewModels;

namespace ST4GR3_InfusionControlApplication.Commands
{
   public class CreatePlanCommand:AsyncCommandBase
   {
      private readonly InfusionOverview _infusionOverview;
      private readonly ViewModelCreateInfusion _viewModelCreateInfusion;

      public CreatePlanCommand(ViewModelCreateInfusion viewModelCreateInfusion,InfusionOverview infusionOverview)
      {
         _infusionOverview = infusionOverview;
         _viewModelCreateInfusion = viewModelCreateInfusion;
      }

      public override async Task ExecuteAsync(object parameter)
      {
         try
         {
            InfusionPlan infusionPlan =
               new InfusionPlan(
                  new Medicine().GetMedicine(_infusionOverview.Configlist, _viewModelCreateInfusion.Medicine)
                  , Convert.ToInt32(_viewModelCreateInfusion.MachineID), Convert.ToInt32(_viewModelCreateInfusion.BatchID), _viewModelCreateInfusion.CPR
                  , Convert.ToInt64(_viewModelCreateInfusion.Weight), _viewModelCreateInfusion.Patient);

            infusionPlan.MakeInfusionPlan();
            

         }
         catch (InvalidMedicineNameConflictException ex)
         {
            MessageBox.Show("Medicin ikke tilgængeligt", "Fejlmeddelelse", MessageBoxButton.OK, MessageBoxImage.Error);
         }
      }
   }
}
