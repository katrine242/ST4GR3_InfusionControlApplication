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
        #region Properties
        public DTO_InfusionPlan InfusionData { get; set; }

        public int MachineID { get; set; }
        public int BatchId { get; set; }
        public long CPR { get; set; }
        public double Weight { get; set; }
        public string PatientName { get; set; }
        public IMedicine Medicine { get; }

        public List<DTO_TimeFlow> DtoTimeFlowList { get; set; }

        #endregion

        public InfusionPlan(IMedicine medicine, int machineId, int batchId, long cpr, double weight, string patientName)
        {
            Medicine = medicine;

            MachineID = machineId;
            BatchId = batchId;
            CPR = cpr;
            Weight = weight;
            PatientName = patientName;
        }

        public void MakeInfusionPlan() 
        {
            InfusionData.DtoTimeFlowList = CalculateFlowRate(InfusionData);

        }

        
        public List<DTO_TimeFlow> CalculateFlowRate(DTO_InfusionPlan m)
        {
         // disse skal hentes fra dto_infusionplan
         //int intervaltime = m.IntervalTime;
         //int fulltime = m.Fulltime;
         //double factor = m.Factor;
         //double maxDosis = m.MaxDoseage;
         //double concentration = m.Concentration;
         //double weight = m.Weight;

         int intervaltime = Medicine.IntervalTime;
         int fulltime = Medicine.Fulltime;
         double factor = Medicine.Factor;
         double maxDosis = Medicine.MaxDosis;
         double concentration = Medicine.Concentration;
         double weight = m.Weight;

         double accFactor = factor;

            int listCapacity = fulltime / intervaltime;

            // List of lists
            //List<DTO_TimeFlowList> myList = new List<DTO_TimeFlowList>();
           List<DTO_TimeFlow> dtoTimeFlowList = new List<DTO_TimeFlow>();

            double time = -intervaltime;
            double flow;

            for (int i = 0; i < listCapacity; i++)
            {
                
                time = time + intervaltime; // lægger tid til for hvert interval
                flow = ((weight * accFactor * intervaltime)/ intervaltime) / concentration; 
                // flow/konc = ml
                DTO_TimeFlow localdtoTimeFlow = new DTO_TimeFlow{Time = time,Flow = flow};

                if (accFactor < maxDosis) // sikrer at der ikke gives mere end maxdosis
                {
                    //DTO_TimeFlowList dto = new DTO_TimeFlowList();
                    //dto.TimeFlowListItems.Add(new DTO_TimeFlowListItem(){ TimeFlowListItemType = time});
                    //dto.TimeFlowListItems.Add(new DTO_TimeFlowListItem() { TimeFlowListItemType = flow});
                    //myList.Add(dto); // dosis pr. interval

                    dtoTimeFlowList.Add(localdtoTimeFlow);

                    accFactor = accFactor + factor; // adderer faktor for hvert interval
                }
                else
                {
                    dtoTimeFlowList.Add(localdtoTimeFlow);
                    //DTO_TimeFlowList dto = new DTO_TimeFlowList();
                    //dto.TimeFlowListItems.Add(new DTO_TimeFlowListItem(){ TimeFlowListItemType = time});
                    //dto.TimeFlowListItems.Add(new DTO_TimeFlowListItem() { TimeFlowListItemType = flow});
                    //myList.Add(dto);

                }
            }

            return dtoTimeFlowList;

        }
    }

    
}
