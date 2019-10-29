using System;

namespace SnowbirdWallet
{
    class Program
    {
        static void Main(string[] args)
        {
            string programnev = "Snowbird Wallet v1.0".PadLeft(Console.WindowWidth);
            Console.WriteLine(programnev);


            Console.WriteLine("Önnek már van felhasználói fiókja(i/n)?");
            char a = char.Parse(Console.ReadLine());
            if (a == 'i')
            {
                Belepes belepes = new Belepes();
                belepes.Funkciok();
                Muveletek muveletek = new Muveletek();
                muveletek.Funkciok();


            }
            else if (a == 'n')
            {

                Regisztracio regisztracio = new Regisztracio();
                regisztracio.Funkciok();
            }

            Console.ReadKey();
            Console.ResetColor();
        }
    }
}
