using Final_Test.Menus;

using System;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

namespace Final_Test {
    public class Snowbird {     // by Ábel

        public static Database db;
        private static bool running;
        public static User user;
        
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args) {

            Console.Title = "Snowbird Wallet Application";

            running = true;
            db = new Database("127.0.0.1", "snowbird", "root", "");

            Welcome.Run();
            while (running) {
                MainMenu.Run();
            }
        }


        /// <summary>
        /// Safely gets and returns the hashed password as a string
        /// </summary>
        /// <returns>The SHA256 hashed password</returns>
        public static string GetHashedPass() {
            string passwd = "";
            ConsoleKeyInfo key;

            do {
                key = Console.ReadKey(true);

                // Ignore any key out of range
                if (((int)key.Key) >= 32 && ((int)key.Key) <= 126) {
                    // Append the character to the password
                    passwd += key.KeyChar;
                    Console.Write("*");
                }
                // Exit if Enter key is pressed
            } while (key.Key != ConsoleKey.Enter);
            Console.WriteLine();

            return ComputeSha256Hash(passwd);
        }
        /// <summary>
        /// Computes the SHA256 hash of a given string
        /// </summary>
        /// <param name="rawData">The string you want to get the has of</param>
        /// <returns>The hashed string of the given input</returns>
        public static string ComputeSha256Hash(string rawData) {
            // Create a SHA256   
            using (SHA256 sha256Hash = SHA256.Create()) {
                // ComputeHash - returns byte array  
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));

                // Convert byte array to a string   
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++) {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }

        /// <summary>
        /// Single key pressed in string format
        /// </summary>
        /// <returns>Which key has been pressed by the user</returns>
        public static string KeyPressed() {
            string key = "";
            ConsoleKeyInfo ans = Console.ReadKey(true);
            key = ans.KeyChar.ToString();
            return key;
        }
        /// <summary>
        /// Get only numbers from User
        /// </summary>
        /// <returns></returns>
        public static string GetNumbers() {
            string number = "";
            ConsoleKeyInfo key;

            do {
                key = Console.ReadKey(true);

                // Ignore any key out of range
                if( Regex.Match(char.ToString(key.KeyChar), "^[0-9]*$").Success || char.ToString(key.KeyChar) == "." ) {
                    // Append the character to the number
                    number += key.KeyChar;
                    Console.Write(key.KeyChar);
                }
                // Exit if Enter key is pressed
            } while (key.Key != ConsoleKey.Enter);
            Console.WriteLine();

            return number;
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
            Console.Write(text);
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
            Console.Write(text);
            Console.ResetColor();
            Console.WriteLine();
        }

        /// <summary>
        /// Make the program exit safely and nicely
        /// </summary>
        public static void Exit() {
            Console.Clear();
            Console.Write("Are you sure you want to ");
            Write("QUIT",ConsoleColor.Red, ConsoleColor.White);
            Console.Write("? ("); /**/ Write("y", ConsoleColor.Yellow); /**/ Console.Write("/"); /**/ Write("n", ConsoleColor.Yellow); /**/ Console.WriteLine(")");

            if (KeyPressed().ToLower() == "y") {
                running = false;
                WriteLine("Quitting...", ConsoleColor.Red, ConsoleColor.White);
                System.Threading.Thread.Sleep(2000);
                System.Environment.Exit(1);
            }
        }

        // Properties
        public static bool Running {
            get { return running; }
            set { running = value; }
        }
    }
}
