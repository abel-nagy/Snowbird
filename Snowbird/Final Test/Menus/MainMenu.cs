using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Final_Test.Menus {
    public static class MainMenu {      // by Ábel

        private static List<string>[] wallets = Snowbird.user.Wallets;

        public static void Run() {

            Console.Clear();
            Console.Write("Welcome ");
            Snowbird.Write(Snowbird.user.Username, ConsoleColor.Blue);
            Console.WriteLine("! \n\nYour wallets: ");
            
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

            string input = Snowbird.KeyPressed();
            if(input == "0") {
                Snowbird.Exit();
            } else if(Regex.Match(input, "^[1-9]*$").Success) {
                int choosenWallet = int.Parse(input);
                Wallet(int.Parse(wallets[0][choosenWallet]), choosenWallet - 1);
            }

        }

        public static void Wallet(int walletId, int wallet) {
            Console.Clear();
            Console.Write("{0}, the summary on your ", Snowbird.user.Username);
            if(wallets[2][wallet] == "0") {

                Snowbird.Write("Wallet", ConsoleColor.Blue, ConsoleColor.Gray);
                
            } else {

                Snowbird.Write("Account", ConsoleColor.Blue, ConsoleColor.Gray);
                Console.Write(" - {0}", wallets[5][wallet]);

            }

            if (!string.IsNullOrEmpty(wallets[7][wallet]))
                Console.Write("  ({0})", wallets[7][wallet]);

            Console.WriteLine();
        }


        public static void AddTransaction() {

            Console.Clear();
            Console.WriteLine("What type of transaction do you want to add?");
            Console.Write("  ("); /**/ Snowbird.Write("1", ConsoleColor.Yellow); /**/ Console.Write(") "); Snowbird.WriteLine("Income", ConsoleColor.Green, ConsoleColor.Gray);
            Console.Write("  ("); /**/ Snowbird.Write("2", ConsoleColor.Yellow); /**/ Console.Write(") "); Snowbird.WriteLine("Expense", ConsoleColor.Green, ConsoleColor.Gray);
            Console.Write("  ("); /**/ Snowbird.Write("3", ConsoleColor.Yellow); /**/ Console.Write(") "); Snowbird.WriteLine("Transfer", ConsoleColor.Green, ConsoleColor.Gray);

        }

        public static void Transfer() {

        }

    }
}
