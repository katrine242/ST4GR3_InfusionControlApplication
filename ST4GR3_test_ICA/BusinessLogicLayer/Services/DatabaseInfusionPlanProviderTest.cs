using System;
using System.Collections.Generic;
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
        private DatabaseInfusionPlanCreator _creator;
        private InfusionPlan _infusionPlan;
        private IMedicine _fakeMedicine;
        private DTO_InfusionPlan _dtoInfusionPlan;
        private string _connectingstring = "Data Source=infusionPlan.db";

        [SetUp]
        public void Setup()
        {
            _uut = new DatabaseInfusionPlanProvider(_connectingstring);
            _creator = new DatabaseInfusionPlanCreator(_connectingstring);
            _fakeMedicine = Substitute.For<IMedicine>();
            _dtoInfusionPlan = new DTO_InfusionPlan();
            _infusionPlan = new InfusionPlan(_fakeMedicine, _dtoInfusionPlan.MachineID
                , _dtoInfusionPlan.BatchId, _dtoInfusionPlan.CPR
                , _dtoInfusionPlan.Weight, _dtoInfusionPlan.PatientName);
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
        public void GetOneInfusionPlanTest(long CPRValue)
        {
            _fakeMedicine = new Medicine("NameHere", 0.5, 20, 180, 2.0, 50);
            _infusionPlan = new InfusionPlan(_fakeMedicine, 123, 12345, CPRValue, 60, "Nadia");

            _infusionPlan.DtoTimeFlowList = new List<DTO_TimeFlow>();

            _infusionPlan.DtoTimeFlowList.Add(new DTO_TimeFlow { Time = 0, Flow = 0.6 });
            _infusionPlan.DtoTimeFlowList.Add(new DTO_TimeFlow { Time = 20, Flow = 1.2 });
            _infusionPlan.DtoTimeFlowList.Add(new DTO_TimeFlow { Time = 40, Flow = 1.8 });
            _infusionPlan.DtoTimeFlowList.Add(new DTO_TimeFlow { Time = 60, Flow = 2.4 });
            _infusionPlan.DtoTimeFlowList.Add(new DTO_TimeFlow { Time = 80, Flow = 2.4 });
            _infusionPlan.DtoTimeFlowList.Add(new DTO_TimeFlow { Time = 100, Flow = 2.4 });
            _infusionPlan.DtoTimeFlowList.Add(new DTO_TimeFlow { Time = 120, Flow = 2.4 });
            _infusionPlan.DtoTimeFlowList.Add(new DTO_TimeFlow { Time = 140, Flow = 2.4 });
            _infusionPlan.DtoTimeFlowList.Add(new DTO_TimeFlow { Time = 160, Flow = 2.4 });

            _creator.CreateInfusionPlan(_infusionPlan);

           _dtoInfusionPlan = _uut.GetOneInfusionPlan(CPRValue);

           Assert.That(_dtoInfusionPlan.CPR, Is.EqualTo(CPRValue));
        }
    }
}
