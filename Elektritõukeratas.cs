using System;
using System.Collections.Generic;
using System.Text;

namespace Bolt
{
    // Elektritõukeratas – kasutab elektrienergiat, kulu arvutatakse kWh põhjal
    public class Elektritõukeratas : ISõiduk
    {
        public double Vahemaa { get; set; }       // Läbitav vahemaa km
        public double Energiakulu { get; set; }   // kWh/100km
        private const double ElektriHind = 0.15;  // €/kWh

        public Elektritõukeratas(double vahemaa, double energiakulu)
        {
            Vahemaa = vahemaa;
            Energiakulu = energiakulu;
        }

        // Arvutab elektrienergia kulu eurodes
        public double ArvutaKulu()
        {
            return Vahemaa / 100 * Energiakulu * ElektriHind;
        }

        // Tagastab läbitava vahemaa
        public double ArvutaVahemaa()
        {
            return Vahemaa;
        }

        public override string ToString()
        {
            return $"Elektritõukeratas - Vahemaa: {ArvutaVahemaa()} km, Kulu: {Math.Round(ArvutaKulu(), 2)}€";
        }
    }
}