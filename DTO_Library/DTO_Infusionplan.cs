using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using SQLitePCL;


namespace DTO_Library
{
    public class DTO_InfusionPlan
    {
        [Key]
        public int InfusionPlanId { get; set; }
        public string CPR { get; set; }
        public int MachineID { get; set; }
        public string MedicineName { get; set; }
        public double Weight { get; set; }
        public int Fulltime { get; set; }
        public double Factor { get; set; } //opgives i mg
        public double MaxDoseage { get; set; }
        public int IntervalTime { get; set; }
        public double Concentration { get; set; } //opgives i mg/ml

        public int  BatchId { get; set; }
        public int  Height { get; set; }
        public string PatientName { get; set; }

        // navigation properties
        public List<DTO_TimeFlow> DtoTimeFlowList { get; set; }
    }
}
