using System.ComponentModel.DataAnnotations;

namespace DTO_Library
{
    public class DTO_TimeFlowListItem
    {
        public int Id { get; set; }
        public double TimeFlowListItemType { get; set; }
        public DTO_TimeFlowList DtoTimeFlowList { get; set; }
        public int DtoTimeFlowListId { get; set; }
        public long DtoTimeFlowListDtoInfusionPlanCpr { get; set; }
    }
}