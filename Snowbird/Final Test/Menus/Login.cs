using System;

namespace Final_Test.Menus {
    public static class Login {

        public static void Run() {

            bool runThis = true, failed = false;

            // ==== Repeat Login screen ===============================================================================================================================================================
            /**/
            /**/    while(runThis) {
            /**/        string username = "", password = "";
            /**/        
            /**/        // ==== Greeting screen ============================================================================
            /**/        /**/
            /**/        /**/    Console.Clear();
            /**/        /**/    Console.Write( "\n\t\t\t\t\t\tWelcome to " ); /**/ Snowbird.Write( "Snowbird Wallet", ConsoleColor.Black, ConsoleColor.White ); /**/ Console.WriteLine( "! \n\n" );
            /**/        /**/
            /**/        /**/    Console.Write("\t\t\t\t\t\t\t"); Snowbird.Write("Login\n\n", ConsoleColor.Black, ConsoleColor.Blue); 
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
            /**/            runThis = false;
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
            /**/                    runThis = false;
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
            /**/                        /**/        double initialAmount = Wallet.AddWallet();
            /**/                        /**/        if(initialAmount != -1.0) {
            /**/                        /**/            Snowbird.db.NonQuery("INSERT INTO transactions (id,   wallet_id,                             type, amount,                  fromWalletId, toWalletId, description,      created_at) " +
            /**/                        /**/                                 "VALUES                   (NULL, '" + Snowbird.user.Wallets[0][0] + "', 1,    '" + initialAmount + "', NULL,         NULL,       'Initial amount', '" + DateTime.Now.ToString( "yyyy-MM-dd HH:mm:ss" ) + "');");
            /**/                        /**/            Snowbird.user.Update();
            /**/                        /**/            Snowbird.Login = false;
            /**/                        /**/            runThis = false;
            /**/                        /**/        } else
            /**/                        /**/            runThis = false;
            /**/                        /**/    } else {
            /**/                        /**/        runThis = false;
            /**/                        /**/        Snowbird.Login = false;
            /**/                        /**/    }
            /**/                        /**/
            /**/                        // ====================================================================================================================================================================
            /**/                        
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
        

    }
}