using System;

namespace Final_Test.Menus {
    public static class Welcome {

        public static void Run() {
            bool isWelcome = true;
            while (Snowbird.Running && isWelcome) {

                Console.Clear();
                Console.Write("\n\t\t\t\t\t\tWelcome to "); /**/ Snowbird.Write("Snowbird Wallet", ConsoleColor.Black, ConsoleColor.White);
                Console.Write("!\n\n\t("); /**/ Snowbird.Write("1", ConsoleColor.Yellow); /**/ Console.Write(") "); Snowbird.WriteLine("Register", ConsoleColor.Green);
                Console.Write("\t("); /**/ Snowbird.Write("2", ConsoleColor.Yellow); /**/ Console.Write(") "); Snowbird.WriteLine("Login", ConsoleColor.Blue);
                Console.Write("\n\n\t("); /**/ Snowbird.Write("0", ConsoleColor.Yellow); /**/ Console.Write(") "); Snowbird.WriteLine("Quit", ConsoleColor.Red);

                switch (int.Parse(Snowbird.KeyPressed()))
                {
                    case 0:
                        Snowbird.Exit();
                        break;
                    case 1:
                        Register.Run();
                        break;
                    case 2:
                        Login.Run();
                        isWelcome = false;
                        break;
                    default: break;
                }
            }
            


        }

    }
}
