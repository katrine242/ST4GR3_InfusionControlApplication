using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Automation;
using System.Windows.Input;
using DTO_Library;
using ICA_BusinessLogicLayer;
using ST4GR3_InfusionControlApplication.Commands;

namespace ST4GR3_InfusionControlApplication.ViewModels
{
    public class ViewModelCreateInfusion : ViewModelBase
    {
        private readonly ObservableCollection<ViewModelDataInfusionPlan> _infusionPlans;
        private readonly ObservableCollection<ViewModelDataTimeFlow> _timeFlows;

        //IEnumerable anvendes så en klasse udenfor ikke kan tilgå denne property og adde eller fjerne items
        public IEnumerable<ViewModelDataInfusionPlan> InfusionPlans => _infusionPlans;
        public IEnumerable<ViewModelDataTimeFlow> TimeFlows;

        public ViewModelCreateInfusion()
        {
            _infusionPlans = new ObservableCollection<ViewModelDataInfusionPlan>();
            _timeFlows = new ObservableCollection<ViewModelDataTimeFlow>();
            DTO_InfusionPlan dtoInfusionPlan = new DTO_InfusionPlan();
            dtoInfusionPlan.Weight = 60;
            Medicine medicine1 = new Medicine("Iloprost", 0.5, 30, 180, 2.0, 200);
           

            _timeFlows.Add(new ViewModelDataTimeFlow(new InfusionPlan(medicine1, dtoInfusionPlan)));
            // CreatePlan = new CreateInfusionViewCommand();
        }

        private int _patient;
        public int Patient
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

        private int _cpr;
        public int CPR
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

        private double _height;
        public double Height
        {
            get
            {
                return _height;
            }
            set
            {
                _height = value;
                OnPropertyChanged(nameof(Height));
            }
        }

        private int _weight;
        public int Weight
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

        private int _medicine;
        public int Medicine
        {
            get
            {
                return _medicine;
            }
            set
            { _medicine = value;
                OnPropertyChanged(nameof(Medicine));
            }
        }

        private int _batchID;
        public int BatchID
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

        private int _machineID;
        public int MachineID
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
        public ICommand UserChoice { get; }
        public ICommand CreatePlan { get; }
        public ICommand CreateInfusionPlan { get; }

        
    }
}
