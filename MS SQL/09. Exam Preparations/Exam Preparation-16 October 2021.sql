CREATE DATABASE CigarShop
USE CigarShop

--P01
CREATE TABLE Sizes(
	Id INT PRIMARY KEY IDENTITY,
	[Length] INT CHECK([Length] >= 10 AND [Length] <= 25) NOT NULL,
	RingRange DECIMAL(15,2) CHECK(RingRange >= 1.5 AND RingRange <= 7.5) NOT NULL
)

CREATE TABLE Tastes(
	Id INT PRIMARY KEY IDENTITY,
	TasteType VARCHAR(20) NOT NULL,
	TasteStrength VARCHAR(15) NOT NULL,
	ImageURL NVARCHAR(100) NOT NULL
)

CREATE TABLE Brands(
	Id INT PRIMARY KEY IDENTITY,
	BrandName VARCHAR(30) UNIQUE,
	BrandDescription VARCHAR(MAX)
)

CREATE TABLE Cigars(
	Id INT PRIMARY KEY IDENTITY,
	CigarName VARCHAR(80) NOT NULL,
	BrandId INT REFERENCES Brands(Id),
	TastId INT REFERENCES Tastes(Id),
	SizeId INT REFERENCES Sizes(Id),
	PriceForSingleCigar DECIMAL(15,2) NOT NULL,
	ImageURL VARCHAR(100) NOT NULL
)

CREATE TABLE Addresses(
	Id INT PRIMARY KEY IDENTITY,
	Town VARCHAR(30) NOT NULL,
	Country VARCHAR(30) NOT NULL,
	Streat VARCHAR(100) NOT NULL,
	ZIP NVARCHAR(20) NOT NULL
)

CREATE TABLE Clients(
	Id INT PRIMARY KEY IDENTITY,
	FirstName VARCHAR(30) NOT NULL,
	LastName VARCHAR(30) NOT NULL,
	Email NVARCHAR(50) NOT NULL,
	AddressId INT REFERENCES Addresses(Id)
)

CREATE TABLE ClientsCigars(
	ClientId INT REFERENCES Clients(Id) NOT NULL,
	CigarId INT REFERENCES Cigars(Id) NOT NULL

	CONSTRAINT PK_ClientsCigars PRIMARY KEY(ClientId, CigarId)
)

--P02
INSERT INTO Cigars(CigarName, BrandId, TastId, SizeId, PriceForSingleCigar, ImageURL) VALUES
('COHIBA ROBUSTO', 9, 1, 5, 15.50, 'cohiba-robusto-stick_18.jpg'),
('COHIBA SIGLO I', 9, 1, 10, 410.00, 'cohiba-siglo-i-stick_12.jpg'),
('HOYO DE MONTERREY LE HOYO DU MAIRE', 14, 5, 11, 7.50, 'hoyo-du-maire-stick_17.jpg'),
('HOYO DE MONTERREY LE HOYO DE SAN JUAN', 14, 4, 15, 32.00, 'hoyo-de-san-juan-stick_20.jpg'),
('TRINIDAD COLONIALES', 2, 3, 8, 85.21, 'trinidad-coloniales-stick_30.jpg')

INSERT INTO Addresses(Town, Country, Streat, ZIP) VALUES
('Sofia', 'Bulgaria', '18 Bul. Vasil levski', '1000'),
('Athens', 'Greece', '4342 McDonald Avenue', '10435'),
('Zagreb', 'Croatia', '4333 Lauren Drive', '10000')

--P03
UPDATE Cigars
SET PriceForSingleCigar += PriceForSingleCigar * 0.2
WHERE TastId = 1

UPDATE Brands
SET BrandDescription = 'New description'
WHERE BrandDescription IS NULL

--P04
ALTER TABLE Clients
DROP CONSTRAINT FK__Clients__Address__33D4B598

DELETE FROM Addresses
WHERE Country LIKE 'C%'

--P05
SELECT
	CigarName,
	PriceForSingleCigar,
	ImageURL
FROM Cigars
ORDER BY PriceForSingleCigar ASC, CigarName DESC

--P06
SELECT
	c.Id,
	c.CigarName,
	c.PriceForSingleCigar,
	t.TasteType,
	t.TasteStrength
FROM Cigars c
	JOIN Tastes t ON t.Id = c.TastId
WHERE t.TasteType = 'Earthy' OR t.TasteType = 'Woody'
ORDER BY c.PriceForSingleCigar DESC

--P07
SELECT
	c.Id,
	c.FirstName + ' ' + c.LastName AS [ClientName],
	c.Email
FROM Clients c
	LEFT JOIN ClientsCigars cc ON cc.ClientId = c.Id
WHERE cc.ClientId IS NULL
ORDER BY [ClientName] ASC

--P08
SELECT TOP(5)
	c.CigarName,
	c.PriceForSingleCigar,
	c.ImageURL
FROM Cigars c
	JOIN Sizes s ON s.Id = c.SizeId
WHERE (s.[Length] >= 12 AND c.CigarName LIKE '%ci%') OR 
	  (c.PriceForSingleCigar > 50 AND s.RingRange > 2.55)
ORDER BY c.CigarName ASC, c.PriceForSingleCigar DESC

--P09
SELECT
	c.FirstName + ' ' + c.LastName AS [FullName],
	a.Country,
	a.ZIP,
	'$' + CAST(MAX(ci.PriceForSingleCigar) AS VARCHAR) AS [CigarPrice]
FROM Clients c
	JOIN ClientsCigars cc ON cc.ClientId = c.Id
	JOIN Cigars ci ON ci.Id = cc.CigarId
	JOIN Addresses a ON a.Id = c.AddressId
WHERE a.ZIP NOT LIKE '%[^0-9]%'
GROUP BY c.FirstName, c.LastName, a.Country, a.ZIP
ORDER BY [FullName] ASC

--P10
SELECT
	c.LastName,
	AVG(s.[Length]) AS [CiagrLength],
	CEILING(s.RingRange) AS [CiagrRingRange]
FROM Clients c
	JOIN ClientsCigars cc ON cc.ClientId = c.Id
	JOIN Cigars ci ON ci.Id = cc.CigarId
	JOIN Sizes s ON s.Id = ci.SizeId
WHERE cc.ClientId IS NOT NULL
GROUP BY c.LastName, s.RingRange
ORDER BY [CiagrLength] DESC

--P11
CREATE FUNCTION udf_ClientWithCigars(@name VARCHAR(30))
RETURNS INT
AS
BEGIN
	DECLARE @numbersOfCigars INT = (SELECT
										COUNT(*)
									FROM Clients c
										JOIN ClientsCigars cc ON cc.ClientId = c.Id
										JOIN Cigars ci ON ci.Id = cc.CigarId
									WHERE c.FirstName = @name)

	RETURN @numbersOfCigars
END

SELECT dbo.udf_ClientWithCigars('Betty')

--P12
CREATE PROC usp_SearchByTaste(@taste VARCHAR(20))
AS
BEGIN
	SELECT
		c.CigarName,
		'$' + CAST(c.PriceForSingleCigar AS VARCHAR(MAX)) AS [Price],
		t.TasteType,
		b.BrandName,
		CAST(s.[Length] AS VARCHAR(MAX)) + ' cm' AS [CigarLength],
		CAST(s.RingRange AS VARCHAR(MAX)) + ' cm' AS [CigarRingRange]
	FROM Cigars c
		JOIN Sizes s ON s.Id = c.SizeId
		JOIN Tastes t ON t.Id = c.TastId
		JOIN Brands b ON b.Id = c.BrandId
	WHERE t.TasteType = @taste
	ORDER BY [CigarLength] ASC, [CigarRingRange] DESC
END

EXEC usp_SearchByTaste 'Woody'