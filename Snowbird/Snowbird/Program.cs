using System;

namespace Snowbird
{
    class Program
    {
        
        static void Main(string[] args)
        {
            DBConnect db = new DBConnect("localhost", "snowbird", "", "");
            db.Insert("INSERT INTO `users` (`user_id`, `email`, `username`, `password`, `created_at`) VALUES (NULL, 'adam.patrik.sztk@gmail.com', 'adampatrik', 'dsadasdasd', '2019-11-01 00:00:00')");
        }

    }
}
