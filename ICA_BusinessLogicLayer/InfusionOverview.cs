﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO_Library;

namespace ICA_BusinessLogicLayer
{
    public class InfusionOverview
    {
        private readonly InfusionPlanBook _infusionPlanBook;

        public InfusionOverview(InfusionPlanBook infusionPlanBook)
        {
            _infusionPlanBook = infusionPlanBook;
        }

        public async Task<IEnumerable<InfusionPlan>> GetAllInfusionPlans()
        {
            return await _infusionPlanBook.GetAllInfusionPlans();
        }

        public async Task CreateInfusionPlan(InfusionPlan infusionPlan)
        {
            await _infusionPlanBook.AddInfusionPlan(infusionPlan);
        }
    }
}
