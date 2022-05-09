using System;
using System.Collections.Generic;


namespace DTO_Library
{
    public class DTO_Infusionplan
    {
        
        public string MedicineName { get; set; }
        public string Name { get; set; }
        public int CPR { get; set; }
        public double Weight { get; set; }
        public int MachineID { get; set; }
        public double FlowRate { get; set; }

        private List<List<double>> _timeFlowList;
        

        public DTO_Infusionplan(string medicineName, string name, int cpr, double weight, int machineId, double flowRate, List<List<double>> timeFlow)
        {
            
            MedicineName = medicineName;
            Name = name;
            CPR = cpr;
            Weight = weight;
            MachineID = machineId;
            FlowRate = flowRate;
            _timeFlowList = timeFlow;

        }

        

    }
}
