using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using NSubstitute;
using ICA_BusinessLogicLayer.Services.InfusionPlanProvider;
using ICA_BusinessLogicLayer.Services.InfusionPlanCreator;
using ICA_BusinessLogicLayer;
using ICA_DataAccessLayer.DbContexts;
using DTO_Library;
using Microsoft.Data.Sqlite;

namespace ST4GR3_test_ICA.BusinessLogicLayer.Services
{
    [TestFixture]
    public class DatabaseInfusionPlanProviderTest
    {
        private DatabaseInfusionPlanProvider _uut;
        private DTO_InfusionPlan _dtoInfusionPlan;
        private string _connectingstring = "Data Source=infusionPlan.db";

        [SetUp]
        public void Setup()
        {
            _uut = new DatabaseInfusionPlanProvider(_connectingstring);
            _dtoInfusionPlan = new DTO_InfusionPlan();

            IInfusionPlanCreator creator = new DatabaseInfusionPlanCreator(_connectingstring);
            creator.MigrateToDataBase();

        }

        [TearDown]
        public void AfterTest()
        {
            File.Delete("InfusionPlan.db");
        }

        [Test]
        public void GetAllInfusionPlansTest()
        {
            _uut.GetAllInfusionPlans().ContinueWith((k) =>
            {
                Console.WriteLine(k);
                Assert.IsNotNull(null, "error");
            });
        }

        [TestCase(0308980566)]
        [TestCase(3112974344)]
        [TestCase(0110982322)]
        public async Task GetOneInfusionPlanTest(long CPRValue)
        {

            _dtoInfusionPlan = new DTO_InfusionPlan()
            {
                MedicineName = "Iloprost", Concentration = 0.2, Factor = 0.0005, IntervalTime = 30,
                MaxDoseage = 0.002, Fulltime = 360, CPR = CPRValue, DtoTimeFlowList = new List<DTO_TimeFlow>(),
                Height = 165, MachineID = 10, Weight = 60, BatchId = 156, PatientName = "Nadia"
            };

            var infusionPlanDbContextFactory = new InfusionPlanDbContextFactory(_connectingstring);

            using (var infusionPlanDbContext = infusionPlanDbContextFactory.CreateDbContext())
            {
                infusionPlanDbContext.InfusionPlans.Add(_dtoInfusionPlan);
                infusionPlanDbContext.SaveChanges();

            }


            _dtoInfusionPlan = _uut.GetOneInfusionPlan(CPRValue);

            Assert.That(_dtoInfusionPlan.CPR, Is.EqualTo(CPRValue));
        }
    }
}
