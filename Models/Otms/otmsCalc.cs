using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Practicum.Models
{
    public class otmsCalc
    {
        public otsmReturn calc(otmsInput oI)
        {
            otsmReturn oR = new otsmReturn();

            oR.S = Math.Round(Math.PI * oI.D * oI.D / 4, 4);
            oR.Vr = Math.Round(oI.wr * oR.S, 4);
            oR.m = Math.Round((oI.Gm * oI.Cm) / (oR.Vr * oI.Cr), 4);
            oR.Yo = Math.Round(oI.aV * oI.Ho * oR.S / (oI.wr * oR.S * oI.Cr * 1000), 4);
            oR.Mexp = Math.Round(1 - oR.m * Math.Exp(-1 * (1 - oR.m) * oR.Yo / oR.m), 4);

            List<double> list1 = new List<double>();
            List<double> list2 = new List<double>();
            List<double> list3 = new List<double>();
            List<double> list4 = new List<double>();
            List<double> list5 = new List<double>();
            List<double> list6 = new List<double>();
            List<double> list7 = new List<double>();
            List<double> list8 = new List<double>();

            for (double i = 0; i <= oI.Ho; i += 0.5)
            {
                double forlist1 = Math.Round(oI.aV * i / (oI.wr * oI.Cr * 1000), 4);
                list1.Add(forlist1);

                double forlist2 = Math.Round(1 - Math.Exp((oR.m - 1) * forlist1 / oR.m), 4);
                list2.Add(forlist2);

                double forlist3 = Math.Round(1 - oR.m * Math.Exp((oR.m - 1) * forlist1 / oR.m), 4);
                list3.Add(forlist3);

                double forlist4 = Math.Round(forlist2 / (1 - oR.m * Math.Exp((oR.m - 1) * oR.Yo / oR.m)), 4);
                list4.Add(forlist4);

                double forlist5 = Math.Round((1 - oR.m * Math.Exp((oR.m - 1) * (forlist1 / oR.m))) / (1 - oR.m * Math.Exp((oR.m - 1) * oR.Yo / oR.m)), 4);
                list5.Add(forlist5);

                double forlist6 = Math.Round((oI.temp + ((oI._Temp - oI.temp) * forlist4)), 4);
                list6.Add(forlist6);

                double forlist7 = Math.Round((oI.temp + ((oI._Temp - oI.temp) * forlist5)), 4);
                list7.Add(forlist7);

                double forlist8 = Math.Round(Math.Abs(forlist6 - forlist7), 4);
                list8.Add(forlist8);
            }
            oR.Ylist = list1;
            oR.explist = list2;
            oR.mexplist = list3;
            oR.ulist = list4;
            oR.olist = list5;
            oR.tlist = list6;
            oR._Tlist = list7;
            oR.Templist = list8;
            return oR;
        }

    }
}
