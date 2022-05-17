using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

      [SetUp]
      public void Setup()
      {
         _uut = new ConfigurationSerialization();
      }

      [Test]

      public void testConfig()
      {

      }


}
}
