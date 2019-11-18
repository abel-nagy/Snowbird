using System.Collections.Generic;

namespace Final_Test {

    /// <summary>
    /// Logged in user
    /// </summary>
    public class User {

        /// <summary>
        /// Creates a new object of a logged in user
        /// </summary>
        /// <param name="username">Username</param>
        /// <param name="userId">UserID in database</param>
        public User(string userId) {
            UserId = userId;

            Username = Snowbird.db.Select( "SELECT username FROM users WHERE id='" + UserId + "';",
                                           1, 
                                           new string[1] { "username" } )[0][0];

            Update();
        }

        /// <summary>
        /// Updates all user related info in program
        /// </summary>
        public void Update() {
            Wallets      = Snowbird.db.Select( "SELECT * FROM wallets WHERE user_id='" + UserId + "' ORDER BY created_at;",
                                               9,
                                               new string[9] { "id", "user_id", "type", "amount", "currency", "account_name", "account_number", "description", "created_at" } );
            Transactions = Snowbird.db.Select( "SELECT * FROM transactions t LEFT JOIN wallets w ON t.wallet_id=w.id WHERE user_id='" + UserId + "' ORDER BY t.created_at;",
                                               8,
                                               new string[8] { "id", "wallet_id", "type", "amount", "fromWalletId", "toWalletId", "description", "created_at" } );

            WalletCount      = Snowbird.db.Count( "SELECT COUNT(*) FROM wallets WHERE user_id='" + UserId + "';");
            TransactionCount = Snowbird.db.Count( "SELECT COUNT(*) FROM transactions t LEFT JOIN wallets w ON t.wallet_id=w.id WHERE user_id='" + UserId + "';" );
        }


        public string Username { get; }
        public string UserId { get; }

        public int WalletCount { get; set; }
        public int TransactionCount { get; set; }

        public List<string>[] Wallets { get; set; }
        public List<string>[] Transactions { get; set; }

    }
}
