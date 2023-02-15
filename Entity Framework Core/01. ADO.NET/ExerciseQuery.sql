CREATE DATABASE MinionsDB
USE MinionsDB

--P01
CREATE TABLE Countries(
	Id INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(50)
)

CREATE TABLE Towns(
	Id INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(50),
	CountryCode INT REFERENCES Countries(Id)
)

CREATE TABLE Minions(
	Id INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(50),
	Age INT,
	TownId INT REFERENCES Towns(Id)
)

CREATE TABLE EvilnessFactors(
	Id INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(50)
)

CREATE TABLE Villains(
	Id INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(50),
	EvilnessFactorId INT REFERENCES EvilnessFactors(Id)
)

CREATE TABLE MinionsVillains(
	MinionId INT REFERENCES Minions(Id),
	VillainId INT REFERENCES Villains(Id),

	CONSTRAINT PK_MinionsVillains PRIMARY KEY (MinionId, VillainId)
)

INSERT INTO Countries([Name]) VALUES
('Afghanistan'),
('Albania'),
('Algeria'),
('Andorra'),
('Angola')

INSERT INTO Towns([Name], CountryCode) VALUES
('Alexander City', 1),
('Andalusia', 2),
('Seward', 3),
('Ajo', 4),
('Bisbee', 5)

INSERT INTO Minions([Name], Age, TownId) VALUES
('Bob', 21, 1),
('Kevin', 42, 2),
('Seward', 35, 3),
('Ivan', 40, 4),
('Hristo', 18, 5)

INSERT INTO EvilnessFactors([Name]) VALUES
('super good'),
('good'),
('bad'),
('evil'),
('super evil')

INSERT INTO Villains([Name], EvilnessFactorId) VALUES
('Gru', 1),
('Victor', 2),
('Jilly', 3),
('Angata', 4),
('Checheneca', 5)

INSERT INTO MinionsVillains(MinionId, VillainId) VALUES
(1,1),(2,2),(3,3),(4,4),(5,5)

--P02
SELECT
	v.[Name], 
	COUNT(m.Id) AS Count 
FROM Villains v
	JOIN MinionsVillains mv ON mv.VillainId = v.Id
    JOIN Minions m ON mv.MinionId = m.Id
GROUP BY v.[Name]
HAVING COUNT(m.Id) > 3
ORDER BY COUNT(m.ID) DESC

--P03
SELECT
	[Name]
FROM Villains
WHERE Id = @Id

SELECT 
	ROW_NUMBER() OVER (ORDER BY m.[Name]) AS [RowNum],
	m.[Name],
	m.Age
FROM MinionsVillains mv
	JOIN Minions m ON mv.MinionId = m.Id
WHERE mv.VillainId = 1
ORDER BY m.[Name]

--P04
SELECT
	[Name]
FROM Towns
WHERE [Name] = 'Ajo'

INSERT INTO Towns([Name]) VALUES
('Berlin')

SELECT
	[Name]
FROM Villains
WHERE [Name] = 'Gru'

INSERT INTO Villains([Name], EvilnessFactorId) VALUES('Ivan', 4)

INSERT INTO Minions([Name], Age) VALUES('Pesho', 20)

INSERT INTO MinionsVillains(MinionId, VillainId) VALUES(
(SELECT Id FROM Minions WHERE [Name] = 'Ivan'), 
(SELECT Id FROM Villains WHERE [Name] = 'Gru'))

--P05
SELECT [Name] 
FROM Countries 
WHERE [Name] = 'Afghanistan'

UPDATE Towns
SET
  [Name] = UPPER([Name])
WHERE (SELECT Id FROM Countries WHERE [Name] = 'Afghanistan') = CountryCode

SELECT 
	t.[Name] 
FROM Towns t
	JOIN Countries c ON c.Id = t.CountryCode
WHERE c.Id = t.CountryCode AND c.[Name] = 'Afghanistan'

--P06
SELECT [Name] 
FROM Villains
WHERE Id = @villainId

DELETE 
FROM MinionsVillains
WHERE VillainId = @villainId

DELETE 
FROM Villains
WHERE Id = @villainId