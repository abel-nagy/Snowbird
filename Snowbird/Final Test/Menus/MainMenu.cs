using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Final_Test.Menus {
    /// <summary>
    /// 
    /// </summary>
    public static class MainMenu {      // by Ábel

        private static List<string>[] wallets;

        /// <summary>
        /// 
        /// </summary>
        public static void Run() {

            bool isMainMenu = true;

            while(isMainMenu) {

                wallets = Snowbird.user.Wallets;

                Console.Clear();
                Console.Write("\n\t\t\t\t\t\tWelcome "); /**/ Snowbird.Write(Snowbird.user.Username, ConsoleColor.Blue);

                Console.WriteLine("! \n\n\t- Your wallets");

                for (int i = 0; i < Snowbird.user.WalletCount && Snowbird.user.WalletCount <= 9; i++) {

                    Console.Write("\n\t\t("); /**/ Snowbird.Write("" + (i + 1), ConsoleColor.Yellow); /**/ Console.Write(") ");

                    if (wallets[2][i] == "0") {

                        Snowbird.Write("Wallet", ConsoleColor.Cyan);

                    } else {

                        Snowbird.Write("Account", ConsoleColor.Magenta);

                    }

                    if (!string.IsNullOrEmpty(wallets[7][i]))
                        Console.Write(" ({0})", wallets[7][i]);
                    Console.Write("\n\t\t\t"); /**/ Snowbird.WriteLine(wallets[3][i] + " " + wallets[4][i], ConsoleColor.Green);

                }

                Console.Write("\n\n\t("); /**/ Snowbird.Write("N", ConsoleColor.Yellow); /**/ Console.Write(") "); Snowbird.WriteLine("New Wallet/Account", ConsoleColor.DarkCyan);

                Console.Write("\n\t("); /**/ Snowbird.Write("L", ConsoleColor.Yellow); /**/ Console.Write(") "); Snowbird.WriteLine("Logout", ConsoleColor.Red);
                Console.Write("\t("); /**/ Snowbird.Write("Q", ConsoleColor.Yellow); /**/ Console.Write(") "); Snowbird.WriteLine("Quit", ConsoleColor.Red);

                ConsoleKeyInfo input = Console.ReadKey(true);
                switch (input.Key) {
                    case ConsoleKey.Q:
                        Snowbird.Exit();
                        break;
                    case ConsoleKey.L:
                        isMainMenu = false;
                        Snowbird.Logout();
                        break;
                    case ConsoleKey.N:
                        addWallets.Run();
                        break;
                    default:
                        string inputString = "";
                        inputString += input.KeyChar;

                        if (Regex.Match(inputString, "^[1-9]*$").Success) {
                            int choosenWallet = int.Parse( inputString );
                            if(choosenWallet <= Snowbird.user.WalletCount) {
                                Wallet( int.Parse( wallets[0][choosenWallet - 1] ), choosenWallet - 1 );
                            }
                        }
                        break;
                }

            }
            
        }

        public static void Wallet(int walletId, int wallet) {

            bool isWallet = true;
            DateTime now = DateTime.Now;

            while (isWallet) {

                Console.Clear();
                Console.Write("\n\t\t\t\t\t\tWelcome "); /**/ Snowbird.WriteLine(Snowbird.user.Username, ConsoleColor.Blue);

                Console.Write("\n\t- Summary of your ");

                if (wallets[2][wallet] == "0")
                    Snowbird.Write("Wallet", ConsoleColor.Cyan);
                else {

                    Snowbird.Write("Account", ConsoleColor.Magenta);
                    Console.Write("-{0}", wallets[5][wallet]);

                }

                if (!string.IsNullOrEmpty(wallets[7][wallet]))
                    Console.Write(" ({0})", wallets[7][wallet]);
                

                Console.Write(" in "); /**/ Snowbird.WriteLine(now.Year + "-" + now.Month, ConsoleColor.Black, ConsoleColor.White);

                int incomeMonth = 0, expenseMonth = 0, amountMonthBegin = 0, amountMonthEnd = 0;
                List<string>[] trans = Snowbird.user.Transactions;

                for (int i = 0; i < Snowbird.user.TransactionCount; i++) {

                    if (Convert.ToInt32(trans[1][i]) == walletId) {
                        DateTime transDate = Convert.ToDateTime(trans[7][i]);

                        if (now.Month == transDate.Month && now.Year == transDate.Year) {

                            if (trans[2][i] == "1") {
                                incomeMonth += Convert.ToInt32(trans[3][i]);
                            } else {
                                expenseMonth += Convert.ToInt32(trans[3][i]);
                            }
                        } else if (now.Month > transDate.Month && now.Year == transDate.Year) {
                            amountMonthBegin += Convert.ToInt32(trans[2][i]) * Convert.ToInt32(trans[3][i]);
                        }
                    }
                }

                amountMonthEnd = amountMonthBegin + incomeMonth - expenseMonth;

                Snowbird.WriteLine("\n\t\tIncome:     " + incomeMonth, ConsoleColor.DarkGreen);
                Snowbird.WriteLine("\t\tExpense:    " + expenseMonth, ConsoleColor.DarkRed);
                Snowbird.Write("\t\tNet income: ", ConsoleColor.DarkYellow);
                if (incomeMonth - expenseMonth >= 0)
                    Snowbird.WriteLine("" + (incomeMonth - expenseMonth), ConsoleColor.DarkGreen);
                else
                    Snowbird.WriteLine("" + (incomeMonth - expenseMonth), ConsoleColor.DarkRed);

                Console.Write("\n\t\tMonth begin: ");
                if (amountMonthBegin >= 0)
                    Snowbird.WriteLine("" + amountMonthBegin, ConsoleColor.DarkGreen);
                else
                    Snowbird.WriteLine("" + amountMonthBegin, ConsoleColor.DarkRed);
                Console.Write("\t\tMonth end:   ");
                if (amountMonthEnd >= 0)
                    Snowbird.WriteLine("" + amountMonthEnd, ConsoleColor.DarkGreen);
                else
                    Snowbird.WriteLine("" + amountMonthEnd, ConsoleColor.DarkRed);

                Console.Write("\n\n\t("); /**/ Snowbird.Write("T", ConsoleColor.Yellow); /**/ Console.Write(") "); Snowbird.WriteLine("Add Transaction", ConsoleColor.DarkCyan);
                Console.Write("\t("); /**/ Snowbird.Write("Q", ConsoleColor.Yellow); /**/ Console.Write(") "); Snowbird.WriteLine("Quit", ConsoleColor.Red);

                ConsoleKeyInfo input = Console.ReadKey(true);
                switch(input.Key) {

                    case ConsoleKey.D0:
                        isWallet = false;
                        Snowbird.Exit();
                        break;
                    case ConsoleKey.Escape:
                        isWallet = false;
                        break;

                    case ConsoleKey.UpArrow:
                        now = ChangeMonth(now, false);
                        break;
                    case ConsoleKey.DownArrow:
                        now = ChangeMonth(now);
                        break;
                    case ConsoleKey.LeftArrow:
                        now = ChangeMonth(now);
                        break;
                    case ConsoleKey.RightArrow:
                        now = ChangeMonth(now, false);
                        break;
                    case ConsoleKey.T:
                        addWallets.AddTransaction();
                        break;
                    default:
                        break;
                }

            }

        }

        public static void Transactions(DateTime date, int wallet, string walletId) {

        }

        /// <summary>
        /// Increase or decreases a DateTime's month (and year)
        /// </summary>
        /// <param name="time">Starting DateTime</param>
        /// <param name="negative">Should I decrease month?</param>
        /// <returns>Decreased/Increased DateTime</returns>
        public static DateTime ChangeMonth(DateTime time, bool negative = true) {

            int month = time.Month, year = time.Year;

            if(negative) {
                if(month == 1) {
                    year--;
                    month = 12;
                } else {
                    month--;
                }
            } else {
                if(month == 12) {
                    year++;
                    month = 1;
                } else {
                    month++;
                }
            }
            return new DateTime(year, month, 1);
        }

    }
}
