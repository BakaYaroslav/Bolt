using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Bolt
{
    // Jalgratas rakendab ISõiduk liidest
    public class Jalgratas : ISõiduk
    {
        // Läbitav vahemaa kilomeetrites
        public double Vahemaa { get; set; }

        // Konstruktor võtab ette vahemaa
        public Jalgratas(double vahemaa)
        {
            Vahemaa = vahemaa;
        }

        // Jalgratas ei kasuta kütust, seega kulu on alati 0
        public double ArvutaKulu()
        {
            return 0;
        }

        // Tagastab läbitava vahemaa
        public double ArvutaVahemaa()
        {
            return Vahemaa;
        }

        // Tagastab jalgratta info tekstina
        public override string ToString()
        {
            return $"Jalgratas - Vahemaa: {ArvutaVahemaa()} km, Kulu: {ArvutaKulu()}€";
        }
    }
}