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
         //Test
         Medicine medicine = new Medicine("Iloprost", 0.5, 30, 2, 360);
         InfusionPlan infusionPlan = new InfusionPlan(medicine, "Erik", 0912771825, 80.0, 1234, 30, 1000);
         infusionPlan.MakeInfusionPlan();
         //Console.WriteLine(Convert.ToString(infusionPlan.CalculateFlowRate(medicine)));
        }
    }
}
