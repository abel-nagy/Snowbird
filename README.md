#Snowbird Wallet Application

##1. User identification: 
    ###I. Username/email
        - No spaces, only english alphabet characters
        - Case insensitive
    ###II. Password
        - Securing with algorithm
##2. Wallet:
    ###I. Type:
        - Wallet (only one per user)
            * Description (not necessary)
        - Bank Account (any number you want)
            * Name (Bank Account name)
            * Account Number (only if actual Bank Account)
            * Description (not necessary)
    ###II. Action:
        - Description (not necessary)
        - Type:
            * Expense
            * Income
            * Transfer
                -- Type:
                    ** Between own wallets
                    ** To another user
                -- Can only be initiated from sender
                -- On the receiver end makes an Income entry
                -- On the sender end makes an Expense entry
    ###III. Currency
        - Given for every account
        - Currency conversion if sender and receiver wallet default currency is not the same
        - Values are checked from database
##3. Backup
    I. Only own wallets can be backed up for download to an SQL file
    II. In a format to be importable to a new database
##4. Views
    ###I. After registration/login (main menu)
        - List all wallets and their actual amount
    ###II. Selecting wallet
        - List account history by month
            * Default is current month
            * Can change month with arrow keys
            * Show only sum first
                -- Show sum of Expenses
                -- Show sum of Incomes
                -- Show sum
                -- Show month begin amount
                -- Show month end amount
            * Show chart on specific key press
                -- Date
                -- Type (expense, income)
                -- Amount
                -- Description
        - Make new entry on specific key press
            * Select type
                -- Expense
                -- Income
                -- Transfer
                    -- Own wallets
                        ** Select from own wallets
                    -- Other user
                        ** Provide name
                        ** Provide Bank Account number
            * Type amount
            * Set description (can be left blank)
            * Set date (can be left blank to default to current date) (only applicable to local transaction)