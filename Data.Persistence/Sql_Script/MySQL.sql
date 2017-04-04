CREATE TABLE IF NOT EXISTS `Impart` (
  `Id` BIGINT NOT NULL PRIMARY KEY COMMENT '',
  `Name` VARCHAR(50) NULL UNIQUE COMMENT '');
  
CREATE TABLE IF NOT EXISTS `Probability`(
	`Id` BIGINT NOT NULL PRIMARY KEY COMMENT '',
    `Name` VARCHAR(50) NULL UNIQUE COMMENT '');

CREATE TABLE IF NOT EXISTS `Project`
(
	`Id` BIGINT auto_increment NOT NULL PRIMARY KEY COMMENT '',
	`Cod` VARCHAR(50) NULL UNIQUE COMMENT '',
	`DateInitial` DATETIME NOT NULL,
	`DateEnd` DATETIME NOT NULL
);

CREATE TABLE IF NOT EXISTS `Risks`
(
	`Id` BIGINT auto_increment NOT NULL PRIMARY KEY,
	`Name` TEXT NOT NULL,
	`IdImpart` BIGINT NOT NULL,
	`IdProbability` BIGINT NOT NULL,
	`IdProject` BIGINT NOT NULL,
	CONSTRAINT `SPFK2` foreign key(`IdImpart`) references `Impart`(`Id`),
    CONSTRAINT `SPFK3` foreign key(`IdProbability`) references `Probability`(`Id`),
    CONSTRAINT `SPFK6` foreign key(`IdProject`) references `Project`(`Id`)
);

Insert into Impart values(1, 'Bajo');
Insert into Impart values(2, 'Medio');
Insert into Impart values(3, 'Alto');

Insert into Probability values(1, 'Baja');
Insert into Probability values(2, 'Media');
Insert into Probability values(3, 'Alta');