-- ALTER TABLE `character_banned` 
-- MODIFY COLUMN `active` tinyint(3) NOT NULL DEFAULT 1 AFTER `banreason`;

-- ALTER TABLE `arena_team` 
-- MODIFY COLUMN `type` tinyint(3) NOT NULL DEFAULT 0 AFTER `captainGuid`,
-- MODIFY COLUMN `emblemStyle` tinyint(3) NOT NULL DEFAULT 0 AFTER `backgroundColor`,
-- MODIFY COLUMN `borderStyle` tinyint(3) NOT NULL DEFAULT 0 AFTER `emblemColor`;

-- ALTER TABLE `guild` 
-- MODIFY COLUMN `EmblemStyle` smallint(5) UNSIGNED NOT NULL DEFAULT 0 AFTER `leaderguid`,
-- MODIFY COLUMN `EmblemColor` smallint(5) UNSIGNED NOT NULL DEFAULT 0 AFTER `EmblemStyle`,
-- MODIFY COLUMN `BorderStyle` smallint(5) UNSIGNED NOT NULL DEFAULT 0 AFTER `EmblemColor`,
-- MODIFY COLUMN `BorderColor` smallint(5) UNSIGNED NOT NULL DEFAULT 0 AFTER `BorderStyle`,
-- MODIFY COLUMN `BackgroundColor` smallint(5) UNSIGNED NOT NULL DEFAULT 0 AFTER `BorderColor`,
-- MODIFY COLUMN `Level` smallint(5) UNSIGNED NOT NULL DEFAULT 0 AFTER `BankMoney`;

-- ALTER TABLE `guild_member` 
-- MODIFY COLUMN `rank` smallint(5) UNSIGNED NOT NULL AFTER `guid`;

-- ALTER TABLE `guild_rank` 
-- MODIFY COLUMN `rid` smallint(5) UNSIGNED NOT NULL AFTER `guildid`;