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
       private readonly InfusionPlan _uut;
       private readonly List<List<double>> _actualList;

       public MainWindow()
      {
         InitializeComponent();

         DTO_InfusionPlan dtoInfusionplan = new DTO_InfusionPlan() { Weight = 60, Factor = 0.5, Concentration = 50, Fulltime = 180, IntervalTime = 20, MaxDoseage = 2.0 };
         _uut = new InfusionPlan(dtoInfusionplan);

         List<List<double>> myList = new List<List<double>>();
         myList.Add(new List<double> { 0, 0.6 });
         myList.Add(new List<double> { 20, 1.2 });
         myList.Add(new List<double> { 40, 1.8 });
         myList.Add(new List<double> { 60, 2.4 });
         myList.Add(new List<double> { 80, 2.4 });
         myList.Add(new List<double> { 100, 2.4 });
         myList.Add(new List<double> { 120, 2.4 });
         myList.Add(new List<double> { 140, 2.4 });
         myList.Add(new List<double> { 160, 2.4 });

         _actualList = _uut.CalculateFlowRate(dtoInfusionplan);

        }
   }
}
