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
        public List<DTO_Infusionplan> InfusionData { get; set; }


        public InfusionPlan(Medicine medicine, string name, int cpr, double weight, int machineId, List<List<double>> timeFlowList)
        {
            InfusionData = new List<DTO_Infusionplan>();
            Medicine = medicine;
            Name = name;
            CPR = cpr;
            Weight = weight;
            MachineID = machineId;
            MedicineName = Medicine.Name;
            _timeFlowList = timeFlowList;

        }

        public void SetDTOInfusion()
        {
            InfusionData.Add();
        }
        public List<List<double>> MakeInfusionPlan() // kan ikke finde ud af tilgå listen hvis void
        {
            //sæt vægt i unit test

            timeFlowList = CalculateFlowRate(Medicine);
            return timeFlowList;

        }

        public List<List<double>> CalculateFlowRate(Medicine m)
        {
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
                flow = Weight * accFactor * intervaltime;

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
