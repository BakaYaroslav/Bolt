using System;
using System.Collections.Generic;
using System.Text;

namespace Bolt
{
    // Mootorratas – kütusega töötav kaherattaline sõiduk
    public class Mootorratas : ISõiduk
    {
        public double Vahemaa { get; set; }      // Läbitav vahemaa km
        public double Kütusekulu { get; set; }   // L/100km
        public double Kütusehind { get; set; }   // €/L

        public Mootorratas(double vahemaa, double kütusekulu, double kütusehind)
        {
            Vahemaa = vahemaa;
            Kütusekulu = kütusekulu;
            Kütusehind = kütusehind;
        }

        // Arvutab kogukulu eurodes
        public double ArvutaKulu()
        {
            return Vahemaa / 100 * Kütusekulu * Kütusehind;
        }

        public double ArvutaVahemaa()
        {
            return Vahemaa;
        }

        public override string ToString()
        {
            return $"Mootorratas - Vahemaa: {ArvutaVahemaa()} km, Kulu: {Math.Round(ArvutaKulu(), 2)}€";
        }
    }
}