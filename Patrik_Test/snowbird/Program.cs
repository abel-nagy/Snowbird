using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Security.Cryptography;

namespace snowbird
{
    class Program
    {
        static void Main(string[] args)
        {
            
            menuClass DB = new menuClass();
            DB.mainMenu();
            
            int choose;
            do
            {
                Console.Write("Választ: "); choose = Int32.Parse(Console.ReadLine());
                switch (choose)
                {
                    case 1:
                        DB.registrationMenu();
                        break;
                    case 2:
                        DB.usersMenu();
                        break;
                    case 9:
                        DB.mainMenu();
                        break;
                }
            }
            while (choose != 0);

            Console.ReadKey();
        }
    }
}

