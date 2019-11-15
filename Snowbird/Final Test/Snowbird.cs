using Final_Test.Menus;

using System;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

namespace Final_Test {
    public class Snowbird {     // by Ábel

        public static Database db;
        private static bool running, login;
        public static User user;
        
        static void Main(string[] args) {

            Console.Title = "Snowbird Wallet Application";

            running = true;
            login = true;
            db = new Database( "127.0.0.1", "snowbird", "root", "" );

            while(running) {

                if(login)
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

            if(key.Key == ConsoleKey.Escape)
                return "!Q!";
            else
                return number;
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
        /// Make the program exit safely and nicely
        /// </summary>
        public static void Exit() {
            while(true) {
                Console.Clear();
                Console.Clear();
                Console.Write( "\n\t\t\t\t\t\tWelcome " );

                if(!login)
                    Write( user.Username, ConsoleColor.Blue );
                else
                    Write( "Snowbird Wallet", ConsoleColor.Black, ConsoleColor.White );

                Console.Write( "! \n\n\tAre you sure you want to " );
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
                    login = true;
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
            get { return login; }
            set { login = value; }
        }
    }
}
