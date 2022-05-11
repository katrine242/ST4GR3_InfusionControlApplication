using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DTO_Library
{
    public class DTO_TimeFlowList
    {
        public int Id { get; set; }
        public List<DTO_TimeFlowListItem>? TimeFlowListItems { get; set; }
        public DTO_InfusionPlan DtoInfusionPlan { get; set; }
        public long DtoInfusionPlanCpr { get; set; }
    }
}