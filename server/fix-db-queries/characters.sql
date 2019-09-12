ALTER TABLE `character_banned` 
MODIFY COLUMN `active` tinyint(3) NOT NULL DEFAULT 1 AFTER `banreason`;

ALTER TABLE `arena_team` 
MODIFY COLUMN `type` tinyint(3) NOT NULL DEFAULT 0 AFTER `captainGuid`,
MODIFY COLUMN `emblemStyle` tinyint(3) NOT NULL DEFAULT 0 AFTER `backgroundColor`,
MODIFY COLUMN `borderStyle` tinyint(3) NOT NULL DEFAULT 0 AFTER `emblemColor`;