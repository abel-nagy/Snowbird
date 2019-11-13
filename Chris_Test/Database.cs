using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;


namespace snowbird
{
    class Database
    {
        private string dbIp, dbPort, dbUsern, dbPassw, dbDatabase;
        private MySqlConnection dbConnect;


        public Database(string dbIp, string dbPort, string dbUsern, string dbPassw, string dbDatabase)
        {
            this.dbIp = dbIp;
            this.dbPort = dbPort;
            this.dbUsern = dbUsern;
            this.dbPassw = dbPassw;
            this.dbDatabase = dbDatabase;
        }

        private bool ConnectDB()
        {
            string MySqlConnectionString = "datasource=127.0.0.0;port3306;username=root;password=;database=snowbird";
            dbConnect = new MySqlConnection(MySqlConnectionString);

            try
            {
                dbConnect.Open();
                return true;
            }
            catch (Exception m)
            {
                Console.WriteLine("Database connect error: " + m.Message);
                return false;
            }
        }
        public void Wallets()
        {
            string query = "SELECT * FROM wallets;";

            if (this.ConnectDB() == true)
            {
                MySqlCommand commandDb = new MySqlCommand(query, dbConnect);
                commandDb.CommandTimeout = 60;
                MySqlDataReader myReader = commandDb.ExecuteReader();

                if (myReader.HasRows)
                {
                    Console.WriteLine("*/t Wallets table data /t*");
                    while (myReader.Read())
                    {
                        Console.WriteLine(myReader.GetString(0) + "\n " + myReader.GetString(1));
                    }
                }
                else
                {
                    Console.WriteLine("Query successfully executed");
                }
            }
        }
        public void AddToDatabase(string username, int type, int amount, string currency, string account_name, string account_number, string description)
        {
            int userid = 0;
            DateTime myDateTime = DateTime.Now;
            string sqlFormattedDate = myDateTime.ToString("yyyy-mm-dd HH:mm:ss");



            string useridquery = "SELECT user_id from users INNER JOIN wallets on users.id = wallets.user_id where username = " + username + ";";

            if (this.ConnectDB() == true)
            {
                MySqlCommand commandDb = new MySqlCommand(useridquery, dbConnect);
                commandDb.CommandTimeout = 60;
                MySqlDataReader myReader = commandDb.ExecuteReader();

                if (myReader.HasRows)
                {
                    Console.WriteLine("Az ön felhasználóneve");
                    while (myReader.Read())
                    {
                        Console.WriteLine(myReader.GetInt32(0));
                        userid = myReader.GetInt32(0);
                    }
                }

            }

            string query = "INSERT INTO `wallets` (`wallet_id`,`user_id`, `type`, `amount`, `currency`, `account_name`, `account_number`, `description`, `created_at`)" +
                " VALUES(NULL, '" + userid + "', '" + type + "', '" + amount + "', '" + currency + "', '" + account_name + "', '" + account_number + "', '" + description + "'" +
                ", '" + sqlFormattedDate + "'";
            if (this.ConnectDB() == true)
            {
                MySqlCommand commandDb = new MySqlCommand(query, dbConnect);
                commandDb.CommandTimeout = 60;
                MySqlDataReader myReader = commandDb.ExecuteReader();
            }
        }
    }
}