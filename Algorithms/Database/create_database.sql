CREATE DATABASE snowbird CHARACTER SET utf8;

USE snowbird;

CREATE TABLE `snowbird`.`users`( 
    `user_id` INT(9) NOT NULL AUTO_INCREMENT, 
    `email` VARCHAR(40), 
    `username` VARCHAR(20) NOT NULL, 
    `password` VARCHAR(256) NOT NULL, 
    `created_at` DATETIME NOT NULL, 
    PRIMARY KEY (`user_id`)
) ENGINE = InnoDB;

ALTER TABLE users AUTO_INCREMENT=100000000; -- Making the IDs auto increment start with the lowest 9 digit number

CREATE TABLE `snowbird`.`wallets`( 
    `id` INT NOT NULL AUTO_INCREMENT, 
    `user_id` INT NOT NULL, 
    `type` INT NOT NULL DEFAULT '0', 
    `amount` INT NOT NULL DEFAULT '0', 
    `currency` VARCHAR(3) NOT NULL, 
    `account_name` VARCHAR(40), 
    `account_number` INT, 
    `description` VARCHAR(20), 
    `created_at` DATETIME NOT NULL, 
    PRIMARY KEY (`id`)
) ENGINE = InnoDB;

ALTER TABLE wallets AUTO_INCREMENT=100000000; -- Making the IDs auto increment start with the lowest 9 digit number