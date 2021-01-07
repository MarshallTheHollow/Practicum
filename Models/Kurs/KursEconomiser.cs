using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Practicum.Models.Kurs
{
    public class KursEconomiser
    {

        public Output EconomiserCount(KursInput ki, KursPIP pip, KursPP pp, KursIS iis)
        {
            double tdn = iis.ISCalc(ki, pp, pip);
            double tvn = ki.tpv;
            double tvk = ki.TempNagr;
            Output op = new Output();
            KursKUInput kp = new KursKUInput();
            YachParams yp = kp.VEParams(ki);
            KUParams kup = kp.Parameters(ki);
            KursAllCalc KAC = new KursAllCalc();
            double tdk = KAC.Calc(ki, yp, kup, tdn, tvn, tvk);
            op.OutputTdk = tdk;
            KursKoef kk = new KursKoef();
            KursEntalpia ke = new KursEntalpia();
            op.Vn0 = (ki.Vd0/3600) * (1 + 0.5 * ki.DpodVos);
            op.Qvip = op.Vn0 * ki.Ksavetemp * (ke.EntalpiaSum(ki.tdn, ki.CO2, ki.H2O, ki.N2, ki.O2) - ke.EntalpiaSum(tdk, ki.CO2, ki.H2O, ki.N2, ki.O2));
            op.Qpp = (ki.Vd0 / 3600) * ki.Ksavetemp * (ke.EntalpiaSum(pip.PIPCalc(ki), ki.CO2, ki.H2O, ki.N2, ki.O2) - ke.EntalpiaSum(pp.PPCalc(ki, pip), ki.CO2, ki.H2O, ki.N2, ki.O2));
            op.Ekv = ke.EntalpiaPV(ki.TempNagr, ki.P);
            op.Epv = ke.EntalpiaPV(ki.tpv, ki.P);
            op.Enp = ke.EntalpiaPP(ki.TempNagr, ki.P);
            op.EppR = ((op.Qvip * op.Enp) - op.Qpp * (op.Epv - ((0.01*ki.StepProd) *(op.Ekv - op.Epv))))/(op.Qvip - op.Qpp);
            op.EppT = ke.EntalpiaPP(kup._tpp, ki.P);
            op.PogRech = Math.Abs(((op.EppR - op.EppT)/ op.EppT)*100);
            op.ParoProisvod = op.Qpp / (op.EppR - op.Enp);
            return op;
        }
    }
}
