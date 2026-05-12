using System;
using System.Collections.Generic;
using System.Security.AccessControl;
using System.Text;

namespace Bolt
{
    public class Auto : ISõiduk
    {
        public double Kütusekulu { get; set; }
        internal const double _kütusehind = 1.67;
        public double Vahemaa { get; set; }
        public double Tank { get; set; }

        public Auto(double kütusekulu,double tank)
        {
            Kütusekulu = kütusekulu;
            Tank = tank;
        }

        public double ArvutaKulu()
        {
            return Tank * _kütusehind;
        }
        
        public double ArvutaVahemaa()
        {
            double vahemaa = Tank / Kütusekulu * 100;
            return vahemaa;
        }

        public override string ToString()
        {
            return $"auto - Vahemaa: {ArvutaVahemaa()} km, Kulu: {ArvutaKulu()}€";
        }

    }
}
