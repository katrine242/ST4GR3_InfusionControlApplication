using System.Collections.Generic;
using System.Linq;
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
        private List<DTO_TimeFlow> _actualTimeFlowList;
        private IMedicine medicine;



        [SetUp]
        public void Setup()
        {
            //_dtoInfusionplan = Substitute.For<DTO_Infusionplan>();


            //_actualList = new List<List<double>>(); --- Rettet af Nadia grundet ny DTO
            _actualList = new List<DTO_TimeFlow>();
            _actualTimeFlowList = new List<DTO_TimeFlow>();
            medicine = Substitute.For<IMedicine>();
        }

        //[Test]

        //public void DtoPropertyTimeFlowListIsSetTest()
        //{
        //    DTO_InfusionPlan dtoInfusionplan = new DTO_InfusionPlan() { Weight = 65 };
        //    medicine = new Medicine("Iloprost", 1.0, 40, 360, 3.0, 100);
        //    List<DTO_TimeFlow> dtoTimeFlow = new List<DTO_TimeFlow>();
            
        //    _uut = new InfusionPlan(medicine, dtoInfusionplan);
        //    _uut.MakeInfusionPlan();
        //    Assert.That(dtoTimeFlow, Is.EqualTo(_uut.CalculateFlowRate(dtoInfusionplan)));

        //}
        [Test]
        public void NumberOfDTOsIsCorrect()
        {
           _uut.InfusionData= new DTO_InfusionPlan() { Weight = 60,};
            medicine = new Medicine("NameHere", 0.5, 20, 180, 2.0, 50);
            _uut = new InfusionPlan(medicine, _uut.InfusionData.MachineID, _uut.InfusionData.BatchId
                , _uut.InfusionData.CPR, _uut.InfusionData.Weight, _uut.InfusionData.PatientName);
            
            List<DTO_TimeFlow> timeFlowList = new List<DTO_TimeFlow>();
            

            timeFlowList.Add(new DTO_TimeFlow {Time = 0, Flow = 0.6});
            timeFlowList.Add(new DTO_TimeFlow { Time = 20, Flow = 1.2 });
            timeFlowList.Add(new DTO_TimeFlow { Time = 40, Flow = 1.8 });
            timeFlowList.Add(new DTO_TimeFlow { Time = 60, Flow = 2.4 });
            timeFlowList.Add(new DTO_TimeFlow { Time = 80, Flow = 2.4 });
            timeFlowList.Add(new DTO_TimeFlow { Time = 100, Flow = 2.4 });
            timeFlowList.Add(new DTO_TimeFlow { Time = 120, Flow = 2.4 });
            timeFlowList.Add(new DTO_TimeFlow { Time = 140, Flow = 2.4 });
            timeFlowList.Add(new DTO_TimeFlow { Time = 160, Flow = 2.4 });

            
            _actualTimeFlowList = _uut.CalculateFlowRate();

            CollectionAssert.AreEqual(new[] {timeFlowList.Count}, new[] {_actualTimeFlowList.Count});
           


        }

        [Test]
        public void MedicineCorrectTimeAndFlowsTest1()
        {
           _uut.InfusionData = new DTO_InfusionPlan() { Weight = 60, };
           medicine = new Medicine("NameHere", 0.5, 20, 180, 2.0, 50);
           _uut = new InfusionPlan(medicine, _uut.InfusionData.MachineID, _uut.InfusionData.BatchId
              , _uut.InfusionData.CPR, _uut.InfusionData.Weight, _uut.InfusionData.PatientName);


         List<DTO_TimeFlow> timeFlowList = new List<DTO_TimeFlow>();


            timeFlowList.Add(new DTO_TimeFlow { Time = 0, Flow = 0.6 });
            timeFlowList.Add(new DTO_TimeFlow { Time = 20, Flow = 1.2 });
            timeFlowList.Add(new DTO_TimeFlow { Time = 40, Flow = 1.8 });
            timeFlowList.Add(new DTO_TimeFlow { Time = 60, Flow = 2.4 });
            timeFlowList.Add(new DTO_TimeFlow { Time = 80, Flow = 2.4 });
            timeFlowList.Add(new DTO_TimeFlow { Time = 100, Flow = 2.4 });
            timeFlowList.Add(new DTO_TimeFlow { Time = 120, Flow = 2.4 });
            timeFlowList.Add(new DTO_TimeFlow { Time = 140, Flow = 2.4 });
            timeFlowList.Add(new DTO_TimeFlow { Time = 160, Flow = 2.4 });


            _actualTimeFlowList = _uut.CalculateFlowRate();

            for (int i = 0; i < timeFlowList.Count; i++)
            {
                Assert.AreEqual(timeFlowList[i].Time, _actualTimeFlowList[i].Time);
                Assert.AreEqual(timeFlowList[i].Flow, _actualTimeFlowList[i].Flow);
            }
            

        }
        [Test]
        public void MedicineCorrectTimeAndFlowsTest2()
        {
           _uut.InfusionData = new DTO_InfusionPlan() { Weight = 70, Factor = 0.9, Concentration = 100, Fulltime = 240, IntervalTime = 30, MaxDoseage = 3.6 };
           medicine = new Medicine("NameHere", 0.9, 30, 240, 3.6, 100);
           _uut = new InfusionPlan(medicine, _uut.InfusionData.MachineID, _uut.InfusionData.BatchId
              , _uut.InfusionData.CPR, _uut.InfusionData.Weight, _uut.InfusionData.PatientName);

           List<DTO_TimeFlow> timeFlowList = new List<DTO_TimeFlow>();

            
            timeFlowList.Add(new DTO_TimeFlow { Time = 0, Flow = 0.63 });
            timeFlowList.Add(new DTO_TimeFlow { Time = 30, Flow = 1.26 });
            timeFlowList.Add(new DTO_TimeFlow { Time = 60, Flow = 1.89 });
            timeFlowList.Add(new DTO_TimeFlow { Time = 90, Flow = 2.52 });
            timeFlowList.Add(new DTO_TimeFlow { Time = 120, Flow = 2.52 });
            timeFlowList.Add(new DTO_TimeFlow { Time = 150, Flow = 2.52 });
            timeFlowList.Add(new DTO_TimeFlow { Time = 180, Flow = 2.52 });
            timeFlowList.Add(new DTO_TimeFlow { Time = 210, Flow = 2.52 });
         

            _actualTimeFlowList =_uut.CalculateFlowRate();

            for (int i = 0; i < timeFlowList.Count; i++)
            {
                Assert.AreEqual(timeFlowList[i].Time, _actualTimeFlowList[i].Time);
                Assert.AreEqual(timeFlowList[i].Flow, _actualTimeFlowList[i].Flow);
            }
        }

        [Test]
        public void MedicineCorrectTimeAndFlowsTest3()
        {
           _uut.InfusionData = new DTO_InfusionPlan() { Weight = 80, };
           medicine = new Medicine("NameHere", 2.0, 60, 300, 6.0, 200);
           _uut = new InfusionPlan(medicine, _uut.InfusionData.MachineID, _uut.InfusionData.BatchId
              , _uut.InfusionData.CPR, _uut.InfusionData.Weight, _uut.InfusionData.PatientName);

        
            List<DTO_TimeFlow> timeFlowList = new List<DTO_TimeFlow>();


            timeFlowList.Add(new DTO_TimeFlow { Time = 0, Flow = 0.8 });
            timeFlowList.Add(new DTO_TimeFlow { Time = 60, Flow = 1.6 });
            timeFlowList.Add(new DTO_TimeFlow { Time = 120, Flow = 2.4 });
            timeFlowList.Add(new DTO_TimeFlow { Time = 180, Flow = 2.4 });
            timeFlowList.Add(new DTO_TimeFlow { Time = 240, Flow = 2.4 });

            _actualTimeFlowList = _uut.CalculateFlowRate();

            for (int i = 0; i < timeFlowList.Count; i++)
            {
                Assert.AreEqual(timeFlowList[i].Time, _actualTimeFlowList[i].Time);
                Assert.AreEqual(timeFlowList[i].Flow, _actualTimeFlowList[i].Flow);
            }

        }
    }
}