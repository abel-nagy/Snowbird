using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace snowbird
{
    class Database
    {
        // az adatbázishoz szükséges változók létrehozása
        private string dbIp, dbPort, dbUsername, dbPassword, dbDatabase;
        private MySqlConnection dbConnection;

        public database(string dbIp, string dbPort, string dbUsername, string dbPassword, string dbDatabase)
        {
            this.dbIp = dbIp;
            this.dbPort = dbPort;
            this.dbUsername = dbUsername;
            this.dbPassword = dbPassword;
            this.dbDatabase = dbDatabase;
        }

        
        private bool ConnectDb()
        {
            
            string MySqlConnectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=snowbird";
            //string MySqlConnectionString = "datasource=" + dbIp + "port=" + dbPort + ";username=" + dbUsername + ";password=;database=" + dbDatabase;
            dbConnection = new MySqlConnection(MySqlConnectionString);

            try
            {
                dbConnection.Open();

                return true;

            }
            catch (Exception e)
            {
                Console.WriteLine("Query error: " + e.Message);
                return false;
            }
        }

        public void Users()
        {
            string query = "SELECT * FROM users;";

            if (this.ConnectDb() == true)
            {
                MySqlCommand commandDb = new MySqlCommand(query, dbConnection);
                commandDb.CommandTimeout = 60;
                MySqlDataReader myReader = commandDb.ExecuteReader();

                if (myReader.HasRows)
                {
                    Console.WriteLine("Itt vannak a faszom adatok");
                    while (myReader.Read())
                    {
                        Console.WriteLine(myReader.GetString(0) + "   " + myReader.GetString(1) + "   " + myReader.GetString(2) + "   " + myReader.GetString(3) + "   " + myReader.GetString(4));
                    }
                }
                else
                {
                    Console.WriteLine("Query succesfully executed");
                }
            }
            else
            {
                Console.WriteLine("Rossz a kapcsolat");
            }
        }
        
        public void Registration()
        {

        }
        
    }
}
