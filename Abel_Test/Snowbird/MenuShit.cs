using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Snowbird {
    static class MenuShit {
        public static void Login_Main() {
            bool run = true;
            while(run) {
                Console.Clear();
                Console.WriteLine("1. Register\n2. Login\n\n0. exit");

                switch (int.Parse(Console.ReadLine())) {
                    case 0:
                        Console.Clear();
                        Console.Write("Are you sure you want to quit? (y/n): ");
                        if (Console.ReadLine() == "y")
                            System.Environment.Exit(1);
                        break;
                    case 1:
                        Register();
                        break;
                    case 2:
                        run = false;
                        Login();
                        break;
                    default: break;
                }
            }
        }

        public static void Register() {
            string email = "", username = "", password = "";
            while (true) {
                email = ""; username = ""; password = "";

                Console.Clear();
                Console.Write("E-mail (used for password reset. Not required but advised): ");
                email = Console.ReadLine();

                if (email != "") {
                    string pattern = "^([0-9a-zA-Z]([-\\.\\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\\w]*[0-9a-zA-Z]\\.)+[a-zA-Z]{2,9})$";
                    while(!Regex.IsMatch(email, pattern)) {
                        Console.Clear();
                        Console.Write("E-mail (used for password reset. Not required but advised): ");
                        email = Console.ReadLine();
                    }
                    // Check here, if the email is already in use
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
                    password = getHashedPass();
                    Console.Write("Password again: ");
                    if (getHashedPass() == password) break;

                    // Make it check for empty password
                }

                Console.Write("Your data:\n  E-mail: {0}\n  Username: {1}\n\nIs this correct? (y/n): ", email, username);
                if (Console.ReadLine() == "y") break;
            }

            DateTime myDateTime = DateTime.Now;
            string dateTime = myDateTime.ToString("yyyy-MM-dd HH:mm:ss");
            int month = DateTime.Now.Month;
            int year = DateTime.Now.Year;
            // if left arrow key
            if (month > 1) {
                month--;
            } else {
                year--;
                month = 12;
            }
            string query = "INSERT INTO `users` (`email`, `username`, `password`, `created_at`) VALUES('" + email + "', '" + username + "', '" + password + "', '" + dateTime + "');";
            Program.db.NonQuery(query);
            query = "";
            Console.ReadLine();
        }
        public static void Login() {
            while(true) {
                string identifier = "", password = "", type = "";

                Console.Clear();
                Console.Write("Username/email: ");
                identifier = Console.ReadLine();

                if (identifier.Length >= 6) {
                    string pattern = "^([0-9a-zA-Z]([-\\.\\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\\w]*[0-9a-zA-Z]\\.)+[a-zA-Z]{2,9})$";
                    if (Regex.IsMatch(identifier, pattern)) type = "0";
                    else type = "1";

                    Console.Write("Password: ");
                    password = getHashedPass();

                    if(type == "0") {
                        int n = Program.db.Count("SELECT count(*) FROM users WHERE email='" + identifier + "' AND password='" + password + "';");
                        if(n != 0) {
                            Console.Write("Email and password combination was correct! ");
                            if (n > 1) Console.WriteLine("WARNING! 2 conflicting entries for this user!");
                            Console.ReadLine();
                        }
                    } else {
                        int n = Program.db.Count("SELECT count(*) FROM users WHERE username='" + identifier + "' AND password='" + password + "';");
                        
                        if (n != 0) {
                            Console.Write("Username and password combination was correct! ");
                            if (n > 1) Console.WriteLine("WARNING! 2 conflicting entries for this user!");
                            Console.ReadLine();
                            break;
                        }
                    }
                }
            }
        }
        
        public static void Main_Menu()
        {

        }

        public static string getHashedPass() {
            string passwd = "";
            ConsoleKeyInfo key;

            do {
                key = Console.ReadKey(true);

                // Ignore any key out of range
                if (((int)key.Key) >= 32 && ((int)key.Key) <= 126) {
                    // Append the character to the password
                    passwd += key.KeyChar;
                    Console.Write("*");
                }
                // Exit if Enter key is pressed
            } while (key.Key != ConsoleKey.Enter);
            Console.WriteLine();

            return Program.ComputeSha256Hash(passwd);
        }
    }
}
