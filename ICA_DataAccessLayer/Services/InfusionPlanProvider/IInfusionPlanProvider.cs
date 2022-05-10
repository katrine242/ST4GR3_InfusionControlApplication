using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO_Library;

namespace ICA_DataAccessLayer.Services.InfusionPlanProvider
{
    public interface IInfusionPlanProvider
    {
        Task<IEnumerable<DTO_Infusionplan>> GetAllInfusionPlans();
    }
}
