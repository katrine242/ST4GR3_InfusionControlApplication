using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO_Library;
using ICA_BusinessLogicLayer;

namespace ST4GR3_InfusionControlApplication.ViewModels
{
   public class ViewModelDataInfusionPlan : ViewModelBase
   {
      private readonly InfusionPlan _infusionPlan;
      public string PatientName => _infusionPlan.PatientName;
      public string CPR => _infusionPlan.CPR.ToString();
      public string Weight => _infusionPlan.Weight.ToString();
      public string MedicineName => _infusionPlan.Medicine.Name;
      public string BatchId => _infusionPlan.BatchId.ToString();
      public string MachineID => _infusionPlan.MachineID.ToString();
      //public DateTime Fulltime => Convert.ToDateTime(_infusionPlan.InfusionData.Fulltime);
      //public DateTime TimeLeft { get; }
      

      public ViewModelDataInfusionPlan(InfusionPlan infusionPlan)
      {
         _infusionPlan = infusionPlan;
      }
   }
}
