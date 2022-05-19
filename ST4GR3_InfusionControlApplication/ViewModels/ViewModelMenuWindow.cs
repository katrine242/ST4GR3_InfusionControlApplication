using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using DTO_Library;
using ICA_BusinessLogicLayer;
using ICA_BusinessLogicLayer.Services;
using ST4GR3_InfusionControlApplication.Commands;
using ST4GR3_InfusionControlApplication.Navigation;

namespace ST4GR3_InfusionControlApplication.ViewModels
{
    public class ViewModelMenuWindow : ViewModelBase
    {
        private readonly InfusionOverview _infusionOverview;
        private readonly ObservableCollection<ViewModelDataInfusionPlan> _infusionPlans;
        public IEnumerable<ViewModelDataInfusionPlan> InfusionPlans => _infusionPlans;

        public ICommand MenuCreateInfusionCommand { get; }
        public ICommand LoadInfusionCommand { get; }
        public ICommand MenuLogOutCommand { get; }

        public ViewModelMenuWindow(InfusionOverview infusionOverview, NavigationService createInfusionInCreateInfusionNavigationService)
        {
            _infusionPlans = new ObservableCollection<ViewModelDataInfusionPlan>();
            _infusionOverview = infusionOverview;

            MenuCreateInfusionCommand = new NavigateCommand(createInfusionInCreateInfusionNavigationService);
            LoadInfusionCommand = new LoadInfusionPlanCommand(this, infusionOverview);
        }

        public static ViewModelMenuWindow LoadViewModel(InfusionOverview overview,
            NavigationService makeNavigationService)
        {
            ViewModelMenuWindow viewModel = new ViewModelMenuWindow(overview, makeNavigationService);

            viewModel.LoadInfusionCommand.Execute(null);

            return viewModel;
        }

        public void UpdateInfusionPlans(IEnumerable<InfusionPlan> infusionPlans)
        {
            _infusionPlans.Clear();

            foreach (InfusionPlan infusionPlan in infusionPlans)
            {
                ViewModelDataInfusionPlan viewModelDataInfusionPlan = new ViewModelDataInfusionPlan(infusionPlan);
                _infusionPlans.Add(viewModelDataInfusionPlan);
            }
        }

    }
}
