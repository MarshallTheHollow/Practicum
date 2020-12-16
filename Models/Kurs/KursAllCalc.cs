using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Practicum.Models.Kurs
{
    public class KursAllCalc
    {
        public static double tsr;
        public static double Vn0;
        public static double Vp0;
        public static double w;
        public static double rtn;
        public static double rtk;
        public static double logsumT;
        public static double S;
        public static double p;
        public static double alfadk;
        public static double alfadl;
        public static double Ksr;
        public static double Kst;
        public static double ps;
        public static double Saff;
        public static double EpsA;
        public static double AlfaA;
        public static double Cpr;
        public static double k;
        public static double Q;
        public static double EntalpiaR;
        public double Calc(KursInput ki, YachParams yp, KUParams kup, double tdn, double tvn, double tvk)
        {
            KursKoef kk = new KursKoef();
            KursEntalpia ke = new KursEntalpia();
            double tdk = tdn;
            do
            {
                tsr = (tdn + tdk) / 2;
                Vn0 = kup._Vd0 * (1 + 0.5 * ki.DpodVos);
                Vp0 = Vn0 * (1 + (tsr / 273));
                w = Vp0 / yp._Ssech;
                rtn = tdn - tvn;
                rtk = tdk - tvk;
                logsumT = (rtn - rtk) / Math.Log(rtn / rtk);
                S = Math.Pow((0.25 * yp._S1 + ki.S2), 0.5);
                p = (yp._S1 - ki.d) / (S - ki.d);
                if (p < 0.7)
                {
                    alfadk = 0.334 * Cz(yp._Ntrub) * ((kk.KoefTP(tsr) * Math.Pow(kk.NumberPr(tsr), 0.35)) / Math.Pow(ki.d, 0.4)) * Math.Pow((w / kk.KoefKinV(tsr)), 0.6) * Math.Pow(p, 0.25);
                }
                else
                {
                    alfadk = 0.305 * Cz(yp._Ntrub) * ((kk.KoefTP(tsr) * Math.Pow(kk.NumberPr(tsr), 0.35)) / Math.Pow(ki.d, 0.4)) * Math.Pow((w / kk.KoefKinV(tsr)), 0.6);
                }
                ps = (yp._S1 + ki.S2) / ki.d;
                if (ps <= 7)
                {
                    Saff = (1.87 * ps - 4.1) * ki.d;
                }
                else
                {
                    Saff = (2.82 * ps - 10.6) * ki.d;
                }
                Ksr = ((0.8 + 1.6 * ki.H2O) * (1 - 0.00038 * (tsr + 273))) / Math.Pow(((ki.H2O + ki.CO2) * Saff), 0.5);
                Kst = ((0.8 + 1.6 * ki.H2O) * (1 - 0.00038 * (tvk + 273))) / Math.Pow(((ki.H2O + ki.CO2) * Saff), 0.5);
                EpsA = 1 - Math.E * ((-Ksr) * (ki.H2O + ki.CO2) * Saff);
                AlfaA = 1 - Math.E * ((-Kst) * (ki.H2O + ki.CO2) * Saff);
                Cpr = ki.Co / ((1 / AlfaA) + (1 / EpsA) - 1);
                alfadl = (Cpr * ((EpsA / AlfaA) * Math.Pow(((tsr + 273) / 100), 4) - Math.Pow(((tvk + 273) / 100), 4))) / (tsr - tvk);
                k = 1 / (1 / (alfadk + alfadl));
                Q = k * yp._Snagr * logsumT;
                EntalpiaR = ke.EntalpiaSum(ki.tdn) - (Q / (Vn0 * ki.Ksavetemp));
                tdk -= 0.001;
            }
            while (Math.Abs(EntalpiaR - ke.EntalpiaSum(tdk)) < 1);
            return tdk;
        }
        public double Cz(double NNN)
        {
            if (NNN < 9)
            {
                return 0.95;
            }
            if (NNN > 20)
            {
                return 1;
            }
            else
            {
                return 0.98;
            }
        }
    }
}
