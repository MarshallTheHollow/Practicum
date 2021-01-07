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
        public double Vd0 { get; set; }
        public double tdn { get; set; }
        public double tpv { get; set; } //100;             
        public double CO2 { get; set; } //0.1;
        public double H2O { get; set; } //0.15;
        public double N2 { get; set; } //0.7;
        public double O2 { get; set; } //0.05;       
        public double DpodVos { get; set; } //= 0.1;
        public double TermSop { get; set; } //= 0; 
        public double StepProd { get; set; } // =10
        public double StepBlackPak { get; set; } //= 0.8;
        public double Ksavetemp { get; set; } //= 0.9;
        public double TempNagr = 206;
        public double S2 = 0.07;
        public double d = 0.032;
        public double Co = 5.67;
    }
}
