using DTO_Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ICA_DataAccessLayer.DbContexts;
using Microsoft.EntityFrameworkCore;
using ICA_BusinessLogicLayer;
using Microsoft.Extensions.DependencyInjection;

namespace ICA_BusinessLogicLayer.Services.InfusionPlanProvider
{
    public class DatabaseInfusionPlanProvider : IInfusionPlanProvider
    {
        private readonly InfusionPlanDbContextFactory _dbContextFactory;
        public DatabaseInfusionPlanProvider(string connectionString)
        {
            _dbContextFactory = new InfusionPlanDbContextFactory(connectionString);
        }

        public async Task<IEnumerable<InfusionPlan>> GetAllInfusionPlans()
        {
            using (InfusionPlanDbContext context = _dbContextFactory.CreateDbContext())
            {
                IEnumerable<DTO_InfusionPlan> infusionPlanDtos = await context.InfusionPlans
                    .Include(i=>i.DtoTimeFlowList).ToListAsync();
                return infusionPlanDtos.Select(i => ToInfusionPlan(i)); //Her tager vi data fra fra DTO til InfusionPlan
            }
        }

        private static InfusionPlan ToInfusionPlan(DTO_InfusionPlan i)
        {
            return new InfusionPlan(new Medicine(i.MedicineName, i.Factor, i.IntervalTime, i.Fulltime, i.MaxDoseage, i.Concentration)
                , i.MachineID, i.BatchId, i.CPR, i.Weight, i.PatientName);
        }

        public DTO_InfusionPlan GetOneInfusionPlan(string WantedCPR)
        {
            using (InfusionPlanDbContext context = _dbContextFactory.CreateDbContext())
            {
                DTO_InfusionPlan infusionPlansDtos = context.InfusionPlans
                    .Where(i => i.CPR == WantedCPR)
                    .Include(i => i.DtoTimeFlowList).FirstOrDefault();
                return infusionPlansDtos;
            }
        }

    }
}





//using (InfusionPlanDbContext context = _dbContextFactory.CreateDbContext())
//{
//    DTO_InfusionPlan infusionPlansDtos = context.InfusionPlans
//        .Where(i => i.CPR == WantedCPR).FirstOrDefault();
//    return infusionPlansDtos;
//}

//DTO_InfusionPlan infusionPlansDtos = context.InfusionPlans
//    .Where(i => i.CPR == WantedCPR).Include(i => i.DtoTimeFlowList).FirstOrDefault();
//return infusionPlansDtos;

//DTO_InfusionPlan infusionPlansDtos = context.InfusionPlans
//    .Include(i => i.DtoTimeFlowList)
//    .Where(i => i.CPR == WantedCPR).FirstOrDefault();
//return infusionPlansDtos;


//DTO_InfusionPlan infusionPlansDtos = context.InfusionPlans
//    .Include(i => i.DtoTimeFlowList).FirstOrDefault(i => i.CPR == WantedCPR);
//return infusionPlansDtos;
