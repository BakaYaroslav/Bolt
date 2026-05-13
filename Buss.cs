using System;
using System.Collections.Generic;
using System.Text;

namespace Bolt
{
    // Buss pärib Auto klassi omadused ja rakendab ISõiduk liidest
    public class Buss : Auto, ISõiduk
    {
        // Bussis olevate reisijate arv
        public int ReisijateArv { get; set; }

        // Konstruktor võtab kütusekulu, kütusehinna, paagi mahu ja reisijate arvu
        public Buss(double kütusekulu, double kütusehind, double tank, int reisijateArv)
            : base(kütusekulu, kütusehind, tank) // Edastame Auto konstruktorile vajalikud andmed
        {
            ReisijateArv = reisijateArv;
        }

        // Arvutab kulu ühe reisija kohta
        public double ArvutaKulu()
        {
            return (Tank * Kütusehind) / ReisijateArv;
        }

        // Arvutab kui kaugele saab täis tankiga sõita
        public double ArvutaVahemaa()
        {
            return Tank / Kütusekulu * 100;
        }

        // Tagastab bussi info tekstina
        public override string ToString()
        {
            return $"Buss - Vahemaa: {Math.Round(ArvutaVahemaa(), 1)} km, Kulu reisija kohta: {Math.Round(ArvutaKulu(), 2)}€";
        }
    }
}