--P01
CREATE DATABASE Minions

--P02

USE Minions

CREATE TABLE Minions
(
	Id INT PRIMARY KEY,
	[Name] VARCHAR(30),
	Age INT
)

CREATE TABLE Towns
(
	Id INT PRIMARY KEY,
	[Name] VARCHAR(50),
)

--P03
ALTER TABLE Minions
ADD TownId INT

ALTER TABLE Minions
ADD FOREIGN KEY (TownId) REFERENCES Towns(Id)

--P04
INSERT INTO Towns (Id, Name) VALUES
(1, 'Sofia'),
(2, 'Plovdiv'),
(3, 'Varna')

INSERT INTO Minions (Id, Name, Age, TownId) VALUES
(1, 'Kevin', 22, 1),
(2, 'Bob', 15, 3),
(3, 'Steward', NULL, 2)

SELECT * FROM Towns
SELECT * FROM Minions

--P05
DELETE FROM Minions

--P06
DROP TABLE Minions
DROP TABLE Towns

--P07
CREATE TABLE People
(
	[Id] INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(200) NOT NULL,
	[Picture] VARBINARY(MAX),
	[Height] DECIMAL(5, 2),
	[Weight] DECIMAL(5, 2),
	[Gender] CHAR(1) NOT NULL CHECK(Gender = 'm' OR Gender = 'f'),
	[Birthdate] DATE NOT NULL,
	[Biography] NVARCHAR(MAX)
)

INSERT INTO People (Name, Picture, Height, Weight, Gender, Birthdate, Biography) VALUES
('Ivan', NULL, 1.80, 75.5, 'm', '2004-04-21', NULL),
('Hristo', NULL, 1.70, 65.7, 'm', '2004-08-13', NULL),
('Angel', NULL, 1.75, 63.0, 'm', '2004-12-12', NULL),
('Stefi', NULL, 1.65, 55.7, 'f', '2004-08-15', NULL),
('Geri', NULL, 1.69, 60.0, 'f', '2007-08-23', NULL)

--P08
CREATE TABLE Users
(
	[Id] BIGINT PRIMARY KEY IDENTITY,
	Username VARCHAR(30) NOT NULL,
	[Password] VARCHAR(26) NOT NULL,
	ProfilePicture VARCHAR(MAX),
	LastLoginTime DATETIME,
	IsDeleted BIT
)

INSERT INTO Users (Username, [Password], ProfilePicture, LastLoginTime, IsDeleted) VALUES
('Karnalow', 'strongPass21', 'https://cdn.pixabay.com/photo/2015/04/23/22/00/tree-736885__480.jpg', '2022-05-21 20:08:53', 1),
('Karnalov', 'weakpass123', 'https://www.bestmobile.pk/mobile-wallpapers/img_320x480/1504588158_320x480_pexels-photo-445.jpeg', '2019-11-14 22:30:00', 0),
('Iceto04', 'megapassbg', 'https://www.planetware.com/wpimages/2020/02/france-in-pictures-beautiful-places-to-photograph-eiffel-tower.jpg', '2022-03-19 05:45:15', 1),
('Angata', 'vestak1231', 'https://images.news18.com/ibnlive/uploads/2021/06/1622715559_disha.jpg?impolicy=website&width=510&height=356', NULL, 0),
('Pesho', 'peshoegotin', 'https://media.istockphoto.com/photos/giraffe-riding-an-elephant-on-field-friendship-and-cooperation-picture-id1349363968?b=1&k=20&m=1349363968&s=170667a&w=0&h=qa1ppsGZuM81Un7tvmClIlESWyUmm0kYkbgy09eLvuY=', NULL, 1)

--P09
ALTER TABLE Users
DROP CONSTRAINT PK__Users__3214EC07E41601DF

ALTER TABLE Users
ADD CONSTRAINT PK_IdUsername PRIMARY KEY (Id, Username)

--P10
ALTER TABLE Users
ADD CONSTRAINT CH_PasswordIsAtLeast5Symbols CHECK (LEN([Password]) > 4)

--P11
ALTER TABLE Users
ADD CONSTRAINT DF_LastLoginTime DEFAULT GETDATE() FOR LastLoginTime

--P12
ALTER TABLE Users
DROP CONSTRAINT PK_IdUsername

ALTER TABLE Users
ADD CONSTRAINT PK_Id PRIMARY KEY (Id)

ALTER TABLE Users
ADD CONSTRAINT CH_UsernameIsAtLeast3Symbols CHECK (LEN(Username) > 2)

--P13
USE Movies

CREATE DATABASE Movies

CREATE TABLE Directors
(
	Id INT PRIMARY KEY IDENTITY,
	DirectorName VARCHAR(50),
	Notes NVARCHAR(MAX)
)
CREATE TABLE Genres
(
	Id INT PRIMARY KEY IDENTITY,
	GenreName VARCHAR(50),
	Notes NVARCHAR(MAX)
)
CREATE TABLE Categories
(
	Id INT PRIMARY KEY IDENTITY,
	CategoryName VARCHAR(50),
	Notes NVARCHAR(MAX)
)
CREATE TABLE Movies
(
	Id INT PRIMARY KEY IDENTITY,
	Title VARCHAR(30),
	DirectorId INT,
	CopyrightYear INT,
	[Length] VARCHAR(10),
	GenreId INT,
	CategoryId INT,
	Rating INT,
	Notes NVARCHAR(MAX)
)

INSERT INTO Directors (DirectorName, Notes) VALUES
('Ivan', NULL),
('Pesho', 'Mnogo dobra kniga'),
('Gosho', NULL),
('Hristo', 'Nai-dobrata mi kniga do momenta'),
('Angel', NULL)

INSERT INTO Genres (GenreName, Notes) VALUES
('Fable', NULL),
('Fairy Tale', NULL),
('Fantasy', NULL),
('Fiction', NULL),
('Folklore', NULL)

INSERT INTO Movies (Title, DirectorId, CopyrightYear, [Length], GenreId, CategoryId, Rating, Notes) VALUES
('The great book', 1, 2004, '120min', 1, 1, 5, NULL),
('Jungle', 2, 2018, '100min', 2, 2, 8, NULL),
('American History', 3, 2000, '350min', 3, 3, 7, NULL),
('Football', 4, 1956, '60min', 4, 4, 10, NULL),
('Basketball', 5, 1987, '80min', 5, 5, 4, NULL)

INSERT INTO Categories (CategoryName, Notes) VALUES
('Action', NULL),
('Adventure', NULL),
('Comedy', NULL),
('Drama', NULL),
('Fantasy', NULL)

--P14
CREATE DATABASE CarRental
USE CarRental

CREATE TABLE Categories
(
	Id INT PRIMARY KEY IDENTITY,
	CategoryName VARCHAR(10),
	DailyRate INT,
	WeeklyRate INT,
	MonthlyRate INT,
	WeekendRate INT
)

INSERT INTO Categories (CategoryName, DailyRate, WeeklyRate, MonthlyRate, WeekendRate) VALUES
('Sedan', 7, 5, 6, 10),
('Sport', 4, 2, 8, 3),
('Hatchback', 10, 10, 10, 10)

CREATE TABLE Cars
(
	Id INT PRIMARY KEY IDENTITY,
	PlateNumber VARCHAR(6),
	Manufacturer VARCHAR(10),
	Model VARCHAR(10),
	CarYear VARCHAR(4),
	CategoryId INT,
	Doors INT,
	Picture NVARCHAR(MAX),
	Condition VARCHAR(10),
	Available BIT
)

INSERT INTO Cars (PlateNumber, Manufacturer, Model, CarYear, CategoryId, Doors, Picture, Condition, Available) VALUES
('PA7275', 'Audi', 'A4', '2003', 1, 5, NULL, 'Perfect', 1),
('PA2222', 'BMW', 'M5', '2013', 2, 5, NULL, 'Good', 0),
('PB0000', 'Mercedes', 'C202', '2020', 3, 5, NULL, 'Poor', 1)

CREATE TABLE Employees
(
	Id INT PRIMARY KEY IDENTITY,
	FirstName VARCHAR(10),
	LastName VARCHAR(10),
	Title VARCHAR(10),
	Notes VARCHAR(MAX)
)

INSERT INTO Employees (FirstName, LastName, Title, Notes) VALUES
('Ivan', 'Karnalov', NULL, NULL),
('Hristo', 'Slavchev', NULL, NULL),
('Angel', 'Nikolov', NULL, NULL)

CREATE TABLE Customers
(
	Id INT PRIMARY KEY IDENTITY,
	DriverLicenceNumber VARCHAR(4),
	FullName VARCHAR(20),
	[Address] VARCHAR(40),
	City VARCHAR(20),
	ZIPCode VARCHAR(4),
	Notes VARCHAR(MAX)
)

INSERT INTO Customers (DriverLicenceNumber, FullName, [Address], City, ZIPCode, Notes) VALUES
('0000', 'Ivan Karnoalv', 'Hristo Smirnenski', 'Bracigovo', '4550', NULL),
('1111', 'Hristo Slavchev', 'Bogdan Mindizov', 'Chernogorovo', '1560', NULL),
('2222', 'Angel Nikolov', 'Nqkude Tam', 'Kozarsko', '4567', NULL)

CREATE TABLE RentalOrders
(
	Id INT PRIMARY KEY IDENTITY,
	EmployeeId INT,
	CustomerId INT,
	CarId INT,
	TankLevel INT,
	KilometrageStart INT,
	KilometrageEnd INT,
	TotalKilometrage INT,
	StartDate DATE,
	EndDate DATE,
	TotalDays INT,
	RateApplied VARCHAR(2),
	TaxRate VARCHAR(2),
	OrderStatus VARCHAR(10),
	NOTES VARCHAR(MAX)
)

INSERT INTO RentalOrders (EmployeeId, CustomerId, CarId, TankLevel, KilometrageStart, KilometrageEnd, TotalKilometrage, StartDate, EndDate, TotalDays, RateApplied, TaxRate, OrderStatus, NOTES) VALUES
(1, 1, 1, 60, 0, 300, 100000, '2004-04-21', '2004-12-29', 100, '10', '7', 'Waiting', NULL),
(2, 2, 2, 50, 0, 300, 100000, '2004-04-21', '2004-12-29', 100, '10', '7', 'Waiting', NULL),
(3, 3, 3, 40, 0, 300, 100000, '2004-04-21', '2004-12-29', 100, '10', '7', 'Waiting', NULL)

--P15
CREATE DATABASE Hotel
USE Hotel

CREATE TABLE Employees
(
	Id INT PRIMARY KEY,
	FirstName VARCHAR(90) NOT NULL,
	LastName VARCHAR(90) NOT NULL,
	Title VARCHAR(50) NOT NULL,
	Notes VARCHAR(MAX)
)

INSERT INTO Employees(Id, FirstName, LastName, Title, Notes) VALUES
(1, 'Ivan', 'Karnalov', 'BOSS', NULL),
(2, 'Hristo', 'Slavchev', 'Employe', NULL),
(3, 'Angel', 'Nikolov', 'Employe', NULL)

CREATE TABLE Customers
(
	AccountNumber INT PRIMARY KEY,
	FirstName VARCHAR(90) NOT NULL,
	LastName VARCHAR(90) NOT NULL,
	PhoneNumber CHAR(10) NOT NULL,
	EmergencyName VARCHAR(90) NOT NULL,
	EmergencyNumber CHAR(10) NOT NULL,
	Notes VARCHAR(MAX)
)

INSERT INTO Customers(AccountNumber, FirstName, LastName, PhoneNumber, EmergencyName, EmergencyNumber, Notes) VALUES
(1, 'Ivan', 'Karnalov', '0894679971', 'Kurta', '4589126745', NULL),
(2, 'Hristo', 'Slavchev', '0894234212', 'Shprica', '8956329056', NULL),
(3, 'Angel', 'Nikolov', '0873672389', 'Kovacha', '8956341678', NULL)

CREATE TABLE RoomStatus
(
	RooomStatus BIT,
	Notes VARCHAR(MAX)
)

INSERT INTO RoomStatus(RooomStatus, Notes) VALUES
(1, NULL),
(0, NULL),
(1, NULL)

CREATE TABLE RoomTypes
(
	RoomType VARCHAR(20) NOT NULL,
	Notes VARCHAR(MAX)
)

INSERT INTO RoomTypes(RoomType, Notes) VALUES
('Cheap', NULL),
('Expensive', NULL),
('Cheap', NULL)

CREATE TABLE BedTypes
(
	BedType VARCHAR(20) NOT NULL,
	Notes VARCHAR(MAX)
)

INSERT INTO BedTypes(BedType, Notes) VALUES
('Double', NULL),
('Single', NULL),
('Double', NULL)

CREATE TABLE Rooms
(
	RoomNumber INT PRIMARY KEY,
	RoomType VARCHAR(20) NOT NULL,
	BedType VARCHAR(20) NOT NULL,
	Rate INT,
	RoomStatus BIT NOT NULL,
	Notes VARCHAR(MAX)
)

INSERT INTO Rooms(RoomNumber, RoomType, BedType, Rate, RoomStatus, Notes) VALUES
(200, 'Double', 'Double', 10, 1, NULL),
(201, 'Single', 'Single', 8, 0, NULL),
(202, 'Double', 'Double', 7, 1, NULL)

CREATE TABLE Payments
(
	Id INT PRIMARY KEY,
	EmployeeId INT NOT NULL,
	PaymentDate DATETIME NOT NULL,
	AccountNumber INT NOT NULL,
	FirstDateOccupied DATETIME NOT NULL,
	LastDateOccupied DATETIME NOT NULL,
	TotalDays INT NOT NULL,
	AmountCharge DECIMAL(15, 2),
	TaxRate INT,
	TaxAmount INT,
	PaymentTotal DECIMAL(15, 2),
	Notes VARCHAR(MAX)
)

INSERT INTO Payments(Id, EmployeeId, PaymentDate, AccountNumber, FirstDateOccupied, LastDateOccupied, TotalDays, AmountCharge, TaxRate, TaxAmount, PaymentTotal, Notes) VALUES
(1, 1, GETDATE(), 1, '05-05-2012', '06-05-2012', 1, 345.12, NULL, NULL, 345.12, NULL),
(2, 2, GETDATE(), 2, '05-05-2012', '06-05-2012', 1, 330.30, NULL, NULL, 330.30, NULL),
(3, 3, GETDATE(), 3, '05-05-2012', '06-05-2012', 1, 500.34, NULL, NULL, 500.34, NULL)

CREATE TABLE Occupancies
(
	Id INT PRIMARY KEY,
	EmployeeId INT NOT NULL,
	DateOccupied DATETIME NOT NULL,
	AccountNumber INT NOT NULL,
	RoomNumber INT NOT NULL,
	RateApplied INT,
	PhoneCharge DECIMAL(15, 2),
	Notes VARCHAR(MAX)
)

INSERT INTO Occupancies(Id, EmployeeId, DateOccupied, AccountNumber, RoomNumber, RateApplied, PhoneCharge, Notes) VALUES
(1, 1, '05-05-2012', 100, 200, 10, 50.50, NULL),
(2, 2, '06-05-2012', 200, 201, 6, 100.32, NULL),
(3, 3, '05-05-2012', 300, 202, 4, 80.99, NULL)

--P16
CREATE DATABASE SoftUni
USE SoftUni

CREATE TABLE Towns
(
	Id INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(50) NOT NULL,
)

CREATE TABLE Addresses
(
	Id INT PRIMARY KEY IDENTITY,
	AddressText VARCHAR(50),
	TownId INT NOT NULL
)

CREATE TABLE Departments
(
	Id INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(50) NOT NULL
)

CREATE TABLE Employees
(
	Id INT PRIMARY KEY IDENTITY,
	FirstName VARCHAR(20) NOT NULL,
	MiddleName VARCHAR(20) NOT NULL,
	LastName VARCHAR(20) NOT NULL,
	JobTitle VARCHAR(20) NOT NULL,
	DepartmentId INT NOT NULL,
	HireDate DATETIME,
	Salary DECIMAL(15, 2) NOT NULL,
	AddressId INT NOT NULL
)

--P18
INSERT INTO Towns([Name]) VALUES
('Sofia'),
('Plovdiv'),
('Varna'),
('Burgas')

INSERT INTO Departments([Name]) VALUES
('Engineering'),
('Sales'),
('Marketing'),
('Software Development'),
('Quality Assurance')

INSERT INTO Employees(FirstName, MiddleName, LastName, JobTitle, DepartmentId, HireDate, Salary, AddressId) VALUES
('Ivan', 'Ivanov', 'Ivanov', '.NET Developer', 1, 01/02/2013, 3500.00, 1),
('Petar', 'Petrov', 'Petrov', 'Senior Engineer', 2, 02/03/2004, 4000.00, 2),
('Maria', 'Petrova', 'Ivanova', 'Intern', 3, 28/08/2016, 525.25, 3),
('Georgi', 'Teziev', 'Ivanov', 'CEO', 4, 09/12/2007, 3000.00, 4),
('Peter', 'Pan', 'Pan', 'Intern', 5, 28/08/2016, 599.88, 5)

--P19
SELECT * FROM Towns
SELECT * FROM Departments
SELECT * FROM Employees

--P20
SELECT * FROM Towns
ORDER BY [Name]

SELECT * FROM Departments
ORDER BY [Name]

SELECT * FROM Employees
ORDER BY Salary DESC

--P21
SELECT  [Name] FROM Towns
	ORDER BY [Name]

SELECT  [Name] FROM Departments
	ORDER BY [Name]

SELECT FirstName, LastName, JobTitle, Salary FROM Employees
	ORDER BY FirstName, LastName, JobTitle, Salary DESC

--P22
UPDATE Employees
	SET Salary *= 1.1

SELECT Salary FROM Employees

--P23
USE Hotel

UPDATE Payments
	SET TaxRate *= 0.97

SELECT TaxRate FROM Payments

--P24
DELETE FROM Occupancies