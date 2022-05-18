using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO_Library;
using NUnit.Framework;
using ICA_BusinessLogicLayer;
using ICA_BusinessLogicLayer.Services.InfusionPlanCreator;
using ICA_BusinessLogicLayer.Services.InfusionPlanProvider;
using NSubstitute;

namespace ST4GR3_test_ICA.BusinessLogicLayer
{
    [TestFixture]
    public class InfusionPlanBookTest
    {
        private InfusionPlanBook _uut;
        private IInfusionPlanProvider _fakeProvider;
        private IInfusionPlanCreator _fakeCreator;
        private IMedicine _fakeMedicine;
        private DTO_InfusionPlan _dtoInfusionPlan;
        private InfusionPlan _infusionPlan;

        [SetUp]
        public void Setup()
        {
            _fakeProvider = Substitute.For<IInfusionPlanProvider>();
            _fakeCreator = Substitute.For<IInfusionPlanCreator>();
            _fakeMedicine = Substitute.For<IMedicine>();
            
            _uut = new InfusionPlanBook(_fakeProvider, _fakeCreator);
            _dtoInfusionPlan = new DTO_InfusionPlan();
            _infusionPlan = new InfusionPlan(_fakeMedicine, _dtoInfusionPlan.MachineID
                , _dtoInfusionPlan.BatchId, _dtoInfusionPlan.CPR
                , _dtoInfusionPlan.Weight, _dtoInfusionPlan.PatientName);
        }

        [Test]
        public void GetAllInfusionPlanTest()
        {
            _uut.GetAllInfusionPlans().ContinueWith((k) =>
            {
                Console.WriteLine(k);
                Assert.IsNotNull(null, "error");
            });
        }

        [Test]
        public void AddInfusionPlanTest()
        {
            _uut.AddInfusionPlan(_infusionPlan).ContinueWith((k) =>
            {
                Console.WriteLine(k);
                Assert.IsNotNull(null, "error");
            });
        }

        [TestCase("0312760544")]
        [TestCase("1209871225")]

        public void GetOneInfusionPlanTest(string CprValue)
        {
            _uut.GetOneInfusionPlan(CprValue);
            _fakeProvider.Received(1).GetOneInfusionPlan(CprValue);

        }
    }
}
