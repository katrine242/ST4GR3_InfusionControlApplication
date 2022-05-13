using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ICA_BusinessLogicLayer;
using ST4GR3_InfusionControlApplication.Commands;

namespace ST4GR3_InfusionControlApplication.ViewModels
{
    public class ViewModelCreateInfusion : ViewModelBase
    {
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
            {
                _medicine = value;
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

        public ViewModelCreateInfusion(InfusionOverview infusionOverview)
        {
            CreatePlan = new CreateInfusionViewCommand(this,infusionOverview);
            
        }
    }
}
