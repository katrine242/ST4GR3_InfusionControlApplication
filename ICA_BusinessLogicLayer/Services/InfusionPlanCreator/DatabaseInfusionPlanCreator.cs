using DTO_Library;
using ICA_DataAccessLayer.DbContexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace ICA_BusinessLogicLayer.Services.InfusionPlanCreator
{
    public class DatabaseInfusionPlanCreator : IInfusionPlanCreator
    {
        private readonly InfusionPlanDbContextFactory _dbContextFactory;
        
        public DatabaseInfusionPlanCreator(string connectionString)
        {
            _dbContextFactory = new InfusionPlanDbContextFactory(connectionString);

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
            return new DTO_InfusionPlan()
            {
                MachineID = infusionPlan.MachineID,
                BatchId = infusionPlan.BatchId,
                CPR = infusionPlan.CPR,
                Weight = infusionPlan.Weight,
                PatientName = infusionPlan.PatientName,
                Fulltime = infusionPlan.Medicine.Fulltime,
                Factor = infusionPlan.Medicine.Factor,
                MaxDoseage = infusionPlan.Medicine.MaxDosis,
                IntervalTime = infusionPlan.Medicine.IntervalTime,
                Concentration = infusionPlan.Medicine.Concentration,
                DtoTimeFlowList = infusionPlan.DtoTimeFlowList,
                MedicineName = infusionPlan.Medicine.Name
            };
        }

        public void MigrateToDataBase()
        {
            using (InfusionPlanDbContext dbContext = _dbContextFactory.CreateDbContext())
            {
                dbContext.Database.Migrate();
            }
        }
    }   
}
