using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using DTO_Library;
using ICA_Model;

namespace ST4GR3_InfusionControlApplication
{
   /// <summary>
   /// Interaction logic for MainWindow.xaml
   /// </summary>
   public partial class MainWindow : Window
   {
      public MainWindow()
      {
         InitializeComponent();

         //Medicine_config iloprost = new Medicine_config { Name = "Iloprost", Factor = 0.0005, IntervalTime = 30, Fulltime = 360, MaxDosis = 0.002, Concentration = 0.2, Disease = "perifere vaskulære" };
         //Medicine_config infliximab_1til4 = new Medicine_config { Name = "Infliximab_1til4", Factor = 5, IntervalTime = 0, Fulltime = 120, MaxDosis = 10, Concentration = 0, Disease = "Reumatoid artritis" };
         //Medicine_config infliximab_5til10 = new Medicine_config { Name = "Infliximab_5til10", Factor = 5, IntervalTime = 0, Fulltime = 60, MaxDosis = 10, Concentration = 0, Disease = "Reumatoid artritis" };
         //Medicine_config infliximab_over10 = new Medicine_config { Name = "Infliximab_over10", Factor = 5, IntervalTime = 0, Fulltime = 30, MaxDosis = 10, Concentration = 0, Disease = "Reumatoid artritis" };

         //List<Medicine_config> configList = new List<Medicine_config> { iloprost, infliximab_1til4, infliximab_5til10, infliximab_over10};
         //NestedConfiguration configlist = new NestedConfiguration() { Configlist = configList };
         //ConfigurationSerialization.SaveList("Ledogbindevæv_auh.xml", configlist.Configlist);

         var ConfigList = ConfigurationSerialization.LoadList("Ledogbindevæv_auh.xml");

      }
   }
}
