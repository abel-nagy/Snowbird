using System;
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

                    Console.WriteLine("Username must contain numbers and english letters only and must be at least 6 characters long!");
                    Console.Write("Username: ");
                    username = Console.ReadLine();

                    if (Regex.Match(username, "^[a-zA-Z0-9]*$").Success && username.Length >= 6) {
                        if(Snowbird.db.Count("SELECT count(*) FROM users WHERE username='" + username + "';") > 0) {

                            usernameOk = false;

                            Console.Clear();
                            Console.WriteLine("Already in use. Try another one!");

                        }
                    } else {

                        usernameOk = false;

                    }

                } while (!usernameOk);
                
                // Password
                while (true) {

                    Console.Clear();
                    Console.WriteLine("Password can be any length and character.");
                    Console.Write("Password:       ");
                    password = Snowbird.getHashedPass();

                    Console.Write("Password again: ");
                    if (Snowbird.getHashedPass() == password && password != "e3b0c44298fc1c149afbf4c8996fb92427ae41e4649b934ca495991b7852b855") break;

                }

                Console.Write("Your data:\n  E-mail: {0}\n  Username: {1}\n\nIs this correct? (y/n): ", email, username);
                if (Console.ReadLine() == "y") break;

            }

            DateTime myDateTime = DateTime.Now;
            string dateTime = myDateTime.ToString("yyyy-MM-dd HH:mm:ss");
            
            string query = "INSERT INTO `users` (`email`, `username`, `password`, `created_at`) VALUES('" + email + "', '" + username + "', '" + password + "', '" + dateTime + "');";
            Snowbird.db.NonQuery(query);
            //Welcome.Run();
        }

    }
}
