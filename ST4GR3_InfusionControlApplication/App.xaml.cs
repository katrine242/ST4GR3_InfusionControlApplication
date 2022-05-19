using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using ST4GR3_InfusionControlApplication.Navigation;
using ICA_BusinessLogicLayer;
using ICA_BusinessLogicLayer.Configuration;
using ICA_BusinessLogicLayer.Services;
using ICA_BusinessLogicLayer.Services.InfusionPlanCreator;
using ICA_BusinessLogicLayer.Services.InfusionPlanProvider;
using Microsoft.Extensions.DependencyInjection;
using ST4GR3_InfusionControlApplication.ViewModels;

namespace ST4GR3_InfusionControlApplication
{
   /// <summary>
   /// Interaction logic for App.xaml
   /// </summary>
   public partial class App : Application
    {
        //private readonly InfusionOverview _infusionOverview;
        private readonly NavigationStore _navigationStore;
        private readonly InfusionOverview _infusionOverview;

        private readonly IInfusionPlanProvider _infusionPlanProvider;
        private readonly IInfusionPlanCreator _infusionPlanCreator;
        private const string CONNECTION_STRING = "Data Source=infusionPlan.db";
        private IInfusionPlanBook _planbook;
        private List<Medicine_config> configList;

        public App()
        {
            _infusionPlanProvider = new DatabaseInfusionPlanProvider(CONNECTION_STRING);
            _infusionPlanCreator = new DatabaseInfusionPlanCreator(CONNECTION_STRING);

            InfusionPlanBook infusionPlanBook = new InfusionPlanBook(_infusionPlanProvider, _infusionPlanCreator);
            configList = ConfigurationSerialization.LoadList("Ledogbindevæv_auh.xml");
            _infusionOverview = new InfusionOverview(infusionPlanBook, configList);

            _navigationStore = new NavigationStore();

        }

        protected override void OnStartup(StartupEventArgs e)
        {
          _infusionPlanCreator.MigrateToDataBase();

            _navigationStore.CurrentViewModel = CreateMakeViewModelMenuWindow();

            MainWindow = new MainWindow()
                {DataContext = new MainViewModel(_navigationStore)};

            MainWindow.Show();

            base.OnStartup(e);
      }
        private ViewModelCreateInfusion CreateViewCreateInfusion()
        {
            return new ViewModelCreateInfusion(_infusionOverview, new NavigationService(_navigationStore, CreateMakeViewModelMenuWindow));
        }

        private ViewModelMenuWindow CreateMakeViewModelMenuWindow()
        {
            //return new ViewModelMenuWindow(_infusionOverview, new NavigationService(_navigationStore, CreateViewCreateInfusion));

            return ViewModelMenuWindow.LoadViewModel(_infusionOverview,
                new NavigationService(_navigationStore, CreateViewCreateInfusion));
        }



    }
}
