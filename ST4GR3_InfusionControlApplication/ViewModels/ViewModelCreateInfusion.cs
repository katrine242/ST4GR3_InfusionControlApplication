using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Automation;
using System.Windows.Input;
using System.Windows.Media.Converters;
using DTO_Library;
using ICA_BusinessLogicLayer;
using ICA_BusinessLogicLayer.Services;
using ST4GR3_InfusionControlApplication.Commands;
using ST4GR3_InfusionControlApplication.Stores;

namespace ST4GR3_InfusionControlApplication.ViewModels
{
    public class ViewModelCreateInfusion : ViewModelBase
    {
       private readonly ObservableCollection<ViewModelDataTimeFlow> _calculatedInfusionPlan;
        private string _patient;
        public IEnumerable<ViewModelDataTimeFlow> Plan => _calculatedInfusionPlan;
        public string Patient
        {
            get
            {
                return _patient;
            }
            set
            {
                _patient = value;
                OnPropertyChanged(nameof(Patient));
            }
        }

        private string _cpr;
        public string CPR
        {
            get
            {
                return _cpr;
            }
            set
            {
               _cpr = value;
                OnPropertyChanged(nameof(CPR));
         }
        }


        private string _weight;
        public string Weight
        {
            get
            {
                return _weight;
            }
            set
            {
                _weight = value;
                OnPropertyChanged(nameof(Weight));
            }
        }

        private string _medicine;
        public string Medicine
        {
            get
            {
                return _medicine;
            }
            set
            {
                _medicine = value;
                OnPropertyChanged(nameof(Medicine));
            }
        }

        private string _batchID;
        public string BatchID
        {
            get
            {
                return _batchID;
            }
            set
            {
                _batchID = value;
                OnPropertyChanged(nameof(BatchID));
            }
        }

        private string _machineID;
        public string MachineID
        {
            get
            {
                return _machineID;
            }
            set
            {
                _machineID = value;
                OnPropertyChanged(nameof(MachineID));
            }
        }

        // Commands for Back, Brugerdefinér og Infusion
        public ICommand BackCommand { get; }
        public ICommand UserChoiceCommand { get; }
        public ICommand CreatePlanCommand { get; }
        public ICommand CreateInfusionPlanCommand { get; }

        public ViewModelCreateInfusion(InfusionOverview infusionOverview,  NavigationService menuViewNavigationService) // har slettet InfusionOverview
        {
           _calculatedInfusionPlan = new ObservableCollection<ViewModelDataTimeFlow>();
            CreatePlanCommand = new CreatePlanCommand(this, infusionOverview);
            CreateInfusionPlanCommand = new CreateInfusionViewCommand(this, infusionOverview, menuViewNavigationService);
            BackCommand = new NavigateCommand(menuViewNavigationService);

        }

        
    }
}
