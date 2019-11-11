using System;
using System.Text.RegularExpressions;
using MySql.Data.MySqlClient;

namespace Final_Test.Menus {
    public static class Register {
        
        public static void Run() {
            string email, username, password;

            while (true) {
                email = ""; username = ""; password = "";

                Console.Clear();
                Console.Write("E-mail (used for password reset. Not required but advised): ");
                email = Console.ReadLine();

                if (email != "") {
                    string pattern = "^([0-9a-zA-Z]([-\\.\\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\\w]*[0-9a-zA-Z]\\.)+[a-zA-Z]{2,9})$";
                    while (!Regex.IsMatch(email, pattern))
                    {
                        Console.Clear();
                        Console.Write("E-mail (used for password reset. Not required but advised): ");
                        email = Console.ReadLine();

                    }

                    // Check here, if the email is already in use
                    //email check (Patrik)
                     int n = Snowbird.db.Count("SELECT count(*) FROM users WHERE email='" + email + "';");
                     while(n != 0)
                     {
                        Console.Clear();
                        Console.Write("E-mail (used for password reset. Not required but advised, foglalt): ");
                        email = Console.ReadLine();
                    }
                        
                }

                while (true) {
                    Console.Clear();
                    Console.Write("Username (Numbers and english letters only! At least 6 characters long): ");
                    username = Console.ReadLine();
                    if (Regex.Match(username, "^[a-zA-Z0-9]*$").Success && username.Length >= 6) break;

                    //Check here, if the username is already in use
                }

                while (true) {
                    Console.Clear();
                    Console.Write("Password (can be any length and character): ");
                    password = Snowbird.getHashedPass();
                    Console.Write("Password again: ");
                    if (Snowbird.getHashedPass() == password) break;

                    // Make it check for empty password
                }

                Console.Write("Your data:\n  E-mail: {0}\n  Username: {1}\n\nIs this correct? (y/n): ", email, username);
                if (Console.ReadLine() == "y") break;
            }

            DateTime myDateTime = DateTime.Now;
            string dateTime = myDateTime.ToString("yyyy-MM-dd HH:mm:ss");
            
            string query = "INSERT INTO `users` (`email`, `username`, `password`, `created_at`) VALUES('" + email + "', '" + username + "', '" + password + "', '" + dateTime + "');";
            Snowbird.db.NonQuery(query);
            query = "";
            Console.ReadLine();
        }

    }
}
