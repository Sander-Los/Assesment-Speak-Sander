using System;
using System.Collections.Generic;



namespace WinkelWagen
{
    /// <summary>
    /// Representatie van een winkelwagen met lineItems die Tours bevatten.
    /// </summary>
    public class WinkelWagen
    {
        private List<Tour> lineItems = new List<Tour>();

        /// <summary>
        /// Voegt de tour toe aan de winkelwagen
        /// </summary>
        /// <param name="tour">De toe te voegen tour.</param>
        public void AddTour(Tour tour)
        {
            lineItems.Add(tour);
        }
        /// <summary>
        /// Berekent de totaalprijs, rekening houdend met kortingen.
        /// </summary>
        /// <returns>
        /// string representatie van de winkelwagen met de totaalprijs.
        /// </returns>
        internal string BerekenPrijs()
        {
            string result = "";
            int aantalTH = GetTours("TH");
            int aantalSP = GetTours("SP");
            int aantalAL = GetTours("AL");

            decimal totaalPrijs = 0;
            foreach (Tour tour in lineItems)
            {
                totaalPrijs += tour.Prijs;
            }

            // ---------------------
            // Kortingen
            // ---------------------

            // 3 voor 2 korting Abe Lenstra
            if (aantalAL >= 3)
            {
                totaalPrijs -= 300;
            }

            // Bulk korting Thialf
            if (aantalTH > 4)
            {
                totaalPrijs -= (aantalTH * 20);
            }

            // Voor iedere rondleiding Abe Lenstra stadion, gratis bezoek aan Speak.
            if (aantalSP > 0)
            {
                for (int i = 0; i < aantalSP; i++)
                {
                    // Als er meer rondleidingen over zijn dan dit bezoek aan speak, korting.
                    if (aantalAL - i >= 1)
                    {
                        totaalPrijs -= 30;
                    }
                }
            }

            result += "Rondleiding Abe Lenstra stadion, Aantal : " + aantalAL + "\n";
            result += "Middag schaatsen in Thialf, Aantal : " + aantalTH + "\n";
            result += "Bezoek Speak, Aantal : " + aantalSP + "\n";
            result += "Totaal: EUR " + Math.Round(totaalPrijs, 2);
            return result;
        }

        /// <summary>
        /// Methode om de verschillende tours te tellen.
        /// </summary>
        /// <param name="s">De gevraagde tour</param>
        /// <returns></returns>
        private int GetTours(string s)
        {
            int result = 0;
            foreach (Tour tour in lineItems)
            {
                if (tour.ID == s)
                {
                    result++;
                }
            }
            return result;
        }
    }
}
