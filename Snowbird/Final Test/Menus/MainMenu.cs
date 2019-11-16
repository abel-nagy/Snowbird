using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Final_Test.Menus {
    /// <summary>
    /// 
    /// </summary>
    public static class MainMenu {      // by Ábel
        
        public static void Run() {

            bool runThis = true;

            while(runThis) {
                
                Console.Clear();
                Console.Write("\n\t\t\t\t\t\tWelcome "); /**/ Snowbird.Write(Snowbird.user.Username, ConsoleColor.Blue); /**/ Console.WriteLine("!\n\n");

                Console.WriteLine("\t- Your wallets");

                for (int i = 0; i < Snowbird.user.WalletCount && Snowbird.user.WalletCount <= 9; i++) {

                    Console.Write("\n\t\t("); /**/ Snowbird.Write("" + (i + 1), ConsoleColor.Yellow); /**/ Console.Write(") ");

                    if (Snowbird.user.Wallets[2][i] == "0") {

                        Snowbird.Write("Wallet", ConsoleColor.Cyan);

                    } else {

                        Snowbird.Write("Account", ConsoleColor.Magenta);

                    }

                    if (!string.IsNullOrEmpty( Snowbird.user.Wallets[7][i]))
                        Console.Write(" ({0})", Snowbird.user.Wallets[7][i]);
                    Console.Write("\n\t\t\t"); /**/ Snowbird.WriteLine( Snowbird.user.Wallets[3][i] + " " + Snowbird.user.Wallets[4][i], ConsoleColor.Green);

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
                        runThis = false;
                        Snowbird.Logout();
                        break;
                    case ConsoleKey.N:
                        Wallet.AddWallet();
                        if(Snowbird.Login)
                            runThis = false;
                        break;
                    default:
                        string inputString = "";
                        inputString += input.KeyChar;

                        if (Regex.Match(inputString, "^[1-9]*$").Success) {
                            int choosenWallet = int.Parse( inputString );
                            if(choosenWallet <= Snowbird.user.WalletCount) {
                                ShowWallet( (Snowbird.user.Wallets[0][choosenWallet - 1] ), choosenWallet - 1 );
                            }
                        }
                        break;
                }

            }
            
        }

        public static void ShowWallet(string walletId, int wallet) {

            bool runThis = true;
            DateTime now = DateTime.Now;

            while (runThis) {

                Console.Clear();
                Console.Write("\n\t\t\t\t\t\tWelcome "); /**/ Snowbird.WriteLine(Snowbird.user.Username, ConsoleColor.Blue); /**/ Console.WriteLine("!");

                Console.Write("\n\t- Summary of your ");

                if (Snowbird.user.Wallets[2][wallet] == "0")
                    Snowbird.Write("Wallet", ConsoleColor.Cyan);
                else {

                    Snowbird.Write("Account", ConsoleColor.Magenta);
                    Console.Write("-{0}", Snowbird.user.Wallets[5][wallet]);

                }

                if (!string.IsNullOrEmpty( Snowbird.user.Wallets[7][wallet]))
                    Console.Write(" ({0})", Snowbird.user.Wallets[7][wallet]);
                

                Console.Write(" in "); /**/ Snowbird.WriteLine(now.Year + "-" + now.Month, ConsoleColor.Black, ConsoleColor.White);

                float incomeMonth = 0, expenseMonth = 0, amountMonthBegin = 0, amountMonthEnd = 0;
                List<string>[] trans = Snowbird.user.Transactions;

                for (int i = 0; i < Snowbird.user.TransactionCount; i++) {

                    if (trans[1][i] == walletId) {
                        DateTime transDate = Convert.ToDateTime(trans[7][i]);

                        if (now.Month == transDate.Month && now.Year == transDate.Year) {

                            if (trans[2][i] == "1") {
                                incomeMonth += float.Parse(trans[3][i]);
                            } else {
                                expenseMonth += float.Parse( trans[3][i] );
                            }
                        } else if (now.Month > transDate.Month && now.Year == transDate.Year) {
                            amountMonthBegin += float.Parse( trans[2][i] ) * float.Parse( trans[3][i] );
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

                Console.Write( "\n\n\t(" ); /**/ Snowbird.Write("T", ConsoleColor.Yellow); /**/ Console.Write(") "); /**/ Snowbird.WriteLine( "  Add Transaction", ConsoleColor.Cyan);
                Console.Write( "\t(" ); /**/ Snowbird.Write("ESC", ConsoleColor.Yellow); /**/ Console.Write(") "); /**/ Snowbird.WriteLine( "Go Back", ConsoleColor.Cyan);
                Console.Write( "\n\t(" ); /**/ Snowbird.Write( "L", ConsoleColor.Yellow ); /**/  Console.Write( ") " ); Snowbird.WriteLine( "  Logout", ConsoleColor.Red );
                Console.Write( "\t(" ); /**/ Snowbird.Write( "Q", ConsoleColor.Yellow ); /**/ Console.Write( ") " ); Snowbird.WriteLine( "  Quit", ConsoleColor.Red );

                ConsoleKeyInfo input = Console.ReadKey(true);
                switch(input.Key) {

                    case ConsoleKey.L:
                        Snowbird.Logout();
                        break;
                    case ConsoleKey.Q:
                        Snowbird.Exit();
                        break;
                    case ConsoleKey.Escape:
                        runThis = false;
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
                        Wallet.AddTransaction();
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
