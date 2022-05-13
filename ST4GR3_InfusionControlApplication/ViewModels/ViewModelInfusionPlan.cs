using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using DTO_Library;
using ICA_BusinessLogicLayer;

namespace ST4GR3_InfusionControlApplication.ViewModels
{
   public class ViewModelInfusionPlan:ViewModelBase
   {
      private readonly InfusionPlan _infusionPlan;
      public string PatientName => _infusionPlan.InfusionData.PatientName;
      public string CPR => _infusionPlan.InfusionData.CPR.ToString();
      public string Height => _infusionPlan.InfusionData.Height.ToString();
      public string Weight => _infusionPlan.InfusionData.Weight.ToString();
      public string MedicineName => _infusionPlan.InfusionData.MedicineName;
      public string BatchId => _infusionPlan.InfusionData.BatchId.ToString();
      public string MachineID => _infusionPlan.InfusionData.MachineID.ToString();
      public DateTime Fulltime => Convert.ToDateTime(_infusionPlan.InfusionData.Fulltime);
      public DateTime TimeLeft { get; }
      public List<DTO_TimeFlow> DtoTimeFlowList { get; set; }

      public ViewModelInfusionPlan(InfusionPlan infusionPlan)
      {
         _infusionPlan = infusionPlan;
      }
      public ICommand BackCommand { get; }

   }
}
