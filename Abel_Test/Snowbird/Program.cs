using System;
using System.Collections.Generic;
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
            //MenuShit.Login_Main();
            /* END Do shit in OOP, yoo!!! */
            
            List<string>[] asd = db.Select("SELECT email, username FROM users WHERE created_at LIKE '%11-04%' ORDER BY id;", 2, new string[2]{"email", "username"});

            for (int i = 0; i < db.Count("SELECT count(*) FROM `users` WHERE created_at LIKE '%11-04%' ;"); i++) {
                Console.Write("email: {0}  username: {1}\n", asd[0][i], asd[1][i]);
            }
            
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
