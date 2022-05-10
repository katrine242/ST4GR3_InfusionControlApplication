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
        public Medicine(DTO_InfusionPlan dtoInfusionplan, Medicine_config config)
        {
            dtoInfusionplan.MedicineName=Name=config.Name;
            dtoInfusionplan.Factor = Factor=config.Factor;
            dtoInfusionplan.IntervalTime = IntervalTime=config.IntervalTime;
            dtoInfusionplan.MaxDoseage=MaxDosis=config.MaxDosis;
            dtoInfusionplan.Fulltime = Fulltime=config.Fulltime;
            dtoInfusionplan.Concentration = Concentration=config.Concentration;
        }



    }
}
