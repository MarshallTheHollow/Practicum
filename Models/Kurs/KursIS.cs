using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Practicum.Models.Kurs
{
    public class KursIS
    {
        public double ISCalc(KursInput ki, KursPP pp, KursPIP pip)
        {
            double tdn = pp.PPCalc(ki, pip);
            KursKUInput kp = new KursKUInput();
            YachParams yp = kp.ISParams(ki);
            KUParams kup = kp.Parameters(ki);
            KursAllCalc KAC = new KursAllCalc();
            return KAC.Calc(ki, yp, kup, tdn, ki.TempNagr, ki.TempNagr);
        }
    }
}
