using System;
using System.Collections.Generic;
using System.Text;

namespace SnowbirdWallet
{
    class Belepes : Kepernyok
    {
        public Belepes() : base("Belépés", "Snowbird Wallet v1.0")
        {
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(s1.PadRight(Console.WindowWidth));
            Console.WriteLine(s2.PadLeft(Console.WindowWidth));
        }

        public override void Funkciok()
        {
           Console.WriteLine("Adja meg a nevét a belépéshez:");
            string nev = Console.ReadLine();
            Console.WriteLine("Adja meg a jelszavát a belépéshez:");
            string jelszo = Console.ReadLine();
            Console.ResetColor();
            Console.ReadKey();


        }
    }
}
