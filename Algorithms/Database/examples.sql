INSERT INTO `users`(        -- Create User (password: asdasd) (id: 0)
    `id`,
    `email`,
    `username`,
    `password`,
    `created_at`
)
VALUES(
    NULL,
    'nagyabe99@gmail.com',
    'sens1tiv',
    '5fd924625f6ab16a19cc9807c7c506ae1813490e4ba675f843d5a10e0baacdb8',
    '2019-11-04 10:43:31'
);
INSERT INTO `wallets`(       -- Create Wallet       (id: 0)
    `id`,
    `user_id`,
    `type`,
    `amount`,
    `currency`,
    `account_name`,
    `account_number`,
    `description`,
    `created_at`
)
VALUES(
    NULL,
    '100000000',
    '0',
    '56420',
    'huf',
    NULL,
    NULL,
    'Zsebem',
    '2019-11-04 10:43:31'
);
INSERT INTO `transactions`(     -- Create initial amount for Wallet (id: 0)
    `id`,
    `wallet_id`,
    `type`,
    `amount`,
    `fromWalletId`,
    `toWalletId`,
    `description`,
    `created_at`
)
VALUES(
    NULL,
    '100000000',
    '1',
    '56420',
    NULL,
    NULL,
    'Fizetés',
    '2019-11-05 10:43:31'
);
INSERT INTO `wallets`(          -- Create test Account       (id: 1)
    `id`,
    `user_id`,
    `type`,
    `amount`,
    `currency`,
    `account_name`,
    `account_number`,
    `description`,
    `created_at`
)
VALUES(
    NULL,
    '100000000',
    '1',
    '1000',
    'eur',
    'Nagy Ábel',
    '000000001234567812345678',
    'Saját bankszámla',
    '2019-11-14 09:48:00'
);
INSERT INTO `transactions`(     -- Create initial amount for Account (id: 1)
    `id`,
    `wallet_id`,
    `type`,
    `amount`,
    `fromWalletId`,
    `toWalletId`,
    `description`,
    `created_at`
)
VALUES(
    NULL,
    '100000001',
    '1',
    '1000',
    NULL,
    NULL,
    'Initial amount',
    '2019-11-14 09:48:00'
);
INSERT INTO `wallets`(          -- Create test2 Account       (id: 2)
    `id`,
    `user_id`,
    `type`,
    `amount`,
    `currency`,
    `account_name`,
    `account_number`,
    `description`,
    `created_at`
)
VALUES(
    NULL,
    '100000000',
    '1',
    '8429',
    'usd',
    'KSZC Széchenyi',
    '987654329876543212345678',
    'Munkahelyi',
    '2019-11-15 15:32:49'
);
INSERT INTO `transactions`(     -- Create initial amount2 for Account (id: 2)
    `id`,
    `wallet_id`,
    `type`,
    `amount`,
    `fromWalletId`,
    `toWalletId`,
    `description`,
    `created_at`
)
VALUES(
    NULL,
    '100000002',
    '1',
    '8429',
    NULL,
    NULL,
    'Initial amount',
    '2019-11-15 15:32:49'
);



INSERT INTO `users`(            -- Create User (password: 123456) (id: 1)
    `id`,
    `email`,
    `username`,
    `password`,
    `created_at`
)
VALUES(
    NULL,
    'adam.patrik.sztk@gmail.com',
    'adampatrik',
    '8d969eef6ecad3c29a3a629280e686cf0c3f5d5a86aff3ca12020c923adc6c92',
    '2019-11-09 16:11:49'
);
INSERT INTO `wallets`(          -- Create Wallet       (id: 3)
    `id`,
    `user_id`,
    `type`,
    `amount`,
    `currency`,
    `account_name`,
    `account_number`,
    `description`,
    `created_at`
)
VALUES(
    NULL,
    '100000001',
    '0',
    '67',
    'eur',
    NULL,
    NULL,
    'Pénzeim',
    '2019-11-09 16:11:49'
);
INSERT INTO `transactions`(     -- Create initial amount for Wallet (id: 3)
    `id`,
    `wallet_id`,
    `type`,
    `amount`,
    `fromWalletId`,
    `toWalletId`,
    `description`, 
    `created_at`
)
VALUES(
    NULL,
    '100000003',
    '1',
    '67',
    NULL,
    NULL,
    'Initial amount', 
    '2019-11-09 16:11:49'
);
INSERT INTO `wallets`(          -- Create test Account       (id: 4)
    `id`,
    `user_id`,
    `type`,
    `amount`,
    `currency`,
    `account_name`,
    `account_number`,
    `description`,
    `created_at`
)
VALUES(
    NULL,
    '100000001',
    '1',
    '84000',
    'huf',
    'Ádám Patrik',
    '000000002345678923456789',
    'Saját',
    '2019-11-15 15:32:49'
);
INSERT INTO `transactions`(     -- Create initial amount for Account (id: 4)
    `id`,
    `wallet_id`,
    `type`,
    `amount`,
    `fromWalletId`,
    `toWalletId`,
    `description`, 
    `created_at`
)
VALUES(
    NULL,
    '100000004',
    '1',
    '84000',
    NULL,
    NULL,
    'Initial amount',
    '2019-11-15 15:32:49'
);



INSERT INTO `users`(            -- Create User (password: chris) (id: 2)
    `id`,
    `email`,
    `username`,
    `password`,
    `created_at`
)
VALUES(
    NULL,
    'csamango.krisztian@gmail.com',
    'csamchris',
    '5d7f15f2fce8ddb2dbef5c38be896c238ba7e0a432e396759030a853fa6b1151',
    '2019-11-12 04:20:55'
);
INSERT INTO `wallets`(          -- Create test Account       (id: 5)
    `id`,
    `user_id`,
    `type`,
    `amount`,
    `currency`,
    `account_name`,
    `account_number`,
    `description`,
    `created_at`
)
VALUES(
    NULL,
    '100000002',
    '0',
    '21560',
    'usd',
    NULL,
    NULL,
    'Fizikális',
    '2019-11-12 04:21:30'
);
INSERT INTO `transactions`(     -- Create initial amount for Account (id: 5)
    `id`,
    `wallet_id`,
    `type`,
    `amount`,
    `fromWalletId`,
    `toWalletId`,
    `description`, 
    `created_at`
)
VALUES(
    NULL,
    '100000005',
    '1',
    '21560',
    NULL,
    NULL,
    'Initial amount',
    '2019-11-12 04:21:30'
);



 


INSERT INTO `transactions`(     -- Create test transaction for Wallet (id: 0)
    `id`,
    `wallet_id`,
    `type`,
    `amount`,
    `fromWalletId`,
    `toWalletId`,
    `description`, 
    `created_at`
)
VALUES(
    NULL,
    '100000000',
    '-1',
    '390',
    NULL,
    NULL,
    'Kenyér', 
    '2019-11-04 17:06:00'
);
UPDATE `wallets` SET `amount` = '56030' WHERE `wallets`.`id` = 100000000;

INSERT INTO `transactions`(     -- Create test transaction for Wallet (id: 0)
    `id`,
    `wallet_id`,
    `type`,
    `amount`,
    `fromWalletId`,
    `toWalletId`,
    `description`, 
    `created_at`
)
VALUES(
    NULL,
    '100000000',
    '-1',
    '45000',
    NULL,
    NULL,
    'Lakás', 
    '2019-11-10 14:08:00'
);
UPDATE `wallets` SET `amount` = '11030' WHERE `wallets`.`id` = 100000000;

INSERT INTO `transactions`(
    `id`,
    `wallet_id`,
    `type`,
    `amount`,
    `fromWalletId`,
    `toWalletId`,
    `description`,
    `created_at`
)
VALUES(
    NULL,
    '100000000',
    '1',
    '13500',
    NULL,
    NULL,
    'Initial amount',
    '2019-10-28 18:00:00'
);
UPDATE `wallets` SET `amount` = '11030' WHERE `wallets`.`id` = 100000000;
INSERT INTO `transactions`(
    `id`,
    `wallet_id`,
    `type`,
    `amount`,
    `fromWalletId`,
    `toWalletId`,
    `description`,
    `created_at`
)
VALUES(
    NULL,
    '100000000',
    '1',
    '69690',
    NULL,
    NULL,
    'Fizetés',
    '2019-12-06 14:48:32'
);
INSERT INTO `transactions`(
    `id`,
    `wallet_id`,
    `type`,
    `amount`,
    `fromWalletId`,
    `toWalletId`,
    `description`,
    `created_at`
)
VALUES(
    NULL,
    '100000000',
    '1',
    '13500',
    NULL,
    NULL,
    'Initial amount',
    '2019-10-28 18:00:00'
)