﻿using System;
using System.Text.RegularExpressions;


namespace Final_Test.Menus {
    public static class Register {
        
        public static void Run() {
            string email, username, password;

            while (true) {
                email = ""; username = ""; password = "";

                    // E-mail
                bool emailOk;
                Console.Clear();
                do {

                    emailOk = true;

                    Console.Write("E-mail (used for password reset. Not required but advised): ");
                    email = Console.ReadLine();

                    if (email != "") {
                        string pattern = "^([0-9a-zA-Z]([-\\.\\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\\w]*[0-9a-zA-Z]\\.)+[a-zA-Z]{2,9})$";

                        if(!Regex.IsMatch(email, pattern)) {

                            emailOk = false;

                            Console.Clear();
                            Console.WriteLine("Not a valid e-mail address!");

                        } else {
                            if (Snowbird.db.Count("SELECT count(*) FROM users WHERE email='" + email + "';") > 0) {

                                emailOk = false;

                                Console.Clear();
                                Console.WriteLine("Email is already in use. Try another one!");

                            }
                        }
                    }
                } while (!emailOk);

                // Usename
                bool usernameOk;
                Console.Clear();
                do {

                    usernameOk = true;

                    Console.Write("Username (Numbers and english letters only! At least 6 characters long): ");
                    username = Console.ReadLine();

                    if (Regex.Match(username, "^[a-zA-Z0-9]*$").Success && username.Length >= 6) {
                        if(Snowbird.db.Count("SELECT count(*) FROM users WHERE username='" + username + "';") > 0) {

                            usern

                        }
                    }

                } while (!usernameOk);


                while (true) {
                    Console.Clear();
                    
                    

                    //Username check (Patrik)
                    int usernameCheck = ;

                    do
                    {
                        Console.Clear();
                        Console.WriteLine("Username has already exists");
                        Console.Write("Username (Numbers and english letters only! At least 6 characters long): ");
                        username = Console.ReadLine();
                    } while (usernameCheck != 0);

                }
                 

                

                //password
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
