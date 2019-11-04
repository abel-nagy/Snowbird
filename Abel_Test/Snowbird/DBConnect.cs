// Add MySql Library
using MySql.Data.MySqlClient;

using System.Collections.Generic;

namespace Snowbird {
    class DBConnect {
        private MySqlConnection connection;
        private string server, database, uid, password;

        //Constructor
        public DBConnect(string server, string database, string uid, string password) {
            Initialize(server, database, uid, password);
        }

        // Initialize values
        private void Initialize(string server, string database, string uid, string password) {
            this.server = server;
            this.database = database;
            this.uid = uid;
            this.password = password;
            
            // Valami más

            string connectionString;
            connectionString = "SERVER=" + server + ";DATABASE=" + database + ";UID=" + uid + ";PASSWORD=" + password + ";";
            connection = new MySqlConnection(connectionString);
        }


        // Open connection to database
        private bool OpenConnection() {
            try {
                connection.Open();
                return true;
            } catch (MySqlException ex) {
                //When handling errors, you can your application's response based 
                //on the error number.
                //The two most common error numbers when connecting are as follows:
                //0: Cannot connect to server.
                //1045: Invalid user name and/or password.

                switch(ex.Number) {
                    case 0:
                        ResponseHandler.Out_Message("Cannot connect to server. Contact administrator!");
                        break;
                    case 1045:
                        ResponseHandler.Out_Message("Invalid username/password, please try again!");
                        break;
                    default:
                        ResponseHandler.Out_Message("We have no idea what happened. Please stay tuned! p.s.: FIX THIS DAMNED PROGRAM!!!");
                        break;
                }

                return false;
            }
        }

        // Close connection
        private bool CloseConnection() {
            try {

                connection.Close();
                return true;
            } catch (MySqlException ex) {
                ResponseHandler.Out_Message(ex.Message);
                return false;
            }
        }

        // Insert, Update, Delete statements (No return values (Non Query))
        public void NonQuery(string query) {
            // Open connection
            if (this.OpenConnection() == true) {
                // Create command and assign the query and connection from the constructor
                MySqlCommand cmd = new MySqlCommand(query, connection);

                // Execute command
                cmd.ExecuteNonQuery();

                // Close connection
                this.CloseConnection();
            }
        }
        /*
        // Select statement
        public List<string> Select(string query) {
            // Create a list to store the result
            List<string> records = new List<string>();

            // Open connection
            if( this.OpenConnection() ) {
                // Create command
                MySqlCommand cmd = new MySqlCommand(query, connection);
                // Create a data reader amd Execute the command
                MySqlDataReader dataReader = cmd.ExecuteReader();

                // Read the data and sotre them in the ArrayList
                if (dataReader.HasRows) {
                    while (dataReader.Read()) {
                        records.Add(dataReader[]);
                    }
                }

                // Close Data Reader
                dataReader.Close();
                // Close Connection
                this.CloseConnection();
            }

            // Return list to be displayed
            return records;
        }*/
        
        // Count statement
        public int Count(string query) {

            int Count = -1;

            // Open connection
            if( this.OpenConnection() ) {
                // Create MySql command
                MySqlCommand cmd = new MySqlCommand(query, connection);

                // ExecuteScalar will return one value
                Count = int.Parse(cmd.ExecuteScalar() + "");

                // Close connection
                this.CloseConnection();
            }

            return Count;
        }

        // Backup
        public void Backup() {

        }

        // Restore
        public void Restore() {

        }

    }
}