using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using ST4GR3_InfusionControlApplication.Stores;
using ICA_Model;
using ICA_Model.Services.InfusionPlanCreator;
using ICA_Model.Services.InfusionPlanProvider;

namespace ST4GR3_InfusionControlApplication
{
   /// <summary>
   /// Interaction logic for App.xaml
   /// </summary>
   public partial class App : Application
   {
        private readonly InfusionOverview _infusionOverview;
        private readonly InfusionPlanBook _infusionPlanBook;
        private readonly NavigationStore _navigationStore;
        private readonly IInfusionPlanCreator _infusionPlanCreator;
        private readonly IInfusionPlanProvider infusionPlanProvider;
        private const string CONNECTION_STRING = "Data Source=infusionPlan.db";

        public App()
        {
            

        }



      protected override void OnStartup(StartupEventArgs e)
      {
         List<Medicine_config> configList = ConfigurationSerialization.LoadList("Ledogbindevæv_auh.xml");


         base.OnStartup(e);
      }

   }
}
