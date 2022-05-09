using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICA_Model
{
    public interface IInfusionPlan
    {
        List<List<double>> MakeInfusionPlan();
        List<List<double>> CalculateFlowRate(Medicine m);
    }
}
