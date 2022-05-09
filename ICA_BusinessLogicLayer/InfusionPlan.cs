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
        public Medicine Medicine { get; }
        public string MedicineName { get; set; }
        public string Name { get; }
        public int CPR { get; }
        public double Weight { get; set; }
        public int MachineID { get; }

        private List<List<double>> _timeFlowList;
        public DTO_Infusionplan InfusionData { get; set; }


        public InfusionPlan()
        {
            
            InfusionData = new DTO_Infusionplan();
            InfusionData.TimeFlowList = MakeInfusionPlan(); // sætter intervaller med tilhørende flow

        }

        public List<List<double>> MakeInfusionPlan() 
        {
            //sæt vægt i unit test

            _timeFlowList = CalculateFlowRate(Medicine);

            return _timeFlowList;
        }

        public List<List<double>> CalculateFlowRate(Medicine m)
        {
            // disse skal hentes fra dto_infusionplan
            int intervaltime = Medicine.IntervalTime;
            int fulltime = Medicine.Fulltime;
            double factor = Medicine.Factor;
            int maxDosis = Medicine.MaxDosis;

            double accFactor = factor;

            int listCapacity = fulltime / intervaltime;

            // List of lists
            List<List<double>> myList = new List<List<double>>();

            double time = -30;
            double flow;

            for (int i = 0; i < listCapacity; i++)
            {
                time = time + intervaltime; // lægger tid til for hvert interval
                flow = ((Weight * accFactor * intervaltime)/ intervaltime) / konc; 
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
