-- MySQL Workbench Forward Engineering

SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION';

-- -----------------------------------------------------
-- Schema ntuevents
-- -----------------------------------------------------

-- -----------------------------------------------------
-- Schema ntuevents
-- -----------------------------------------------------
CREATE SCHEMA IF NOT EXISTS `ntuevents` DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci ;
USE `ntuevents` ;

-- -----------------------------------------------------
-- Table `ntuevents`.`userprofile`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `ntuevents`.`userprofile` (
  `UserProfileId` INT(11) NOT NULL,
  `Name` VARCHAR(45) NULL DEFAULT NULL,
  `Contact` INT(11) NULL DEFAULT NULL,
  `Email` VARCHAR(45) NULL DEFAULT NULL,
  `CreatedDate` DATETIME NULL DEFAULT NULL,
  `UpdatedDate` DATETIME NULL DEFAULT NULL,
  `isDeleted` BIT(1) NULL DEFAULT NULL,
  PRIMARY KEY (`UserProfileId`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `ntuevents`.`user`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `ntuevents`.`user` (
  `UserId` INT(11) NOT NULL,
  `UserProfileId_User_FK` INT(11) NULL DEFAULT NULL,
  `Username` VARCHAR(45) CHARACTER SET 'utf8mb4' COLLATE 'utf8mb4_0900_ai_ci' NULL DEFAULT NULL,
  `Password` VARCHAR(128) CHARACTER SET 'utf8mb4' COLLATE 'utf8mb4_0900_ai_ci' NULL DEFAULT NULL,
  `CreatedDate` DATETIME NULL DEFAULT NULL,
  `isDeleted` BIT(1) NULL DEFAULT NULL,
  PRIMARY KEY (`UserId`),
  INDEX `UserProfileId_idx` (`UserProfileId_User_FK` ASC) VISIBLE,
  CONSTRAINT `UserProfileId_User_FK`
    FOREIGN KEY (`UserProfileId_User_FK`)
    REFERENCES `ntuevents`.`userprofile` (`UserProfileId`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `ntuevents`.`cca`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `ntuevents`.`cca` (
  `CcaId` INT(11) NOT NULL,
  `CcaType` VARCHAR(45) NULL DEFAULT NULL,
  `Description` VARCHAR(1024) NULL DEFAULT NULL,
  `Schedule` VARCHAR(45) NULL DEFAULT NULL,
  `Venue` VARCHAR(45) NULL DEFAULT NULL,
  `Contact` VARCHAR(45) NULL DEFAULT NULL,
  `UserId_Cca_FK` INT(11) NULL DEFAULT NULL,
  PRIMARY KEY (`CcaId`),
  INDEX `UserId_idx` (`UserId_Cca_FK` ASC) VISIBLE,
  CONSTRAINT `UserId_Cca_FK`
    FOREIGN KEY (`UserId_Cca_FK`)
    REFERENCES `ntuevents`.`user` (`UserId`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8mb4
COLLATE = utf8mb4_0900_ai_ci;


-- -----------------------------------------------------
-- Table `ntuevents`.`ccamembership`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `ntuevents`.`ccamembership` (
  `CcaMembershipId` INT(11) NOT NULL,
  `UserId_CcaMem_FK` INT(11) NULL DEFAULT NULL,
  `CcaId_CcaMem_FK` INT(11) NULL DEFAULT NULL,
  `CreatedBy` INT(11) NULL DEFAULT NULL,
  `CreatedDate` DATETIME NULL DEFAULT NULL,
  `UpdatedDate` DATETIME NULL DEFAULT NULL,
  `UpdatedBy` INT(11) NULL DEFAULT NULL,
  `IsDeleted` BIT(1) NULL DEFAULT NULL,
  PRIMARY KEY (`CcaMembershipId`),
  INDEX `UserId_idx` (`UserId_CcaMem_FK` ASC) VISIBLE,
  INDEX `CcaId_idx` (`CcaId_CcaMem_FK` ASC) VISIBLE,
  CONSTRAINT `CcaId_CcaMem_FK`
    FOREIGN KEY (`CcaId_CcaMem_FK`)
    REFERENCES `ntuevents`.`cca` (`CcaId`),
  CONSTRAINT `UserId_CcaMem_FK`
    FOREIGN KEY (`UserId_CcaMem_FK`)
    REFERENCES `ntuevents`.`user` (`UserId`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8mb4
COLLATE = utf8mb4_0900_ai_ci;


-- -----------------------------------------------------
-- Table `ntuevents`.`event`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `ntuevents`.`event` (
  `EventId` INT(11) NOT NULL,
  `CCAId_Event_FK` INT(11) NULL DEFAULT NULL,
  `Title` VARCHAR(45) NULL DEFAULT NULL,
  `Type` VARCHAR(45) NULL DEFAULT NULL,
  `Venue` VARCHAR(45) NULL DEFAULT NULL,
  `Description` VARCHAR(1024) NULL DEFAULT NULL,
  `StartDate` DATETIME NULL DEFAULT NULL,
  `EndDate` DATETIME NULL DEFAULT NULL,
  `Quota` INT(11) NULL DEFAULT NULL,
  `CreatedBy` INT(11) NULL DEFAULT NULL,
  `CreatedDate` DATETIME NULL DEFAULT NULL,
  `UpdatedDate` DATETIME NULL DEFAULT NULL,
  `UpdatedBy` INT(11) NULL DEFAULT NULL,
  `IsDeleted` BIT(1) NULL DEFAULT NULL,
  PRIMARY KEY (`EventId`),
  INDEX `CcaId_Event_Fk_idx` (`CCAId_Event_FK` ASC) VISIBLE,
  CONSTRAINT `CcaId_Event_Fk`
    FOREIGN KEY (`CCAId_Event_FK`)
    REFERENCES `ntuevents`.`cca` (`CcaId`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8mb4
COLLATE = utf8mb4_0900_ai_ci;


-- -----------------------------------------------------
-- Table `ntuevents`.`eventreg`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `ntuevents`.`eventreg` (
  `EventregId` INT(11) NOT NULL,
  `Eventid_Eventreg_FK` INT(11) NULL DEFAULT NULL,
  `UserId_Eventreg_FK` INT(11) NULL DEFAULT NULL,
  `CreatedBy` INT(11) NULL DEFAULT NULL,
  `CreatedDate` DATETIME NULL DEFAULT NULL,
  `isDeleted` BIT(1) NULL DEFAULT NULL,
  PRIMARY KEY (`EventregId`),
  INDEX `EventId_idx` (`Eventid_Eventreg_FK` ASC) VISIBLE,
  INDEX `UserId_idx` (`UserId_Eventreg_FK` ASC) VISIBLE,
  CONSTRAINT `EventId_Eventreg_FK`
    FOREIGN KEY (`Eventid_Eventreg_FK`)
    REFERENCES `ntuevents`.`event` (`EventId`),
  CONSTRAINT `UserId_Eventreg_FK`
    FOREIGN KEY (`UserId_Eventreg_FK`)
    REFERENCES `ntuevents`.`user` (`UserId`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8mb4
COLLATE = utf8mb4_0900_ai_ci;


SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;
