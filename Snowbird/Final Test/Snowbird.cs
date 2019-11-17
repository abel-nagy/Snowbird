using Final_Test.Menus;

using System;
using System.Globalization;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

namespace Final_Test {
    public class Snowbird {     // by Ábel

        public static Database db;
        private static bool running, welcome;
        public static User user;
        
        static void Main(string[] args) {

            Console.Title = "Snowbird Wallet Application";

            running = true;
            welcome = true;
            db = new Database( "127.0.0.1", "snowbird", "root", "" );

            while(running) {

                if(welcome)
                    Welcome.Run();
                else
                    MainMenu.Run();

            }
        }


        /// <summary>
        /// Get only numbers from User while making it possible to quit from input
        /// </summary>
        /// <returns>Decimal numbers in string format</returns>
        public static string GetNumbers() {
            string number = "";
            ConsoleKeyInfo key;
            
            NumberStyles style = NumberStyles.Number | NumberStyles.AllowCurrencySymbol;
            CultureInfo culture = CultureInfo.CreateSpecificCulture( "en-GB" );

            do {
                key = Console.ReadKey( true );

                // Ignore any key out of range
                if(Regex.Match( char.ToString( key.KeyChar ), "^[0-9]*$" ).Success || char.ToString( key.KeyChar ) == ".") {
                    // Append the character to the number
                    number += key.KeyChar;
                    Console.Write( key.KeyChar );
                }
                // Exit if Enter key is pressed
            } while(key.Key != ConsoleKey.Enter && key.Key != ConsoleKey.Escape);
            Console.WriteLine();

            double value;
            if(double.TryParse(number, style, culture, out value)) {
                return number;
            } else {
                if(key.Key == ConsoleKey.Escape)
                    return "!Q!";
                return "!R!";
            }
                
        }
        /// <summary>
        /// Making it possible to quit from input field
        /// </summary>
        /// <returns></returns>
        public static string GetInput() {
            string input = "";
            ConsoleKeyInfo key;

            do {
                key = Console.ReadKey( true );

                // Ignore any key out of range
                if(((int)key.Key) >= 32 && ((int)key.Key) <= 126 || char.ToString(key.KeyChar) == ".") {
                    // Append the character to the password
                    input += key.KeyChar;
                    Console.Write( key.KeyChar );
                }
                // Exit if Enter key is pressed
            } while(key.Key != ConsoleKey.Enter && key.Key != ConsoleKey.Escape);
            Console.WriteLine();

            if(key.Key == ConsoleKey.Escape)
                return "!Q!";
            else
                return input;
        }
        /// <summary>
        /// Safely gets and returns the hashed password as a string while making it possible to quit from input
        /// </summary>
        /// <returns>Hashed password input</returns>
        public static string GetHashedPass() {
            string passwd = "";
            ConsoleKeyInfo key;

            do {
                key = Console.ReadKey( true );

                // Ignore any key out of range
                if(((int)key.Key) >= 32 && ((int)key.Key) <= 126) {
                    // Append the character to the password
                    passwd += key.KeyChar;
                    Console.Write( "*" );
                }
                // Exit if Enter key is pressed
            } while(key.Key != ConsoleKey.Enter && key.Key != ConsoleKey.Escape);
            Console.WriteLine();

            if(key.Key == ConsoleKey.Escape)
                return "!Q!";
            else
                return ComputeSha256Hash( passwd );
        }

        /// <summary>
        /// Single key pressed in string format
        /// </summary>
        /// <returns>Which key has been pressed by the user</returns>
        public static string KeyPressed() {
            string key = "";
            ConsoleKeyInfo input = Console.ReadKey( true );
            key = input.KeyChar.ToString();
            return key;
        }

        /// <summary>
        /// Computes the SHA256 hash of a given string
        /// </summary>
        /// <param name="rawData">The string you want to get the has of</param>
        /// <returns>The hashed string of the given input</returns>
        public static string ComputeSha256Hash(string rawData) {
            // Create a SHA256   
            using(SHA256 sha256Hash = SHA256.Create()) {
                // ComputeHash - returns byte array  
                byte[] bytes = sha256Hash.ComputeHash( Encoding.UTF8.GetBytes( rawData ) );

                // Convert byte array to a string   
                StringBuilder builder = new StringBuilder();
                for(int i = 0; i < bytes.Length; i++) {
                    builder.Append( bytes[i].ToString( "x2" ) );
                }
                return builder.ToString();
            }
        }

        /// <summary>
        /// Easier colored output
        /// </summary>
        /// <param name="text">Your text</param>
        /// <param name="fColor">Foreground color</param>
        /// <param name="bColor">Background color</param>
        public static void Write(string text, ConsoleColor fColor, ConsoleColor bColor = ConsoleColor.Black) {
            Console.BackgroundColor = bColor;
            Console.ForegroundColor = fColor;
            Console.Write( text );
            Console.ResetColor();
        }
        /// <summary>
        /// Easier colored output with new line
        /// </summary>
        /// <param name="text">Your text</param>
        /// <param name="fColor">Foreground color</param>
        /// <param name="bColor">Background color</param>
        public static void WriteLine(string text, ConsoleColor fColor, ConsoleColor bColor = ConsoleColor.Black) {
            Console.BackgroundColor = bColor;
            Console.ForegroundColor = fColor;
            Console.Write( text );
            Console.ResetColor();
            Console.WriteLine();
        }

        /// <summary>
        /// Insert Wallet to database
        /// </summary>
        /// <param name="type">Wallet type (0/1)</param>
        /// <param name="a">Amount</param>
        /// <param name="currency">Currency</param>
        /// <param name="account_name">Account name</param>
        /// <param name="account_number">Account number</param>
        /// <param name="description">Description</param>
        /// <param name="dT">Date created at</param>
        public static void InsertWallet(int type, double a, string currency, string account_name, string account_number, string description, DateTime dT) {
            string dateTime = dT.ToString( "yyyy-MM-dd HH:mm:ss" );
            Snowbird.db.NonQuery( "INSERT INTO wallets (id,   user_id,                        type,           amount,           currency,           account_name,           account_number,           description,      created_at) " +
                                  "VALUES (             NULL, '" + Snowbird.user.UserId + "', '" + type + "', '" + a + "', '" + currency + "', '" + account_name + "', '" + account_number + "', '" + description + "', '" + dateTime + "');" );
            Snowbird.user.Update();
        }
        /// <summary>
        /// Insert Transaction to database
        /// </summary>
        /// <param name="walletId">Wallet ID</param>
        /// <param name="type">Transaction type (1/-1)</param>
        /// <param name="a">Amount</param>
        /// <param name="fromWid">Transfer initiating Wallet ID</param>
        /// <param name="toWid">Transfer reciever Wallet ID</param>
        /// <param name="description">Description</param>
        /// <param name="dT">Date created at</param>
        public static void InsertTransaction(string walletId, int type, double a, string fromWid, string toWid, string description, DateTime dT) {
            string dateTime = dT.ToString( "yyyy-MM-dd HH:mm:ss" );
            Snowbird.db.NonQuery( "INSERT INTO transactions (id,   wallet_id,          type,         amount,    fromWalletId,      toWalletId,      description,           created_at) " +
                                  "VALUES                   (NULL, '" + walletId + "', " + type + ", " + a + ", '" + fromWid + "', '" + toWid + "', '" + description + "', '" + dateTime + "');" );
            Snowbird.user.Update();
        }
        /// <summary>
        /// Update given Wallet amount to a new amount
        /// </summary>
        /// <param name="walletId">WalletID</param>
        /// <param name="type">Transaction type (income/expense)</param>
        /// <param name="amount">Transaction amount</param>
        public static void UpdateWallet(string walletId, int type, double amount) {
            Snowbird.db.NonQuery( "UPDATE wallets SET amount=amount+" + (type * amount) + " WHERE id=" + walletId + ";" );
            Snowbird.user.Update();
        }

        /// <summary>
        /// Make the program exit safely and nicely
        /// </summary>
        public static void Exit() {
            while(true) {
                Console.Clear();
                Console.Write( "\n\t\t\t\t\t\tWelcome " );

                if(!welcome)
                    Write( user.Username, ConsoleColor.Blue );
                else {
                    Console.Write("to ");
                    Write( "Snowbird Wallet", ConsoleColor.Black, ConsoleColor.White );
                }

                Console.Write( "!\n\n\t\t\t\t\t\t\t   " ); /**/ WriteLine("Quit", ConsoleColor.Black, ConsoleColor.Red);

                Console.Write( "\n\n\tAre you sure you want to " );
                Write( "QUIT", ConsoleColor.Red );
                Console.Write( "? (" ); /**/
                Write( "Y", ConsoleColor.Yellow ); /**/
                Console.Write( "/" ); /**/
                Write( "N", ConsoleColor.Yellow ); /**/
                Console.WriteLine( ")" );

                string input = KeyPressed().ToLower();

                if(input == "y") {
                    running = false;
                    WriteLine( "\n\tQuitting...", ConsoleColor.Red );
                    System.Threading.Thread.Sleep( 1000 );
                    Environment.Exit( 1 );
                } else if(input == "n") {
                    break;
                }
            }
        }
        /// <summary>
        /// Logs out the user
        /// </summary>
        public static void Logout() {
            while(true) {
                Console.Clear();
                Console.Clear();
                Console.Write( "\n\t\t\t\t\t\tWelcome " ); /**/
                Write( user.Username, ConsoleColor.Blue );
                Console.Write( "! \n\n\tAre you sure you want to " );
                Write( "LOG OUT", ConsoleColor.Red );
                Console.Write( "? (" ); /**/
                Write( "Y", ConsoleColor.Yellow ); /**/
                Console.Write( "/" ); /**/
                Write( "N", ConsoleColor.Yellow ); /**/
                Console.WriteLine( ")" );

                string input = KeyPressed().ToLower();

                if(input == "y") {
                    WriteLine( "\n\tLogging out...", ConsoleColor.Red );
                    welcome = true;
                    System.Threading.Thread.Sleep( 1000 );
                    break;
                } else if(input == "n") {
                    break;
                }
            }
        }

        // Properties
        public static bool Running {
            get { return running; }
            set { running = value; }
        }
        public static bool Login {
            get { return welcome; }
            set { welcome = value; }
        }
    }
}
