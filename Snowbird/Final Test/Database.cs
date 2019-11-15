// Add MySql Library
using MySql.Data.MySqlClient;

using System;
using System.Collections.Generic;

namespace Final_Test {
    public class Database {

        private MySqlConnection connection;
        private string server, database, uid, password;

        /// <summary>
        /// Create an instance to a database
        /// </summary>
        /// <param name="server">The server IP Address</param>
        /// <param name="database">The database name</param>
        /// <param name="uid">MySQL server username</param>
        /// <param name="password">MySQL server password</param>
        public Database(string server, string database, string uid, string password) {
            Initialize(server, database, uid, password);
        }

        // Initialize values
        private void Initialize(string server, string database, string uid, string password) {
            this.server = server;
            this.database = database;
            this.uid = uid;
            this.password = password;
            
            string connectionString  = "SERVER=" + server + ";DATABASE=" + database + ";UID=" + uid + ";PASSWORD=" + password + ";";
            connection = new MySqlConnection(connectionString);

            try {

            } catch(Exception ex) {

            }
        }


        // Open connection to database
        private bool OpenConnection() {

            bool retry = true;

            while(retry) {

                retry = false;

                try {
                    connection.Open();
                    return true;
                } catch(MySqlException ex) {

                    bool runThis = true;

                    while(runThis) {

                        Console.Clear();
                        Console.Write( "\n\t\t\t\t\t\tWelcome to " ); /**/
                        Snowbird.Write( "Snowbird Wallet", ConsoleColor.Black, ConsoleColor.White ); /**/
                        Console.WriteLine( "! \n\n" );

                        switch(ex.Number) {
                            case 0:
                                Console.WriteLine( "Cannot connect to server. Contact administrator!" );
                                break;
                            case 1045:
                                Console.WriteLine( "Invalid SQL server username/password, please try again!" );
                                break;
                            case 1042:
                                Console.WriteLine( "\tOur database servers may be down! Please stay tuned and try again later!" );
                                break;
                            default:
                                Console.WriteLine( "We have no idea what happened. Please stay tuned and read below! p.s.: FIX THIS DAMNED PROGRAM!!!" );
                                Console.WriteLine( ex.Message );
                                break;
                        }

                        Console.Write( "\n\tRetry? (" ); /**/
                        Snowbird.Write( "Y", ConsoleColor.Yellow ); /**/
                        Console.Write( "/" ); /**/
                        Snowbird.Write( "N", ConsoleColor.Yellow ); /**/
                        Console.WriteLine( ")" );

                        ConsoleKeyInfo input = Console.ReadKey( true );
                        switch(input.Key) {
                            case ConsoleKey.N:
                                Snowbird.Exit();
                                break;
                            case ConsoleKey.Y:
                                retry = true;
                                runThis = false;
                                break;
                            default:
                                break;
                        }
                        
                    }
                }
            }

            return true;
        }

        // Close connection
        private bool CloseConnection() {
            try {
                connection.Close();
                return true;
            } catch (MySqlException ex) {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
        

        /// <summary>
        /// Insert, Update, Delete statements. Doesn't return any values
        /// </summary>
        /// <param name="query">MySQL Command</param>
        public void NonQuery(string query) {

            // Open connection
            if (OpenConnection() == true) {
                try {

                    // Create command and assign the query and connection from the constructor
                    MySqlCommand cmd = new MySqlCommand(query, connection);

                    // Execute command
                    cmd.ExecuteNonQuery();

                } catch (MySqlException ex) {
                    Console.WriteLine(ex.Message);
                }

                // Close connection
                CloseConnection();
            }

        }

        /// <summary>
        /// MySQL Select statement
        /// </summary>
        /// <param name="query">MySQL Command</param>
        /// <param name="columns">How many columns to ask for</param>
        /// <param name="columnsName">The names of the asked columns</param>
        /// <returns>A string type List of the returned entries (nested array)</returns>
        public List<string>[] Select(string query, int columns, string[] columnsName) {

            // A list to store the results
            List<string>[] records = new List<string>[columns];
            for (int i = 0; i < columns; i++) {
                records[i] = new List<string>();
            }

            // Open connection
            if (OpenConnection()) {
                try {

                    // Create command
                    MySqlCommand cmd = new MySqlCommand(query, connection);
                    // Create a data reader amd Execute the command
                    MySqlDataReader dataReader = cmd.ExecuteReader();

                    // Read the data and sotre them in the ArrayList
                    if (dataReader.HasRows) {
                        while (dataReader.Read()) {
                            for (int i = 0; i < columns; i++) {
                                records[i].Add(dataReader[columnsName[i]] + "");
                            }
                        }
                    }

                    // Close Data Reader
                    dataReader.Close();

                } catch (MySqlException ex) {
                    Console.WriteLine(ex.Message);
                }

                // Close Connection
                CloseConnection();
            }

            // Return list to be displayed
            return records;
        }
        
        /// <summary>
        /// MySQL Count statement
        /// </summary>
        /// <param name="query">MySQL Command</param>
        /// <returns>The number of entries present in the database</returns>
        public int Count(string query) {

            int Count = -1;

            // Open connection
            if (OpenConnection()) {
                try {
                    // Create MySql command
                    MySqlCommand cmd = new MySqlCommand(query, connection);

                    // ExecuteScalar will return one value
                    Count = int.Parse(cmd.ExecuteScalar() + "");

                } catch (MySqlException ex) {
                    Console.WriteLine(ex.Message);
                }

                // Close connection
                CloseConnection();
            }

            return Count;
        }
        
    }
}
