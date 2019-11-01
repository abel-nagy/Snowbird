using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using MySql.Data.MySqlClient;

namespace snowbird
{
    class Database
    {
        // az adatbázishoz szükséges változók létrehozása
        private string dbIp, dbPort, dbUsername, dbPassword, dbDatabase;
        private MySqlConnection dbConnection;

        public Database(string dbIp, string dbPort, string dbUsername, string dbPassword, string dbDatabase)
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


        //Users tábla lekérdezése ( az idő és dátum rossz vmi-ért)
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
                        Console.WriteLine(myReader.GetString(0) + "   " + myReader.GetString(1) + "   " + myReader.GetString(2) + "   " + myReader.GetString(3));
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

        //jelszó titkosítása MD5-el
        public static string passwordMD5(string text)
        {
            MD5 md5 = new MD5CryptoServiceProvider();

            //compute hash from the bytes of text  
            md5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(text));

            //get hash result after compute it  
            byte[] result = md5.Hash;

            StringBuilder strBuilder = new StringBuilder();
            for (int i = 0; i < result.Length; i++)
            {
                //change it into 2 hexadecimal digits  
                //for each byte  
                strBuilder.Append(result[i].ToString("x2"));
            }
            return strBuilder.ToString();
        }


        //regisztráció
        public void Registration(string email, string username, string password)
        {
            //aktuális dátum és idő
            DateTime myDateTime = DateTime.Now;
            string sqlFormattedDate = myDateTime.ToString("yyyy-MM-dd HH:mm:ss");

            string query = "INSERT INTO `users` (`user_id`, `email`, `username`, `password`, `created_at`) VALUES(NULL, '" + email + "', '" + username + "', '" + passwordMD5(password) + "', '" + sqlFormattedDate + "');";
            if (this.ConnectDb() == true)
            {
                MySqlCommand commandDb = new MySqlCommand(query, dbConnection);
                commandDb.CommandTimeout = 60;
                MySqlDataReader myReader = commandDb.ExecuteReader();
            }
            else
            {
                Console.WriteLine("Rossz a kapcsolat");
            }
        }


    }
}

//string query = "INSERT INTO `users` (`user_id`, `email`, `username`, `password`, `created_at`) VALUES(NULL, '" + email + "', '" + username + "', '" + password + "', '2019-11-01 00:00:00');";