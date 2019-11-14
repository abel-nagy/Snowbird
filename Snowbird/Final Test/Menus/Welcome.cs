using System;

namespace Final_Test.Menus {
    public static class Welcome {

        public static void Run() {
            Console.WriteLine("### Házi Pénztár ###\n");
            Console.WriteLine("1. Register\n2. Login\n\n0. exit");
            switch (int.Parse(Console.ReadLine()))
            {
                case 0:
                    Console.Clear();
                    Console.Write("Are you sure you want to quit? (y/n): ");
                    if (Console.ReadLine() == "y")
                        System.Environment.Exit(1);
                    break;
                case 1:
                    Login.Run();
                    break;
                case 2:
                    Register.Run();
                    break;
                default: break;
            }


        }

    }
}
