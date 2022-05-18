using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using DTO_Library;
using ICA_BusinessLogicLayer;
using ICA_BusinessLogicLayer.Configuration;
using NSubstitute;
using NUnit.Framework;

namespace ST4GR3_test_ICA
{
   public class Configuration_Unittest
   {
      private ConfigurationSerialization _uut;
      private List<Medicine_config> configList;

      [SetUp]
      public void Setup()
      {
         _uut = new ConfigurationSerialization();

      }

      [Test]

      public void testConfigReturnsListOf4Elemnts()
      {
         Assert.That(ConfigurationSerialization.LoadList("Ledogbindevæv_auh.xml").Count,Is.EqualTo(4));
      }


      [Test]

      //Test that method throws exception when called with invalid filename
      public void testConfigReturnsException()
      {
         Assert.That(() => ConfigurationSerialization.LoadList("Ledogbindeæv_auh.xml"),
            Throws.TypeOf< System.IO.FileNotFoundException> ());
      }


      [TestCase("Iloprost", 0.2, "perifere vaskulære", 0.0005, 360, 30, 0.002 )]
      [TestCase("Infliximab_1til4", 0, "Reumatoid artritis", 5, 120, 1, 10)]
      [TestCase("Infliximab_5til10", 0, "Reumatoid artritis", 5, 60, 1, 10)]
      [TestCase("Infliximab_over10", 0, "Reumatoid artritis", 5, 30, 1, 10)]

      public void testConfigReturnsListContainsrightValues(string name, double concentration, string disease, double factor, int fulltime, int intervaltime, double maxdosage)
      {
         configList = ConfigurationSerialization.LoadList("Ledogbindevæv_auh.xml");

         foreach (var medicine in configList)
         {
            if (medicine.Name == name)
            {
               Assert.That(medicine.Factor, Is.EqualTo(factor));
               Assert.That(medicine.Name, Is.EqualTo(name));
               Assert.That(medicine.Concentration, Is.EqualTo(concentration));
               Assert.That(medicine.Fulltime, Is.EqualTo(fulltime));
               Assert.That(medicine.MaxDosis, Is.EqualTo(maxdosage));
               Assert.That(medicine.Disease, Is.EqualTo(disease));
               Assert.That(medicine.IntervalTime,Is.EqualTo(intervaltime));

            }

         }


      }


   }
}
