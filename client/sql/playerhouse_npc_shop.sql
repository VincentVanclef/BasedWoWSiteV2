/*
 Navicat Premium Data Transfer

 Source Server         : localhost
 Source Server Type    : MySQL
 Source Server Version : 50643
 Source Host           : localhost:3306
 Source Schema         : world

 Target Server Type    : MySQL
 Target Server Version : 50643
 File Encoding         : 65001

 Date: 28/04/2019 00:18:49
*/

SET NAMES utf8mb4;
SET FOREIGN_KEY_CHECKS = 0;

-- ----------------------------
-- Table structure for playerhouse_npc_shop
-- ----------------------------
DROP TABLE IF EXISTS `playerhouse_npc_shop`;
CREATE TABLE `playerhouse_npc_shop`  (
  `NpcId` int(11) UNSIGNED NOT NULL DEFAULT 0,
  `ExtendedCostId` int(11) UNSIGNED NOT NULL DEFAULT 0,
  PRIMARY KEY (`NpcId`) USING BTREE
) ENGINE = InnoDB CHARACTER SET = latin1 COLLATE = latin1_swedish_ci ROW_FORMAT = Compact;

SET FOREIGN_KEY_CHECKS = 1;
