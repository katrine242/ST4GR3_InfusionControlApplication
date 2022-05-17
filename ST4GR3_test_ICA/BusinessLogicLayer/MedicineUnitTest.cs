using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ICA_BusinessLogicLayer;
using NUnit.Framework;

namespace ST4GR3_test_ICA.BusinessLogicLayer
{
   public class MedicineUnitTest
   {
      private IMedicine _uut;
      private List<Medicine_config> _configlist;
      [SetUp]
      public void Setup()
      {
         _uut = new Medicine(){};
   }

      [Test]

      public void TestGetMedicineReturnEmpty()
      {
         Medicine_config infliximab_1til4 = new Medicine_config()
         {
            Name = "Infliximab_1til4",
            Concentration = 0,
            Disease = "Reumatoid artritis",
            Factor = 5,
            Fulltime = 120,
            IntervalTime = 0,
            MaxDosis = 10
         };

         _configlist = new List<Medicine_config>();
         var medicineList = _uut.GetMedicine(_configlist, "Iloprost");
         Assert.That(medicineList.Equals());
      }
      [Test]

      public void TestGetMedicineReturnRightMedicine()
      {
         Medicine_config iloprost = new Medicine_config()
         {
            Name = "Iloprost", Concentration = 0.02, Disease = "Perifære Vaskulære", Factor = 0.0005, Fulltime = 360,
            IntervalTime = 30, MaxDosis = 0.002
         };
         Medicine_config infliximab_1til4 = new Medicine_config()
         {
            Name = "Infliximab_1til4", Concentration = 0, Disease = "Reumatoid artritis", Factor = 5,
            Fulltime = 120, IntervalTime = 0, MaxDosis = 10
         };

         _configlist = new List<Medicine_config>(){iloprost, infliximab_1til4};
         var medicine=_uut.GetMedicine(_configlist,"Iloprost");
         Assert.That(medicine.Equals(new Medicine("Iloprost",0.0005,30,360,0.002,0.0)));
      }


   }
}
