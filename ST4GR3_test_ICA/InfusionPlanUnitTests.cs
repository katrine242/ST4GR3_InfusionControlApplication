using System.Collections.Generic;
using ICA_Model;
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
        
        private List<List<double>> _actualList;
        

        [SetUp]
      public void Setup()
      {
          //_dtoInfusionplan = Substitute.For<DTO_Infusionplan>();
          
          
          _actualList = new List<List<double>>();

      }

      [Test]
      public void Medicine1ListOfListCheck()
      {
          
            DTO_Infusionplan dtoInfusionplan = new DTO_Infusionplan() { Weight = 60, Factor = 0.5, Concentration = 50, Fulltime = 180, IntervalTime = 20, MaxDoseage = 2.0};
            _uut = new InfusionPlan(dtoInfusionplan);

            List<List<double>> myList = new List<List<double>>();
          myList.Add(new List<double> {0, 0.6});
          myList.Add(new List<double> { 20, 1.2 });
          myList.Add(new List<double> { 40, 1.8 });
          myList.Add(new List<double> { 60, 2.4 });
          myList.Add(new List<double> { 80, 2.4 });
          myList.Add(new List<double> { 100, 2.4 });
          myList.Add(new List<double> { 120, 2.4 });
          myList.Add(new List<double> { 140, 2.4 });
          myList.Add(new List<double> { 160, 2.4 });
          
           _actualList = _uut.CalculateFlowRate(dtoInfusionplan);
          CollectionAssert.AreEqual(myList, _actualList);
          
      }
    }
}