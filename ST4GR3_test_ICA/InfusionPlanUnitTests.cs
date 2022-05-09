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
        private DTO_Infusionplan _dtoInfusionplan;
        
        private List<List<double>> _actualList;

       [SetUp]
      public void Setup()
      {
          _dtoInfusionplan = Substitute.For<DTO_Infusionplan>();
          _uut = new InfusionPlan(_dtoInfusionplan);
          _actualList = new List<List<double>>();

      }

      [Test]
      public void Medicine1ListOfListCheck()
      {
          _dtoInfusionplan.Weight = 60;
          _dtoInfusionplan.Factor = 0.5;
          _dtoInfusionplan.Concentration = 50;
          _dtoInfusionplan.Fulltime = 180;
          _dtoInfusionplan.IntervalTime = 20;
          _dtoInfusionplan.MaxDoseage = 2.0;

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
          
           _actualList = _uut.CalculateFlowRate(_dtoInfusionplan);
          CollectionAssert.AreEqual(myList, _actualList);
          
      }
    }
}