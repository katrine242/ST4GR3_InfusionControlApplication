using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ICA_BusinessLogicLayer;
using ICA_BusinessLogicLayer.Services.InfusionPlanProvider;
using ST4GR3_InfusionControlApplication.Stores;
using ST4GR3_InfusionControlApplication.ViewModels;

namespace ST4GR3_InfusionControlApplication.Commands
{
    public class NavigateCommand :CommandBase
    {
        // Lige nu Binder Opret Infusionsplan-knappen (MenuWindovwViewModel) til denne command
        private readonly NavigationStore _navigationStore;

        public NavigateCommand(NavigationStore navigationStore)
        {
            _navigationStore = navigationStore;
        }
        public override void Execute(object parameter)
        {
            
            _navigationStore.CurrentViewModel = new ViewModelMenuWindow(_navigationStore); //Når trykket på knappen, ledes til dette View
        }
    }
}
