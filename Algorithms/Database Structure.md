** Users (**id**, email, username, password)
   **id** = {9 jegyű INT >= 100'000'000} => PRIMARY KEY
   email = {legfeljebb 40 karakteres VARCHAR}
   username = {legfeljebb 20 karakteres VARCHAR}
   password = {pontosan 256 karakteres VARCHAR}
   created_at = {DATETIME}

** Wallets (**id**, *user_id*, type, currency, account_name, account_number, description)
  **id** = {9 jegyű INT >= 100'000'000, NOT NULL} => PRIMARY KEY
  *user_id* = {9 jegyű INT >= 100'000'000, NOT NULL} => FOREIGN KEY => users.id
  type = {1 jegyű INT, NOT NULL}
  amount = {9 jegyű INT, NOT NULL}
  currency = {3 karakteres VARCHAR, NOT NULL}
  account_name = {legfeljebb 30 karakteres VARCHAR}
  account_number = {pontosan 24 jegyű INT}
  description = {legfeljebb 20 karakteres VARCHAR}
  created_at = {DATETIME, NOT NULL}

** Transactions (**id**, *wallet_id*, type, amount, fromWallet_id, toWallet_id, description)
  **id** = {9 jegyű INT >= 100'000'000, NOT NULL} => PRIMARY KEY
  *wallet_id* = {9 jegyű INT >= 100'000'000, NOT NULL} = FOREIGN KEY => wallets.id
  type = {1 jegyű INT, NOT NULL}
  amount = {legfeljebb 9 jegyű INT, NOT NULL}
  fromWallet_id = {9 jegyű INT >= 100'000'000}
  toWallet_id = {9 jegyű INT >= 100'000'000}
  description = {legfeljebb 20 karakteres VARCHAR}