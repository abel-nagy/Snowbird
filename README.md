# Snowbird Wallet Application

## The program
1. User identification
   1. Username/email
      * No spaces, only english alphabet characters
      * Case insensitive
   2. Password
      * Securing with algorithm
2. Wallet:
    - Type:
      1. Wallet (only one per user)
      2. Bank Account (any number you want)
         - Name (Bank Account name)
         - Account Number (only if actual Bank Account)
         - Description (not necessary)
    - Action
       - Description (not necessary)
       - Type:
         1. Expense
         3. Income
         3. Transfer
            - Type:
              1. Between own wallets
              2. To another user
            * Can only be initiated from sender
            * On the receiver end makes an Income entry
            * On the sender end makes an Expense entry
    - Currency
      * Given for every account
      * Currency conversion if sender and receiver wallet default currency is not the same
      * Values are checked from database
3. Backup
   * Only own wallets can be backed up for download to an SQL file
   * In a format to be importable to a new database
4. Views
    1. After registration/login (main menu)
       - List all wallets and their actual amount
    3. Selecting wallet
       - List account history by month
         * Default is current month
         * Can change month with arrow keys
         * Show only sum first
           - Show sum of Expenses
           - Show sum of Incomes
           - Show sum
           - Show month begin amount
           - Show month end amount
         * Show chart on specific key press
           - Date
           - Type (expense, income)
           - Amount
           - Description
       - Make new entry on specific key press
         1. Select type
            1. Expense
            2. Income
            3. Transfer
              1. Own wallets
                 - Select from own wallets
              2. Other user
                 - Provide name
                 - Provide Bank Account number
         2. Type amount
         3. Set description (can be left blank)
         4. Set date (can be left blank to default to current date) (only applicable to local transaction)


## The Database
### Name: Snowbird
1. Currency
   1. from (The currency id from which we want to convert)
      * varchar
      * 3 character long
   2. to (The currency id to which we want to convert)
      * varchar
      * 3 character long
   3. multiplier (The value which the program will use to convert the currency)
      * int