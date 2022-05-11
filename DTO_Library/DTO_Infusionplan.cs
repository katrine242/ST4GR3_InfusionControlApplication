using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;


namespace DTO_Library
{
    public class DTO_InfusionPlan
    {
        public long CPR { get; set; }
        public string MedicineName { get; set; }
        public double Weight { get; set; }
        public int MachineID { get; set; }
        public int Fulltime { get; set; }
        public double Factor { get; set; } //opgives i mg
        public double MaxDoseage { get; set; }
        public int IntervalTime { get; set; }
        public double Concentration { get; set; } //opgives i mg/ml

        public DTO_TimeFlow DtoTimeflow { get; set; }
        public List<DTO_TimeFlowList>? TimeList { get; set; }
        public List<DTO_TimeFlowList>? FlowList { get; set; }
        //public List<List<double>> TimeFlowList { get; set; }
    }
}
