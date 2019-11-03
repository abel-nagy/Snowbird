using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Mail;

namespace SnowbirdWallet
{

    class Jelszovissza : Kepernyok   
    { 
        private string e;
        public Jelszovissza() : base("Jelszó visszaállítás", "Snowbird Wallet v1.0")
        {
            Console.Clear();
            Console.BackgroundColor = ConsoleColor.Cyan;
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine(s1.PadRight(Console.WindowWidth));
            Console.WriteLine(s2.PadLeft(Console.WindowWidth));
        }
        public override void Funkciok()
        {
            //if (){ ellenoriznie kell, hogy az adatbazisban megtalalhato e
            Console.WriteLine("Kérem adja meg az email címét");
                e = Console.ReadLine();
            //}
        }
        public void EmailEll()
        {
            Console.WriteLine("Megerősítő kód küldése a következő email címre: {0}", e);

            string[] emszerv = e.Split('@');
            Random rnd = new Random();
            int megekod = rnd.Next(1, 10000);
            Console.WriteLine("{0}", megekod);


            /* try
             {

                 MailMessage level = new MailMessage();
                 SmtpClient SmtpServer = new SmtpClient("smtp.emszerv[emszerv.Length-1]");

                 level.From = new MailAddress("xy@gmail.com");
                 level.To.Add(e);
                 level.Subject = "Megerősítő Kód";
                 level.Body =  string.Format("Kérem erősítse meg a jelszóváltást. Az ön kódja {0}", megekod);

                 SmtpServer.Port = 587;
                 SmtpServer.Credentials = new System.Net.NetworkCredential("xy", "xy");
                 SmtpServer.EnableSsl = true;

                 SmtpServer.Send(level);
                 Console.WriteLine("Email küldése");
             }
             catch (Exception kivetel)
             {
                 Console.WriteLine(kivetel.ToString());
             }*/

            int szam;
            do
            {
                Console.WriteLine("Kérem a kódot");
                szam = int.Parse(Console.ReadLine());
            } while (szam != megekod);

            // beírás az adatbázisba;

            Console.WriteLine("Jelszó:");
            string fjelsz = Console.ReadLine();
            // beírás az adatbázisba
            Console.WriteLine("Sikeres jelszó váltás");
            
        }
    }
}
