using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ICA_Model
{
    public class Medicine : IMedicine
    {
        public string Name { get; }
        public double Factor { get; }
        public int IntervalTime { get; }
        public int Fulltime { get; }
        public int MaxDosis { get; }
        public Medicine(string name, double factor, int intervalTime, int maxDosis, int fulltime)
        {
            Name = name;
            Factor = factor;
            IntervalTime = intervalTime;
            MaxDosis = maxDosis;
            Fulltime = fulltime;
        }
    }
}
