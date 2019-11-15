using System;
using System.Text.RegularExpressions;
using System.Security;
using System.Collections.Generic;
using System.Globalization;

namespace Final_Test.Menus {
    public static class Login {

        public static void Run() {

            bool islogin = true, failed = false;

            // ==== Repeat Login screen ===============================================================================================================================================================
            /**/
            /**/    while(islogin) {
            /**/        string username = "", password = "";
            /**/        
            /**/        // ==== Greeting screen ============================================================================
            /**/        /**/
            /**/        /**/    Console.Clear();
            /**/        /**/    Console.Write( "\n\t\t\t\t\t\tWelcome to " ); /**/ Snowbird.Write( "Snowbird Wallet", ConsoleColor.Black, ConsoleColor.White ); /**/ Console.WriteLine( "! \n\n" );
            /**/        /**/    
            /**/        /**/    if(failed) {
            /**/        /**/        Snowbird.WriteLine( "\tWrong login credidentials! Let's try again!", ConsoleColor.Red );
            /**/        /**/        failed = false;
            /**/        /**/    } else
            /**/        /**/        Console.WriteLine();
            /**/        /**/
            /**/        // =================================================================================================
            /**/        
            /**/        
            /**/        // ==== Username Input =========================================
            /**/        /**/
            /**/        /**/    Snowbird.Write( "\n\n\tUsername: ", ConsoleColor.Blue );
            /**/        /**/    string input = Snowbird.GetInput();
            /**/        /**/
            /**/        //==============================================================
            /**/        
            /**/        if(input == "!Q!")          // -- Quit from input -----
            /**/            islogin = false;
            /**/
            /**/        else {
            /**/            username = input;
            /**/        
            /**/            if(username.Length >= 6 && username.Length <= 20) {      // Username must be at least 6 characters but maximum 20 characters long
            /**/            
            /**/                // ==== Password Input =========================================
            /**/                /**/
            /**/                /**/    Snowbird.Write( "\tPassword: ", ConsoleColor.DarkRed );
            /**/                /**/    input = Snowbird.GetHashedPass();
            /**/                /**/
            /**/                //==============================================================
            /**/                
            /**/                if(input == "!Q!")          // -- Quit from input -----
            /**/                    islogin = false;
            /**/
            /**/                else {
            /**/                
            /**/                    password = input;
            /**/                    
            /**/                    string user_id = ValidateLogin( username, password );       // Validate/Log in user and return the UserID
            /**/                    
            /**/                    if(user_id == "!E!")        // -- Quit from input -----
            /**/                        failed = true;
            /**/                    else if(int.Parse( user_id ) >= 100000000) {        // Just to make sure the returned value is a valid UserID
            /**/                    
            /**/                        Snowbird.user = new User( user_id );        // Save all current data locally
            /**/                        
            /**/                        // ==== Add first wallet for freshly created user =====================================================================================================================
            /**/                        /**/
            /**/                        /**/    if(Snowbird.user.WalletCount == 0) {
            /**/                        /**/        double initialAmount = AddWallet( Snowbird.user.UserId, 0 );
            /**/                        /**/        Snowbird.user.Update();
            /**/                        /**/        string query = "INSERT INTO transactions (id,   wallet_id,                             type, amount,                  fromWalletId, toWalletId, description,      created_at) " +
            /**/                        /**/                       "VALUES                   (NULL, '" + Snowbird.user.Wallets[0][0] + "', 1,    '" + initialAmount + "', NULL,         NULL,       'Initial amount', '" + DateTime.Now.ToString( "yyyy-MM-dd HH:mm:ss" ) + "');";
            /**/                        /**/        Snowbird.db.NonQuery( query );
            /**/                        /**/        Snowbird.user.Update();
            /**/                        /**/    }
            /**/                        /**/
            /**/                        // ====================================================================================================================================================================
            /**/                        
            /**/                        // ==== Quit Login screen to log in User ========
            /**/                        /**/
            /**/                        /**/    Snowbird.Login = false;
            /**/                        /**/    islogin = false;
            /**/                        /**/
            /**/                        // =============================================
            /**/                        
            /**/                    }
            /**/                }
            /**/            } else
            /**/                failed = true;
            /**/                
            /**/        }
            /**/    }
            /**/
            // ========================================================================================================================================================================================
        }

        /// <summary>
        /// Validate/Log in user and return the UserID
        /// </summary>
        /// <param name="username">Username/Email</param>
        /// <param name="password">User password</param>
        /// <returns>UserID</returns>
        public static string ValidateLogin(string username, string password) {
            int mathcing = Snowbird.db.Count( "SELECT COUNT(*) FROM users WHERE username='" + username + "' AND password='" + password + "';" );
            if(mathcing == 1)
                return Snowbird.db.Select( "SELECT id FROM users WHERE username='" + username + "' AND password='" + password + "';", 1, new string[1] { "id" } )[0][0];
            else if(mathcing > 1 || mathcing < 0) {
                Console.WriteLine( "\n\n\tWOW! You made the impossible possible!" );
                Console.ReadKey();
            }

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
                Console.WriteLine( "Create your first wallet\n" );
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