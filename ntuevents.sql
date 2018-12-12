-- MySQL dump 10.13  Distrib 8.0.13, for Win64 (x86_64)
--
-- Host: localhost    Database: ntuevents
-- ------------------------------------------------------
-- Server version	8.0.13

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
 SET NAMES utf8 ;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `cca`
--

DROP TABLE IF EXISTS `cca`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `cca` (
  `CcaId` int(11) NOT NULL AUTO_INCREMENT,
  `CcaType` varchar(45) DEFAULT NULL,
  `Description` varchar(1024) DEFAULT NULL,
  `Schedule` varchar(45) DEFAULT NULL,
  `Venue` varchar(45) DEFAULT NULL,
  `Contact` varchar(45) DEFAULT NULL,
  `UserId_Cca_FK` int(11) DEFAULT NULL,
  PRIMARY KEY (`CcaId`),
  KEY `UserId_Cca_FK_idx` (`UserId_Cca_FK`),
  CONSTRAINT `UserId_Cca_FK` FOREIGN KEY (`UserId_Cca_FK`) REFERENCES `user` (`userid`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `ccamembership`
--

DROP TABLE IF EXISTS `ccamembership`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `ccamembership` (
  `CcaMembershipId` int(11) NOT NULL AUTO_INCREMENT,
  `UserId_CcaMem_FK` int(11) DEFAULT NULL,
  `CcaId_CcaMem_FK` int(11) DEFAULT NULL,
  `CreatedBy` int(11) DEFAULT NULL,
  `CreatedDate` datetime DEFAULT NULL,
  `UpdatedDate` datetime DEFAULT NULL,
  `UpdatedBy` int(11) DEFAULT NULL,
  `IsDeleted` bit(1) DEFAULT NULL,
  PRIMARY KEY (`CcaMembershipId`),
  KEY `UserId_CcaMem_FK_idx` (`UserId_CcaMem_FK`),
  KEY `CcaId_CcaMem_FK_idx` (`CcaId_CcaMem_FK`),
  CONSTRAINT `CcaId_CcaMem_FK` FOREIGN KEY (`CcaId_CcaMem_FK`) REFERENCES `cca` (`ccaid`),
  CONSTRAINT `UserId_CcaMem_FK` FOREIGN KEY (`UserId_CcaMem_FK`) REFERENCES `user` (`userid`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `event`
--

DROP TABLE IF EXISTS `event`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `event` (
  `EventId` int(11) NOT NULL AUTO_INCREMENT,
  `CCAId_Event_FK` int(11) DEFAULT NULL,
  `Title` varchar(45) DEFAULT NULL,
  `Type` varchar(45) DEFAULT NULL,
  `Venue` varchar(45) DEFAULT NULL,
  `Description` varchar(1024) DEFAULT NULL,
  `StartDate` datetime DEFAULT NULL,
  `EndDate` datetime DEFAULT NULL,
  `Quota` int(11) DEFAULT NULL,
  `CreatedBy` int(11) DEFAULT NULL,
  `CreatedDate` datetime DEFAULT NULL,
  `UpdatedDate` datetime DEFAULT NULL,
  `UpdatedBy` int(11) DEFAULT NULL,
  `IsDeleted` bit(1) DEFAULT NULL,
  PRIMARY KEY (`EventId`),
  KEY `CCAId_Event_FK_idx` (`CCAId_Event_FK`),
  CONSTRAINT `CCAId_Event_FK` FOREIGN KEY (`CCAId_Event_FK`) REFERENCES `cca` (`ccaid`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `eventreg`
--

DROP TABLE IF EXISTS `eventreg`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `eventreg` (
  `EventregId` int(11) NOT NULL AUTO_INCREMENT,
  `Eventid_Eventreg_FK` int(11) DEFAULT NULL,
  `UserId_Eventreg_FK` int(11) DEFAULT NULL,
  `CreatedBy` int(11) DEFAULT NULL,
  `CreatedDate` datetime DEFAULT NULL,
  `isDeleted` bit(1) DEFAULT NULL,
  PRIMARY KEY (`EventregId`),
  KEY `EventId_Eventreg_FK_idx` (`Eventid_Eventreg_FK`),
  KEY `UserId_Eventreg_FK_idx` (`UserId_Eventreg_FK`),
  CONSTRAINT `EventId_Eventreg_FK` FOREIGN KEY (`Eventid_Eventreg_FK`) REFERENCES `event` (`eventid`),
  CONSTRAINT `UserId_Eventreg_FK` FOREIGN KEY (`UserId_Eventreg_FK`) REFERENCES `user` (`userid`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `user`
--

DROP TABLE IF EXISTS `user`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `user` (
  `UserId` int(11) NOT NULL AUTO_INCREMENT,
  `UserProfileId_User_FK` int(11) DEFAULT NULL,
  `Username` varchar(45) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  `Password` varchar(128) CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci DEFAULT NULL,
  `CreatedDate` datetime DEFAULT NULL,
  `isDeleted` bit(1) DEFAULT NULL,
  PRIMARY KEY (`UserId`),
  KEY `UserProfileId_User_FK_idx` (`UserProfileId_User_FK`),
  CONSTRAINT `UserProfileId_User_FK` FOREIGN KEY (`UserProfileId_User_FK`) REFERENCES `userprofile` (`userprofileid`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `userprofile`
--

DROP TABLE IF EXISTS `userprofile`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
 SET character_set_client = utf8mb4 ;
CREATE TABLE `userprofile` (
  `UserProfileId` int(11) NOT NULL AUTO_INCREMENT,
  `Name` varchar(45) DEFAULT NULL,
  `Contact` int(11) DEFAULT NULL,
  `Email` varchar(45) DEFAULT NULL,
  `CreatedDate` datetime DEFAULT NULL,
  `UpdatedDate` datetime DEFAULT NULL,
  `isDeleted` bit(1) DEFAULT NULL,
  PRIMARY KEY (`UserProfileId`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2018-12-12 15:21:37
