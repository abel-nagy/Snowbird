using System;

namespace Final_Test.Menus {
    public static class Welcome {

        public static void Run() {
            while (Snowbird.Running)
            {
                Console.WriteLine("### Házi Pénztár ###\n");
                Console.WriteLine("1. Register\n2. Login\n\n0. exit");
                switch (int.Parse(Console.ReadLine()))
                {
                    case 0:
                        Console.Clear();
                        Console.Write("Are you sure you want to quit? (y/n): ");
                        if (Console.ReadLine() == "y")
                        {
                            System.Environment.Exit(1);
                            Snowbird.Running = false;
                        }
                        else Snowbird.Running = true;
                        break;
                    case 1:
                        Register.Run();
                        break;
                    case 2:
                        Login.Run();
                        break;
                    default: break;
                }
            }
            


        }

    }
}
