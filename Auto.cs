using System;
using System.Collections.Generic;
using System.Security.AccessControl;
using System.Text;

namespace Bolt
{
    // Auto klass rakendab ISõiduk liidest
    public class Auto : ISõiduk
    {
        // Kütusekulu liitrites 100 km kohta
        public double Kütusekulu { get; set; }

        // Kütuse hind eurodes liitri kohta
        public double Kütusehind { get; set; }

        // Läbitav vahemaa kilomeetrites
        public double Vahemaa { get; set; }

        // Kütusepaagi maht liitrites
        public double Tank { get; set; }

        // Konstruktor võtab kütusekulu, kütusehinna ja paagi mahu
        public Auto(double kütusekulu, double kütusehind, double tank)
        {
            Kütusekulu = kütusekulu;
            Kütusehind = kütusehind;
            Tank = tank;
        }

        // Arvutab kogu kütusekulu eurodes (täis paak * kütusehind)
        public double ArvutaKulu()
        {
            return Tank * Kütusehind;
        }

        // Arvutab kui kaugele saab täis tankiga sõita
        public double ArvutaVahemaa()
        {
            double vahemaa = Tank / Kütusekulu * 100;
            return vahemaa;
        }

        // Tagastab auto info tekstina
        public override string ToString()
        {
            return $"Auto - Vahemaa: {Math.Round(ArvutaVahemaa(), 1)} km, Kulu: {Math.Round(ArvutaKulu(), 2)}€";
        }
    }
}