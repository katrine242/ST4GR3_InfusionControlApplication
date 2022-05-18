using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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

        // navigation properties
        public DTO_InfusionPlan DtoInfusionPlan { get; set; }

        //Foreign key
        public int DtoInfusionPlanId { get; set; }
    }
}
