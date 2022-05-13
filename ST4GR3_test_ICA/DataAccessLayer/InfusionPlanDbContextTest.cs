using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using NSubstitute;
using DTO_Library;
using ICA_DataAccessLayer.DbContexts;
using Microsoft.EntityFrameworkCore;

namespace ST4GR3_test_ICA.DataAccessLayer
{
    [TestFixture]
    public class InfusionPlanDbContextTest
    {
        private InfusionPlanDbContext _uut;
        private DTO_InfusionPlan _dtoInfusionPlan;

        [SetUp]
        public void Setup()
        {
            _uut = new InfusionPlanDbContext();
            _dtoInfusionPlan = new DTO_InfusionPlan();
        }

        [Test]

        public void TestOnConfiguring()
        {
            

        }
    }
}
