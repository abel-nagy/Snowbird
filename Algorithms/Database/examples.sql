INSERT INTO `users` (`id`, `email`, `username`, `password`, `created_at`) 
VALUES (NULL, 'nagyabe99@gmail.com', 'sens1tiv', '7d4e2e6f46cc445dc7eaf455cd0397a028fd6a24a701a6ea38328ea06d5fcef8', '2019-11-04 10:43:31');
INSERT INTO `wallets` (`id`, `user_id`, `type`, `amount`, `currency`, `account_name`, `account_number`, `description`, `created_at`) 
VALUES (NULL, '100000000', '0', '0', 'huf', NULL, NULL, NULL, '2019-11-04 10:43:31');
INSERT INTO `transactions`(`id`, `wallet_id`, `type`, `amount`, `fromWalletId`, `toWalletId`, `description`)
VALUES(NULL, '100000000', '1', '0', NULL, NULL, 'Initial amount');

INSERT INTO `users` (`id`, `email`, `username`, `password`, `created_at`) 
VALUES (NULL, 'adam.patrik.sztk@gmail.com', 'adampatrik', '239f56de88d1dd6b0fa70d63861e49caba3a3f7140ae1b075ae8ae1f3929fe4b', '2019-11-09 16:11:49');
INSERT INTO `wallets` (`id`, `user_id`, `type`, `amount`, `currency`, `account_name`, `account_number`, `description`, `created_at`) 
VALUES (NULL, '100000001', '0', '0', 'eur', NULL, NULL, NULL, '2019-11-09 16:11:49');
INSERT INTO `transactions`(`id`, `wallet_id`, `type`, `amount`, `fromWalletId`, `toWalletId`, `description`)
VALUES(NULL, '100000001', '1', '0', NULL, NULL, 'Initial amount');

INSERT INTO `users` (`id`, `email`, `username`, `password`, `created_at`) 
VALUES (NULL, 'csamango.krisztian@gmail.com', 'csamchris', 'eeb99f61625e37307a659770a4d0f1e140c05acd5b65a93f94d1a23893fb8041', '2019-11-12 04:20:55');
INSERT INTO `wallets` (`id`, `user_id`, `type`, `amount`, `currency`, `account_name`, `account_number`, `description`, `created_at`) 
VALUES (NULL, '100000002', '0', '0', 'usd', NULL, NULL, NULL, '2019-11-12 04:20:55');
INSERT INTO `transactions`(`id`, `wallet_id`, `type`, `amount`, `fromWalletId`, `toWalletId`, `description`)
VALUES(NULL, '100000002', '1', '0', NULL, NULL, 'Initial amount');

INSERT INTO `currencies`(`from`, `to`, `multiplier`, `updated`)
VALUES(
    'huf',
    'eur',
    '0.0030',
    '2019-11-04 00:00:00'
),(
    'huf',
    'usd',
    '0.0034',
    '2019-11-04 00:00:00'
),(
    'eur',
    'huf',
    '328.30',
    '2019-11-04 00:00:00'
),(
    'eur',
    'usd',
    '1.12',
    '2019-11-04 00:00:00'
),(
    'usd',
    'huf',
    '294.21',
    '2019-11-04 00:00:00'
),(
    'usd',
    'eur',
    '0.90',
    '2019-11-04 00:00:00'
);