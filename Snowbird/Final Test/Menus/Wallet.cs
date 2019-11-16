using System;
using System.Globalization;
using System.Text.RegularExpressions;

namespace Final_Test.Menus
{
    public static class Wallet {        // by Patrik and Ábel

        public static double AddWallet() {

            double amount = -1.0;
            int type = 0;
            string currency = "huf", account_name = "", account_number = "", description = "";
            bool runThis = true, runThis2 = true, good = false;
            Random rand = new Random((int)DateTime.Now.Ticks);
            
            while(runThis) {

                good = true;

                    // Type / Main
                while(runThis2 && good) {

                    good = false;
                    
                    Console.Clear();

                    Console.Write( "\n\t\t\t\t\t\tWelcome " ); /**/ Snowbird.Write( Snowbird.user.Username, ConsoleColor.Blue );
                    Console.Write( "!\n\n\t\t\t\t\t\t " ); /**/ Snowbird.Write("New wallet", ConsoleColor.Black, ConsoleColor.DarkCyan); /**/ Snowbird.WriteLine(" 1/3\n", ConsoleColor.DarkYellow);

                        // Type
                    Console.WriteLine( "\t- Choose what type of wallet do you want to add:\n" );

                    Console.Write( "\t\t(" ); /**/ Snowbird.Write( "1", ConsoleColor.Yellow ); /**/ Console.Write( ") " ); Snowbird.Write( "Wallet", ConsoleColor.Cyan); /**/ Console.WriteLine("  (Like a physical wallet)");
                    Console.Write( "\t\t(" ); /**/ Snowbird.Write( "2", ConsoleColor.Yellow ); /**/ Console.Write( ") " ); Snowbird.Write( "Account", ConsoleColor.Magenta); /**/ Console.WriteLine(" (Bank account, Savings Deposit)");

                    if(Snowbird.user.WalletCount >= 1) {
                        Console.Write( "\n\n\t(" ); /**/ Snowbird.Write("ESC", ConsoleColor.Yellow); /**/ Console.Write(") "); /**/ Snowbird.Write( "Go Back", ConsoleColor.Cyan);
                    }
                    Console.Write( "\n\n\t(" ); /**/ Snowbird.Write( "L", ConsoleColor.Yellow ); /**/  Console.Write( ") " ); Snowbird.WriteLine( "  Logout", ConsoleColor.Red );
                    Console.Write( "\t(" ); /**/ Snowbird.Write( "Q", ConsoleColor.Yellow ); /**/ Console.Write( ") " ); Snowbird.WriteLine( "  Quit", ConsoleColor.Red );

                    ConsoleKeyInfo input = Console.ReadKey( true );
                    switch(input.Key) {
                        case ConsoleKey.Q:
                            Snowbird.Exit();
                            good = true;
                            break;
                        case ConsoleKey.L:
                            Snowbird.Logout();
                            if(Snowbird.Login) {
                                runThis = false;
                                runThis2 = false;
                            }
                            break;
                        case ConsoleKey.Escape:
                            if(Snowbird.user.WalletCount >= 1) {
                                runThis = false;
                                runThis2 = false;
                            }
                            break;
                        default:
                            string inputString = "";
                            inputString += input.KeyChar;

                            if(Regex.Match( inputString, "^[1-2]*$" ).Success) {
                                type = int.Parse( inputString );
                                type--;
                                runThis2 = false;
                                good = true;
                            }
                            break;
                    }
                }

                    // Amount
                runThis2 = true;
                while(runThis2 && good) {

                    runThis2 = false;
                    good = false;

                    Console.Clear();

                    Console.Write( "\n\t\t\t\t\t\tWelcome " ); /**/ Snowbird.Write( Snowbird.user.Username, ConsoleColor.Blue );
                    Console.Write( "!\n\n\t\t\t\t\t\t" ); /**/ Snowbird.Write(" New wallet ", ConsoleColor.Black, ConsoleColor.DarkCyan); /**/ Snowbird.WriteLine(" 2/3\n", ConsoleColor.DarkYellow);
                    
                    Console.Write( "\n\t- Type in the desired initial " ); /**/ Snowbird.Write("amount", ConsoleColor.Green); /**/ Console.Write(": ");
                    string input = Snowbird.GetNumbers();

                    if(input == "!Q!") {

                        if(Snowbird.user.WalletCount >= 1)
                            runThis = false;

                    } else if(input == "!R!") {
                        good = true;
                        runThis2 = true;
                    } else {
                        amount = double.Parse( input, CultureInfo.InvariantCulture.NumberFormat );
                        good = true;
                    }
                    
                }

                    // Currency
                runThis2 = true;
                while(runThis2 && good) {

                    good = false;

                    Console.Clear();

                    Console.Write( "\n\t\t\t\t\t\tWelcome " ); /**/ Snowbird.Write( Snowbird.user.Username, ConsoleColor.Blue );
                    Console.Write( "!\n\n\t\t\t\t\t\t" ); /**/ Snowbird.Write( " New wallet ", ConsoleColor.Black, ConsoleColor.DarkCyan ); /**/ Snowbird.WriteLine( " 2/3\n", ConsoleColor.DarkYellow );

                    Console.WriteLine( "\n\t- Currency:\n" ); Console.Write( "\t\t(" ); /**/ Snowbird.Write( "1", ConsoleColor.Yellow ); /**/ Console.Write( ") " ); /**/ Snowbird.WriteLine( "HUF", ConsoleColor.Green );
                    Console.Write( "\t\t(" ); /**/ Snowbird.Write( "2", ConsoleColor.Yellow ); /**/ Console.Write( ") " ); /**/ Snowbird.WriteLine( "EUR", ConsoleColor.Green );
                    Console.Write( "\t\t(" ); /**/ Snowbird.Write( "3", ConsoleColor.Yellow ); /**/ Console.Write( ") " ); /**/ Snowbird.WriteLine( "USD", ConsoleColor.Green );

                    if(Snowbird.user.WalletCount >= 1) {
                        Console.Write( "\n\n\t(" ); /**/ Snowbird.Write( "ESC", ConsoleColor.Yellow ); /**/ Console.Write( ") " ); /**/ Snowbird.Write( "Go Back", ConsoleColor.Cyan );
                    }
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
                            if(Snowbird.Login) {
                                runThis = false;
                                runThis2 = false;
                            } else
                                good = true;
                            break;
                        case ConsoleKey.Escape:
                            if(Snowbird.user.WalletCount >= 1) {
                                runThis = false;
                                runThis2 = false;
                            }
                            break;
                        default:
                            string inputString = "";
                            inputString += input.KeyChar;

                            if(Regex.Match( inputString, "^[1-3]*$" ).Success) {
                                int curr = int.Parse( inputString );
                                switch(curr) {
                                    case 1:
                                        currency = "huf";
                                        runThis2 = false;
                                        good = true;
                                        break;
                                    case 2:
                                        currency = "eur";
                                        runThis2 = false;
                                        good = true;
                                        break;
                                    case 3:
                                        currency = "usd";
                                        runThis2 = false;
                                        good = true;
                                        break;
                                    default:
                                        break;
                                }
                            } else
                                good = true;
                            break;
                    }

                }

                    // Account
                runThis2 = true;
                while(runThis2 && good) {

                    good = false;
                    
                    if(type == 1) {

                        Console.Clear();

                        Console.Write( "\n\t\t\t\t\t\tWelcome " ); /**/ Snowbird.Write( Snowbird.user.Username, ConsoleColor.Blue );
                        Console.Write( "!\n\n\t\t\t\t\t\t" ); /**/ Snowbird.Write( " New wallet ", ConsoleColor.Black, ConsoleColor.DarkCyan ); /**/ Snowbird.WriteLine( " 3/3\n", ConsoleColor.DarkYellow );
                        Snowbird.Write("\tAccount", ConsoleColor.Magenta); /**/ Console.Write( " name: " );
                        
                        account_name = Snowbird.GetInput();

                        if(account_name != "!Q!") {

                            account_number = "00000000" + rand.Next( 10000000, 100000000 ) + rand.Next( 10000000, 100000000 );
                            good = true;
                            runThis2 = false;

                        }
                        
                    } else {
                        runThis2 = false;
                        good = true;
                        account_name = null;
                        account_number = null;
                    }
                    
                }

                    // Amount
                runThis2 = true;
                while(runThis2 && good) {

                    runThis2 = false;
                    good = false;

                    Console.Clear();

                    Console.Write( "\n\t\t\t\t\t\tWelcome " ); /**/ Snowbird.Write( Snowbird.user.Username, ConsoleColor.Blue );
                    Console.Write( "!\n\n\t\t\t\t\t\t" ); /**/ Snowbird.Write(" New wallet ", ConsoleColor.Black, ConsoleColor.DarkCyan); /**/ Snowbird.WriteLine(" 3/3\n", ConsoleColor.DarkYellow);
                    
                    Console.Write( "\n\t- Wallet description: " );
                    string input = Snowbird.GetInput();

                    if(input == "!Q!") {

                        if(Snowbird.user.WalletCount >= 1)
                            runThis = false;

                    } else {
                        description = input;
                        good = true;
                    }
                    
                }

                    // Finalizing
                runThis2 = true;
                while(runThis2 && good) {

                    good = false;

                    Console.Clear();
                    
                    Console.Write( "\n\t\t\t\t\t\tWelcome " ); /**/ Snowbird.Write( Snowbird.user.Username, ConsoleColor.Blue );
                    Console.Write( "!\n\n\t\t\t\t\t\t" ); /**/ Snowbird.Write( " New wallet ", ConsoleColor.Black, ConsoleColor.DarkCyan ); /**/ Snowbird.WriteLine( " 3/3\n", ConsoleColor.DarkYellow );

                    Console.WriteLine("\t- Your wallet details:");
                    Console.Write("\t\t- Type: ");
                    if(type == 0)
                        Snowbird.WriteLine( "Wallet", ConsoleColor.Cyan );
                    else
                        Snowbird.WriteLine( "Account", ConsoleColor.Magenta );

                    Console.Write("\t\t- Initial amount: "); /**/ Snowbird.WriteLine("" + amount, ConsoleColor.Green);
                    Console.Write("\t\t- Currency: "); /**/ Snowbird.WriteLine("" + currency, ConsoleColor.Green);
                    Console.Write("\t\t- Account name: "); /**/ Snowbird.WriteLine("" + account_name, ConsoleColor.Green);
                    Console.Write("\t\t- Account number: "); /**/ Snowbird.WriteLine("" + account_number, ConsoleColor.Green);
                    Console.WriteLine("\t\t- Description: " + description);

                    Console.Write("\n\tIs this correct? ("); /**/ Snowbird.Write("Y", ConsoleColor.Yellow); /**/ Console.Write("/"); /**/ Snowbird.Write("N", ConsoleColor.Yellow); /**/ Console.WriteLine(")");

                    if(Snowbird.user.WalletCount >= 1) {
                        Console.Write( "\n\n\t(" ); /**/ Snowbird.Write( "ESC", ConsoleColor.Yellow ); /**/ Console.Write( ") " ); /**/ Snowbird.Write( "Go Back", ConsoleColor.Cyan );
                    }
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
                            if(Snowbird.Login) {
                                runThis = false;
                                runThis2 = false;
                            } else
                                good = true;
                            break;
                        case ConsoleKey.Escape:
                            if(Snowbird.user.WalletCount >= 1)
                                runThis = false;
                            break;
                        case ConsoleKey.Y:

                                // Date
                            DateTime myDateTime = DateTime.Now;
                            string dateTime = myDateTime.ToString( "yyyy-MM-dd HH:mm:ss" );
                            
                            Snowbird.db.NonQuery( "INSERT INTO wallets (id,   user_id,                        type,           amount,           currency,           account_name,           account_number,           description,      created_at) " +
                                                  "VALUES (             NULL, '" + Snowbird.user.UserId + "', '" + type + "', '" + amount + "', '" + currency + "', '" + account_name + "', '" + account_number + "', '" + description + "', '" + dateTime + "');" );
                            Snowbird.user.Update();
                            
                            Snowbird.db.NonQuery( "INSERT INTO transactions (id,   wallet_id,          type,  amount,          fromWalletId, toWalletId, description,    created_at) " +
                                                  "VALUES                   (NULL, '" + Snowbird.user.Wallets[0][Snowbird.user.WalletCount - 1] + "', 1,     " + amount + ", NULL,         NULL,       'Initial amount', '" + dateTime + "');" );
                            Snowbird.user.Update();

                            runThis = false;

                            break;
                        case ConsoleKey.N:
                            runThis = true;
                            break;
                        default:
                            good = true;
                            break;
                    }

                }
                
            }

            return amount;
        }
        

        public static void AddTransaction() {

            bool runThis = true;

            while (runThis) {

                Console.Clear();
                Console.Write( "\n\t\t\t\t\t\tWelcome " ); /**/
                Snowbird.Write( Snowbird.user.Username, ConsoleColor.Blue );
                Console.WriteLine( "! \n\n\t- What type of transaction do you want to add?\n" );
                Console.Write( "\t\t(" ); /**/ Snowbird.Write( "1", ConsoleColor.Yellow ); /**/ Console.Write( ") " ); /**/ Snowbird.WriteLine( "Income", ConsoleColor.DarkGreen );
                Console.Write( "\t\t(" ); /**/ Snowbird.Write( "2", ConsoleColor.Yellow ); /**/ Console.Write( ") " ); /**/ Snowbird.WriteLine( "Expense", ConsoleColor.DarkRed );
                Console.Write( "\t\t(" ); /**/ Snowbird.Write( "3", ConsoleColor.Yellow ); /**/ Console.Write( ") " ); /**/ Snowbird.Write( "Transfer", ConsoleColor.DarkGreen ); /**/ Console.WriteLine(" (To your wallets)");
                Console.Write( "\t\t(" ); /**/ Snowbird.Write( "4", ConsoleColor.Yellow ); /**/ Console.Write( ") " ); /**/ Snowbird.Write( "Transfer", ConsoleColor.DarkRed ); /**/ Console.WriteLine(" (To bank account)");

                Console.Write( "\n\n\t(" ); /**/ Snowbird.Write("ESC", ConsoleColor.Yellow); /**/ Console.Write(") "); /**/ Snowbird.WriteLine( "Go Back", ConsoleColor.Cyan);
                Console.Write( "\n\t(" ); /**/ Snowbird.Write( "L", ConsoleColor.Yellow ); /**/  Console.Write( ") " ); Snowbird.WriteLine( "  Logout", ConsoleColor.Red );
                Console.Write( "\t(" ); /**/ Snowbird.Write( "Q", ConsoleColor.Yellow ); /**/ Console.Write( ") " ); Snowbird.WriteLine( "  Quit", ConsoleColor.Red );
                
                ConsoleKeyInfo input = Console.ReadKey( true );

                switch(input.Key) {
                    
                    case ConsoleKey.Escape:
                        runThis = false;
                        break;
                    case ConsoleKey.Q:
                        Snowbird.Exit();
                        break;
                    case ConsoleKey.L:
                        Snowbird.Logout();
                        break;
                    default:
                        string inputString = "";
                        inputString += input.KeyChar;

                        if(Regex.Match( inputString, "^[1-4]*$" ).Success) {
                            int inputNumber = int.Parse( inputString );
                            switch(inputNumber) {
                                case 1:
                                    AddLocalTransaction();
                                    break;
                                case 2:
                                    AddLocalTransaction(false);
                                    break;
                                case 3:
                                    break;
                                case 4:
                                    break;
                                default:
                                    Console.WriteLine("WAIT!!! WHAT THE FUCK??????");
                                    Console.ReadKey();
                                    break;
                            }
                        }

                        break;
                }
                

            }
            
        }

        public static void AddLocalTransaction(bool isIncome = true) {

            bool runThis = true;

            while(runThis) {
                Console.Clear();
                Console.Write( "\n\t\t\t\t\t\tWelcome " ); /**/
                Snowbird.Write( Snowbird.user.Username, ConsoleColor.Blue );

                Console.WriteLine( "! \n\n\t- \n" );


                ConsoleKeyInfo input = Console.ReadKey( true );

                switch(input.Key) {

                    case ConsoleKey.Escape:
                        runThis = false;
                        break;
                    case ConsoleKey.Q:
                        Snowbird.Exit();
                        break;
                    case ConsoleKey.L:
                        Snowbird.Logout();
                        break;
                    default:
                        break;
                }
            }
            
        }
    }
}
