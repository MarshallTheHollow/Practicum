using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Practicum.Models.Kurs
{    
    public class KursPP
    {
        public double PPCalc (KursInput ki, KursPIP pip)
        {
            double tdn = pip.PIPCalc(ki);
            KursKUInput kp = new KursKUInput();
            YachParams yp = kp.PPParams(ki);
            KUParams kup = kp.Parameters(ki);
            KursAllCalc KAC = new KursAllCalc();
            return KAC.Calc(ki, yp, kup, tdn, ki.TempNagr, kup._tpp);
        }
    }
}
