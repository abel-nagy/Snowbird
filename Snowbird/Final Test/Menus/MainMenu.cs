using MySql.Data.Types;

using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Final_Test.Menus {
    
    public static class MainMenu {      // by Ábel

        static DateTime now = DateTime.Now;

        public static void Run() {
            
            while(!Snowbird.Login) {
                
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
                        Snowbird.Logout();
                        break;
                    case ConsoleKey.N:
                        Wallet.AddWallet();
                        break;
                    default:
                        string inputString = "";
                        inputString += input.KeyChar;

                        if (Regex.Match(inputString, "^[1-9]*$").Success) {
                            int choosenWallet = int.Parse( inputString );
                            if(choosenWallet <= Snowbird.user.WalletCount) {
                                now = DateTime.Now;
                                ShowWallet( (Snowbird.user.Wallets[0][choosenWallet - 1] ), choosenWallet - 1 );
                            }
                        }
                        break;
                }

            }
            
        }

        public static void ShowWallet(string walletId, int wallet) {

            bool runThis = true;

            while (runThis) {

                Console.Clear();
                Console.Write("\n\t\t\t\t\t\tWelcome "); /**/ Snowbird.Write(Snowbird.user.Username, ConsoleColor.Blue); /**/ Console.WriteLine("!");

                Console.Write( "\n\t\t\t\t\t\t" );

                if (Snowbird.user.Wallets[2][wallet] == "0")
                    Snowbird.WriteLine("Wallet", ConsoleColor.White, ConsoleColor.Cyan);
                else {

                    Snowbird.WriteLine( Snowbird.user.Wallets[5][wallet] + " - Account", ConsoleColor.White, ConsoleColor.Magenta );

                }

                if (!string.IsNullOrEmpty( Snowbird.user.Wallets[7][wallet]))
                    Console.WriteLine( "\t\t\t\t\t\t({0})", Snowbird.user.Wallets[7][wallet]);


                Console.Write( "\t\t\t\t\t\t     " ); /**/ Snowbird.WriteLine( now.Year + "-" + now.Month, ConsoleColor.Black, ConsoleColor.White);

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

                Snowbird.Write("\n\t\tIncome:     " + incomeMonth, ConsoleColor.DarkGreen); /**/ Console.WriteLine(" " + Snowbird.user.Wallets[4][wallet]);
                Snowbird.Write("\t\tExpense:    " + expenseMonth, ConsoleColor.DarkRed); /**/ Console.WriteLine(" " + Snowbird.user.Wallets[4][wallet]);
                Snowbird.Write("\t\tNet income: ", ConsoleColor.DarkYellow);

                if (incomeMonth - expenseMonth >= 0)
                    Snowbird.Write("" + (incomeMonth - expenseMonth), ConsoleColor.DarkGreen);
                else
                    Snowbird.Write("" + (incomeMonth - expenseMonth), ConsoleColor.DarkRed);

                Console.WriteLine( " " + Snowbird.user.Wallets[4][wallet] );

                Console.Write("\n\t\tMonth begin: ");
                if (amountMonthBegin >= 0)
                    Snowbird.Write("" + amountMonthBegin, ConsoleColor.DarkGreen);
                else
                    Snowbird.Write("" + amountMonthBegin, ConsoleColor.DarkRed);

                Console.WriteLine(" " + Snowbird.user.Wallets[4][wallet]);

                Console.Write("\t\tMonth end:   ");
                if (amountMonthEnd >= 0)
                    Snowbird.Write("" + amountMonthEnd, ConsoleColor.DarkGreen);
                else
                    Snowbird.Write("" + amountMonthEnd, ConsoleColor.DarkRed);

                Console.WriteLine( " " + Snowbird.user.Wallets[4][wallet] );

                Console.Write("\n\n\t("); /**/ Snowbird.Write("Enter", ConsoleColor.Yellow); /**/ Console.WriteLine(") Show details");

                Console.Write( "\n\t(" ); /**/ Snowbird.Write("T", ConsoleColor.Yellow); /**/ Console.Write(") "); /**/ Snowbird.WriteLine( "  Add Transaction", ConsoleColor.Cyan);
                Console.Write( "\t(" ); /**/ Snowbird.Write("ESC", ConsoleColor.Yellow); /**/ Console.Write(") "); /**/ Snowbird.WriteLine( "Go Back", ConsoleColor.Cyan);
                Console.Write( "\n\t(" ); /**/ Snowbird.Write( "L", ConsoleColor.Yellow ); /**/  Console.Write( ") " ); Snowbird.WriteLine( "  Logout", ConsoleColor.Red );
                Console.Write( "\t(" ); /**/ Snowbird.Write( "Q", ConsoleColor.Yellow ); /**/ Console.Write( ") " ); Snowbird.WriteLine( "  Quit", ConsoleColor.Red );

                ConsoleKeyInfo input = Console.ReadKey(true);
                switch(input.Key) {
                    case ConsoleKey.L:
                        Snowbird.Logout();
                        if(Snowbird.Login)
                            runThis = false;
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

                    case ConsoleKey.Enter:
                        ShowTransactions( walletId, wallet );
                        if(Snowbird.Login)
                            runThis = false;
                        break;

                    case ConsoleKey.T:
                        TransactionsClass.AddTransaction(walletId, wallet);
                        if(Snowbird.Login)
                            runThis = false;
                        break;
                    default:
                        break;
                }

            }

        }

        public static void ShowTransactions(string walletId, int wallet) {

            bool runThis = true;

            while(runThis) {

                Console.Clear();
                Console.Write("\n\t\t\t\t\t\tWelcome "); /**/ Snowbird.Write(Snowbird.user.Username, ConsoleColor.Blue); /**/ Console.WriteLine("!");

                Console.Write( "\n\t\t\t\t\t\t" );

                if (Snowbird.user.Wallets[2][wallet] == "0")
                    Snowbird.WriteLine("Wallet", ConsoleColor.White, ConsoleColor.Cyan);
                else {

                    Snowbird.WriteLine( Snowbird.user.Wallets[5][wallet] + " - Account", ConsoleColor.White, ConsoleColor.Magenta );

                }

                if (!string.IsNullOrEmpty( Snowbird.user.Wallets[7][wallet]))
                    Console.WriteLine( "\t\t\t\t\t\t({0})", Snowbird.user.Wallets[7][wallet]);


                Console.Write( "\t\t\t\t\t\t     " ); /**/ Snowbird.WriteLine( now.Year + "-" + now.Month, ConsoleColor.Black, ConsoleColor.White);

                Console.WriteLine("\n\t=============================================================");
                Console.WriteLine("\t= Date  = Time  = Amount  = Description ");
                Console.WriteLine("\t=============================================================");
                Console.WriteLine("\t=                                                           =");
                
                for(int i = 0; i < Snowbird.user.TransactionCount; i++) {

                    MySqlDateTime wrong = new MySqlDateTime( Snowbird.user.Transactions[7][i] );
                    DateTime trans = new DateTime( wrong.Day, wrong.Month, wrong.Year, wrong.Hour, wrong.Minute, wrong.Second );

                    if(trans.Month == now.Month && trans.Year == now.Year && Snowbird.user.Transactions[1][i] == walletId) {

                        Console.Write( "\t= {0} = {1} = ", trans.Month + "-" + trans.Day, trans.Hour + ":" + trans.Minute );

                        if(Snowbird.user.Transactions[2][i] == "1")
                            Snowbird.Write("" + Snowbird.user.Transactions[3][i], ConsoleColor.Green);
                        else
                            Snowbird.Write( "-" + Snowbird.user.Transactions[3][i], ConsoleColor.Red );

                        Console.WriteLine("\t" + Snowbird.user.Transactions[6][i]);

                        Console.WriteLine("\t=============================================================");

                    }

                }


                Console.Write( "\n\t(" ); /**/ Snowbird.Write("T", ConsoleColor.Yellow); /**/ Console.Write(") "); /**/ Snowbird.WriteLine( "  Add Transaction", ConsoleColor.Cyan);
                Console.Write( "\t(" ); /**/ Snowbird.Write("ESC", ConsoleColor.Yellow); /**/ Console.Write(") "); /**/ Snowbird.WriteLine( "Go Back", ConsoleColor.Cyan);
                Console.Write( "\n\t(" ); /**/ Snowbird.Write( "L", ConsoleColor.Yellow ); /**/  Console.Write( ") " ); Snowbird.WriteLine( "  Logout", ConsoleColor.Red );
                Console.Write( "\t(" ); /**/ Snowbird.Write( "Q", ConsoleColor.Yellow ); /**/ Console.Write( ") " ); Snowbird.WriteLine( "  Quit", ConsoleColor.Red );

                ConsoleKeyInfo input = Console.ReadKey( true );
                switch(input.Key) {
                    case ConsoleKey.L:
                        Snowbird.Logout();
                        if(Snowbird.Login)
                            runThis = false;
                        break;
                    case ConsoleKey.Q:
                        Snowbird.Exit();
                        break;
                    case ConsoleKey.Escape:
                        runThis = false;
                        break;

                    case ConsoleKey.UpArrow:
                        now = ChangeMonth( now, false );
                        break;
                    case ConsoleKey.DownArrow:
                        now = ChangeMonth( now );
                        break;
                    case ConsoleKey.LeftArrow:
                        now = ChangeMonth( now );
                        break;
                    case ConsoleKey.RightArrow:
                        now = ChangeMonth( now, false );
                        break;
                        
                    case ConsoleKey.T:
                        TransactionsClass.AddTransaction( walletId, wallet );
                        if(Snowbird.Login)
                            runThis = false;
                        break;
                    default:
                        break;
                }

            }

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
