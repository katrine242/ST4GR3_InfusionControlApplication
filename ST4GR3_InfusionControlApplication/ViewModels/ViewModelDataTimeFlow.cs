using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO_Library;
using ICA_BusinessLogicLayer;

namespace ST4GR3_InfusionControlApplication.ViewModels
{
    public class ViewModelDataTimeFlow : ViewModelBase
    {
        private readonly InfusionPlan _infusionPlan;

        public ViewModelDataTimeFlow(InfusionPlan infusionPlan)
        {
            _infusionPlan = infusionPlan;
        }

        public string Time => _infusionPlan.DtoTimeFlowList[0].Time.ToString();
        public string Flow => _infusionPlan.DtoTimeFlowList[0].Flow.ToString();


    }
}
