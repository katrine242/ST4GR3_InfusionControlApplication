using DTO_Library;
using ICA_DataAccessLayer.DbContexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICA_Model.Services.InfusionPlanCreator
{
    public class DatabaseInfusionPlanCreator : IInfusionPlanCreator
    {
        private readonly InfusionPlanDbContextFactory _dbContextFactory;
        
        public DatabaseInfusionPlanCreator(InfusionPlanDbContextFactory dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }

        public async Task CreateInfusionPlan(InfusionPlan infusionPlan)
        {
            using (InfusionPlanDbContext context = _dbContextFactory.CreateDbContext())
            {
                DTO_InfusionPlan infusionPlanDto = ToInfusionPlanDTO(infusionPlan); //Her vil vi gå fra infusionPlan til DTO

                context.InfusionPlans.Add(infusionPlanDto);
                await context.SaveChangesAsync();
            }
        }

        private DTO_InfusionPlan ToInfusionPlanDTO(InfusionPlan infusionPlan)
        {
            return infusionPlan.InfusionData;
        }
    }
}
