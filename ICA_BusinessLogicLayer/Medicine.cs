using System;
using System.Collections.Generic;
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
        private Medicine _medicine;


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

      public override string ToString()
      {
         return $"{Name}{Factor}{IntervalTime}{Fulltime}{MaxDosis}{Concentration}";
      }

      public override bool Equals(object obj)
      {
         return obj is Medicine medicine &&
            Name == medicine.Name &&
            Factor == medicine.Factor &&
            IntervalTime == medicine.IntervalTime &&
            MaxDosis == medicine.MaxDosis &&
            Concentration == medicine.Concentration;
      }
      public override int GetHashCode()
      {
         return HashCode.Combine(Name, Factor, IntervalTime, MaxDosis, Concentration);
      }

      public Medicine GetMedicine(List<Medicine_config> medicinelist, string name)
      {

         foreach (Medicine_config medicineConfig in medicinelist)
         {
            if (medicineConfig.Name == name)
            {
               _medicine = new Medicine(medicineConfig.Name, medicineConfig.Factor, medicineConfig.IntervalTime,
                  medicineConfig.Fulltime, medicineConfig.MaxDosis, medicineConfig.Concentration);
               break;
            }
            else
            {
               throw new InvalidMedicineNameConflictException(name);
            }
         }

         return _medicine;
         
      }


   }
}
