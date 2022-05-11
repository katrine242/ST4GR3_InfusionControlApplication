using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO_Library;


namespace ICA_BusinessLogicLayer
{
    public class InfusionPlan : IInfusionPlan
    {
        
        public DTO_InfusionPlan InfusionData { get; set; }
       
        public InfusionPlan(IMedicine medicine, DTO_InfusionPlan dtoInfusionplan)
        {
            InfusionData = dtoInfusionplan;
            
        }

        public void MakeInfusionPlan() 
        {
            InfusionData.TimeFlowLists = CalculateFlowRate(InfusionData);

        }

        
        public List<DTO_TimeFlowList> CalculateFlowRate(DTO_InfusionPlan m)
        {
            // disse skal hentes fra dto_infusionplan
            int intervaltime = m.IntervalTime;
            int fulltime = m.Fulltime;
            double factor = m.Factor;
            double maxDosis = m.MaxDoseage;
            double concentration = m.Concentration;
            double weight = m.Weight;

            double accFactor = factor;

            int listCapacity = fulltime / intervaltime;

            // List of lists
            List<DTO_TimeFlowList> myList = new List<DTO_TimeFlowList>();

            double time = -intervaltime;
            double flow;

            for (int i = 0; i < listCapacity; i++)
            {
                
                time = time + intervaltime; // lægger tid til for hvert interval
                flow = ((weight * accFactor * intervaltime)/ intervaltime) / concentration; 
                // flow/konc = ml

                if (accFactor < maxDosis) // sikrer at der ikke gives mere end maxdosis
                {
                    DTO_TimeFlowList dto = new DTO_TimeFlowList();
                    dto.TimeFlowListItems.Add(new DTO_TimeFlowListItem(){ TimeFlowListItemType = time});
                    dto.TimeFlowListItems.Add(new DTO_TimeFlowListItem() { TimeFlowListItemType = flow});
                    myList.Add(dto); // dosis pr. interval
                    accFactor = accFactor + factor; // adderer faktor for hvert interval
                }
                else
                {
                    DTO_TimeFlowList dto = new DTO_TimeFlowList();
                    dto.TimeFlowListItems.Add(new DTO_TimeFlowListItem(){ TimeFlowListItemType = time});
                    dto.TimeFlowListItems.Add(new DTO_TimeFlowListItem() { TimeFlowListItemType = flow});
                    myList.Add(dto);
                }
            }

            return myList;
            
        }
    }

    
}
