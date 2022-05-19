using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using DTO_Library;
using ICA_BusinessLogicLayer.Exception;

namespace ICA_BusinessLogicLayer
{
    public class Medicine : IMedicine
    {
        public string Name { get; }
        public double Factor { get; }
        public int IntervalTime { get; }
        public int Fulltime { get; }
        public double MaxDosis { get; }
        public double Concentration { get;  }


        public Medicine(){}
        public Medicine(string name, double factor, int intervaltime, int fulltime, double maxDosis, double concentration)
        {
            Name = name;
            Factor = factor;
            IntervalTime = intervaltime;
            MaxDosis = maxDosis;
            Concentration = concentration;
            Fulltime = fulltime;
        }


      public Medicine GetMedicine(List<Medicine_config> medicinelist, string name)
      {
         bool medicinenamevalid=false;
         Medicine _medicine=new Medicine();


         foreach (Medicine_config medicineConfig in medicinelist)
         {
            if (medicineConfig.Name == name)
            {
               _medicine=new Medicine(medicineConfig.Name, medicineConfig.Factor, medicineConfig.IntervalTime,
                  medicineConfig.Fulltime, medicineConfig.MaxDosis, medicineConfig.Concentration);

               medicinenamevalid = true;

               break;
            }
         }

         if (medicinenamevalid==false)
         {
            throw new InvalidMedicineNameConflictException(name);

         }

         return _medicine;
         
      }


   }
}
