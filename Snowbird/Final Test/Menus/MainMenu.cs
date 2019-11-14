using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Final_Test.Menus {
    public static class MainMenu {      // by Ábel

        private static List<string>[] wallets = Snowbird.user.Wallets;

        public static void Run() {

            Console.Clear();
            Console.Write("\n\t\t\t\t\t\tWelcome "); /**/ Snowbird.Write(Snowbird.user.Username, ConsoleColor.Blue);

            Console.WriteLine("! \n\n\t- Your wallets");
            
            for (int i = 0; i < Snowbird.user.WalletCount && Snowbird.user.WalletCount <= 9; i++) {

                Console.Write("\n\t\t("); /**/ Snowbird.Write("" + (i + 1), ConsoleColor.Yellow); /**/ Console.Write(") ");

                if (wallets[2][i] == "0") {

                    Snowbird.Write("Wallet", ConsoleColor.Green);
                    
                } else {

                    Snowbird.Write("Account", ConsoleColor.Magenta);
                    
                }

                if (!string.IsNullOrEmpty(wallets[7][i]))
                    Console.Write(" ({0})", wallets[7][i]);
                Console.Write("\n\t\t\t"); /**/ Snowbird.WriteLine(wallets[3][i] + " " + wallets[4][i], ConsoleColor.DarkCyan);

            }

            Console.Write("\n\n\n\n\t("); /**/ Snowbird.Write("0", ConsoleColor.Yellow); /**/ Console.Write(") "); Snowbird.WriteLine("Quit", ConsoleColor.Red);

            string input = Snowbird.KeyPressed();
            
            switch(input) {
                case "0":
                    Snowbird.Exit();
                    break;
                default:
                    if (Regex.Match(input, "^[1-9]*$").Success) {
                        int choosenWallet = int.Parse(input);
                        Wallet(int.Parse(wallets[0][choosenWallet - 1]), choosenWallet - 1);
                    }
                    break;
            }
            
        }

        public static void Wallet(int walletId, int wallet) {

            Console.Clear();
            Console.Write("\n\t\t\t\t\t\tWelcome "); /**/ Snowbird.WriteLine(Snowbird.user.Username, ConsoleColor.Blue);

            Console.Write("\n\t- Summary of your ");

            if (wallets[2][wallet] == "0")
                Snowbird.Write("Wallet", ConsoleColor.Green);
            else {

                Snowbird.Write("Account", ConsoleColor.Magenta);
                Console.Write("-{0}", wallets[5][wallet]);

            }

            if (!string.IsNullOrEmpty(wallets[7][wallet]))
                Console.Write(" ({0})", wallets[7][wallet]);

            Console.WriteLine();

            DateTime now = DateTime.Now;
            int incomeMonth = 0, expenseMonth = 0;
            List<string>[] trans = Snowbird.user.Transactions;

            for (int i = 0; i < Snowbird.user.TransactionCount && Convert.ToInt32(trans[1][i]) == walletId; i++) {

                DateTime transDate = Convert.ToDateTime(trans[7][i]);
                if (now.Month == transDate.Month && now.Year == transDate.Year) {

                    if (trans[2][i] == "1") {
                        incomeMonth += Convert.ToInt32(trans[3][i]);
                    } else {
                        expenseMonth += Convert.ToInt32(trans[3][i]);
                    }
                }
            }

            Console.WriteLine("\n\tIncome: " + incomeMonth + "\n\tExpense: " + expenseMonth);

            Console.ReadKey();
        }

        public static void Transactions() {

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
