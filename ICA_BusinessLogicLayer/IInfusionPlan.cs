using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO_Library;

namespace ICA_Model
{
    public interface IInfusionPlan
    {
        void MakeInfusionPlan();
        List<List<double>> CalculateFlowRate(DTO_InfusionPlan dtoInfusionplan);
    }
}
