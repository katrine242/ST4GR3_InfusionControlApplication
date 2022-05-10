using System;
using System.Collections.Generic;


namespace DTO_Library
{
    public class DTO_Infusionplan
    {
        public string MedicineName { get; set; }
        public int CPR { get; set; }
        public double Weight { get; set; }
        public int MachineID { get; set; }
        public int Fulltime { get; set; }
        public double Factor { get; set; } //opgives i mg
        public double MaxDoseage { get; set; }
        public int IntervalTime { get; set; }
        public double Concentration { get; set; } //opgives i mg/ml

   
      public List<List<double>> TimeFlowList { get; set; }
    }
}
