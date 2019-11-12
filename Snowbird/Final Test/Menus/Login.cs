using System;
using System.Text.RegularExpressions;
using System.Security;

namespace Final_Test.Menus {
    public static class Login {

        public static void Run()
        {

            while (true)
            {
                string identifier = "", password = "", type = "";

                Console.Clear();
                Console.Write("Username/email: ");
                identifier = Console.ReadLine();

                if (identifier.Length >= 6)
                {
                    string pattern = "^([0-9a-zA-Z]([-\\.\\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\\w]*[0-9a-zA-Z]\\.)+[a-zA-Z]{2,9})$";
                    if (Regex.IsMatch(identifier, pattern)) type = "0";
                    else type = "1";

                    Console.Write("Password: ");
                    password = Snowbird.getHashedPass();

                    if (type == "0")
                    {
                        int n = Snowbird.db.Count("SELECT count(*) FROM users WHERE email='" + identifier + "' AND password='" + password + "';");
                        if (n != 0)
                        {
                            Console.Write("Email and password combination was correct! ");
                            if (n > 1) Console.WriteLine("WARNING! 2 conflicting entries for this user!");
                            Console.ReadLine();
                        }
                    }
                    else
                    {
                        int n = Snowbird.db.Count("SELECT count(*) FROM users WHERE username='" + identifier + "' AND password='" + password + "';");

                        if (n != 0)
                        {
                            Console.Write("Username and password combination was correct! ");
                            if (n > 1) Console.WriteLine("WARNING! 2 conflicting entries for this user!");
                            Console.ReadLine();
                            break;
                        }
                    }
                }
            }

        }

    }
}