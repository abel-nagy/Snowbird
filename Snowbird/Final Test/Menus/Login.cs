using System;
using System.Text.RegularExpressions;
using System.Security;
using System.Collections.Generic;
using System.Globalization;

namespace Final_Test.Menus {
    public static class Login {

        public static void Run() {

            bool islogin = true, isFailed = false;

            // -- Repeat ------
            while(islogin) {
                string identifier = "", password = "", type = "1";

                Console.Clear();
                Console.Write( "\n\t\t\t\t\t\tWelcome to " ); /**/
                Snowbird.Write( "Snowbird Wallet", ConsoleColor.Black, ConsoleColor.White );
                Console.WriteLine( "! \n\n" );

                if(isFailed) {
                    Snowbird.WriteLine( "\tWrong login credidentials! Let's try again!", ConsoleColor.Red );
                } else {
                    Console.WriteLine();
                }

                isFailed = false;

                Snowbird.Write( "\n\n\tUsername/email: ", ConsoleColor.Blue );
                string ifCommand = Snowbird.GetInput();

                if(ifCommand == "!Q!") {
                    islogin = false;
                } else {
                    identifier = ifCommand;

                    if(identifier.Length >= 6) {

                        Snowbird.Write( "\n\tPassword:       ", ConsoleColor.DarkRed );
                        ifCommand = Snowbird.GetHashedPass();

                        if(ifCommand == "!Q!") {
                            islogin = false;
                        } else {

                            password = ifCommand;

                            string user_id = GetUserId( identifier, password );

                            if(user_id == "!E!")
                                isFailed = true;
                            else if(int.Parse( user_id ) >= 100000000) {

                                Snowbird.user = new User( user_id );

                                if(Snowbird.user.WalletCount == 0) {
                                    double initialAmount = AddWallet( Snowbird.user.UserId, 0 );
                                    Snowbird.user.Update();
                                    string query = "INSERT INTO transactions (id, wallet_id, type, amount, fromWalletId, toWalletId, description, created_at) " +
                                                   "VALUES (NULL, '" + Snowbird.user.Wallets[0][0] + "', 1, '" + initialAmount + "', NULL, NULL, 'Initial amount', '" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "');";
                                    Snowbird.db.NonQuery(query);
                                    Snowbird.user.Update();
                                }

                                Snowbird.Login = false;
                                islogin = false;

                            }

                        }
                    } else {
                        isFailed = true;
                    }

                }
            }
            // ----------------
        }

        /// <summary>
        /// Get the User ID for a given Username
        /// </summary>
        /// <param name="identifier">Username/Email</param>
        /// <param name="password">User password</param>
        /// <returns>9 digit ID</returns>
        public static string GetUserId(string identifier, string password) {
            int mathcing = Snowbird.db.Count("SELECT COUNT(*) FROM users WHERE (username='" + identifier + "' OR email='" + identifier + "') AND password='" + password + "';");
            if(mathcing == 1)
                return Snowbird.db.Select( "SELECT id FROM users WHERE (username='" + identifier + "' OR email='" + identifier + "') AND password='" + password + "';", 1, new string[1] { "id" } )[0][0];
            else if(mathcing > 1 || mathcing < 0)
                Console.WriteLine("\n\n\tWOW! You made the impossible possible!");
            
            return "!E!";
        }


        /// <summary>
        /// Creates a Wallet for the user
        /// </summary>
        /// <param name="userId">User ID</param>
        /// <param name="type">Wallet type</param>
        public static double AddWallet(string userId, int type) {

            double amount = -1.0;

            if(type == 0) {
                Console.Clear();
                Console.WriteLine( "Create your first wallets\n" );
                string currency = "huf";

                // Amount
                Console.Write( "Amount: " );
                amount = double.Parse( Snowbird.GetNumbers(), CultureInfo.InvariantCulture.NumberFormat );
                Snowbird.WriteLine( amount + "", ConsoleColor.Blue );
                
                //Console.WriteLine( "Currency:" );
                //Console.Write( "  (" ); /**/ Snowbird.Write( "1", ConsoleColor.Yellow ); /**/ Console.Write( ") " ); Snowbird.WriteLine( "HUF", ConsoleColor.Green, ConsoleColor.Gray );
                //Console.Write( "  (" ); /**/ Snowbird.Write( "2", ConsoleColor.Yellow ); /**/ Console.Write( ") " ); Snowbird.WriteLine( "EUR", ConsoleColor.Green, ConsoleColor.Gray );
                //Console.Write( "  (" ); /**/ Snowbird.Write( "3", ConsoleColor.Yellow ); /**/ Console.Write( ") " ); Snowbird.WriteLine( "USD", ConsoleColor.Green, ConsoleColor.Gray );
                /*
                switch(Snowbird.KeyPressed()) {
                    case "1":
                        currency = "huf";
                        break;
                    case "2":
                        currency = "eur";
                        break;
                    case "3":
                        currency = "usd";
                        break;
                    default:
                        break;
                }*/

                DateTime myDateTime = DateTime.Now;
                string dateTime = myDateTime.ToString( "yyyy-MM-dd HH:mm:ss" );

                string query = "INSERT INTO wallets (id, user_id, type, amount, currency, account_name, account_number, description, created_at) " +
                               "VALUES (NULL, '" + userId + "', '0', '" + amount + "', '" + currency + "', NULL, NULL, NULL, '" + dateTime + "');";
                Snowbird.db.NonQuery( query );
            }

            return amount;

        }

    }
}