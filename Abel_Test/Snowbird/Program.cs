using System;
using System.Security.Cryptography;
using System.Text;

namespace Snowbird
{
    class Program
    {
        public static DBConnect db;
        public static void Main(string[] args)
        {
            db = new DBConnect("127.0.0.1", "snowbird", "root", "");

            /* Do shit in OOP, yoo!!! */
            MenuShit.Login_Main();
            /* END Do shit in OOP, yoo!!! */
            
            //query = "DELETE FROM users WHERE username = 'boobsaregay';";
            //Console.WriteLine(query);
        }

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

    }
}
