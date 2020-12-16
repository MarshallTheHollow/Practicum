using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Practicum.Models.Kurs
{
    public class YachParams
    {
        public double _S1 { get; set; }
        public double _Ntrub { get; set; }
        public double _Ssech { get; set; }
        public double _Snagr { get; set; }
    }
    public class KUParams
    {
        public double _ParPros { get; set; }
        public double _tpp { get; set; }
        public double _tdnEtalon { get; set; }
        public double _tdkEtalon { get; set; }
        public double _Vd0 { get; set; }
        public double _Sopr { get; set; }
    }
    public class KursKUInput
    {  
        public double ParPros;
        public double tpp;
        public double tdnEtalon;
        public double tdkEtalon;
        public double Vd0;
        public double Sopr;
        public KUParams Parameters(KursInput ki)
        {
            
            if (ki.KUcount == 40 && ki.P == 1.8)
            {
                ParPros = 13;
                tpp = 375;
                tdkEtalon = 248;
                tdnEtalon = 850;
                Vd0 = 40000 / 3600;
                Sopr = 1.12 * 1000;
                
            }
            if(ki.KUcount == 40 && ki.P == 4.5)
            {
                ParPros = 12.9;
                tpp = 385;
                tdkEtalon = 248;
                tdnEtalon = 850;
                Vd0 = 40000 / 3600;
                Sopr = 1.12 * 1000;
            }
            if (ki.KUcount == 60 && ki.P == 1.8)
            {
                ParPros = 13.8;
                tpp = 340;
                tdkEtalon = 219;
                tdnEtalon = 650;
                Vd0 = 60000 / 3600;
                Sopr = 1.1 * 1000;
            }
            if (ki.KUcount == 60 && ki.P == 4.5)
            {
                ParPros = 19;
                tpp = 392;
                tdkEtalon = 252;
                tdnEtalon = 850;
                Vd0 = 60000 / 3600;
                Sopr = 1.15 * 1000;
            }
            if (ki.KUcount == 80 && ki.P == 1.8)
            {
                ParPros = 18.4;
                tpp = 336;
                tdkEtalon = 216;
                tdnEtalon = 650;
                Vd0 = 80000 / 3600;
                Sopr = 1.19 * 1000;
            }
            if (ki.KUcount == 80 && ki.P == 4.5)
            {
                ParPros = 25.8;
                tpp = 385;
                tdkEtalon = 248;
                tdnEtalon = 850;
                Vd0 = 80000 / 3600;
                Sopr = 1.24 * 1000;
            }
            if (ki.KUcount == 100 && ki.P == 1.8)
            {
                ParPros = 32.6;
                tpp = 382;
                tdkEtalon = 242;
                tdnEtalon = 850;
                Vd0 = 100000 / 3600;
                Sopr = 1.20 * 1000;
            }
            if (ki.KUcount == 100 && ki.P == 4.5)
            {
                ParPros = 33.9;
                tpp = 360;
                tdkEtalon = 242;
                tdnEtalon = 850;
                Vd0 = 100000 / 3600;
                Sopr = 1.14 * 1000;
            }
            if (ki.KUcount == 125 && ki.P == 1.8)
            {
                ParPros = 42.4;
                tpp = 365;
                tdkEtalon = 220;
                tdnEtalon = 850;
                Vd0 = 125000 / 3600;
                Sopr = 1.10 * 1000;
            }
            if (ki.KUcount == 125 && ki.P == 4.5)
            {
                ParPros = 40.8;
                tpp = 385;
                tdkEtalon = 230;
                tdnEtalon = 850;
                Vd0 = 125000 / 3600;
                Sopr = 1.15 * 1000;
            }
            if (ki.KUcount == 150 )
            {
                ParPros = 50.5;
                tpp = 393;
                tdkEtalon = 213;
                tdnEtalon = 850;
                Vd0 = 150000 / 3600;
                Sopr = 1.13 * 1000;               
            }
            return new KUParams { _ParPros = ParPros, _tpp = tpp, _tdnEtalon = tdnEtalon, _tdkEtalon = tdkEtalon, _Vd0 = Vd0, _Sopr = Sopr };
        }
        public double S1;
        public double Ntrub;
        public double Ssech;
        public double Snagr;
        public YachParams PIPParms(KursInput ki)
        {
            Ntrub = 12;
            S1 = 0.172;
            if (ki.KUcount == 40)
            {
                Snagr = 30;
                Ssech = 4.32;
            }
            if (ki.KUcount == 60)
            {
                Snagr = 46;
                Ssech = 7;                               
            }
            if (ki.KUcount == 80)
            {
                Snagr = 60;
                Ssech = 8.63;
            }
            if (ki.KUcount == 100)
            {
                Snagr = 85;
                Ssech = 10.8;
            }
            if (ki.KUcount == 125)
            {
                Snagr = 110;
                Ssech = 13.2;
            }
            if (ki.KUcount == 150)
            {
                Snagr = 133;
                Ssech = 16.6;
            }
            return new YachParams { _Ntrub = Ntrub, _S1 = S1, _Snagr = Snagr, _Ssech = Ssech };
        }
        public YachParams ISParams(KursInput ki)
        {
            Ntrub = 22;
            S1 = 0.086;
            if (ki.KUcount == 40)
            {
                Snagr = 110+122+110;
                Ssech = 3.13*3;
            }
            if (ki.KUcount == 60)
            {
                Snagr = 173+192+175;
                Ssech = 5.06*3;
            }
            if (ki.KUcount == 80)
            {
                Snagr = 219+244+221;
                Ssech = 6.34*3;
            }
            if (ki.KUcount == 100)
            {
                Snagr = 285+315+295;
                Ssech = 8.04*3;
            }
            if (ki.KUcount == 125)
            {
                Snagr = 370+410+380;
                Ssech = 10.3*3;
            }
            if (ki.KUcount == 150)
            {
                Snagr = 415+475+436;
                Ssech = 12.5*3;
            }
            return new YachParams { _Ntrub = Ntrub, _S1 = S1, _Snagr = Snagr, _Ssech = Ssech };
        }
        public YachParams PPParams(KursInput ki)
        {
            Ntrub = 8;
            S1 = 0.086;
            if (ki.KUcount == 40)
            {
                Snagr = 43.5;
                Ssech = 3.17;
            }
            if (ki.KUcount == 60)
            {
                Snagr = 70;
                Ssech = 5.06;
            }
            if (ki.KUcount == 80)
            {
                Snagr = 87;
                Ssech = 6.34;
            }
            if (ki.KUcount == 100)
            {
                Snagr = 110;
                Ssech = 8.04 ;
            }
            if (ki.KUcount == 125)
            {
                Snagr = 144;
                Ssech = 10.3;
            }
            if (ki.KUcount == 150)
            {
                Snagr = 166;
                Ssech = 12.5;
            }
            return new YachParams { _Ntrub = Ntrub, _S1 = S1, _Snagr = Snagr, _Ssech = Ssech };
        }
        public YachParams VEParams(KursInput ki)
        {
            Ntrub = 20;
            S1 = 0.09;
            if (ki.KUcount == 40)
            {
                Snagr = 185;
                Ssech = 3.18;
            }
            if (ki.KUcount == 60)
            {
                Snagr = 247;
                Ssech = 4.55;
            }
            if (ki.KUcount == 80)
            {
                Snagr = 370;
                Ssech = 6.36;
            }
            if (ki.KUcount == 100)
            {
                Snagr = 460;
                Ssech = 7.67;
            }
            if (ki.KUcount == 125)
            {
                Snagr = 615;
                Ssech = 9.8;
            }
            if (ki.KUcount == 150)
            {
                Snagr = 725;
                Ssech = 9.65;
            }
            return new YachParams { _Ntrub = Ntrub, _S1 = S1, _Snagr = Snagr, _Ssech = Ssech };
        }
    }
}
