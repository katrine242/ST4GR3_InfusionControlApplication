using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ICA_BusinessLogicLayer;
using ST4GR3_InfusionControlApplication.ViewModels;

namespace ST4GR3_InfusionControlApplication.Commands
{
    public class CreateInfusionViewCommand : CommandBase
    {
       private readonly ViewModelCreateInfusion _viewModelCreateInfusion;
       private readonly InfusionOverview _infusionOverview;

       public override void Execute(object parameter)
        {
            //InfusionPlan infusionPlan=new InfusionPlan(new Medicine(_viewModelCreateInfusion.Medicine,))
        }

        public CreateInfusionViewCommand(ViewModelCreateInfusion viewModelCreateInfusion, InfusionOverview Infusionoverview)
        {
           _viewModelCreateInfusion = viewModelCreateInfusion;
           _infusionOverview = Infusionoverview;
        }
    }
}