using System.Collections.Generic;

namespace Final_Test {
    public class User {

        private int walletCount, transactionCount;
        private List<string>[] wallets, transactions;

        public User(string username, string userId) {
            Username = username;
            UserId = userId;
        }

        // Properties
        /// <summary>
        /// Logged-in user's username
        /// </summary>
        public string Username { get; }
        /// <summary>
        /// Logged-in user's user id
        /// </summary>
        public string UserId { get; }
        /// <summary>
        /// How many wallets the logged-in user have
        /// </summary>
        public int WalletCount {
            get { return walletCount; }
            set { walletCount = value; }
        }
        /// <summary>
        /// All data for the logged-in user's every wallet
        /// </summary>
        public List<string>[] Wallets {
            get { return wallets; }
            set { wallets = value; }
        }
        /// <summary>
        /// How many transactions the logged-in user have
        /// </summary>
        public int TransactionCount {
            get { return transactionCount; }
            set { transactionCount = value; }
        }
        /// <summary>
        /// All data for the logged-in user's every transactions
        /// </summary>
        public List<string>[] Transactions {
            get { return transactions; }
            set { transactions = value; }
        }

    }
}
