using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using NSubstitute;
using ICA_BusinessLogicLayer.Services.InfusionPlanProvider;
using ICA_BusinessLogicLayer;
using ICA_DataAccessLayer.DbContexts;
using DTO_Library;
using Microsoft.Data.Sqlite;

namespace ST4GR3_test_ICA.BusinessLogicLayer.Services
{
    [TestFixture]
    public class DatabaseInfusionPlanProviderTest
    {
        private DatabaseInfusionPlanProvider _uut;
        private DTO_InfusionPlan _dtoInfusionPlan;
        private string _connectingstring = "Data Source=infusionPlan.db";

        [SetUp]
        public void Setup()
        {
            _uut = new DatabaseInfusionPlanProvider(_connectingstring);
            _dtoInfusionPlan = new DTO_InfusionPlan();
        }

        [Test]
        public void GetAllInfusionPlansTest()
        {
            _uut.GetAllInfusionPlans().ContinueWith((k) =>
            {
                Console.WriteLine(k);
                Assert.IsNotNull(null, "error");
            });
        }

        [TestCase(0308980566)]
        [TestCase(3112974344)]
        [TestCase(0110982322)]
        public void GetOneInfusionPlanTest(long CPRValue)
        {
           //_dtoInfusionPlan = _uut.GetOneInfusionPlan(CPRValue);

           // Assert.That(_dtoInfusionPlan.CPR, Is.EqualTo(CPRValue));
        }
    }
}
