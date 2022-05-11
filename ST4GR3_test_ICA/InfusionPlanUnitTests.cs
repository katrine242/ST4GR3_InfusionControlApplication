using System.Collections.Generic;
using Castle.Core.Internal;
using ICA_BusinessLogicLayer;
using NUnit.Framework;
using NSubstitute;
using DTO_Library;


namespace ST4GR3_test_ICA
{
    [TestFixture]
    public class InfusionPlanUnitTest
    {
        private InfusionPlan _uut;
        //private DTO_Infusionplan _dtoInfusionplan;

        //private List<List<double>> _actualList; --- Rettet af Nadia grundet ny DTO
        private List<DTO_TimeFlow> _actualList;
        private IMedicine medicine;



        [SetUp]
        public void Setup()
        {
            //_dtoInfusionplan = Substitute.For<DTO_Infusionplan>();


            //_actualList = new List<List<double>>(); --- Rettet af Nadia grundet ny DTO
            _actualList = new List<DTO_TimeFlow>();
            medicine = Substitute.For<IMedicine>();
        }

        [Test]

        public void DtoPropertyTimeFlowListIsSetTest()
        {
            DTO_InfusionPlan dtoInfusionplan = new DTO_InfusionPlan() { Weight = 65 };
            medicine = new Medicine("Iloprost", 1.0, 40, 360, 3.0, 100);
            DTO_TimeFlow dtoTimeFlow = new DTO_TimeFlow();
            
            _uut = new InfusionPlan(medicine, dtoInfusionplan);
            _uut.MakeInfusionPlan();
            Assert.That(dtoTimeFlow, Is.EqualTo(_uut.CalculateFlowRate(dtoInfusionplan)));

        }
        [Test]
        public void MedicineListOfListCheckTest1()
        {

            DTO_InfusionPlan dtoInfusionplan = new DTO_InfusionPlan() { Weight = 60};
            medicine = new Medicine("NameHere", 0.5, 20, 180, 2.0, 50);
            _uut = new InfusionPlan(medicine, dtoInfusionplan);

            //DTO_TimeFlow dtoTimeFlow = new DTO_TimeFlow();
            List<DTO_TimeFlow> timeFlowList = new List<DTO_TimeFlow>();
            List<DTO_TimeFlow> actualTimeFlowList;
            //List<List<double>> myList = new List<List<double>>();

            timeFlowList.Add(new DTO_TimeFlow {Time = 0, Flow = 0.6});
            timeFlowList.Add(new DTO_TimeFlow { Time = 20, Flow = 1.2 });
            timeFlowList.Add(new DTO_TimeFlow { Time = 40, Flow = 1.8 });
            timeFlowList.Add(new DTO_TimeFlow { Time = 60, Flow = 2.4 });
            timeFlowList.Add(new DTO_TimeFlow { Time = 80, Flow = 2.4 });
            timeFlowList.Add(new DTO_TimeFlow { Time = 100, Flow = 2.4 });
            timeFlowList.Add(new DTO_TimeFlow { Time = 120, Flow = 2.4 });
            timeFlowList.Add(new DTO_TimeFlow { Time = 140, Flow = 2.4 });
            timeFlowList.Add(new DTO_TimeFlow { Time = 160, Flow = 2.4 });
            
            actualTimeFlowList = _uut.CalculateFlowRate(dtoInfusionplan);

            Assert.AreEqual(timeFlowList, actualTimeFlowList);


        }

        [Test]
        public void MedicineListOfListCheckTest2()
        {

            DTO_InfusionPlan dtoInfusionplan = new DTO_InfusionPlan() { Weight = 70, Factor = 0.9, Concentration = 100, Fulltime = 240, IntervalTime = 30, MaxDoseage = 3.6 };
            _uut = new InfusionPlan(medicine, dtoInfusionplan);

            List<List<double>> myList = new List<List<double>>();
            myList.Add(new List<double> { 0, 0.63 });
            myList.Add(new List<double> { 30, 1.26 });
            myList.Add(new List<double> { 60, 1.89 });
            myList.Add(new List<double> { 90, 2.52 });
            myList.Add(new List<double> { 120, 2.52 });
            myList.Add(new List<double> { 150, 2.52 });
            myList.Add(new List<double> { 180, 2.52 });
            myList.Add(new List<double> { 210, 2.52 });

            //_actualList = _uut.CalculateFlowRate(dtoInfusionplan);
            //CollectionAssert.AreEqual(myList, _actualList);
            _uut.CalculateFlowRate(dtoInfusionplan);
            //Assert.AreEqual(dtoTimeFlow, _actualTimeFlow);
        }

        [Test]
        public void MedicineListOfListCheckTest3()
        {

            DTO_InfusionPlan dtoInfusionplan = new DTO_InfusionPlan() { Weight = 80, Factor = 2.0, Concentration = 200, Fulltime = 300, IntervalTime = 60, MaxDoseage = 6.0 };
            _uut = new InfusionPlan(medicine, dtoInfusionplan);

            List<List<double>> myList = new List<List<double>>();
            myList.Add(new List<double> { 0, 0.8 });
            myList.Add(new List<double> { 60, 1.6 });
            myList.Add(new List<double> { 120, 2.4 });
            myList.Add(new List<double> { 180, 2.4 });
            myList.Add(new List<double> { 240, 2.4 });


            //_actualList = _uut.CalculateFlowRate(dtoInfusionplan);
            //CollectionAssert.AreEqual(myList, _actualList);
            _uut.CalculateFlowRate(dtoInfusionplan);
            //Assert.AreEqual(dtoTimeFlow, _actualTimeFlow);
        }
    }
}