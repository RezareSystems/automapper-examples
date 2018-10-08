using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoMapping
{
    public class Weather
    {
        public DateTime Date { get; set; }
        public double TempMax { get; set; }
        public double TempMin { get; set; }
        public double TempMean => (TempMax + TempMin)/2;
        public double Rainfall { get; set; }
        public double SoilTemp { get; set; }
    }
}
