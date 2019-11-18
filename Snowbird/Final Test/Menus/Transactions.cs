using System;
using System.Globalization;
using System.Text.RegularExpressions;

namespace Final_Test.Menus {

    class TransactionsClass {

        public static void AddTransaction(string walletId, int wallet) {

            int type = 1;
            double amount = 0.0;
            string description = "";
            DateTime dateTime;

            bool runThis = true, runThis2 = true, good = false;

            while(runThis) {

                good = true;

                        // Type (income/expense)
                while(runThis2 && good) {

                    good = false;

                    Console.Clear();
                    Console.Write("\n\t\t\t\t\t\tWelcome "); /**/ Snowbird.Write(Snowbird.user.Username, ConsoleColor.Blue); /**/ Console.WriteLine("!\n\n");

                    Console.Write( "\t\t\t\t\t   Add transaction to ");
                    if(Snowbird.user.Wallets[2][wallet] == "0")
                        Snowbird.WriteLine( "Wallet ", ConsoleColor.Cyan );
                    else
                        Snowbird.WriteLine("Account ", ConsoleColor.Magenta);

                    if( !string.IsNullOrEmpty(Snowbird.user.Wallets[7][wallet]))
                        Console.WriteLine( "\t\t\t\t\t\t  (" + Snowbird.user.Wallets[7][wallet] + ")\n");

                    Console.WriteLine("\t- What type of transaction do you want to register?");

                    Console.Write("\t\t("); /**/ Snowbird.Write("1", ConsoleColor.Yellow); /**/ Console.Write(") "); /**/ Snowbird.WriteLine("Income", ConsoleColor.Green);
                    Console.Write("\t\t("); /**/ Snowbird.Write("2", ConsoleColor.Yellow); /**/ Console.Write(") "); /**/ Snowbird.WriteLine("Expense", ConsoleColor.Red);

                    ConsoleKeyInfo input = Console.ReadKey( true );
                    switch (input.Key) {

                        case ConsoleKey.Q:
                            Snowbird.Exit();
                            good = true;
                            break;
                        case ConsoleKey.L:
                            Snowbird.Logout();
                            if(Snowbird.Login) {
                                runThis = false;
                                runThis2 = false;
                            } else {
                                good = true;
                            }
                            break;
                        case ConsoleKey.Escape:
                            runThis = false;
                            break;
                        default:
                            string inputString = "";
                            inputString += input.KeyChar;

                            if(Regex.Match( inputString, "^[1-2]*$" ).Success) {
                                switch(inputString) {
                                    case "1":
                                        type = 1;
                                        good = true;
                                        runThis2 = false;
                                        break;
                                    case "2":
                                        type = -1;
                                        good = true;
                                        runThis2 = false;
                                        break;
                                }
                            }
                            break;
                    }
                }

                    // Amount
                runThis2 = true;
                while(runThis2 && good) {

                    good = false;

                    Console.Write("\n\t- Amount: ");
                    string input = Snowbird.GetNumbers();

                    if(input == "!Q!") {
                        runThis = false;
                    } else if(input == "!R!") {
                        good = true;
                    } else {
                        amount = double.Parse( input, CultureInfo.InvariantCulture.NumberFormat );
                        runThis2 = false;
                        good = true;
                    }
                
                }

                    // Description
                runThis2 = true;
                while(runThis2 && good) {

                    good = false;

                    Console.Write("\n\t- Transaction description: ");
                    string input = Snowbird.GetInput();

                    if(input == "!Q!") {
                        runThis = false;
                    } else {
                        description = input;
                        runThis2 = false;
                        good = true;
                    }

                }

                    // Finalizing
                runThis2 = true;
                while(runThis2 && good) {

                    good = false;

                    Console.Clear();

                    Console.Write( "\n\t\t\t\t\t\tWelcome " ); /**/ Snowbird.Write( Snowbird.user.Username, ConsoleColor.Blue ); /**/ Console.WriteLine("!\n");

                    Console.Write( "\t\t\t\t\t   Add transaction to " );
                    if(Snowbird.user.Wallets[2][wallet] == "0")
                        Snowbird.WriteLine( "Wallet ", ConsoleColor.Cyan );
                    else
                        Snowbird.WriteLine( "Account ", ConsoleColor.Magenta );

                    if(!string.IsNullOrEmpty( Snowbird.user.Wallets[7][wallet] ))
                        Console.WriteLine( "\t\t\t\t\t\t  (" + Snowbird.user.Wallets[7][wallet] + ")\n" );

                    Console.WriteLine( "\t- Your transaction details:" );

                    Console.Write( "\t\t- Wallet: " ); /**/
                    if(Snowbird.user.Wallets[2][wallet] == "0")
                        Snowbird.Write( "Wallet ", ConsoleColor.Cyan );
                    else
                        Snowbird.Write( Snowbird.user.Wallets[5][wallet] + " - Account", ConsoleColor.Magenta );

                    if(!string.IsNullOrEmpty( Snowbird.user.Wallets[7][wallet] ))
                        Console.WriteLine( " (" + Snowbird.user.Wallets[7][wallet] + ")" );
                    else
                        Console.WriteLine();

                    Console.Write( "\t\t- Transaction type: " );
                    if(type == 1)
                        Snowbird.WriteLine( "Income", ConsoleColor.Green );
                    else
                        Snowbird.WriteLine( "Expense", ConsoleColor.Red );
                
                    Console.WriteLine( "\t\t- Transaction amount: " + amount);

                    Console.WriteLine( "\t\t. Description: " + description);

                    Console.Write("\n\tIs this correct? ("); /**/ Snowbird.Write("Y", ConsoleColor.Yellow); /**/ Console.Write("/"); /**/ Snowbird.Write("N", ConsoleColor.Yellow); /**/ Console.WriteLine(")");
                    Console.Write( "\n\n\t(" ); /**/ Snowbird.Write( "ESC", ConsoleColor.Yellow ); /**/ Console.Write( ") " ); /**/ Snowbird.Write( "Go Back", ConsoleColor.Cyan );
                    Console.Write( "\n\n\t(" ); /**/ Snowbird.Write( "L", ConsoleColor.Yellow ); /**/ Console.Write( ") " ); Snowbird.WriteLine( "  Logout", ConsoleColor.Red );
                    Console.Write( "\t(" ); /**/ Snowbird.Write( "Q", ConsoleColor.Yellow ); /**/ Console.Write( ") " ); Snowbird.WriteLine( "  Quit", ConsoleColor.Red );

                    ConsoleKeyInfo input = Console.ReadKey( true );
                    switch(input.Key) {
                        case ConsoleKey.Q:
                            Snowbird.Exit();
                            good = true;
                            break;
                        case ConsoleKey.L:
                            Snowbird.Logout();
                            if( Snowbird.Login ) {
                                runThis = false;
                            } else {
                                good = true;
                            }
                            break;
                        case ConsoleKey.Escape:
                            runThis = false;
                            break;
                        case ConsoleKey.Y:
                            dateTime = DateTime.Now;

                            Snowbird.InsertTransaction( walletId, type, amount, null, null, description, dateTime );
                            Snowbird.UpdateWallet( walletId, type, amount );

                            runThis = false;
                            break;
                        case ConsoleKey.N:
                            break;
                        default:
                            good = true;
                            break;
                    }
                        
                }

            }
            
        }
        

    }
}
