using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Practicum.Models
{
    public class KursInput
    {
        public double P { get; set; }
        public int KUcount { get; set; }
        public double tdn { get; set; }
        public double tpv = 100;
        public double TempNagr = 206;        
        public double CO2 = 0.1;
        public double H2O = 0.15;
        public double N2 = 0.7;
        public double O2 = 0.05;
        public double n = 0.1;
        public double DpodVos = 0.1;
        public double TermSop = 0;
        public double Co = 5.67;
        public double StepBlackPak = 0.8;
        public double Ksavetemp = 0.9;       
        public double S2 = 0.07;
        public double d = 0.032;

    }
}
