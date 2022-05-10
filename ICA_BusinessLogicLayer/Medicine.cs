using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO_Library;

namespace ICA_Model
{
    public class Medicine : IMedicine
    {
        public string Name { get; }
        public double Factor { get; }
        public int IntervalTime { get; }
        public int Fulltime { get; }
        public double MaxDosis { get; }
        public double Concentration { get;  }

        private DTO_InfusionPlan dtoInfusionplan;
        public Medicine(string name, double factor, int intervaltime, int fulltime, double maxDosis, double concentration)
        {
            Name = name;
            Factor = factor;
            IntervalTime = intervaltime;
            MaxDosis = maxDosis;
            Concentration = concentration;

            //dtoInfusionplan.MedicineName=Name=config.Name;
            //dtoInfusionplan.Factor = Factor=config.Factor;
            //dtoInfusionplan.IntervalTime = IntervalTime=config.IntervalTime;
            //dtoInfusionplan.MaxDoseage=MaxDosis=config.MaxDosis;
            //dtoInfusionplan.Fulltime = Fulltime=config.Fulltime;
            //dtoInfusionplan.Concentration = Concentration=config.Concentration;
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
