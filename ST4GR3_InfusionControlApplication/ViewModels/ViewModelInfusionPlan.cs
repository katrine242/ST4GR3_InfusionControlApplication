using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using DTO_Library;
using ICA_BusinessLogicLayer;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using ST4GR3_InfusionControlApplication.Commands;

namespace ST4GR3_InfusionControlApplication.ViewModels
{
   public class ViewModelInfusionPlan:ViewModelBase
   {
      public ViewModelDataInfusionPlan _DataInfusionPlan;

      public int Patient { get; set; }

      public int CPR { get; set; }

      public double Height { get; set; }

      public int Weight { get; set; }

      public int Medicine { get; set; }

      public int BatchID { get; set; }

      public int MachineID { get; set; }

      public ICommand BackCommand { get; }
      public ViewModelInfusionPlan()
      {
         // _DataInfusionPlan = new ViewModelDataInfusionPlan(infusionPlan);
         BackCommand = new ReturnCommand();
      }


   }
}
