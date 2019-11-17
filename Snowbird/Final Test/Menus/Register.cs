using System;
using System.Text.RegularExpressions;


namespace Final_Test.Menus {
    public static class Register {
        
        public static bool Run() {

            

            bool registered = false;

            string email, username, password;

            while (true) {
                email = ""; username = ""; password = "";
                Console.Clear();
                Console.Write("\n\t\t\t\t\t\tWelcome to "); /**/ Snowbird.Write("Snowbird Wallet", ConsoleColor.Black, ConsoleColor.White); /**/ Console.WriteLine("! \n\n");
                Console.Write("\t\t\t\t\t\t\t"); Snowbird.Write("Registration\n\n", ConsoleColor.Black, ConsoleColor.Green); 
                // E-mail
                bool emailOk;
                //Console.Clear();
                do {

                    emailOk = true;
                    Snowbird.Write("\t\tE-mail ", ConsoleColor.Green);
                    Console.Write("(used for password reset. Not required but advised): ");
                    email = Snowbird.GetInput();

                    if (email != "") {
                        string pattern = "^([0-9a-zA-Z]([-\\.\\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\\w]*[0-9a-zA-Z]\\.)+[a-zA-Z]{2,9})$";

                        if(!Regex.IsMatch(email, pattern)) {

                            emailOk = false;

                            Console.Clear();
                            Snowbird.Write("\t\tNot a valid e-mail address!\n", ConsoleColor.Red);

                        } else {
                            if (Snowbird.db.Count("SELECT count(*) FROM users WHERE email='" + email + "';") > 0) {

                                emailOk = false;

                                Console.Clear();
                                Snowbird.Write("\t\tEmail is already in use. Try another one!\n", ConsoleColor.Red);

                            }
                        }
                    }
                } while (!emailOk);

                // Usename
                bool usernameOk;
                //Console.Clear();
                do {

                    usernameOk = true;

                    Console.WriteLine("\tUsername must contain numbers and english letters only and must be at least 6 characters long!");
                    Snowbird.Write("\t\tUsername: ", ConsoleColor.Blue);
                    username = Snowbird.GetInput();

                    if (Regex.Match(username, "^[a-zA-Z0-9]*$").Success && username.Length >= 6) {
                        if(Snowbird.db.Count("SELECT count(*) FROM users WHERE username='" + username + "';") > 0) {

                            usernameOk = false;

                            Console.Clear();
                            Snowbird.Write("\t\tAlready in use. Try another one!", ConsoleColor.Red);

                        }
                    } else {

                        usernameOk = false;

                    }

                } while (!usernameOk);
                
                // Password
                while (true) {

                    //Console.Clear();
                    Console.WriteLine("\tPassword can be any length and character.");
                    Snowbird.Write("\t\tPassword: ", ConsoleColor.DarkRed);
                    password = Snowbird.GetHashedPass();

                    if(password != "!Q!")
                    {
                        Snowbird.Write("\t\tPassword again: ", ConsoleColor.DarkRed);
                        if (Snowbird.GetHashedPass() == password && password != "e3b0c44298fc1c149afbf4c8996fb92427ae41e4649b934ca495991b7852b855") break;
                    }


                    

                }

                Console.Clear();
                //Console.Write("\t\tYour data:\n  E-mail: {0}\n  Username: {1}\n\nIs this correct? (y/n): ", email, username);

                Snowbird.Write("\n\n\tYour data:\n", ConsoleColor.Yellow);
                Snowbird.Write("\t\tE-mail: ", ConsoleColor.Green); Console.WriteLine(email);
                Snowbird.Write("\t\tUsername: ", ConsoleColor.Blue); Console.WriteLine(username);
                Snowbird.Write("\n\n\tIs this correct? (y/n): ", ConsoleColor.Magenta);

                if (Console.ReadLine() == "y") break;

            }

            DateTime myDateTime = DateTime.Now;
            string dateTime = myDateTime.ToString("yyyy-MM-dd HH:mm:ss");
            
            string query = "INSERT INTO `users` (`email`, `username`, `password`, `created_at`) VALUES('" + email + "', '" + username + "', '" + password + "', '" + dateTime + "');";
            Snowbird.db.NonQuery(query);

            registered = true;

            return registered;
        }

    }
}
