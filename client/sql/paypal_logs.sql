/*
 Navicat Premium Data Transfer

 Source Server         : localhost
 Source Server Type    : MySQL
 Source Server Version : 50643
 Source Host           : localhost:3306
 Source Schema         : website

 Target Server Type    : MySQL
 Target Server Version : 50643
 File Encoding         : 65001

 Date: 28/04/2019 02:50:20
*/

SET NAMES utf8mb4;
SET FOREIGN_KEY_CHECKS = 0;

-- ----------------------------
-- Table structure for paypal_logs
-- ----------------------------
DROP TABLE IF EXISTS `paypal_logs`;
CREATE TABLE `paypal_logs`  (
  `UserId` char(36) CHARACTER SET latin1 COLLATE latin1_swedish_ci NOT NULL,
  `PaymentId` char(50) CHARACTER SET latin1 COLLATE latin1_swedish_ci NOT NULL,
  `PayerId` char(50) CHARACTER SET latin1 COLLATE latin1_swedish_ci NOT NULL,
  `PayerEmail` longtext CHARACTER SET latin1 COLLATE latin1_swedish_ci NOT NULL,
  `PayerFirstName` longtext CHARACTER SET latin1 COLLATE latin1_swedish_ci NOT NULL,
  `PayerLastName` longtext CHARACTER SET latin1 COLLATE latin1_swedish_ci NULL,
  `Total` float UNSIGNED NOT NULL DEFAULT 0,
  `Item` varchar(255) CHARACTER SET latin1 COLLATE latin1_swedish_ci NULL DEFAULT NULL,
  `Quantity` int(10) UNSIGNED NULL DEFAULT 0,
  `Currency` varchar(10) CHARACTER SET latin1 COLLATE latin1_swedish_ci NULL DEFAULT NULL,
  `Price` float NULL DEFAULT 0,
  `Date` datetime(0) NOT NULL DEFAULT CURRENT_TIMESTAMP(0),
  PRIMARY KEY (`UserId`, `PayerId`, `PaymentId`) USING BTREE
) ENGINE = InnoDB CHARACTER SET = latin1 COLLATE = latin1_swedish_ci ROW_FORMAT = Compact;

SET FOREIGN_KEY_CHECKS = 1;
