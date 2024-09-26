using System;
using System.Collections.Generic;
using System.Linq;

namespace Inlämning2LTU
{
    public static class Input
    {
        public static List<Säljare> LäsInSäljare()
        {
            List<Säljare> säljareLista = new List<Säljare>();

            // Validering för antal säljare
            int antalSäljare = 0;
            bool korrektAntalSäljare = false;
            while (!korrektAntalSäljare)
            {
                Console.Write("Hur många säljare vill du registrera? ");
                string? input = Console.ReadLine();

                if (!string.IsNullOrEmpty(input) && int.TryParse(input, out antalSäljare) && antalSäljare > 0)
                {
                    korrektAntalSäljare = true;
                }
                else
                {
                    Console.WriteLine("Fel: Ange ett giltigt positivt heltal för antal säljare.");
                }
            }

            for (int i = 0; i < antalSäljare; i++)
            {
                Säljare säljare = new Säljare();

                // Namn
                Console.Write("Namn: ");
                säljare.Namn = Console.ReadLine() ?? string.Empty;

                // Validering för personnummer
                bool korrektPersonnummer = false;
                while (!korrektPersonnummer)
                {
                    Console.Write("Personnummer (12 siffror): ");
                    string? personnummerInput = Console.ReadLine();

                    if (!string.IsNullOrEmpty(personnummerInput) && personnummerInput.Length == 12 && personnummerInput.All(char.IsDigit))
                    {
                        säljare.Personnummer = personnummerInput;
                        korrektPersonnummer = true;
                    }
                    else
                    {
                        Console.WriteLine("Fel: Personnumret måste bestå av exakt 12 siffror utan bindestreck. Försök igen.");
                    }
                }

                // Distrikt
                Console.Write("Distrikt: ");
                säljare.Distrikt = Console.ReadLine() ?? string.Empty;

                // Validering för antal sålda artiklar
                bool korrektAntalArtiklar = false;
                while (!korrektAntalArtiklar)
                {
                    Console.Write("Antal sålda artiklar: ");
                    string? artikelInput = Console.ReadLine();

                    if (!string.IsNullOrEmpty(artikelInput) && int.TryParse(artikelInput, out int antalArtiklar) && antalArtiklar >= 0)
                    {
                        säljare.AntalSåldaArtiklar = antalArtiklar;
                        korrektAntalArtiklar = true;
                    }
                    else
                    {
                        Console.WriteLine("Fel: Ange ett giltigt heltal för antal sålda artiklar.");
                    }
                }

                säljareLista.Add(säljare);

                // Lägg till en blank rad efter att en säljare har lagts till
                Console.WriteLine();
            }

            return säljareLista;
        }
    }
}
