-- MySQL Script generated by MySQL Workbench
-- 06/08/15 17:16:19
-- Model: New Model    Version: 1.0
-- MySQL Workbench Forward Engineering

SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='TRADITIONAL,ALLOW_INVALID_DATES';

-- -----------------------------------------------------
-- Schema demodata
-- -----------------------------------------------------

-- -----------------------------------------------------
-- Schema demodata
-- -----------------------------------------------------
CREATE SCHEMA IF NOT EXISTS `demodata` DEFAULT CHARACTER SET utf8 COLLATE utf8_general_ci ;
USE `demodata` ;

-- -----------------------------------------------------
-- Table `demodata`.`demotable_1`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `demodata`.`demotable_1` (
  `Id` INT NOT NULL AUTO_INCREMENT,
  `ColStr` VARCHAR(45) NULL,
  `ColDecimal` DECIMAL(10,2) NULL,
  `newCol_1` VARCHAR(128) NULL,
  `newCol_2` INT NULL,
  `demotable_1col` DECIMAL(10,2) NULL,
  `demotable_1col1` VARCHAR(45) NULL,
  `demotable_1col2` VARCHAR(45) NULL,
  `demotable_1col3` VARCHAR(45) NULL,
  `demotable_1col4` VARCHAR(45) NULL,
  `demotable_1col5` VARCHAR(45) NULL,
  PRIMARY KEY (`Id`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `demodata`.`demotable_2`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `demodata`.`demotable_2` (
  `id` INT NOT NULL,
  `demotable_2col` DECIMAL(10,2) NULL,
  `demotable_2col1` VARCHAR(45) NULL,
  `demotable_2col2` VARCHAR(45) NULL,
  `demotable_2col3` VARCHAR(45) NULL,
  `demotable_2col4` VARCHAR(45) NULL,
  `demotable_2col5` VARCHAR(45) NULL,
  PRIMARY KEY (`id`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `demodata`.`table1`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `demodata`.`table1` (
  `idtable1` INT NOT NULL,
  `table1col` VARCHAR(45) NULL,
  `table1col1` VARCHAR(45) NULL,
  `table1col2` DATETIME NULL,
  `table1col3` VARCHAR(45) NULL,
  `table1col4` VARCHAR(45) NULL,
  `table1col5` FLOAT NULL,
  PRIMARY KEY (`idtable1`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `demodata`.`table2`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `demodata`.`table2` (
  `idtable2` INT NOT NULL,
  `table2col` VARCHAR(45) NULL,
  `table2col1` VARCHAR(45) NULL,
  `table2col2` VARCHAR(45) NULL,
  PRIMARY KEY (`idtable2`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `demodata`.`table3`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `demodata`.`table3` (
  `idtable3` INT NOT NULL,
  `table3col` VARCHAR(45) NULL,
  `table3col1` VARCHAR(45) NULL,
  `table3col2` VARCHAR(45) NULL,
  PRIMARY KEY (`idtable3`))
ENGINE = InnoDB;


SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;
