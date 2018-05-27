-- --------------------------------------------------------
-- Host:                         127.0.0.1
-- Wersja serwera:               5.7.18-log - MySQL Community Server (GPL)
-- Serwer OS:                    Win64
-- HeidiSQL Wersja:              9.5.0.5196
-- --------------------------------------------------------

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET NAMES utf8 */;
/*!50503 SET NAMES utf8mb4 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;


-- Zrzut struktury bazy danych logowanieobecnosci
DROP DATABASE IF EXISTS `logowanieobecnosci`;
CREATE DATABASE IF NOT EXISTS `logowanieobecnosci` /*!40100 DEFAULT CHARACTER SET utf8 */;
USE `logowanieobecnosci`;

-- Zrzut struktury tabela logowanieobecnosci.obecnosc
DROP TABLE IF EXISTS `obecnosc`;
CREATE TABLE IF NOT EXISTS `obecnosc` (
  `zaj_id` int(11) NOT NULL,
  `stud_id` int(11) NOT NULL,
  PRIMARY KEY (`zaj_id`,`stud_id`),
  KEY `FK_obecnosc_student` (`stud_id`),
  CONSTRAINT `FK_obecnosc_student` FOREIGN KEY (`stud_id`) REFERENCES `student` (`indeks`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `FK_obecnosc_zajecia` FOREIGN KEY (`zaj_id`) REFERENCES `zajecia` (`id_zajec`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- Data exporting was unselected.
-- Zrzut struktury tabela logowanieobecnosci.obowiazek_obecnosci
DROP TABLE IF EXISTS `obowiazek_obecnosci`;
CREATE TABLE IF NOT EXISTS `obowiazek_obecnosci` (
  `stud_id` int(11) NOT NULL,
  `przed_id` int(11) NOT NULL,
  PRIMARY KEY (`stud_id`,`przed_id`),
  KEY `FK_obowiazek_obecnosci_przedmiot` (`przed_id`),
  CONSTRAINT `FK_obowiazek_obecnosci_przedmiot` FOREIGN KEY (`przed_id`) REFERENCES `przedmiot` (`id_przed`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `FK_obowiazek_obecnosci_student` FOREIGN KEY (`stud_id`) REFERENCES `student` (`indeks`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- Data exporting was unselected.
-- Zrzut struktury tabela logowanieobecnosci.prowadzacy
DROP TABLE IF EXISTS `prowadzacy`;
CREATE TABLE IF NOT EXISTS `prowadzacy` (
  `id_prow` int(11) NOT NULL AUTO_INCREMENT,
  `imie` varchar(50) DEFAULT NULL,
  `nazwisko` varchar(50) DEFAULT NULL,
  `skrot_hasla` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`id_prow`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8;

-- Data exporting was unselected.
-- Zrzut struktury tabela logowanieobecnosci.przedmiot
DROP TABLE IF EXISTS `przedmiot`;
CREATE TABLE IF NOT EXISTS `przedmiot` (
  `id_przed` int(11) NOT NULL AUTO_INCREMENT,
  `prow_id` int(11) DEFAULT NULL,
  `tydzien` varchar(50) DEFAULT NULL,
  `dzien` varchar(50) DEFAULT NULL,
  `godzina` varchar(50) DEFAULT NULL,
  `sala` varchar(50) DEFAULT NULL,
  `nazwa` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`id_przed`),
  KEY `FK_przedmiot_prowadzacy` (`prow_id`),
  CONSTRAINT `FK_przedmiot_prowadzacy` FOREIGN KEY (`prow_id`) REFERENCES `prowadzacy` (`id_prow`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8;

-- Data exporting was unselected.
-- Zrzut struktury tabela logowanieobecnosci.student
DROP TABLE IF EXISTS `student`;
CREATE TABLE IF NOT EXISTS `student` (
  `indeks` int(11) NOT NULL,
  `imie` varchar(50) DEFAULT NULL,
  `nazwisko` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`indeks`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- Data exporting was unselected.
-- Zrzut struktury tabela logowanieobecnosci.zajecia
DROP TABLE IF EXISTS `zajecia`;
CREATE TABLE IF NOT EXISTS `zajecia` (
  `id_zajec` int(11) NOT NULL AUTO_INCREMENT,
  `data` datetime DEFAULT NULL,
  `nazwa` varchar(50) DEFAULT NULL,
  `typ_zaj` int(11) DEFAULT NULL,
  PRIMARY KEY (`id_zajec`),
  KEY `FK_zajecia_przedmiot` (`typ_zaj`),
  CONSTRAINT `FK_zajecia_przedmiot` FOREIGN KEY (`typ_zaj`) REFERENCES `przedmiot` (`id_przed`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8;

-- Data exporting was unselected.
/*!40101 SET SQL_MODE=IFNULL(@OLD_SQL_MODE, '') */;
/*!40014 SET FOREIGN_KEY_CHECKS=IF(@OLD_FOREIGN_KEY_CHECKS IS NULL, 1, @OLD_FOREIGN_KEY_CHECKS) */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
