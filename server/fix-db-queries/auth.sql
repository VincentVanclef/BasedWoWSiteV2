ALTER TABLE `realmlist` 
MODIFY COLUMN `icon` tinyint(3) NOT NULL DEFAULT 0 AFTER `port`,
MODIFY COLUMN `flag` tinyint(3) NOT NULL DEFAULT 2 AFTER `icon`,
MODIFY COLUMN `timezone` tinyint(3) NOT NULL DEFAULT 0 AFTER `flag`,
MODIFY COLUMN `allowedSecurityLevel` tinyint(3) NOT NULL DEFAULT 0 AFTER `timezone`