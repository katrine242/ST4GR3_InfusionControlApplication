using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using ST4GR3_InfusionControlApplication.Stores;
using ICA_BusinessLogicLayer;
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
        private readonly IInfusionPlanProvider _infusionPlanProvider;
        private readonly IInfusionPlanCreator _infusionPlanCreator;
        private const string CONNECTION_STRING = "Data Source=infusionPlan.db";
        private readonly InfusionOverview _infusionOverview;
        private IInfusionPlanBook _planbook;

        public App()
        {
            _infusionPlanProvider = new DatabaseInfusionPlanProvider(CONNECTION_STRING);
            _infusionPlanCreator = new DatabaseInfusionPlanCreator(CONNECTION_STRING);

            InfusionPlanBook infusionPlanBook = new InfusionPlanBook(_infusionPlanProvider, _infusionPlanCreator);

            //_infusionOverview = new InfusionOverview(infusionPlanBook);
            _navigationStore = new NavigationStore();

        }

        protected override void OnStartup(StartupEventArgs e)
        {
            MainWindow = new MainWindow()
                {DataContext = new MainViewModel()};

            MainWindow.Show();
          //List<Medicine_config> configList = ConfigurationSerialization.LoadList("Ledogbindevæv_auh.xml");

          //_infusionPlanCreator.MigrateToDataBase();

          base.OnStartup(e);
      }

   }
}
