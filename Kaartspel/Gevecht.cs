using System;
using System.Collections.Generic;

namespace Kaartspel
{
    class Gevecht : Ronde
    {
        private Kaart<int> speler1Kaart;
        private Kaart<int> speler2Kaart;
        public Gevecht(Kaart<int> speler1Kaart, Kaart<int> speler2Kaart)
        {
            this.speler1Kaart = speler1Kaart;
            this.speler2Kaart = speler2Kaart;
        }

        public override List<Kaart<int>> VerdeelKaarten(int winnaar)
        {

            List<Kaart<int>> result = new List<Kaart<int>>();
            if (winnaar == 1)
            {
                result.Add(speler1Kaart);
                result.Add(speler2Kaart);
            }
            else
            {
                result.Add(speler2Kaart);
                result.Add(speler1Kaart);
            }
            return result;
        }

        public override int VoerUit()
        {
            Console.WriteLine("Speler 1 heeft: " + speler1Kaart.Waarde);
            Console.WriteLine("Speler 2 heeft: " + speler2Kaart.Waarde);
            int result;
            if (speler1Kaart.Waarde.CompareTo(speler2Kaart.Waarde) == 0)
            {
                result = 0;
            }
            else if (speler1Kaart.Waarde.CompareTo(speler2Kaart.Waarde) > 0)
            {
                Console.WriteLine("Speler 1 wint dit gevecht!\n");
                result = 1;
            }
            else
            {
                Console.WriteLine("Speler 2 wint dit gevecht!\n");
                result = 2;
            }
            return result;
        }
    }
}
