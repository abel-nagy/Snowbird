using System;
using System.Collections.Generic;
using System.Text;

namespace SnowbirdWallet
{
    class Regisztracio : Kepernyok
    {
        public Regisztracio() : base("Regisztráció", "Snowbird Wallet v1.0")
        {
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.Red;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine(s1.PadRight(Console.WindowWidth));
            Console.WriteLine(s2.PadLeft(Console.WindowWidth));
        }
        public override void Funkciok()
        {
            Console.WriteLine("Adja meg a nevét a regisztrációhoz:");
            string nev = Console.ReadLine();
            Console.WriteLine("Adja meg a jelszavát a regisztrációhoz:");
            string jelszo = Console.ReadLine();
            Console.ResetColor();
            Console.ReadKey();
        }
    }
}
