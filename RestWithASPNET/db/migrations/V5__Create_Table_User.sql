DROP TABLE IF EXISTS `books`;

CREATE TABLE `users` (
	`id` VARCHAR(255) NOT NULL,
	`user_name` VARCHAR(255) NOT NULL DEFAULT '0',
	`password` VARCHAR(255) NOT NULL DEFAULT '0',
	`full_name` VARCHAR(255) NOT NULL DEFAULT '0',
	`refresh_token` VARCHAR(1024) NULL DEFAULT '0',
	`refresh_token_expiry_time` DATETIME NULL DEFAULT NULL,
	PRIMARY KEY (`id`),
	UNIQUE `user_name` (`user_name`)
)
ENGINE=InnoDB DEFAULT CHARSET=latin1;