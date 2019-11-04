using System;

namespace Snowbird
{
    class Program
    {
        
        static void Main(string[] args)
        {
            DBConnect db = new DBConnect("127.0.0.1", "snowbird", "root", "");
            string email = "", 
                   username = "asd", 
                   password = "";

            DateTime myDateTime = DateTime.Now;
            string dateTime = myDateTime.ToString("yyyy-MM-dd HH:mm:ss");
            string query = "";
            query = "INSERT INTO `users` (`email`, `username`, `password`, `created_at`) VALUES('" + email + "', '" + username + "', '" + password + "', '" + dateTime + "');";
            query = "UPDATE users SET username = '" + username+ "' WHERE user_id = 100000007;";
            query = "DELETE FROM users WHERE username = 'boobsaregay';";
            Console.WriteLine(query);
            db.NonQuery(query);
        }

    }
}
