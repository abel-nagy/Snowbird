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

            Database db = new Database("127.0.0.1", "3306", "root", "", "snowbird"); //ezek még nem működnek

            Console.WriteLine("###  HÁZIPÉNZTÁR  ###\n");
            Console.WriteLine("Regiszráció = 1");
            Console.WriteLine("Users lekérdezése = 2");



            Console.ReadKey();
        }
    }
}

