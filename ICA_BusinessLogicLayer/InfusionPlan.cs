using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO_Library;


namespace ICA_Model
{
    public class InfusionPlan : IInfusionPlan
    {
        
        public DTO_Infusionplan InfusionData { get; set; }
       


        public InfusionPlan(Medicine medicine, DTO_Infusionplan dtoInfusionplan)
        {
            InfusionData = dtoInfusionplan;
            
        }

        public void MakeInfusionPlan() 
        {
            InfusionData.TimeFlowList = CalculateFlowRate(InfusionData);

        }

        
        public List<List<double>> CalculateFlowRate(DTO_Infusionplan m)
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
            List<List<double>> myList = new List<List<double>>();

            double time = -intervaltime;
            double flow;

            for (int i = 0; i < listCapacity; i++)
            {
                
                time = time + intervaltime; // lægger tid til for hvert interval
                flow = ((weight * accFactor * intervaltime)/ intervaltime) / concentration; 
                // flow/konc = ml

                if (accFactor < maxDosis) // sikrer at der ikke gives mere end maxdosis
                {
                    myList.Add(new List<double> { time, flow }); // dosis pr. interval
                    accFactor = accFactor + factor; // adderer faktor for hvert interval

                }
                else
                    myList.Add(new List<double> { time, flow });
            }

            return myList;
            
        }
    }

    
}
