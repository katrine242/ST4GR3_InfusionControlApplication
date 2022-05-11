using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICA_BusinessLogicLayer
{
   public class Medicine_config
   {
      public string Name { get; set; }
      public double Factor { get; set; }
      public int IntervalTime { get; set; }
      public int Fulltime { get; set; }
      public double MaxDosis { get; set; }
      public double Concentration { get; set; }
      public string Disease { get; set; }

      public Medicine_config()
      {
         Name = "Unknown";
         Factor = 0;
         IntervalTime = 0;
         Fulltime = 0;
         MaxDosis = 0;
         Concentration = 0;
         Disease = "Unknown";
      }

   }
}
