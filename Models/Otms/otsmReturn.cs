using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Practicum.Models
{
    public class otsmReturn
    {
        public double S;
        public double Vr;
        public double m;
        public double Yo;
        public double Mexp;

        public List<double> Ylist = new List<double>();
        public List<double> explist = new List<double>();
        public List<double> mexplist = new List<double>();
        public List<double> ulist = new List<double>();
        public List<double> olist = new List<double>();
        public List<double> tlist = new List<double>();
        public List<double> _Tlist = new List<double>();
        public List<double> Templist = new List<double>();
    }
}
