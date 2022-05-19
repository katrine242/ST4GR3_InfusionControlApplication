using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO_Library;
using ICA_BusinessLogicLayer;

namespace ST4GR3_InfusionControlApplication.ViewModels
{
    public class ViewModelDataTimeFlow : ViewModelBase
    {
       public ViewModelDataTimeFlow()
        {
        }

        public double Time { get; set; }
        public double Flow { get; set; }

   }
}
