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
            if (P == 4.5)
            {
                Epp = 2.5149 * T + 2200.9;
            }
            else
            {
                return 0;
            }
            return Epp;
        }
        public double EntalpiaPV(double T, double P)
        {
            double Epv;
            if (P == 1.8)
            {
                Epv = 4.3104 * T - 13.41;
            }
            if (P == 4.5)
            {
                Epv = 4.3104 * T - 9.9143;
            }
            else
            {
                return 0;
            }
            return Epv;
        }
        public double EntalpiaSum(double T)
        {
            double EgSum = (0.0002 * Math.Pow(T, 2)) + (1.338 * T) + 1.9992;
            return EgSum;
        }
    }
}
