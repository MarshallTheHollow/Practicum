using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Practicum.Models.Kurs
{
    public class KursEntalpia
    {
        public double EntalpiaPP(double T, double P)
        {           
            double Epp;           
            if (P == 1.8)
            {
                Epp = 2.2054 * T + 2372.1;
            }
            else
            {
                Epp = 2.5149 * T + 2200.9;
            }
            return Epp;
        }
        public double EntalpiaPV(double T, double P)
        {
            double Epv;
            if (P == 1.8)
            {
                Epv = 4.3223 * T - 13.41;
            }
            else
            {
                Epv = 4.3104 * T - 9.9143;
            }
            return Epv;
        }
        public double EntalpiaSum(double T, double CO2, double H2O, double N2, double O2)
        {
            double eCO2 = (0.0004 * Math.Pow(T, 2)) + (1.8505 * T) - 22.683;
            double eH2O = (0.0003 * Math.Pow(T, 2)) + (1.4428 * T) + 3.65;
            double eN2 = (0.0001 * Math.Pow(T, 2)) + (1.2423 * T) + 5.7667;
            double eO2 = (0.0001 * Math.Pow(T, 2)) + (1.3396 * T) - 6.3333;
            double EgSum = (eCO2*(CO2/100)) + (eH2O*(H2O/100))+(eN2*(N2/100))+(eO2*(O2/100));
            return EgSum;
        }
    }
}
