using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_Library
{
    public class DTO_TimeFlow
    {
        public int Id { get; set; }
        public double Time { get; set; }
        public double Flow { get; set; }

        public DTO_InfusionPlan DtoInfusionPlan { get; set; }
        public int DtoInfusionPlanMachineId { get; set; }



        //public List<double> Time { get; set; }
        //public List<double> Flow { get; set; }
    }
}
