using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ICA_BusinessLogicLayer;

namespace ST4GR3_InfusionControlApplication.ViewModels
{
    public class MainViewModel: ViewModelBase
    {
        public ViewModelBase CurrentViewModel { get; }

        public MainViewModel()
        {
            CurrentViewModel = new ViewModelCreateInfusion();
        }

       public MainViewModel(InfusionOverview infusionOverview)
       {
          CurrentViewModel = new ViewModelCreateInfusion(infusionOverview);
       }
    }
}
