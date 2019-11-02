using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace snowbird
{
    class menuClass
    {
        // csatlakozás az adatbázishoz
        private Database db = new Database("127.0.0.1", "3306", "root", "", "snowbird");

        // főmenü
        public void mainMenu()
        {
            Console.Clear();
            Console.WriteLine("###   HÁZIPÉNZTÁR   ###\n");
            Console.WriteLine("Regiszráció = 1");
            Console.WriteLine("Users lekérdezése = 2");
            Console.WriteLine("\nMenu - 9\n");
            Console.WriteLine("\nKilép - 0\n");
        }

        // regisztréció menü
        public void registrationMenu()
        {
            Console.Clear();
            Console.Write("Email: ");
            string email = Console.ReadLine();
            Console.Write("Username: ");
            string username = Console.ReadLine();
            Console.Write("Password: ");
            string password = Console.ReadLine();
            db.Registration(email, username, password);
        }

        // users menü
        public void usersMenu()
        {
            Console.Clear();
            db.Users();
        }
    }
}
