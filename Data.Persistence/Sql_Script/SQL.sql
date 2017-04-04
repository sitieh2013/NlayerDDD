CREATE TABLE Impart
(
	[Id] BIGINT NOT NULL PRIMARY KEY, 
    [Name] VARCHAR(50) UNIQUE NOT NULL
)

CREATE TABLE Probability
(
	[Id] BIGINT NOT NULL PRIMARY KEY, 
    [Name] VARCHAR(50) UNIQUE NOT NULL
)
 
CREATE TABLE Project
(
	[Id] BIGINT  NOT NULL PRIMARY KEY IDENTITY,
	[Cod] VARCHAR(50) UNIQUE NOT NULL,
	[DateInitial] DATETIME NOT NULL,
	[DateEnd] DATETIME NOT NULL
);

CREATE TABLE Risks
(
	[Id] BIGINT  NOT NULL PRIMARY KEY IDENTITY,
	[Name] TEXT NOT NULL,
	[IdImpart] BIGINT NOT NULL,
	[IdProbability] BIGINT NOT NULL,
	[IdProject] BIGINT NOT NULL,
	CONSTRAINT SPFK2 foreign key(IdImpart) references Impart(Id),
    CONSTRAINT SPFK3 foreign key(IdProbability) references Probability(Id),
    CONSTRAINT SPFK6 foreign key(IdProject) references Project(Id)
);

Insert into Impart values(1, 'Bajo');
Insert into Impart values(2, 'Medio');
Insert into Impart values(3, 'Alto');

Insert into Probability values(1, 'Baja');
Insert into Probability values(2, 'Media');
Insert into Probability values(3, 'Alta');