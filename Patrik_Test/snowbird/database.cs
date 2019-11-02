using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography; // a jelszót titkosításhoz kell
using MySql.Data.MySqlClient; // az mysql adatbázishoz kell

namespace snowbird
{
    class Database
    {
        // az adatbázishoz szükséges változók létrehozása
        private string dbIp, dbPort, dbUsername, dbPassword, dbDatabase;
        private MySqlConnection dbConnection;

        // a változóknak értékadás
        //                  127.0.0.1       3306              root                              snowbird
        public Database(string dbIp, string dbPort, string dbUsername, string dbPassword, string dbDatabase)
        {
            this.dbIp = dbIp;
            this.dbPort = dbPort;
            this.dbUsername = dbUsername;
            this.dbPassword = dbPassword;
            this.dbDatabase = dbDatabase;
        }


        // csatlakozás az adatbázishoz
        private bool ConnectionDB()
        {
            string MySqlConnectionString = "datasource=127.0.0.1;port=3306;username=root;password=;database=snowbird";
            dbConnection = new MySqlConnection(MySqlConnectionString);

            try
            {
                dbConnection.Open();
                return true; // ha sikerült a csatlakozás akkor true értéked ad vissza
            }
            catch (Exception e)
            {
                Console.WriteLine("Query error: " + e.Message); // hibaüzenet
                return false; // ha nem sikerült a csatlakozás akkor false értéket ad vissza
            }
        }


        //Users tábla lekérdezése
        public void Users()
        {
            // a query váltiozóba tesszük az SQL lekérdezést
            string query = "SELECT * FROM users;";


            if (this.ConnectionDB() == true) //megnézzük hogy a ConnectionDB true értéket ad e visszia
            {
                MySqlCommand commandDb = new MySqlCommand(query, dbConnection);
                commandDb.CommandTimeout = 60;
                MySqlDataReader myReader = commandDb.ExecuteReader();

                if (myReader.HasRows)
                {
                    Console.WriteLine("###   Users tábla adatai   ###");
                    while (myReader.Read())
                    {
                        Console.WriteLine(myReader.GetString(0) + "   " + myReader.GetString(1) + "   " + myReader.GetString(2) + "   " + myReader.GetString(3)); // kiiratja az adatokat ( az idő nem jó valamiért!)
                    }
                }
                else
                {
                    Console.WriteLine("Query succesfully executed");
                }
            }
        }

        //jelszó titkosítása MD5-el
        public static string passwordMD5(string text)
        {
            MD5 md5 = new MD5CryptoServiceProvider();

            md5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(text));

            byte[] result = md5.Hash;

            StringBuilder strBuilder = new StringBuilder();
            for (int i = 0; i < result.Length; i++)
            {
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

            // a query string tipusú változóba beleirjuk a parancsot.
            // a jelszót titkosítjuk a passwordMD5-el
            string query = "INSERT INTO `users` (`user_id`, `email`, `username`, `password`, `created_at`) VALUES(NULL, '" + email + "', '" + username + "', '" + passwordMD5(password) + "', '" + sqlFormattedDate + "');";
            if (this.ConnectionDB() == true) //megnézzük hogy a ConnectionDB true értéket ad e visszia
            {
                MySqlCommand commandDb = new MySqlCommand(query, dbConnection);
                commandDb.CommandTimeout = 60;
                MySqlDataReader myReader = commandDb.ExecuteReader();
            }
        }



    }
}

//string query = "INSERT INTO `users` (`user_id`, `email`, `username`, `password`, `created_at`) VALUES(NULL, '" + email + "', '" + username + "', '" + password + "', '2019-11-01 00:00:00');";