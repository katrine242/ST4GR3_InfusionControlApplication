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
using ICA_BusinessLogicLayer;

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

        

         
      }
   }
}
