using System;
using System.Globalization;
using System.Text.RegularExpressions;

namespace Final_Test.Menus
{
    public static class Wallet {        // by Patrik and Ábel

        public static double AddWallet() {

            double amount = -1.0;

            bool runThis = true;
            while(runThis) {

                int type = 0;

                bool runThis2 = true;
                while(runThis2) {

                    Console.Clear();

                    Console.Write( "\n\t\t\t\t\t\tWelcome " ); /**/ Snowbird.Write( Snowbird.user.Username, ConsoleColor.Blue );
                    Console.Write( "!\n\n\t\t\t\t\t\t " ); /**/ Snowbird.Write("New wallet", ConsoleColor.Black, ConsoleColor.DarkCyan); /**/ Snowbird.WriteLine(" 1/3\n", ConsoleColor.DarkYellow);

                        // Type
                    Console.WriteLine( "\t- Choose what type of wallet do you want to add:\n" );

                    Console.Write( "\t\t(" ); /**/ Snowbird.Write( "1", ConsoleColor.Yellow ); /**/ Console.Write( ") " ); Snowbird.Write( "Wallet", ConsoleColor.Cyan); /**/ Console.WriteLine("  (Like a physical wallet)");
                    Console.Write( "\t\t(" ); /**/ Snowbird.Write( "2", ConsoleColor.Yellow ); /**/ Console.Write( ") " ); Snowbird.Write( "Account", ConsoleColor.Magenta); /**/ Console.WriteLine(" (Bank account, Savings Deposit)");

                    Console.Write( "\n\n\t(" ); /**/ Snowbird.Write("ESC", ConsoleColor.Yellow); /**/ Console.Write(") "); /**/ Snowbird.WriteLine( "Go Back", ConsoleColor.Cyan);
                    Console.Write( "\n\t(" ); /**/ Snowbird.Write( "L", ConsoleColor.Yellow ); /**/  Console.Write( ") " ); Snowbird.WriteLine( "  Logout", ConsoleColor.Red );
                    Console.Write( "\t(" ); /**/ Snowbird.Write( "Q", ConsoleColor.Yellow ); /**/ Console.Write( ") " ); Snowbird.WriteLine( "  Quit", ConsoleColor.Red );

                    ConsoleKeyInfo input = Console.ReadKey( true );
                    switch(input.Key) {
                        case ConsoleKey.Q:
                            Snowbird.Exit();
                            runThis = false;
                            runThis2 = false;
                            break;
                        case ConsoleKey.L:
                            Snowbird.Logout();
                            runThis = false;
                            runThis2 = false;
                            break;
                        case ConsoleKey.Escape:
                            runThis = false;
                            runThis2 = false;
                            break;
                        default:
                            string inputString = "";
                            inputString += input.KeyChar;

                            if(Regex.Match( inputString, "^[1-2]*$" ).Success) {
                                type = int.Parse( inputString );
                                runThis2 = false;
                            }
                            break;
                    }
                }

                runThis2 = true;
                while(runThis2 && runThis) {

                    runThis2 = false;

                    Console.Clear();

                    Console.Write( "\n\t\t\t\t\t\tWelcome " ); /**/ Snowbird.Write( Snowbird.user.Username, ConsoleColor.Blue );
                    Console.Write( "!\n\n\t\t\t\t\t\t" ); /**/ Snowbird.Write(" New wallet ", ConsoleColor.Black, ConsoleColor.DarkCyan); /**/ Snowbird.WriteLine(" 2/3\n", ConsoleColor.DarkYellow);

                        // Amount
                    Console.Write( "\n\t- Type in the desired Initial amount: " );
                    string input = Snowbird.GetNumbers();

                    if(input == "!Q!") {
                        runThis = false;
                        runThis2 = false;
                    } else if(input == "!R!") {
                        runThis2 = true;
                    } else {

                        amount = double.Parse( input, CultureInfo.InvariantCulture.NumberFormat );

                            // Currency
                        string currency = "huf";

                        Console.WriteLine( "\n\tCurrency:\n" );
                        Console.Write( "\t\t(" ); /**/ Snowbird.Write( "1", ConsoleColor.Yellow ); /**/ Console.Write( ") " ); /**/ Snowbird.WriteLine( "HUF", ConsoleColor.Green );
                        Console.Write( "\t\t(" ); /**/ Snowbird.Write( "2", ConsoleColor.Yellow ); /**/ Console.Write( ") " ); /**/ Snowbird.WriteLine( "EUR", ConsoleColor.Green );
                        Console.Write( "\t\t(" ); /**/ Snowbird.Write( "3", ConsoleColor.Yellow ); /**/ Console.Write( ") " ); /**/ Snowbird.WriteLine( "USD", ConsoleColor.Green );

                        switch(Snowbird.KeyPressed()) {
                            case "1":
                                currency = "huf";
                                runThis2 = false;
                                break;
                            case "2":
                                currency = "eur";
                                runThis2 = false;
                                break;
                            case "3":
                                currency = "usd";
                                runThis2 = false;
                                break;
                            default:
                                break;
                        }

                        // Date
                        DateTime myDateTime = DateTime.Now;
                        string dateTime = myDateTime.ToString( "yyyy-MM-dd HH:mm:ss" );

                        Random r = new Random();
                        if(type == 1) {
                            string account_name, account_number;
                            int account_number_1, account_number_2;
                            Console.Write( "Account Name: " );
                            account_name = Console.ReadLine();

                            // ezt nemtudom hogy kellene, megirom így egyenlőre
                            account_number_1 = r.Next( 10000000, 100000000 );
                            account_number_2 = r.Next( 10000000, 100000000 );
                            account_number = "00000000" + account_number_1 + account_number_2;
                            Snowbird.db.NonQuery( "INSERT INTO wallets (id,   user_id,                        type,           amount,           currency,           account_name,           account_number,           description, created_at) " +
                                                  "VALUES (             NULL, '" + Snowbird.user.UserId + "', '" + type + "', '" + amount + "', '" + currency + "', '" + account_name + "', '" + account_number + "', NULL,        '" + dateTime + "');" );

                        } else {

                            Snowbird.db.NonQuery( "INSERT INTO wallets (id,   user_id,                        type, amount,           currency,           account_name, account_number, description, created_at) " +
                                                  "VALUES              (NULL, '" + Snowbird.user.UserId + "', 0,    '" + amount + "', '" + currency + "', NULL,         NULL,           NULL,        '" + dateTime + "');" );
                        }

                        runThis = false;
                        Snowbird.user.Update();

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
