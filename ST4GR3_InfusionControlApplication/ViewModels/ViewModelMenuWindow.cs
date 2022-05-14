using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ICA_BusinessLogicLayer;
using ICA_BusinessLogicLayer.Services;
using ST4GR3_InfusionControlApplication.Commands;
using ST4GR3_InfusionControlApplication.Stores;

namespace ST4GR3_InfusionControlApplication.ViewModels
{
    public class ViewModelMenuWindow : ViewModelBase
    {
        private readonly InfusionOverview _infusionOverview;
        private readonly ObservableCollection<ViewModelDataInfusionPlan> _infusionPlans;

        public ICommand MenuCreateInfusionCommand { get; }
        public ICommand MenuLogOutCommand { get; }

        public ViewModelMenuWindow(InfusionOverview infusionOverview, NavigationService createInfusionInCreateInfusionNavigationService)
        {
            _infusionOverview = infusionOverview;
            MenuCreateInfusionCommand = new NavigateCommand(createInfusionInCreateInfusionNavigationService);
            
            //UpdateTreatments();
        }

        //private void UpdateTreatments()
        //{
        //    _infusionPlans.Clear();
        //    // Hent Data (Patient, CPR, Behandling) fra DB
        //    foreach (InfusionPlan infusionPlan in _infusionOverview.GetAllInfusionPlans())
        //    {
        //        ViewModelDataInfusionPlan viewModelDataInfusionPlan = new ViewModelDataInfusionPlan(infusionPlan);
        //        _infusionPlans.Add(viewModelDataInfusionPlan);
        //    }
        //}
    }
}
