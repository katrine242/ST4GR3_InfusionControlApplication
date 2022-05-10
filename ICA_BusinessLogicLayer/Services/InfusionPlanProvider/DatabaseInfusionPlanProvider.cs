using DTO_Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ICA_DataAccessLayer.DbContexts;
using Microsoft.EntityFrameworkCore;

namespace ICA_Model.Services.InfusionPlanProvider
{
    public class DatabaseInfusionPlanProvider : IInfusionPlanProvider
    {
        private readonly InfusionPlanDbContextFactory _dbContextFactory;
        public DatabaseInfusionPlanProvider(InfusionPlanDbContextFactory DbContextFactory)
        {
            _dbContextFactory = DbContextFactory;
        }

        public async Task<IEnumerable<InfusionPlan>> GetAllInfusionPlans()
        {
            using (InfusionPlanDbContext context = _dbContextFactory.CreateDbContext())
            {
                IEnumerable<DTO_InfusionPlan> infusionPlanDtos = await context.InfusionPlans.ToListAsync();
                return infusionPlanDtos.Select(i => ToInfusionPlan(i)); //Her tager vi data fra fra DTO til InfusionPlan
            }
        }

        private static InfusionPlan ToInfusionPlan(DTO_InfusionPlan i)
        {
            return new InfusionPlan(i);
        }
    }
}

