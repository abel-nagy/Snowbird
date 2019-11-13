using System.Collections.Generic;

namespace Final_Test {
    public class User {

        private int walletCount;
        private List<string>[] wallets;

        public User(string username, string userId) {
            this.Username = username;
            this.UserId = userId;
        }

        // Properties
        public string Username { get; }
        public string UserId { get; }
        public int WalletCount {
            get { return walletCount; }
            set { walletCount = value; }
        }
        public List<string>[] Wallets {
            get { return wallets; }
            set { wallets = value; }
        }

    }
}
