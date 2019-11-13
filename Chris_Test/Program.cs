using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;


namespace snowbird
{
    class Program{
        static void Main(string[] args)
        {
           AddWallet wallet = new AddWallet();
           wallet.Questions();
        }
    }
}
