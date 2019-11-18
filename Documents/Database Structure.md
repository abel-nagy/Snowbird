
# Snowbird

## Users
   - **id** = {9 digit INT >= 100'000'000, NOT NULL} => PRIMARY KEY
   - email = {max 40 long VARCHAR}
   - username = {max 20 long VARCHAR, NOT NULL}
   - password = {exactly 256 long VARCHAR, NOT NULL}
   - created_at = {DATETIME, NOT NULL}

## Wallets
  - **id** = {9 digit INT >= 100'000'000, NOT NULL} => PRIMARY KEY
  - *user_id* = {9 digit INT >= 100'000'000, NOT NULL} => FOREIGN KEY => users.id
  - type = {1 digit INT, NOT NULL}
  - amount = {9 digit FLOAT, NOT NULL}
  - currency = {3 long VARCHAR, NOT NULL}
  - account_name = {max 30 long VARCHAR}
  - account_number = {exactly 24 long VARCHAR}
  - description = {max 20 long VARCHAR}
  - created_at = {DATETIME, NOT NULL}

## Transactions
  - **id** = {9 digit INT >= 100'000'000, NOT NULL} => PRIMARY KEY
  - *wallet_id* = {9 digit INT >= 100'000'000, NOT NULL} = FOREIGN KEY => wallets.id
  - type = {1 digit INT, NOT NULL}
  - amount = {max 9 digit FLOAT, NOT NULL}
  - fromWallet_id = {9 digit INT >= 100'000'000}
  - toWallet_id = {9 digit INT >= 100'000'000}
  - description = {max 20 long VARCHAR}
  - created_at = {DATETIME, NOT NULL}

## Currencies
  - from = {exactly 3 long VARCHAR, NOT NULL}
  - to = {exactly 3 long VARCHAR, NOT NULL}
  - multiplier = {FLOAT, NOT NULL}
  - updated = {DATETIME, NOT NULL}