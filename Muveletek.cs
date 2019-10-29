using System;
using System.Collections.Generic;
using System.Text;

namespace SnowbirdWallet
{
    class Muveletek : Kepernyok
    {
        public Muveletek() : base("Felhasználói profil", "Snowbird Wallet v1.0")
        {
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.DarkRed;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine(s1.PadRight(Console.WindowWidth));
            Console.WriteLine(s2.PadLeft(Console.WindowWidth));

        }
        public override void Funkciok()
        {
            Console.WriteLine("Pénztárcák");
            //listázás  
            Console.WriteLine("1-Tranzakció".PadLeft(Console.WindowWidth));
            Console.WriteLine("2-Biztonsági mentés".PadLeft(Console.WindowWidth));
            Console.WriteLine("3-Pénztárca kiválasztása".PadLeft(Console.WindowWidth));
            Console.WriteLine("4-Kilépés".PadLeft(Console.WindowWidth));


           bool i = true;
            while(i == true)
                {
                switch(int.Parse(Console.ReadLine()))
                {
                    case (1): Console.WriteLine("Tranzakció");
                        Console.WriteLine("Kérem adja meg az adatait");
                        string adatok = Console.ReadLine();
                        Console.WriteLine("Kérem adja meg a kedvezményezett adatait");
                        string kadatok = Console.ReadLine();
                        break;
                    case (2): Console.WriteLine("Biztonsági mentés");

                        break;
                    case (3): Console.WriteLine("Kérem írja be a pénztárca nevét");
                        string pnev = Console.ReadLine();
                        Console.WriteLine(pnev);
                        Console.WriteLine("Havi adatok \t Összesítés");
                        break;
                    case (4): i = false;
                        Console.WriteLine("A program bezár.");
                        break;
                }


              

             
            }


        }
  
    }
}
