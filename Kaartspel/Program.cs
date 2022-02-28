using System;
using System.Collections.Generic;

// @author Sander Los
// Kaartspel ter behoeve van Assesment bij Internetbureau Speak.

namespace Kaartspel
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var speler1Kaarten = new List<Kaart<int>>();
            var speler2Kaarten = new List<Kaart<int>>();

            // Input voor de decks krijgen en deze toevoegen aan de spelers. .
            // mogelijk uitbreiding: checken of input alleen maar integers zijn.
            // Er wordt niet uitgegaan van niet lege inputs. Dit is uit te breiden.
            Console.WriteLine("Noteer/Plak de kaarten van de speler 1: ");
            int[] speler1KaartenInput = Array.ConvertAll(Console.ReadLine().Split(" "), int.Parse);

            foreach (int waarde in speler1KaartenInput)
            {
                speler1Kaarten.Add(new Kaart<int>(waarde));
            }

            Console.WriteLine("Noteer/Plak de kaarten van de speler 2: ");
            int[] speler2KaartenInput = Array.ConvertAll(Console.ReadLine().Split(" "), int.Parse);

            foreach (int waarde in speler2KaartenInput)
            {
                speler2Kaarten.Add(new Kaart<int>(waarde));
            }

            // Gameloop
            bool spelAfgelopen = false;
            while (!spelAfgelopen)
            {

                // Spelronde
                List<Ronde> spelronde = new List<Ronde>();
                bool spelrondeAfgelopen = false;
                int winnaar = -1;
                while (!spelrondeAfgelopen)
                {
                    int rondeWinnaar = -1;
                    // Alleen het eerste item kan een gevecht zijn, eventuele overige rondes zijn oorlogen
                    if (spelronde.Count == 0)
                    {
                        Console.WriteLine("Een nieuwe speelronde is begonnen!");
                        Ronde gevecht = new Gevecht(speler1Kaarten[0], speler2Kaarten[0]);
                        spelronde.Add(gevecht);
                        speler1Kaarten.RemoveAt(0);
                        speler2Kaarten.RemoveAt(0);

                        rondeWinnaar = gevecht.VoerUit();
                        if (rondeWinnaar == 1 || rondeWinnaar == 2)
                        {
                            spelrondeAfgelopen = true;
                        }
                        else
                        {
                            Console.WriteLine("De kaarten zijn gelijk! Een oorlog volgt!\n");
                        }

                    }
                    // De vorige ronde is geëindigd in gelijkspel. Er is sprake van een oorlog
                    else
                    {
                        int faceDownKaarten = 3;
                        // Check of er genoeg kaarten zijn. Als er niet genoeg zijn, 
                        if (speler1Kaarten.Count < 4 || speler2Kaarten.Count < 4)
                        {
                            faceDownKaarten = Math.Min(speler1Kaarten.Count, speler2Kaarten.Count) - 1;
                        }

                        List<Kaart<int>> faceDownKaartenLijstSpeler1 = new List<Kaart<int>>();
                        List<Kaart<int>> faceDownKaartenLijstSpeler2 = new List<Kaart<int>>();

                        //Als er 0 faceDownKaarten zijn, hoeft de loop niet doorlopen te worden.
                        if (faceDownKaarten != 0)
                        {
                            for (int i = 0; i < faceDownKaarten; i++)
                            {
                                faceDownKaartenLijstSpeler1.Add(speler1Kaarten[0]);
                                speler1Kaarten.RemoveAt(0);
                                faceDownKaartenLijstSpeler2.Add(speler2Kaarten[0]);
                                speler2Kaarten.RemoveAt(0);
                            }
                        }

                        Kaart<int> faceUpKaartSpeler1 = speler1Kaarten[0];
                        speler1Kaarten.RemoveAt(0);
                        Kaart<int> faceUpKaartSpeler2 = speler2Kaarten[0];
                        speler2Kaarten.RemoveAt(0);

                        Ronde oorlog = new Oorlog(faceUpKaartSpeler1, faceDownKaartenLijstSpeler1, faceUpKaartSpeler2, faceDownKaartenLijstSpeler2);
                        spelronde.Add(oorlog);
                        rondeWinnaar = oorlog.VoerUit();
                    }

                    // Als er een rondewinnaar is, voeg de kaarten van de verschillende rondes toe aan de kaarten van de winnaar.
                    if (rondeWinnaar > 0 && rondeWinnaar < 3)
                    {
                        List<Kaart<int>> gewonnenKaarten = new List<Kaart<int>>();
                        while (spelronde.Count > 0)
                        {
                            gewonnenKaarten.AddRange(spelronde[spelronde.Count - 1].VerdeelKaarten(rondeWinnaar));
                            spelronde.RemoveAt(spelronde.Count - 1);
                        }
                        if (rondeWinnaar == 1)
                        {
                            speler1Kaarten.AddRange(gewonnenKaarten);
                        }
                        if (rondeWinnaar == 2)
                        {
                            speler2Kaarten.AddRange(gewonnenKaarten);
                        }
                    }

                    // Check of er een speler is (of beide) die geen kaarten meer heeft. De ronde en het spel zijn dan afgelopen.
                    if (speler1Kaarten.Count == 0 && speler2Kaarten.Count == 0)
                    {
                        winnaar = 0;
                        spelrondeAfgelopen = true;
                    }
                    else if (speler1Kaarten.Count == 0)
                    {
                        winnaar = 2;
                        spelrondeAfgelopen = true;
                    }
                    else if (speler2Kaarten.Count == 0)
                    {
                        winnaar = 1;
                        spelrondeAfgelopen = true;
                    }
                    else { }
                }
                // spelronde is voorbij. Er wordt gekeken of er speler is die geen kaarten meer heeft.
                // Als dit zo is, wordt bekeken of er een winnaar is.
                if (winnaar != -1)
                {
                    spelAfgelopen = true;
                    if (winnaar == 1)
                    {
                        Console.WriteLine("Speler 1 heeft gewonnen");
                    }
                    else if (winnaar == 2)
                    {
                        Console.WriteLine("Speler 2 heeft gewonnen");
                    }
                    else if (winnaar == 0)
                    {
                        Console.WriteLine("Gelijkspel");
                    }
                }
            }
        }
    }
}
