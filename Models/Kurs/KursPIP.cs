using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Practicum.Models.Kurs
{   
    public class KursPIP
    {       
        public double PIPCalc(KursInput ki)
        {
            KursKUInput kp = new KursKUInput();
            YachParams yp = kp.PIPParms(ki);
            KUParams kup = kp.Parameters(ki);
            KursAllCalc KAC = new KursAllCalc();
            return KAC.Calc(ki, yp, kup, ki.tdn, kup.TempNagr, kup.TempNagr);
        }         
    }
}
