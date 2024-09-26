using System;
using System.Collections.Generic;
using System.IO;

namespace Inlämning2LTU
{
    public static class Output
    {
        public static void SkrivUtResultat(List<Säljare> säljareLista, Dictionary<string, int> nivåer)
        {
            // Sortera säljarna efter antal sålda artiklar i stigande ordning (minst först)
            säljareLista.Sort((s1, s2) => s1.AntalSåldaArtiklar.CompareTo(s2.AntalSåldaArtiklar));

            // Dictionary för att hålla koll på säljare per nivå och deras artikelbeskrivning
            Dictionary<int, (List<Säljare>, string)> säljarePerNivå = new Dictionary<int, (List<Säljare>, string)>
            {
                { 1, (new List<Säljare>(), "Under 50 artiklar") },
                { 2, (new List<Säljare>(), "50-99 artiklar") },
                { 3, (new List<Säljare>(), "100-199 artiklar") },
                { 4, (new List<Säljare>(), "Över 199 artiklar") }
            };

            // Gruppera säljarna efter nivå
            foreach (var säljare in säljareLista)
            {
                if (säljare.AntalSåldaArtiklar < 50)
                {
                    säljarePerNivå[1].Item1.Add(säljare);  // Nivå 1
                }
                else if (säljare.AntalSåldaArtiklar < 100)
                {
                    säljarePerNivå[2].Item1.Add(säljare);  // Nivå 2
                }
                else if (säljare.AntalSåldaArtiklar < 200)
                {
                    säljarePerNivå[3].Item1.Add(säljare);  // Nivå 3
                }
                else
                {
                    säljarePerNivå[4].Item1.Add(säljare);  // Nivå 4
                }
            }

            // Skriv ut rubrikerna med justeringar
            Console.WriteLine("{0,-20} {1,-15} {2,-15} {3,-10}", "Namn", "Persnr", "Distrikt", "Antal");

            // Skriv ut säljarna i sorterad ordning, nivå för nivå
            foreach (var nivå in säljarePerNivå)
            {
                if (nivå.Value.Item1.Count > 0)
                {
                    foreach (var säljareItem in nivå.Value.Item1)
                    {
                        // Skriv ut varje säljare i den aktuella nivån med justeringar
                        Console.WriteLine("{0,-20} {1,-15} {2,-15} {3,-10}", säljareItem.Namn, säljareItem.Personnummer, säljareItem.Distrikt, säljareItem.AntalSåldaArtiklar);
                    }

                    // Skriv ut sammanfattningen för nivån
                    Console.WriteLine($"{nivå.Value.Item1.Count} säljare har nått nivå {nivå.Key}: {nivå.Value.Item2}");
                }
            }

            // Skriv resultat till fil
            using (StreamWriter sw = new StreamWriter("resultat.txt"))
            {
                sw.WriteLine("{0,-20} {1,-15} {2,-15} {3,-10}", "Namn", "Persnr", "Distrikt", "Antal");

                foreach (var nivå in säljarePerNivå)
                {
                    if (nivå.Value.Item1.Count > 0)
                    {
                        foreach (var säljareItem in nivå.Value.Item1)
                        {
                            // Skriv varje säljare till filen med justeringar
                            sw.WriteLine("{0,-20} {1,-15} {2,-15} {3,-10}", säljareItem.Namn, säljareItem.Personnummer, säljareItem.Distrikt, säljareItem.AntalSåldaArtiklar);
                        }

                        // Skriv sammanfattning till filen
                        sw.WriteLine($"{nivå.Value.Item1.Count} säljare har nått nivå {nivå.Key}: {nivå.Value.Item2}");
                    }
                }
            }
        }
    }
}

