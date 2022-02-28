using System;
using System.Collections.Generic;

namespace Kaartspel
{
    internal class Oorlog : Ronde
    {
        private Kaart<int> faceUpKaartSpeler1;
        private List<Kaart<int>> faceDownKaartenLijstSpeler1;
        private Kaart<int> faceUpKaartSpeler2;
        private List<Kaart<int>> faceDownKaartenLijstSpeler2;

        public Oorlog(Kaart<int> faceUpKaartSpeler1, List<Kaart<int>> faceDownKaartenLijstSpeler1, Kaart<int> faceUpKaartSpeler2, List<Kaart<int>> faceDownKaartenLijstSpeler2)
        {
            this.faceUpKaartSpeler1 = faceUpKaartSpeler1;
            this.faceDownKaartenLijstSpeler1 = faceDownKaartenLijstSpeler1;
            this.faceUpKaartSpeler2 = faceUpKaartSpeler2;
            this.faceDownKaartenLijstSpeler2 = faceDownKaartenLijstSpeler2;
        }

        public override List<Kaart<int>> VerdeelKaarten(int winnaar)
        {
            List<Kaart<int>> result = new List<Kaart<int>>();

            return result;
        }

        public override int VoerUit()
        {
            int result;
            Console.WriteLine("De spelers hebben de volgende face up kaarten in deze oorlog:");
            Console.WriteLine("Speler 1 heeft: " + faceUpKaartSpeler1.Waarde);
            Console.WriteLine("Speler 2 heeft: " + faceUpKaartSpeler2.Waarde);

            if (faceUpKaartSpeler1.Waarde.CompareTo(faceUpKaartSpeler2.Waarde) == 0)
            {
                Console.WriteLine("De kaarten zijn gelijk! Een oorlog volgt!\n");
                result = 0;
            }
            else if (faceUpKaartSpeler1.Waarde.CompareTo(faceUpKaartSpeler2.Waarde) > 0)
            {
                Console.WriteLine("Speler 1 wint deze oorlog!\n");
                result = 1;
            }
            else
            {
                Console.WriteLine("Speler 2 wint deze oorlog!\n");
                result = 2;
            }

            return result;
        }
    }
}