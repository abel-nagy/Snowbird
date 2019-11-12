using Final_Test.Menus;

using System;
using System.Security.Cryptography;
using System.Text;

namespace Final_Test {
    public class Snowbird {

        public static Database db;
        private static bool running;
        public static User user;


        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args) {
            running = true;
            db = new Database("127.0.0.1", "snowbird", "root", "");

            Register.Run();
            
            //while(running) {
                
            //}
        }


        /// <summary>
        /// Safely gets and returns the hashed password as a string
        /// </summary>
        /// <returns>The SHA256 hashed password</returns>
        public static string getHashedPass() {
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
        public static string keyPressed() {
            string key = "";
            ConsoleKeyInfo ans = Console.ReadKey(true);
            key = ans.KeyChar.ToString();
            return key;
        }

        // Properties
        public bool Running {
            get { return running; }
            set { running = value; }
        }
    }
}
