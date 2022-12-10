--P01
CREATE TABLE Persons(
 PersonID INT NOT NULL,
 FirstName VARCHAR(50),
 Salary DECIMAL(15,2),
 PassportID INT
)

CREATE TABLE Passports(
 PassportsId INT NOT NULL,
 PassportNumber VARCHAR(50)
)

INSERT INTO Persons VALUES
(1,'Roberto',43300.00,102),
(2,'Tom',56100.00,103),
(3,'Yana',60200.00,101)

INSERT INTO Passports VALUES 
(101, 'N34FG21B'),
(102, 'K65LO4R7'),
(103, 'ZE657QP2')	

ALTER TABLE Persons
ADD CONSTRAINT PK_PersonID
PRIMARY KEY (PersonId) 

ALTER TABLE Passports
ADD CONSTRAINT PK_PassportsId
PRIMARY KEY (PassportsId) 

ALTER TABLE Persons
ADD CONSTRAINT FK_PersonsPasspord
FOREIGN KEY (PassportId) REFERENCES Passports(PassportsId) 

--P02
CREATE TABLE Models(
ModelID INT PRIMARY KEY IDENTITY(101, 1),
[Name] VARCHAR(20),
ManufactuderID INT NOT NULL
)

CREATE TABLE Manufactures(
ManufacturerID INT PRIMARY KEY IDENTITY,
[Name] VARCHAR(20),
EstablishedOn DATE
)

INSERT INTO Models VALUES
('X1', 1),
('i6', 1),
('Model S', 2),
('Model X', 2),
('Model 3', 2),
('Nova', 3)

INSERT INTO Manufactures VALUES
('BMW', '07/03/1916'),
('Tesla', '01/01/2003'),
('Lada', '01/05/1966')

ALTER TABLE Models
	ADD FOREIGN KEY (ManufactuderID ) REFERENCES Manufactures(ManufacturerID)

--P03
CREATE TABLE Students(
StudentID INT PRIMARY KEY IDENTITY,
[Name] VARCHAR(20)
)

INSERT INTO Students VALUES
('Mila'),
('Toni'),
('Ron')

CREATE TABLE Exams(
ExamID INT PRIMARY KEY IDENTITY(101, 1),
[Name] VARCHAR(20)
)

INSERT INTO Exams VALUES
('SpringMVC'),
('Neo4j'),
('Oracle 11g')

CREATE TABLE StudentsExams(
StudentID INT NOT NULL,
ExamID INT NOT NULL
)

INSERT INTO StudentsExams VALUES
(1, 101),
(1, 102),
(2, 101),
(3, 103),
(2, 102),
(2, 103)

ALTER TABLE StudentsExams
	ADD FOREIGN KEY (StudentID) REFERENCES Students(StudentID)

ALTER TABLE StudentsExams
	ADD FOREIGN KEY (ExamID) REFERENCES Exams(ExamID)

--P04
CREATE TABLE Teachers(
TeacherID INT PRIMARY KEY IDENTITY(101, 1),
[Name] VARCHAR(20),
ManagerID INT
)

INSERT INTO Teachers VALUES
('John', NULL),
('Maya', 106),
('Silvia', 106),
('Ted', 105),
('Mark', 101),
('Greta', 101)

ALTER TABLE Teachers
	ADD FOREIGN KEY (ManagerID) REFERENCES Teachers(TeacherID)

--P05
CREATE DATABASE OnlineStore
USE OnlineStore

CREATE TABLE Orders(
OrderId INT PRIMARY KEY,
CustomerID INT
)

CREATE TABLE Customers(
CustomersID INT PRIMARY KEY,
[Name] VARCHAR(50),
Birthday DATE,
CityID INT
)

CREATE TABLE Cities(
CityID INT PRIMARY KEY,
[Name] VARCHAR(50)
)

CREATE TABLE OrderItems(
OrderID INT NOT NULL,
ItemID INT NOT NULL
)

CREATE TABLE Items(
ItemID INT PRIMARY KEY,
[Name] VARCHAR(50),
ItemTypeID INT
)

CREATE TABLE ItemTypes(
ItemTypeID INT PRIMARY KEY,
[Name] VARCHAR(50)
)

ALTER TABLE Orders
	ADD FOREIGN KEY (CustomerID) REFERENCES Customers(CustomersID)

ALTER TABLE Customers
	ADD FOREIGN KEY (CityID) REFERENCES Cities(CityID)

ALTER TABLE OrderItems
	ADD FOREIGN KEY (OrderID) REFERENCES Orders(OrderId)

ALTER TABLE OrderItems
	ADD FOREIGN KEY (ItemID) REFERENCES Items(ItemID)

ALTER TABLE Items
	ADD FOREIGN KEY (ItemTypeID) REFERENCES ItemTypes(ItemTypeID)

--P06
CREATE DATABASE Universiry
USE Universiry

CREATE TABLE Majors(
MajorID INT PRIMARY KEY,
[Name] VARCHAR(50)
)

CREATE TABLE Payments(
PaymentID INT PRIMARY KEY,
PaymentDate DATE,
PaymentAmount DECIMAL(6,2),
StudentID INT NOT NULL
)

CREATE TABLE Students(
StudentID INT PRIMARY KEY,
StudentNumber INT NOT NULL,
StudentName VARCHAR(50),
MajorID INT NOT NULL
)

CREATE TABLE Agenda(
StudentID INT NOT NULL,
SubjectID INT NOT NULL
)

CREATE TABLE Subjects(
SubjectID INT PRIMARY KEY,
SubjectName VARCHAR(50)
)

ALTER TABLE Students
	ADD FOREIGN KEY (MajorID) REFERENCES Majors(MajorID)

ALTER TABLE Payments
	ADD FOREIGN KEY (StudentID) REFERENCES Students(StudentID)

ALTER TABLE Agenda
	ADD FOREIGN KEY (StudentID) REFERENCES Students(StudentID)

ALTER TABLE Agenda
	ADD FOREIGN KEY (SubjectID) REFERENCES Subjects(SubjectID)

--P09
SELECT m.MountainRange, p.PeakName, p.Elevation
	FROM Peaks p
		JOIN Mountains m ON p.MountainId = m.Id
			WHERE MountainRange = 'Rila'
			ORDER BY p.Elevation DESC