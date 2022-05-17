using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ICA_BusinessLogicLayer;
using ICA_BusinessLogicLayer.Exception;
using NUnit.Framework;

namespace ST4GR3_test_ICA.BusinessLogicLayer
{
   public class MedicineUnitTest
   {
      private IMedicine _uut;
      private List<Medicine_config> _configlist;
      private Medicine_config iloprost;
      private Medicine_config infliximab_1til4;

      [SetUp]
      public void Setup()
      {
         _uut = new Medicine(){};
         
      }

      [Test]

      public void TestGetMedicine_WrongMedicine()
      {
         iloprost = new Medicine_config()
         {
            Name = "Iloprost",
            Concentration = 0.02,
            Disease = "Perifære Vaskulære",
            Factor = 0.0005,
            Fulltime = 360,
            IntervalTime = 30,
            MaxDosis = 0.002
         };
         infliximab_1til4 = new Medicine_config()
         {
            Name = "Infliximab_1til4",
            Concentration = 0,
            Disease = "Reumatoid artritis",
            Factor = 5,
            Fulltime = 120,
            IntervalTime = 0,
            MaxDosis = 10
         };
         _configlist = new List<Medicine_config>() { iloprost, infliximab_1til4 };

         Assert.Throws<InvalidMedicineNameConflictException>(() => _uut.GetMedicine(_configlist, "panodil"));
      }

      //[TestCase()]

      //public void TestGetMedicineReturnRightMedicine(string name, double concentration, string disease )
      //{
      //   iloprost = new Medicine_config()
      //   {
      //      Name = "Iloprost",
      //      Concentration = 0.02,
      //      Disease = "Perifære Vaskulære",
      //      Factor = 0.0005,
      //      Fulltime = 360,
      //      IntervalTime = 30,
      //      MaxDosis = 0.002
      //   };
      //   infliximab_1til4 = new Medicine_config()
      //   {
      //      Name = "Infliximab_1til4",
      //      Concentration = 0,
      //      Disease = "Reumatoid artritis",
      //      Factor = 5,
      //      Fulltime = 120,
      //      IntervalTime = 0,
      //      MaxDosis = 10
      //   };
      //   _configlist = new List<Medicine_config>() { iloprost, infliximab_1til4 };

      //   Medicine medicine=_uut.GetMedicine(_configlist,"Iloprost");
      //   Assert.That(medicine, Is.EqualTo(new Medicine("Iloprost", 0.0005, 30, 360, 0.002, 0.02)));
      //}


   }
}
