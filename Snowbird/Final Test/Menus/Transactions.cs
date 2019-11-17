using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final_Test.Menus
{
    class TransactionsClass
    {
        public static void addTransactions(string walletId)
        {
            Console.Clear();
            Console.Write("\n\t\t\t\t\t\tAdd transaction to "); /**/ Snowbird.Write(Snowbird.user.Username, ConsoleColor.Blue); /**/ Console.WriteLine("!\n\n");
            //Console.WriteLine("Add Transactions to " + walletId);

            Console.Write("\t\t"); /**/ Snowbird.Write("1 - Income", ConsoleColor.Green);
            Console.Write("\n\t\t"); /**/ Snowbird.Write("2 - Expense", ConsoleColor.Red);

            switch (Snowbird.KeyPressed())
            {
                case "1":
                    incomeTrans(walletId);
                    break;
                case "2":
                    expenseTrans(walletId);
                    break;
                default:
                    break;
            }
        }

        public static void incomeTrans(string walletId)
        {

            Console.Clear();
            Console.Write("\n\t\t\t\t\t\tAdd transaction to "); /**/ Snowbird.Write(Snowbird.user.Username, ConsoleColor.Blue); /**/ Console.WriteLine("!\n\n");
            Console.WriteLine("\t\t\tIncome Transaction\n");
            Console.Write("Amount: ");
            double amount = Convert.ToDouble(Console.ReadLine());

            DateTime myDateTime = DateTime.Now;
            string dateTime = myDateTime.ToString("yyyy-MM-dd HH:mm:ss");

            string queryTrans = "INSERT INTO `transactions` (`id`, `wallet_id`, `type`, `amount`, `fromWalletId`, `toWalletId`, `description`, `created_at`) VALUES (NULL, '" + walletId + "', '1', '" + amount + "', NULL, NULL, 'fizetés', '" + dateTime + "');";
            Snowbird.db.NonQuery(queryTrans);

            string queryWallet = "UPDATE wallets SET amount = amount + " + amount + " WHERE wallet_id = " + walletId + ";";
            Snowbird.db.NonQuery(queryWallet);

        }

        public static void expenseTrans(string walletId)
        {

            Console.Clear();
            Console.Write("\n\t\t\t\t\t\tAdd transaction to "); /**/ Snowbird.Write(Snowbird.user.Username, ConsoleColor.Blue); /**/ Console.WriteLine("!\n\n");
            Console.WriteLine("\t\t\tExpense Transaction\n");
            Console.Write("Amount: ");
            double amount = Convert.ToDouble(Console.ReadLine());

            DateTime myDateTime = DateTime.Now;
            string dateTime = myDateTime.ToString("yyyy-MM-dd HH:mm:ss");

            string queryTrans = "INSERT INTO `transactions` (`id`, `wallet_id`, `type`, `amount`, `fromWalletId`, `toWalletId`, `description`, `created_at`) VALUES (NULL, '" + walletId + "', '-1', '" + amount + "', NULL, NULL, 'fizetés', '" + dateTime + "');";
            Snowbird.db.NonQuery(queryTrans);

            string queryWallet = "UPDATE wallets SET amount = amount - " + amount + " WHERE wallet_id = " + walletId + ";";
            Snowbird.db.NonQuery(queryWallet);

        }

    }
}
