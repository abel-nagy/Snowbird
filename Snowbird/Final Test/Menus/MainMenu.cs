using System;
using System.Collections.Generic;

namespace Final_Test.Menus {
    public static class MainMenu {

        public static void Run() {

            Console.Clear();
            Console.WriteLine("Welcome {0}! \n\nYour wallets:", Snowbird.user.Username);

            List<string>[] wallets = Snowbird.user.Wallets;

            for (int i = 0; i < Snowbird.user.WalletCount; i++) {
                if (wallets[2][i] == "0") {
                    Console.Write("  ({0}) ", i+1);
                    Snowbird.Write("Wallet", ConsoleColor.DarkRed, ConsoleColor.Gray);
                    if (!string.IsNullOrEmpty(wallets[7][i]))
                        Console.Write(" ({0})", wallets[7][i]);
                    Console.Write("\n    \t");
                    Snowbird.WriteLine(wallets[3][i] + " " + wallets[4][i], ConsoleColor.Yellow);
                } else {
                    Console.Write("  ({0}) ", i + 1);
                    Snowbird.Write("Account", ConsoleColor.DarkRed, ConsoleColor.Gray);
                    if (!string.IsNullOrEmpty(wallets[7][i]))
                        Console.Write(" ({0})", wallets[7][i]);
                    Console.Write("\n    \t");
                    Snowbird.WriteLine(wallets[3][i] + " " + wallets[4][i], ConsoleColor.Yellow);
                }

            }

        }

    }
}
