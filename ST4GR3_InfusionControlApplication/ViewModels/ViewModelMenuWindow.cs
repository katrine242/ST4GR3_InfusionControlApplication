using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ST4GR3_InfusionControlApplication.Commands;

namespace ST4GR3_InfusionControlApplication.ViewModels
{
    public class ViewModelMenuWindow : ViewModelBase
    {

        public ICommand MenuCreateInfusionCommand { get; }
        public ICommand MenuLogOutCommand { get; }

        public ViewModelMenuWindow()
        {
            MenuCreateInfusionCommand = new MenuCreateInfusionCommand();
        }
    }
}
