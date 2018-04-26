-- MySQL dump 10.13  Distrib 5.7.17, for Win64 (x86_64)
--
-- Host: localhost    Database: soccernation
-- ------------------------------------------------------
-- Server version	8.0.11

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `__efmigrationshistory`
--

DROP TABLE IF EXISTS `__efmigrationshistory`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `__efmigrationshistory` (
  `MigrationId` varchar(95) NOT NULL,
  `ProductVersion` varchar(32) NOT NULL,
  PRIMARY KEY (`MigrationId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `__efmigrationshistory`
--

LOCK TABLES `__efmigrationshistory` WRITE;
/*!40000 ALTER TABLE `__efmigrationshistory` DISABLE KEYS */;
INSERT INTO `__efmigrationshistory` VALUES ('20180423120703_first-migration','2.0.2-rtm-10011');
/*!40000 ALTER TABLE `__efmigrationshistory` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `competitions`
--

DROP TABLE IF EXISTS `competitions`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `competitions` (
  `Id` char(36) NOT NULL,
  `CreatedOn` datetime(6) NOT NULL,
  `EndDate` datetime(6) NOT NULL,
  `ModifiedOn` datetime(6) NOT NULL,
  `Name` longtext NOT NULL,
  `StartDate` datetime(6) NOT NULL,
  `Status` longtext,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `competitions`
--

LOCK TABLES `competitions` WRITE;
/*!40000 ALTER TABLE `competitions` DISABLE KEYS */;
INSERT INTO `competitions` VALUES ('0bc2bdfb-65d0-443f-b6f0-e160d62111a1','2018-04-23 22:56:33.815278','0001-01-01 00:00:00.000000','2018-04-23 22:56:33.815278','Thursday Lunch Time','2018-04-25 00:00:00.000000','Active');
/*!40000 ALTER TABLE `competitions` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `fixtures`
--

DROP TABLE IF EXISTS `fixtures`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `fixtures` (
  `Id` char(36) NOT NULL,
  `CompetitionId` char(36) DEFAULT NULL,
  `CreatedOn` datetime(6) NOT NULL,
  `Date` datetime(6) NOT NULL,
  `ModifiedOn` datetime(6) NOT NULL,
  `Round` int(11) NOT NULL,
  `Status` longtext,
  `TeamHomeId` char(36) NOT NULL,
  `TeamHomeScore` int(11) NOT NULL,
  `TeamVisitorId` char(36) NOT NULL,
  `TeamVisitorScore` int(11) NOT NULL,
  PRIMARY KEY (`Id`),
  KEY `IX_Fixtures_CompetitionId` (`CompetitionId`),
  KEY `IX_Fixtures_TeamHomeId` (`TeamHomeId`),
  KEY `IX_Fixtures_TeamVisitorId` (`TeamVisitorId`),
  CONSTRAINT `FK_Fixtures_Competitions_CompetitionId` FOREIGN KEY (`CompetitionId`) REFERENCES `competitions` (`id`),
  CONSTRAINT `FK_Fixtures_Teams_TeamHomeId` FOREIGN KEY (`TeamHomeId`) REFERENCES `teams` (`id`) ON DELETE CASCADE,
  CONSTRAINT `FK_Fixtures_Teams_TeamVisitorId` FOREIGN KEY (`TeamVisitorId`) REFERENCES `teams` (`id`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `fixtures`
--

LOCK TABLES `fixtures` WRITE;
/*!40000 ALTER TABLE `fixtures` DISABLE KEYS */;
INSERT INTO `fixtures` VALUES ('08d5aa9d-1b80-fe13-3c52-28a9534dbab2','0bc2bdfb-65d0-443f-b6f0-e160d62111a1','0001-01-01 00:00:00.000000','2018-04-25 00:00:00.000000','0001-01-01 00:00:00.000000',1,'PEN','19a278a3-67a6-4500-85a4-909107f166db',0,'1c0885f7-2468-4e10-b32c-03259e2b61a6',0);
/*!40000 ALTER TABLE `fixtures` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `players`
--

DROP TABLE IF EXISTS `players`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `players` (
  `Id` char(36) NOT NULL,
  `Avatar` longtext,
  `AvatarLarge` longtext,
  `AvatarThumb` longtext,
  `CreatedOn` datetime(6) NOT NULL,
  `ModifiedOn` datetime(6) NOT NULL,
  `Name` longtext NOT NULL,
  `Status` longtext,
  `TeamId` char(36) DEFAULT NULL,
  PRIMARY KEY (`Id`),
  KEY `IX_Players_TeamId` (`TeamId`),
  CONSTRAINT `FK_Players_Teams_TeamId` FOREIGN KEY (`TeamId`) REFERENCES `teams` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `players`
--

LOCK TABLES `players` WRITE;
/*!40000 ALTER TABLE `players` DISABLE KEYS */;
/*!40000 ALTER TABLE `players` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `resultrows`
--

DROP TABLE IF EXISTS `resultrows`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `resultrows` (
  `Id` char(36) NOT NULL,
  `CompetitionId` char(36) DEFAULT NULL,
  `ConcedeForfeits` int(11) NOT NULL,
  `CreatedOn` datetime(6) NOT NULL,
  `Draws` int(11) NOT NULL,
  `Forfeits` int(11) NOT NULL,
  `GoalsAgainst` int(11) NOT NULL,
  `GoalsFor` int(11) NOT NULL,
  `Loses` int(11) NOT NULL,
  `Matches` int(11) NOT NULL,
  `ModifiedOn` datetime(6) NOT NULL,
  `Position` smallint(6) NOT NULL,
  `Status` longtext,
  `TeamId` char(36) DEFAULT NULL,
  `Wins` int(11) NOT NULL,
  PRIMARY KEY (`Id`),
  KEY `IX_ResultRows_CompetitionId` (`CompetitionId`),
  KEY `IX_ResultRows_TeamId` (`TeamId`),
  CONSTRAINT `FK_ResultRows_Competitions_CompetitionId` FOREIGN KEY (`CompetitionId`) REFERENCES `competitions` (`id`),
  CONSTRAINT `FK_ResultRows_Teams_TeamId` FOREIGN KEY (`TeamId`) REFERENCES `teams` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `resultrows`
--

LOCK TABLES `resultrows` WRITE;
/*!40000 ALTER TABLE `resultrows` DISABLE KEYS */;
/*!40000 ALTER TABLE `resultrows` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `teams`
--

DROP TABLE IF EXISTS `teams`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `teams` (
  `Id` char(36) NOT NULL,
  `CompetitionId` char(36) DEFAULT NULL,
  `CreatedOn` datetime(6) NOT NULL,
  `LogoImage` longtext,
  `ModifiedOn` datetime(6) NOT NULL,
  `Name` longtext NOT NULL,
  `Status` longtext,
  PRIMARY KEY (`Id`),
  KEY `IX_Teams_CompetitionId` (`CompetitionId`),
  CONSTRAINT `FK_Teams_Competitions_CompetitionId` FOREIGN KEY (`CompetitionId`) REFERENCES `competitions` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `teams`
--

LOCK TABLES `teams` WRITE;
/*!40000 ALTER TABLE `teams` DISABLE KEYS */;
INSERT INTO `teams` VALUES ('19a278a3-67a6-4500-85a4-909107f166db','0bc2bdfb-65d0-443f-b6f0-e160d62111a1','2018-04-23 22:22:42.385173',NULL,'2018-04-23 22:22:42.385173','Qantas','Active'),('1c0885f7-2468-4e10-b32c-03259e2b61a6','0bc2bdfb-65d0-443f-b6f0-e160d62111a1','2018-04-23 22:23:38.018128',NULL,'2018-04-23 22:23:38.018128','Kn','Active'),('3860e8e2-e027-416b-a8b6-f1ff0244020e','0bc2bdfb-65d0-443f-b6f0-e160d62111a1','2018-04-23 22:22:54.236380',NULL,'2018-04-23 22:22:54.236380','Ivory Toast','Active'),('513a050f-b5ed-4c54-8394-ff65b229fe47','0bc2bdfb-65d0-443f-b6f0-e160d62111a1','2018-04-23 22:23:04.874897',NULL,'2018-04-23 22:23:04.874897','Anchors','Active'),('51d5cecf-2fac-4ffd-b3e0-87a4116b0416','0bc2bdfb-65d0-443f-b6f0-e160d62111a1','2018-04-23 22:10:03.197003',NULL,'2018-04-23 22:10:03.197003','No I In Team','Active'),('68fd9014-b683-4e9c-ac6b-f80f84a357da','0bc2bdfb-65d0-443f-b6f0-e160d62111a1','2018-04-23 22:23:32.345482',NULL,'2018-04-23 22:23:32.345482','Schenker Utd','Active'),('6c03a748-525e-40d1-893e-e0e2ebb3523d','0bc2bdfb-65d0-443f-b6f0-e160d62111a1','2018-04-23 22:22:59.846447',NULL,'2018-04-23 22:22:59.846447','Unreal Madrid','Active'),('b14e1455-0b24-4e47-a5d3-6a181e4712fd','0bc2bdfb-65d0-443f-b6f0-e160d62111a1','2018-04-23 22:23:17.254541',NULL,'2018-04-23 22:23:17.254541','Commander Centre','Active'),('c3faad45-ca4e-403d-bd1d-708b61c68301','0bc2bdfb-65d0-443f-b6f0-e160d62111a1','2018-04-23 22:23:09.683840',NULL,'2018-04-23 22:23:09.683840','Team Tam','Active'),('c4126c33-df18-481f-9f16-9fc40087e3d8','0bc2bdfb-65d0-443f-b6f0-e160d62111a1','2018-04-23 22:23:26.038832',NULL,'2018-04-23 22:23:26.038832','Tricky Dicky\'s Big Suite','Active'),('cd9d0f5e-b643-4736-b7ea-3d6c4e2d8944',NULL,'2018-04-25 21:08:28.642841',NULL,'2018-04-25 21:08:28.642841','Kn','Active'),('cdcd9b67-3510-4d94-ae70-af358dc5f92e','0bc2bdfb-65d0-443f-b6f0-e160d62111a1','2018-04-23 22:22:47.969734',NULL,'2018-04-23 22:22:47.969734','Autopia','Active'),('f2069357-e48d-4c49-9769-496e36ccea36','0bc2bdfb-65d0-443f-b6f0-e160d62111a1','2018-04-23 22:22:34.503694',NULL,'2018-04-23 22:22:34.503694','Schenker','Active');
/*!40000 ALTER TABLE `teams` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `users`
--

DROP TABLE IF EXISTS `users`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `users` (
  `Id` char(36) NOT NULL,
  `CreatedOn` datetime(6) NOT NULL,
  `Email` longtext NOT NULL,
  `ModifiedOn` datetime(6) NOT NULL,
  `Name` longtext NOT NULL,
  `Password` longtext NOT NULL,
  `PlayerId` char(36) DEFAULT NULL,
  `Status` longtext,
  PRIMARY KEY (`Id`),
  KEY `IX_Users_PlayerId` (`PlayerId`),
  CONSTRAINT `FK_Users_Players_PlayerId` FOREIGN KEY (`PlayerId`) REFERENCES `players` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `users`
--

LOCK TABLES `users` WRITE;
/*!40000 ALTER TABLE `users` DISABLE KEYS */;
/*!40000 ALTER TABLE `users` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2018-04-26 23:00:49
