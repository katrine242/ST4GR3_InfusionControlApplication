using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO_Library;

namespace ICA_BusinessLogicLayer
{
    public interface IInfusionPlan
    {
        void MakeInfusionPlan();
        DTO_TimeFlow CalculateFlowRate(DTO_InfusionPlan dtoInfusionplan);
    }
}
