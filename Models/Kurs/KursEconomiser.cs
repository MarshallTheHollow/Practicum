using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Practicum.Models.Kurs
{
    public class KursEconomiser
    {
        public static double Vn0;
        public static double Qvip;
        public static double Qpp;
        public static double Ekv;
        public static double Epv;
        public static double Enp;
        public static double EppT;
        public static double EppR;
        public static double PogRech;
        public static double ParoProisvod;
        public double EconomiserCount(KursInput ki, KursPIP pip, KursPP pp, KursIS iis)
        {
            double tdn = iis.ISCalc(ki, pp, pip);
            double tvn = ki.tpv;
            double tvk = ki.TempNagr;
            KursKUInput kp = new KursKUInput();
            YachParams yp = kp.ISParams(ki);
            KUParams kup = kp.Parameters(ki);
            KursAllCalc KAC = new KursAllCalc();
            double tdk = KAC.Calc(ki, yp, kup, tdn, tvn, tvk);
            KursKoef kk = new KursKoef();
            KursEntalpia ke = new KursEntalpia();
            Vn0 = kup._Vd0 * (1 + 0.5 * ki.DpodVos);
            Qvip = Vn0 * ki.Ksavetemp * (ke.EntalpiaSum(ki.tdn) - ke.EntalpiaSum(tdk));
            Qpp = kp.Vd0 * ki.Ksavetemp * (ke.EntalpiaSum(pip.PIPCalc(ki)) - ke.EntalpiaSum(pp.PPCalc(ki, pip)));
            Ekv = ke.EntalpiaPV(ki.TempNagr, ki.P);
            Epv = ke.EntalpiaPV(ki.tpv, ki.P);
            Enp = ke.EntalpiaPP(ki.TempNagr, ki.P);
            EppR = ((Qvip * Enp) - Qpp * (Epv - (ki.n*(Ekv-Epv))))/(Qvip-Qpp);
            EppT = ke.EntalpiaPP(kup._tpp, ki.P);
            PogRech = ((EppR - EppT)/EppT)*100;
            ParoProisvod = Qpp / (EppR-Enp);
            return ParoProisvod;
        }
    }
}
