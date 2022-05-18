using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO_Library;
using NUnit.Framework;
using ICA_BusinessLogicLayer;
using NSubstitute;

namespace ST4GR3_test_ICA.BusinessLogicLayer
{
    [TestFixture]
    public class InfusionOverviewTest
    {
        private InfusionOverview _uut;
        private IInfusionPlanBook _fakInfusionPlanBook;
        private IMedicine _fakeMedicine;
        private List<Medicine_config> _medicineConfig;
        private DTO_InfusionPlan _dtoInfusionPlan;
        private InfusionPlan _infusionPlan;

        [SetUp]
        public void Setup()
        {
            _fakInfusionPlanBook = Substitute.For<IInfusionPlanBook>();
            _fakeMedicine = Substitute.For<IMedicine>();
            _medicineConfig = new List<Medicine_config>();
            _uut = new InfusionOverview(_fakInfusionPlanBook, _medicineConfig);

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

        [Test]
        public void CreateInfusionPlanTest()
        {
            _uut.CreateInfusionPlan(_infusionPlan).ContinueWith((k) =>
            {
                Console.WriteLine(k);
                Assert.IsNotNull(null, "error");
            });
        }


    }
}
