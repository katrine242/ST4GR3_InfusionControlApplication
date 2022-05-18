using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using ST4GR3_InfusionControlApplication.ViewModels;
using ICA_BusinessLogicLayer;

namespace ST4GR3_InfusionControlApplication.Commands
{
    public class LoadInfusionPlanCommand:AsyncCommandBase
    {
        private readonly ViewModelMenuWindow _viewModelMenuWindow;
        private readonly InfusionOverview _overview;

        public LoadInfusionPlanCommand(ViewModelMenuWindow viewModelMenuWindow, InfusionOverview overview)
        {
            _viewModelMenuWindow = viewModelMenuWindow;
            _overview = overview;
        }


        public override async Task ExecuteAsync(object parameter)
        {
            try
            {
                IEnumerable<InfusionPlan> infusionPlans = await _overview.GetAllInfusionPlans();
                _viewModelMenuWindow.UpdateInfusionPlans(infusionPlans);
            }
            catch (Exception e)
            {
                MessageBox.Show("Failed to load InfusionPlans.", "Error",
                    MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
