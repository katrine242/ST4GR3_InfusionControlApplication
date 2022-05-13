using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICA_BusinessLogicLayer
{
    public interface IMedicine
    {
       public string Name { get; }
       public double Factor { get; }
       public int IntervalTime { get; }
       public int Fulltime { get; }
       public double MaxDosis { get; }
       public double Concentration { get; }

       public Medicine GetMedicine(List<Medicine_config> medicinelist, string name);

    }
}
