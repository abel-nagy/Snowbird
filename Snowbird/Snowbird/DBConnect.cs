// Add MySql Library
using MySql.Data.MySqlClient;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        // Insert statement
        public void Insert() {

        }

        // Update statement
        public void Update() {

        }

        // Delete statement
        public void Delete() {

        }

        // Select statement
        public List<string>[] Select() {
            return new List<string>[1];
        }

        // Count statement
        public int Count() {
            return 0;
        }

        // Backup
        public void Backup() {

        }

        // Restore
        public void Restore() {

        }

    }
}