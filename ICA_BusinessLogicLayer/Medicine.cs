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
        public int MaxDosis { get; }
        public int Concentration { get;  }

        private DTO_Infusionplan dtoInfusionplan;
        public Medicine(DTO_Infusionplan dtoInfusionplan)
        {
            dtoInfusionplan.MedicineName=Name;
            dtoInfusionplan.Factor = Factor;
            dtoInfusionplan.IntervalTime = IntervalTime;
            dtoInfusionplan.MaxDoseage=MaxDosis;
            dtoInfusionplan.Fulltime = Fulltime;
            dtoInfusionplan.Concentration = Concentration;

        }



    }
}
