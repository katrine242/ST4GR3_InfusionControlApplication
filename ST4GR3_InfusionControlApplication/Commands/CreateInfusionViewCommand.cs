using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO_Library;
using ICA_BusinessLogicLayer;
using ST4GR3_InfusionControlApplication.ViewModels;

namespace ST4GR3_InfusionControlApplication.Commands
{
    public class CreateInfusionViewCommand : CommandBase
    {
       private readonly ViewModelCreateInfusion _viewModelCreateInfusion;
       private readonly InfusionOverview _infusionOverview;
       private new DTO_InfusionPlan _infusionPlanDTO;
       private new Medicine _medicine;

       public override void Execute(object parameter)
       {
          InfusionPlan infusionPlan =
             new InfusionPlan(new Medicine().GetMedicine(_infusionOverview.Configlist, _viewModelCreateInfusion.Medicine),
                _infusionPlanDTO);
          _infusionPlanDTO.Weight = _viewModelCreateInfusion.Weight;

          infusionPlan.MakeInfusionPlan();
       }

        public CreateInfusionViewCommand(ViewModelCreateInfusion viewModelCreateInfusion, InfusionOverview infusionOverview)
        {
           _viewModelCreateInfusion = viewModelCreateInfusion;
           _infusionOverview = infusionOverview;
           _infusionPlanDTO = new DTO_InfusionPlan();
           _medicine=new Medicine();
        }
    }
}