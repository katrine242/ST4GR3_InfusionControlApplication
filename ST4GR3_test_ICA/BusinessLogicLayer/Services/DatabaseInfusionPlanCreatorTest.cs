using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using NSubstitute;
using ICA_BusinessLogicLayer.Services.InfusionPlanCreator;
using ICA_BusinessLogicLayer;
using ICA_DataAccessLayer.DbContexts;
using DTO_Library;
using Microsoft.Data.Sqlite;

namespace ST4GR3_test_ICA.BusinessLogicLayer.Services
{
    [TestFixture]
    public class DatabaseInfusionPlanCreatorTest
    {
        private DatabaseInfusionPlanCreator _uut;
        private InfusionPlan _infusionPlan;
        private DTO_InfusionPlan _dtoInfusionPlan;
        private IMedicine _fakeMedicine;
        private string _connectingstring = "Data Source=infusionPlan.db";

        [SetUp]
        public void Setup()
        {
            _fakeMedicine = Substitute.For<IMedicine>();

            _dtoInfusionPlan = new DTO_InfusionPlan();

            _infusionPlan = new InfusionPlan(_fakeMedicine,_dtoInfusionPlan);
            _uut = new DatabaseInfusionPlanCreator(_connectingstring);
        }

        [Test]
        public void TestIfInfusionPlanIsCreated()
        {
            _uut.CreateInfusionPlan(_infusionPlan).ContinueWith((k) =>
            {
                Console.WriteLine(k);
                Assert.IsNotNull(null, "error");
            });
        }

        [Test]
        public void TestMigrateToDatabase()
        {
            SqliteCommand sqliteCommand = new SqliteCommand(_connectingstring);

            _uut.MigrateToDataBase();

            Assert.IsTrue(!sqliteCommand.Equals(null));
        }
    }
}
