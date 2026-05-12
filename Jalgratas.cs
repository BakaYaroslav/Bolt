using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Bolt
{
    public class Jalgratas : ISõiduk
    {
        
        public double Vahemaa { get; set; }

        
        public Jalgratas(double vahemaa)
        {
            Vahemaa = vahemaa;
        }

        public double ArvutaKulu()
        {
            return 0;
        }

        public double ArvutaVahemaa()
        {
            return Vahemaa;
        }
        public override string ToString()
        {
            return $"Jalgratas - Vahemaa: {ArvutaVahemaa()} km, Kulu: {ArvutaKulu()}€";
        }
    }
}
