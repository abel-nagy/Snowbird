using System;

namespace Final_Test.Menus {
    public static class Welcome {

        public static void Run() {
            bool isWelcome = true, registered = false;
            while (Snowbird.Running && isWelcome) {

                Console.Clear();
                Console.Write("\n\t\t\t\t\t\tWelcome to "); /**/ Snowbird.Write("Snowbird Wallet", ConsoleColor.Black, ConsoleColor.White);
                Console.Write("!\n\n");
                if(registered) {
                    Console.Write( "\tCongratulations! You " ); /**/ Snowbird.Write("successfully ", ConsoleColor.DarkGreen); /**/ Snowbird.Write( "REGISTERED", ConsoleColor.Green ); /**/ Console.WriteLine("!\n");
                } else {
                    Console.Write("\n\n");
                }
                Console.Write("\t("); /**/ Snowbird.Write("1", ConsoleColor.Yellow); /**/ Console.Write(") "); Snowbird.WriteLine("Register", ConsoleColor.Green);
                Console.Write("\t("); /**/ Snowbird.Write("2", ConsoleColor.Yellow); /**/ Console.Write(") "); Snowbird.WriteLine("Login", ConsoleColor.Blue);
                Console.Write("\n\n\t("); /**/ Snowbird.Write("Q", ConsoleColor.Yellow); /**/ Console.Write(") "); Snowbird.WriteLine("Quit", ConsoleColor.Red);

                ConsoleKeyInfo input = Console.ReadKey(true);
                switch (input.Key) {
                    case ConsoleKey.Q:
                        Snowbird.Exit();
                        break;
                    case ConsoleKey.D1:
                        registered = Register.Run();
                        break;
                    case ConsoleKey.D2:
                        Login.Run();
                        isWelcome = false;
                        break;
                    default: break;
                }
            }
            


        }

    }
}
