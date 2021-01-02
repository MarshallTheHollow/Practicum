using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Practicum.Models.Kurs
{
    public class KursKoef
    {
        public double KoefTP (double T)
        {
            double KoefTP = (0.00009 * T) + 0.0227;
            return KoefTP;
        }
        public double KoefKinV(double T)
        {
            double KoefKinV = (0.00000000007 * Math.Pow(T, 2)) + (0.0000001 * T) + 0.00001;
            return KoefKinV;
        }
        public double NumberPr(double T)
        {
            double NumberPr = (0.00000008 * Math.Pow(T, 2)) + (0.0002 * T) + 0.7127;
            return NumberPr;
        }
        public double alfaV (double P)
        {
            double alfaV = (164.29 * P) + 61.429;
            return alfaV;
        }
    }
}
