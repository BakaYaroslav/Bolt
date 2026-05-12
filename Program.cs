using System.Globalization;

namespace Bolt
{
    class Program
        {
            static void Main(string[] args)
            {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            // Edasine kood...
            System.Threading.Thread.CurrentThread.CurrentCulture = System.Globalization.CultureInfo.InvariantCulture;
           

                List<ISõiduk> sõidukid = new List<ISõiduk>();
                bool lisaVeel = true;

                Console.WriteLine("--- Sõidukite haldussüsteem ---");

                while (lisaVeel)
                {
                    try
                    {
                        Console.WriteLine("\nVali sõiduki tüüp: 1 - Auto, 2 - Jalgratas, 3 - Buss, 0 - Lõpeta");
                        string valik = Console.ReadLine();

                        if (valik == "0") break;

                        switch (valik)
                        {
                            case "1":
                                Console.Write("Sisesta läbitud vahemaa (km): ");
                                double autoKm = double.Parse(Console.ReadLine());
                                Console.Write("Sisesta kütusekulu (L/100km): ");
                                double autoKulu = double.Parse(Console.ReadLine());
                                Console.Write("Sisesta kütusehind (€/L): ");
                                double autoHind = double.Parse(Console.ReadLine());

                                sõidukid.Add(new Auto(autoKulu, autoHind));
                                break;

                            case "2":
                                Console.Write("Sisesta läbitud vahemaa (km): ");
                                double ratasKm = double.Parse(Console.ReadLine());

                                sõidukid.Add(new Jalgratas(ratasKm));
                                break;

                            case "3":
                                Console.Write("Sisesta läbitud vahemaa (km): ");
                                double bussKm = double.Parse(Console.ReadLine());
                                Console.Write("Sisesta bussi kütusekulu (L/100km): ");
                                double bussKulu = double.Parse(Console.ReadLine());
                                Console.Write("Sisesta kütusehind (€/L): ");
                                double bussHind = double.Parse(Console.ReadLine());
                                Console.Write("Sisesta reisijate arv: ");
                                int reisijad = int.Parse(Console.ReadLine());

                                sõidukid.Add(new Buss(bussKulu, bussHind, reisijad));
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

                Console.WriteLine("\nProgrammi lõpetamiseks vajuta suvalist klahvi...");
                Console.ReadKey();
            }
        }
    }
