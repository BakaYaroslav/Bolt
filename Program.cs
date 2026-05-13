using System.Globalization;
namespace Bolt
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            System.Threading.Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

            List<ISõiduk> sõidukid = new List<ISõiduk>();
            Console.WriteLine("--- Sõidukite haldussüsteem ---");

            // Loo txt fail kui seda pole
            string failTee = "soidukid.txt";
            if (File.Exists(failTee))
            {
                string[] read = File.ReadAllLines(failTee);
                foreach (string rida in read)
                {
                    string[] osad = rida.Split(';');
                    try
                    {
                        switch (osad[0].ToLower())
                        {
                            case "auto":
                                sõidukid.Add(new Auto(double.Parse(osad[2]), double.Parse(osad[3]), double.Parse(osad[1])));
                                break;
                            case "jalgratas":
                                sõidukid.Add(new Jalgratas(double.Parse(osad[1])));
                                break;
                            case "buss":
                                sõidukid.Add(new Buss(double.Parse(osad[2]), double.Parse(osad[3]), double.Parse(osad[1]), int.Parse(osad[4])));
                                break;
                        }
                        Console.WriteLine($"Loetud failist: {osad[0]}");
                    }
                    catch
                    {
                        Console.WriteLine($"Vigane rida: {rida}");
                    }
                }
            }

            while (true)
            {
                try
                {
                    Console.WriteLine("\nVali sõiduki tüüp: 1 - Auto, 2 - Jalgratas, 3 - Buss, 4 - Elektritõukeratas, 5 - Mootorratas, 0 - Lõpeta");
                    string valik = Console.ReadLine();
                    if (valik == "0") break;

                    switch (valik)
                    {
                        case "1":
                            Console.Write("Sisesta paagi maht (L): ");
                            double autoTank = double.Parse(Console.ReadLine());
                            Console.Write("Sisesta kütusekulu (L/100km): ");
                            double autoKulu = double.Parse(Console.ReadLine());
                            Console.Write("Sisesta kütusehind (€/L): ");
                            double autoHind = double.Parse(Console.ReadLine());
                            sõidukid.Add(new Auto(autoKulu, autoHind, autoTank));
                            break;

                        case "2":
                            Console.Write("Sisesta läbitud vahemaa (km): ");
                            double ratasKm = double.Parse(Console.ReadLine());
                            sõidukid.Add(new Jalgratas(ratasKm));
                            break;

                        case "3":
                            Console.Write("Sisesta paagi maht (L): ");
                            double bussTank = double.Parse(Console.ReadLine());
                            Console.Write("Sisesta kütusekulu (L/100km): ");
                            double bussKulu = double.Parse(Console.ReadLine());
                            Console.Write("Sisesta kütusehind (€/L): ");
                            double bussHind = double.Parse(Console.ReadLine());
                            Console.Write("Sisesta reisijate arv: ");
                            int reisijad = int.Parse(Console.ReadLine());
                            sõidukid.Add(new Buss(bussKulu, bussHind, bussTank, reisijad));
                            break;

                        case "4":
                            Console.Write("Sisesta vahemaa (km): ");
                            double tõukeVahemaa = double.Parse(Console.ReadLine());
                            Console.Write("Sisesta energiakulu (kWh/100km): ");
                            double tõukeKulu = double.Parse(Console.ReadLine());
                            sõidukid.Add(new Elektritõukeratas(tõukeVahemaa, tõukeKulu));
                            break;

                        case "5":
                            Console.Write("Sisesta paagi maht (L): ");
                            double motoTank = double.Parse(Console.ReadLine());
                            Console.Write("Sisesta kütusekulu (L/100km): ");
                            double motoKulu = double.Parse(Console.ReadLine());
                            Console.Write("Sisesta kütusehind (€/L): ");
                            double motoHind = double.Parse(Console.ReadLine());
                            sõidukid.Add(new Mootorratas(motoKulu, motoHind, motoTank));
                            break;

                        default:
                            Console.WriteLine("Vale valik, proovi uuesti.");
                            continue;
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Viga: Palun sisesta ainult numbreid!");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Tekkis ootamatu viga: {ex.Message}");
                }
            }

            Console.WriteLine("\n--- TULEMUSED ---");
            double kokkuKulu = 0;
            foreach (ISõiduk s in sõidukid)
            {
                Console.WriteLine(s.ToString());
                kokkuKulu += s.ArvutaKulu();
            }
            Console.WriteLine("-------------------------");
            Console.WriteLine($"Kogu kulu kõikide sõidukite peale: {Math.Round(kokkuKulu, 2)}€");

            // Salvesta tulemused txt faili
            using (StreamWriter sw = new StreamWriter(failTee))
            {
                foreach (ISõiduk s in sõidukid)
                {
                    sw.WriteLine(s.ToString());
                }
            }
            Console.WriteLine($"Salvestatud faili: {failTee}");

            Console.WriteLine("\nProgrammi lõpetamiseks vajuta suvalist klahvi...");
            Console.ReadKey();
        }
    }
}