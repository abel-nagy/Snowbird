using System;
using System.Text.RegularExpressions;
using System.Security;
using System.Collections.Generic;

namespace Final_Test.Menus {
    public static class Login {

        public static void Run() {

            while(true) {
                string identifier = "", password = "", type = "1";

                Console.Clear();
                Console.Write("Username/email: ");
                identifier = Console.ReadLine();

                if (identifier.Length >= 6) {

                    string pattern = "^([0-9a-zA-Z]([-\\.\\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\\w]*[0-9a-zA-Z]\\.)+[a-zA-Z]{2,9})$";
                    if (Regex.IsMatch(identifier, pattern)) type = "0";

                    Console.Write("Password: ");
                    password = Snowbird.getHashedPass();

                    if (type == "0") {
                        string s = "FROM users WHERE email='" + identifier + "' AND password='" + password + "';";
                        if (Snowbird.db.Count("SELECT COUNT(*) " + s) == 1) {
                            //Console.Clear();
                            Console.WriteLine("Welcome {0}! ({1})", Snowbird.db.Select("SELECT username " + s, 1, new string[1]{"username"})[0][0], Snowbird.db.Select("SELECT id " + s, 1, new string[1] { "id" })[0][0]);
                            break;
                        }
                    } else {
                        string s = "FROM users WHERE username='" + identifier + "' AND password='" + password + "';";
                        if (Snowbird.db.Count("SELECT COUNT(*) " + s) == 1) {

                            Snowbird.user = new User(identifier, getUserId(identifier));
                            if (Snowbird.db.Count("SELECT COUNT(*) FROM wallets WHERE user_id='" + Snowbird.user.UserId + "';") == 0) createFirstWallet(Snowbird.user.UserId);    
                            Snowbird.user.WalletCount = Snowbird.db.Count("SELECT COUNT(*) FROM wallets WHERE user_id='" + Snowbird.user.UserId + "';");   
                            Snowbird.user.Wallets = getWallets(Snowbird.user.UserId);
                            break;

                        }
                    }
                }
            }

        }

        public static string getUserId(string username) {
            return Snowbird.db.Select("SELECT id FROM users WHERE username='" + username + "';", 1, new string[1] { "id" })[0][0];
        }

        public static List<string>[] getWallets(string userId) {
            return Snowbird.db.Select("SELECT * FROM wallets WHERE user_id='" + userId + "' ORDER BY type;", 9, new string[9] { "id", "user_id", "type", "amount", "currency", "account_name", "account_number", "description", "created_at" });
        }

        public static void createFirstWallet(string userId)
        {
            Console.Clear();
            Console.WriteLine("Create your first wallets\n");
            int amount = 0;
            string currency = "huf";
            //amount
            Console.Write("Amount: ");
            amount = Convert.ToInt32(Console.ReadLine());

            Console.Write("Currency (HUF - 1 / EUR - 2 / USD - 3): ");
            switch(Snowbird.keyPressed())
            {
                case "1":
                    currency = "huf";
                    break;
                case "2":
                    currency = "eur";
                    break;
                case "3":
                    currency = "usd";
                    break;
                default: break;
            }

            DateTime myDateTime = DateTime.Now;
            string dateTime = myDateTime.ToString("yyyy-MM-dd HH:mm:ss");

            string query = "INSERT INTO `wallets` (`id`, `user_id`, `type`, `amount`, `currency`, `account_name`, `account_number`, `description`, `created_at`) VALUES (NULL, '" + userId + "', '0', '" + amount + "', '" + currency + "', NULL, NULL, NULL, '" + dateTime + "');";
            Snowbird.db.NonQuery(query);
        }

    }
}