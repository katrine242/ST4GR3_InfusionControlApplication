using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ICA_BusinessLogicLayer;
using ST4GR3_InfusionControlApplication.Stores;

namespace ST4GR3_InfusionControlApplication.ViewModels
{
    public class MainViewModel: ViewModelBase
    {
        private readonly NavigationStore _navigationStore;
        public ViewModelBase CurrentViewModel => _navigationStore.CurrentViewModel;
        // Navigationstore skal Notify MainViewModel, når CurrentViewModel ændres
        // Laver derfor et Event i NavigationStore

        public MainViewModel(NavigationStore navigationStore)
        {
            _navigationStore = navigationStore;
            _navigationStore.CurrentViewModelChanged += OnCurrentViewModelChanged; //Subscriber til Eventet (når CurrentViiewModel ændres)
        }

        private void OnCurrentViewModelChanged()
        {
            //UI "regrabber" value af CurrentViewModel og opdaterer View:
            OnPropertyChanged(nameof(CurrentViewModel)); 
        }
    }
}
