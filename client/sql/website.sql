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

 Date: 28/04/2019 02:50:11
*/

SET NAMES utf8mb4;
SET FOREIGN_KEY_CHECKS = 0;

-- ----------------------------
-- Table structure for aspnetuserroles
-- ----------------------------
DROP TABLE IF EXISTS `aspnetuserroles`;
CREATE TABLE `aspnetuserroles`  (
  `UserId` char(36) CHARACTER SET latin1 COLLATE latin1_swedish_ci NOT NULL,
  `RoleId` char(36) CHARACTER SET latin1 COLLATE latin1_swedish_ci NOT NULL,
  PRIMARY KEY (`UserId`, `RoleId`) USING BTREE,
  INDEX `IX_AspNetUserRoles_RoleId`(`RoleId`) USING BTREE,
  CONSTRAINT `FK_AspNetUserRoles_UserRoles_RoleId` FOREIGN KEY (`RoleId`) REFERENCES `userroles` (`Id`) ON DELETE CASCADE ON UPDATE RESTRICT,
  CONSTRAINT `FK_AspNetUserRoles_Users_UserId` FOREIGN KEY (`UserId`) REFERENCES `users` (`UserId`) ON DELETE CASCADE ON UPDATE RESTRICT
) ENGINE = InnoDB CHARACTER SET = latin1 COLLATE = latin1_swedish_ci ROW_FORMAT = Compact;

-- ----------------------------
-- Table structure for role
-- ----------------------------
DROP TABLE IF EXISTS `role`;
CREATE TABLE `role`  (
  `Id` char(36) CHARACTER SET latin1 COLLATE latin1_swedish_ci NOT NULL,
  `Name` varchar(255) CHARACTER SET latin1 COLLATE latin1_swedish_ci NULL DEFAULT NULL,
  `NormalizedName` varchar(255) CHARACTER SET latin1 COLLATE latin1_swedish_ci NULL DEFAULT NULL,
  `ConcurrencyStamp` longtext CHARACTER SET latin1 COLLATE latin1_swedish_ci NULL,
  PRIMARY KEY (`Id`) USING BTREE
) ENGINE = InnoDB CHARACTER SET = latin1 COLLATE = latin1_swedish_ci ROW_FORMAT = Compact;

-- ----------------------------
-- Table structure for roleclaim
-- ----------------------------
DROP TABLE IF EXISTS `roleclaim`;
CREATE TABLE `roleclaim`  (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `RoleId` char(36) CHARACTER SET latin1 COLLATE latin1_swedish_ci NOT NULL,
  `ClaimType` longtext CHARACTER SET latin1 COLLATE latin1_swedish_ci NULL,
  `ClaimValue` longtext CHARACTER SET latin1 COLLATE latin1_swedish_ci NULL,
  PRIMARY KEY (`Id`) USING BTREE,
  INDEX `IX_RoleClaim_RoleId`(`RoleId`) USING BTREE,
  CONSTRAINT `FK_RoleClaim_UserRoles_RoleId` FOREIGN KEY (`RoleId`) REFERENCES `userroles` (`Id`) ON DELETE CASCADE ON UPDATE RESTRICT
) ENGINE = InnoDB AUTO_INCREMENT = 1 CHARACTER SET = latin1 COLLATE = latin1_swedish_ci ROW_FORMAT = Compact;

-- ----------------------------
-- Table structure for userclaims
-- ----------------------------
DROP TABLE IF EXISTS `userclaims`;
CREATE TABLE `userclaims`  (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `UserId` char(36) CHARACTER SET latin1 COLLATE latin1_swedish_ci NOT NULL,
  `ClaimType` longtext CHARACTER SET latin1 COLLATE latin1_swedish_ci NULL,
  `ClaimValue` longtext CHARACTER SET latin1 COLLATE latin1_swedish_ci NULL,
  PRIMARY KEY (`Id`) USING BTREE,
  INDEX `IX_UserClaims_UserId`(`UserId`) USING BTREE,
  CONSTRAINT `FK_UserClaims_Users_UserId` FOREIGN KEY (`UserId`) REFERENCES `users` (`UserId`) ON DELETE CASCADE ON UPDATE RESTRICT
) ENGINE = InnoDB AUTO_INCREMENT = 1 CHARACTER SET = latin1 COLLATE = latin1_swedish_ci ROW_FORMAT = Compact;

-- ----------------------------
-- Table structure for userlogins
-- ----------------------------
DROP TABLE IF EXISTS `userlogins`;
CREATE TABLE `userlogins`  (
  `LoginProvider` varchar(255) CHARACTER SET latin1 COLLATE latin1_swedish_ci NOT NULL,
  `ProviderKey` varchar(255) CHARACTER SET latin1 COLLATE latin1_swedish_ci NOT NULL,
  `ProviderDisplayName` longtext CHARACTER SET latin1 COLLATE latin1_swedish_ci NULL,
  `UserId` char(36) CHARACTER SET latin1 COLLATE latin1_swedish_ci NOT NULL,
  PRIMARY KEY (`LoginProvider`, `ProviderKey`) USING BTREE,
  INDEX `IX_UserLogins_UserId`(`UserId`) USING BTREE,
  CONSTRAINT `FK_UserLogins_Users_UserId` FOREIGN KEY (`UserId`) REFERENCES `users` (`UserId`) ON DELETE CASCADE ON UPDATE RESTRICT
) ENGINE = InnoDB CHARACTER SET = latin1 COLLATE = latin1_swedish_ci ROW_FORMAT = Compact;

-- ----------------------------
-- Table structure for userroles
-- ----------------------------
DROP TABLE IF EXISTS `userroles`;
CREATE TABLE `userroles`  (
  `Id` char(36) CHARACTER SET latin1 COLLATE latin1_swedish_ci NOT NULL,
  `Name` varchar(255) CHARACTER SET latin1 COLLATE latin1_swedish_ci NULL DEFAULT NULL,
  `NormalizedName` varchar(255) CHARACTER SET latin1 COLLATE latin1_swedish_ci NULL DEFAULT NULL,
  `ConcurrencyStamp` longtext CHARACTER SET latin1 COLLATE latin1_swedish_ci NULL,
  PRIMARY KEY (`Id`) USING BTREE,
  UNIQUE INDEX `RoleNameIndex`(`NormalizedName`) USING BTREE
) ENGINE = InnoDB CHARACTER SET = latin1 COLLATE = latin1_swedish_ci ROW_FORMAT = Compact;

-- ----------------------------
-- Table structure for users
-- ----------------------------
DROP TABLE IF EXISTS `users`;
CREATE TABLE `users`  (
  `UserId` char(36) CHARACTER SET latin1 COLLATE latin1_swedish_ci NOT NULL,
  `NormalizedUserName` varchar(255) CHARACTER SET latin1 COLLATE latin1_swedish_ci NULL DEFAULT NULL,
  `Email` varchar(255) CHARACTER SET latin1 COLLATE latin1_swedish_ci NULL DEFAULT NULL,
  `NormalizedEmail` varchar(255) CHARACTER SET latin1 COLLATE latin1_swedish_ci NULL DEFAULT NULL,
  `EmailConfirmed` bit(1) NOT NULL,
  `PasswordHash` longtext CHARACTER SET latin1 COLLATE latin1_swedish_ci NULL,
  `SecurityStamp` longtext CHARACTER SET latin1 COLLATE latin1_swedish_ci NULL,
  `ConcurrencyStamp` longtext CHARACTER SET latin1 COLLATE latin1_swedish_ci NULL,
  `PhoneNumber` longtext CHARACTER SET latin1 COLLATE latin1_swedish_ci NULL,
  `PhoneNumberConfirmed` bit(1) NOT NULL,
  `TwoFactorEnabled` bit(1) NOT NULL,
  `LockoutEnd` datetime(6) NULL DEFAULT NULL,
  `LockoutEnabled` bit(1) NOT NULL,
  `AccessFailedCount` int(11) NOT NULL,
  `UserName` varchar(255) CHARACTER SET latin1 COLLATE latin1_swedish_ci NULL DEFAULT NULL,
  `Lastname` longtext CHARACTER SET latin1 COLLATE latin1_swedish_ci NULL,
  `Firstname` longtext CHARACTER SET latin1 COLLATE latin1_swedish_ci NULL,
  `AccountId` int(11) NOT NULL DEFAULT 0,
  `Online` tinyint(3) UNSIGNED NOT NULL DEFAULT 0,
  `JoinDate` datetime(6) NOT NULL DEFAULT CURRENT_TIMESTAMP(6),
  `Location` longtext CHARACTER SET latin1 COLLATE latin1_swedish_ci NULL,
  PRIMARY KEY (`UserId`) USING BTREE,
  UNIQUE INDEX `UserNameIndex`(`NormalizedUserName`) USING BTREE,
  INDEX `EmailIndex`(`NormalizedEmail`) USING BTREE
) ENGINE = InnoDB CHARACTER SET = latin1 COLLATE = latin1_swedish_ci ROW_FORMAT = Compact;

-- ----------------------------
-- Table structure for usertoken
-- ----------------------------
DROP TABLE IF EXISTS `usertoken`;
CREATE TABLE `usertoken`  (
  `UserId` char(36) CHARACTER SET latin1 COLLATE latin1_swedish_ci NOT NULL,
  `LoginProvider` varchar(255) CHARACTER SET latin1 COLLATE latin1_swedish_ci NOT NULL,
  `Name` varchar(255) CHARACTER SET latin1 COLLATE latin1_swedish_ci NOT NULL,
  `Value` longtext CHARACTER SET latin1 COLLATE latin1_swedish_ci NULL,
  PRIMARY KEY (`UserId`, `LoginProvider`, `Name`) USING BTREE,
  CONSTRAINT `FK_UserToken_Users_UserId` FOREIGN KEY (`UserId`) REFERENCES `users` (`UserId`) ON DELETE CASCADE ON UPDATE RESTRICT
) ENGINE = InnoDB CHARACTER SET = latin1 COLLATE = latin1_swedish_ci ROW_FORMAT = Compact;

-- ----------------------------
-- Table structure for votes
-- ----------------------------
DROP TABLE IF EXISTS `votes`;
CREATE TABLE `votes`  (
  `UserId` char(36) CHARACTER SET latin1 COLLATE latin1_swedish_ci NOT NULL,
  `Site` tinyint(3) UNSIGNED NOT NULL,
  `UnsetTimer` bigint(20) NOT NULL,
  PRIMARY KEY (`UserId`, `Site`) USING BTREE,
  UNIQUE INDEX `AK_Votes_Site_UserId`(`Site`, `UserId`) USING BTREE
) ENGINE = InnoDB CHARACTER SET = latin1 COLLATE = latin1_swedish_ci ROW_FORMAT = Compact;

-- ----------------------------
-- Table structure for votesites
-- ----------------------------
DROP TABLE IF EXISTS `votesites`;
CREATE TABLE `votesites`  (
  `Id` tinyint(3) UNSIGNED NOT NULL,
  `Link` longtext CHARACTER SET latin1 COLLATE latin1_swedish_ci NULL,
  `Image` longtext CHARACTER SET latin1 COLLATE latin1_swedish_ci NULL,
  `UnsetTime` int(11) NOT NULL,
  `Name` longtext CHARACTER SET latin1 COLLATE latin1_swedish_ci NULL,
  `Value` tinyint(3) UNSIGNED NOT NULL DEFAULT 0,
  PRIMARY KEY (`Id`) USING BTREE
) ENGINE = InnoDB CHARACTER SET = latin1 COLLATE = latin1_swedish_ci ROW_FORMAT = Compact;

SET FOREIGN_KEY_CHECKS = 1;
