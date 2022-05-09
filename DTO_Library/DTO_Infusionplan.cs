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
        public double Fulltime { get; set; }
        public List<List<double>> TimeFlowList { get; set; }
    }
}
