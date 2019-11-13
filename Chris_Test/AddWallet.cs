using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;


namespace snowbird
    {
        class AddWallet
        {
            private int typ, am;
            private string uname, cur, acname, description, accnum;


            public bool Checknum(string a)
            {

                foreach (char c in a)
                {
                    if (c < '0' || c > '9')
                    {
                        return false;
                    }
                }
                return true;
            }
            public void Questions()
            {
                Console.WriteLine("Please type your username:");
                uname = Console.ReadLine();


                Console.WriteLine("Please type the wallet's type:");
                typ = int.Parse(Console.ReadLine());

                do
                {
                    Console.WriteLine("Please type the wallet's currency (maximum 3 character):");
                    cur = Console.ReadLine();
                } while (cur.Length > 3 || cur.Length < 1);
                do
                {
                    Console.WriteLine("Please type wallet's description (maximum 20 character), if you don't want to type acoount name press n and after press enter:");
                    description = Console.ReadLine();
                } while (description.Length > 20 || description != "n");

                do
                {
                    Console.WriteLine("Please type wallet's account name (maximum 30 character), if you don't want to type acoount name press n and after press enter:");
                    acname = Console.ReadLine();
                } while (acname.Length > 30 || acname != "n");
                do
                {

                    Console.WriteLine("Please type wallet's account number (exactly 24 number), if you don't want to type acoount name press n and after press enter:");
                    accnum = Console.ReadLine();

                } while ((accnum.Length != 24 || Checknum(accnum) != true) && accnum != "n");
                Console.WriteLine("Please type wallet's amount:");
                am = int.Parse(Console.ReadLine());

            }
        }
    }
