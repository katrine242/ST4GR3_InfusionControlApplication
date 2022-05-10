using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using ST4GR3_InfusionControlApplication.Stores;
using ICA_Model;

namespace ST4GR3_InfusionControlApplication
{
   /// <summary>
   /// Interaction logic for App.xaml
   /// </summary>
   public partial class App : Application
   {
        private readonly NavigationStore _navigationStore;


      protected override void OnStartup(StartupEventArgs e)
      {
         List<Medicine_config> configList = ConfigurationSerialization.LoadList("Ledogbindevæv_auh.xml");


         base.OnStartup(e);
      }

   }
}
