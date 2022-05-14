using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ST4GR3_InfusionControlApplication.Commands;
using ST4GR3_InfusionControlApplication.Stores;

namespace ST4GR3_InfusionControlApplication.ViewModels
{
    public class ViewModelMenuWindow : ViewModelBase
    {

        public ICommand MenuCreateInfusionCommand { get; }
        public ICommand MenuLogOutCommand { get; }

        public ViewModelMenuWindow(NavigationStore navigationStore, Func<ViewModelCreateInfusion> createViewModelCreateInfusion)
        {
            MenuCreateInfusionCommand = new NavigateCommand(navigationStore, createViewModelCreateInfusion);
            
        }
    }
}
