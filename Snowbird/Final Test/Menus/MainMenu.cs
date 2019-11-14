using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Final_Test.Menus {
    public static class MainMenu {      // by Ábel

        public static void Run() {

            Console.Clear();
            Console.Write("Welcome ");
            Snowbird.Write(Snowbird.user.Username, ConsoleColor.Blue);
            Console.WriteLine("! \n\nYour wallets: ");

            List<string>[] wallets = Snowbird.user.Wallets;

            for (int i = 0; i < Snowbird.user.WalletCount; i++) {
                if (wallets[2][i] == "0") {
                    Console.Write("  ({0}) ", i+1);
                    Snowbird.Write("Wallet", ConsoleColor.Blue, ConsoleColor.Gray);
                    if (!string.IsNullOrEmpty(wallets[7][i]))
                        Console.Write(" ({0})", wallets[7][i]);
                    Console.Write("\n    \t");
                    Snowbird.WriteLine(wallets[3][i] + " " + wallets[4][i], ConsoleColor.Yellow);
                } else {
                    Console.Write("  ({0}) ", i + 1);
                    Snowbird.Write("Account", ConsoleColor.Blue, ConsoleColor.Gray);
                    if (!string.IsNullOrEmpty(wallets[7][i]))
                        Console.Write(" ({0})", wallets[7][i]);
                    Console.Write("\n    \t");
                    Snowbird.WriteLine(wallets[3][i] + " " + wallets[4][i], ConsoleColor.Yellow);
                }
            }

            string input = Snowbird.keyPressed();
            if(input == "0") {
                Snowbird.Exit();
            } else if(Regex.Match(input, "^[1-9]*$").Success) {
                int choosenWallet = int.Parse(input); ;
            }

        }


        public static void AddTransaction() {

            Console.Clear();
            Console.Write("What type of transaction do you want to add?\n\t(1) ");
            Snowbird.WriteLine("Income", ConsoleColor.Red);
            Console.Write("\t(2) ");
            Snowbird.WriteLine("Expense", ConsoleColor.Red);

        }

    }
}
