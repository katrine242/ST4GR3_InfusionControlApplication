﻿using System;
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

      [TestCase("Iloprost", 0.02, "Perifære Vaskulære", 0.0005,360,30,0.002)]

      public void TestGetMedicineReturnRightMedicine(string name, double concentration, string disease, double factor,int fulltime,int intervaltime,double maxdosage)
      {
         Medicine_config medicine_config_ = new Medicine_config()
         {
            Concentration = concentration, Disease = disease, Factor = factor, Fulltime = fulltime,
            IntervalTime = intervaltime, MaxDosis = maxdosage, Name = name
         };
         
         _configlist = new List<Medicine_config>() { medicine_config_ };

         Assert.That(_uut.GetMedicine(_configlist, "Iloprost"), Is.EqualTo(new Medicine(name, factor, intervaltime, fulltime, maxdosage, concentration)));
      }

      [TestCase("Iloprost", 0.02, "Perifære Vaskulære", 0.0005, 360, 30, 0.002)]

      public void throws_Rightexception_whennamewrong(string name, double concentration, string disease, double factor, int fulltime, int intervaltime, double maxdosage)
      {
         Medicine_config medicine_config_ = new Medicine_config()
         {
            Concentration = concentration,
            Disease = disease,
            Factor = factor,
            Fulltime = fulltime,
            IntervalTime = intervaltime,
            MaxDosis = maxdosage,
            Name = name
         };

         _configlist = new List<Medicine_config>() { medicine_config_ };

         Assert.That(() => _uut.GetMedicine(_configlist, "panodil"),
            Throws.TypeOf<InvalidMedicineNameConflictException>().With.Property("MedicineName").EqualTo("panodil"));

      }

   }
}
