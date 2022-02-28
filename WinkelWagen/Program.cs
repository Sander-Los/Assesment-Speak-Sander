using System;


namespace WinkelWagen
{
    internal class Program
    {

        static void Main(string[] args)
        {
            // Init Mapper & Winkelwagen
            Mapper db = new Mapper();
            WinkelWagen ww = new WinkelWagen();

            Console.WriteLine("Welkom bij tours in Heerenveen, Voer hieronder uw bestelling in: ");
            string[] input = Console.ReadLine().Split();

            foreach (string s in input)
            {
                ww.AddTour(db.getTour(s));
            }

            Console.WriteLine(ww.BerekenPrijs());

            Console.WriteLine("\nPress any key to Exit");
            Console.ReadKey();

        }
    }
}
