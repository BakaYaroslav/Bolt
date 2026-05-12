using System;
using System.Collections.Generic;
using System.Text;

namespace Bolt
{
    public class Buss : Auto, ISõiduk
    {
        public int ReisijateArv { get; set; }

        public Buss(double kütusekulu, double kütusehind, int reisijateArv)
        : base(kütusekulu, kütusehind)
        {
            ReisijateArv = reisijateArv;
        }

        public double ArvutaKulu()
        {
            return (Tank * _kütusehind) / ReisijateArv;
        }

        public double ArvutaVahemaa()
        {
            return Tank / Kütusekulu * 100;
            
        }

        public override string ToString()
        {    
            return $"Buss - Vahemaa: {ArvutaVahemaa()} km, Kulu: {ArvutaKulu()}€";
        }
    }
}
