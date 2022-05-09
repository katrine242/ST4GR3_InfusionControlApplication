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

        //Gets Fulltime, Factor, IntervalLength, MaxDosis from Medicine
        public string MedicineName { get; set; }
        public string Name { get; }
        public int CPR { get; }
        public double Weight { get; set; }
        public int MachineID { get; }

        private List<List<double>> _timeFlowList;
        public DTO_Infusionplan InfusionData { get; set; }


        public InfusionPlan(DTO_Infusionplan dtoInfusionplan)
        {
            
            InfusionData.TimeFlowList = MakeInfusionPlan();

        }

        public List<List<double>> MakeInfusionPlan() 
        {
            //sæt vægt i unit test

            _timeFlowList = CalculateFlowRate(InfusionData);

            return _timeFlowList;
        }

        public List<List<double>> CalculateFlowRate(DTO_Infusionplan m)
        {
            // disse skal hentes fra dto_infusionplan
            int intervaltime = InfusionData.IntervalTime;
            int fulltime = InfusionData.Fulltime;
            double factor = InfusionData.Factor;
            double maxDosis = InfusionData.MaxDoseage;
            double concentration = InfusionData.Concentration;

            double accFactor = factor;

            int listCapacity = fulltime / intervaltime;

            // List of lists
            List<List<double>> myList = new List<List<double>>();

            double time = -30;
            double flow;

            for (int i = 0; i < listCapacity; i++)
            {
                time = time + intervaltime; // lægger tid til for hvert interval
                flow = ((Weight * accFactor * intervaltime)/ intervaltime) / concentration; 
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
