using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO_Library;

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
      
        public Medicine(string name, double factor, int intervaltime, int fulltime, double maxDosis, double concentration)
        {
            Name = name;
            Factor = factor;
            IntervalTime = intervaltime;
            MaxDosis = maxDosis;
            Concentration = concentration;
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


   }
}
