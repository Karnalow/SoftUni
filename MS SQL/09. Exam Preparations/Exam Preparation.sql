--P01
CREATE DATABASE WMS
USE WMS

CREATE TABLE Clients(
	ClientId INT PRIMARY KEY IDENTITY,
	FirstName VARCHAR(50) NOT NULL,
	LastName VARCHAR(50) NOT NULL,
	Phone CHAR(12) CHECK(LEN(Phone) = 12) NOT NULL
)

CREATE TABLE Mechanics(
	MechanicId INT PRIMARY KEY IDENTITY,
	FirstName VARCHAR(50) NOT NULL,
	LastName VARCHAR(50) NOT NULL,
	[Address] VARCHAR(255) NOT NULL
)

CREATE TABLE Models(
	ModelId INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(50) UNIQUE
)

CREATE TABLE Jobs(
	JobId INT PRIMARY KEY IDENTITY,
	ModelId INT REFERENCES Models(ModelId),
	[Status] VARCHAR(11) DEFAULT 'Pending' CHECK([Status] = 'Pending' OR [Status] = 'In Progress' OR [Status] = 'Finished'),
	ClientId INT REFERENCES Clients(ClientId),
	MechanicId INT REFERENCES Mechanics(MechanicId),
	IssueDate DATE NOT NULL,
	FinishDate DATE
)

CREATE TABLE Orders(
	OrderId INT PRIMARY KEY IDENTITY,
	JobId INT REFERENCES Jobs(JobId),
	IssueDate DATE,
	Delivered BIT DEFAULT 'False'
)

CREATE TABLE Vendors(
	VendorId INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(50) UNIQUE
)

CREATE TABLE Parts(
	PartId INT PRIMARY KEY IDENTITY,
	SerialNumber VARCHAR(50) UNIQUE,
	[Description] VARCHAR(255),
	Price DECIMAL(15,2) CHECK(Price > 0 AND PRICE <= 9999.99) NOT NULL,
	VendorId INT REFERENCES Vendors(VendorId),
	StockQty INT DEFAULT 0 CHECK(StockQty >= 0)
)

CREATE TABLE OrderParts(
	OrderId INT REFERENCES Orders(OrderId),
	PartId INT REFERENCES Parts(PartId),
	Quantity INT DEFAULT 1 CHECK(Quantity > 0)

	CONSTRAINT PK_OrderParts PRIMARY KEY (OrderId, PartId)
)

CREATE TABLE PartsNeeded(
	JobId INT REFERENCES Jobs(JobId),
	PartId INT REFERENCES Parts(PartId),
	Quantity INT DEFAULT 1 CHECK(Quantity > 0)

	CONSTRAINT PK_PartsNeeded PRIMARY KEY (JobId, PartId)
)

--P02
INSERT INTO Clients(FirstName, LastName, Phone) VALUES
('Teri', 'Ennaco', '570-889-5187'),
('Merlyn', 'Lawler', '201-588-7810'),
('Georgene', 'Montezuma', '925-615-5185'),
('Jettie', 'Mconnell', '908-802-3564'),
('Lemuel', 'Latzke', '631-748-6479'),
('Melodie', 'Knipp', '805-690-1682'),
('Candida', 'Corbley', '908-275-8357')

INSERT INTO Parts(SerialNumber, [Description], Price, VendorId) VALUES
('WP8182119', 'Door Boot Seal', 117.86, 2),
('W10780048', 'Suspension Rod', 42.81, 1),
('W10841140', 'Silicone Adhesive', 6.77, 4),
('WPY055980', 'High Temperature Adhesive', 13.94, 3)

--P03
UPDATE Jobs
SET MechanicId = 3, [Status] = 'In Progress'
WHERE [Status] = 'Pending'

--P04
DELETE FROM OrderParts
WHERE OrderId = 19

DELETE FROM Orders
WHERE OrderId = 19

--P05
SELECT
	m.FirstName + ' ' + m.LastName AS [Mechanic],
	j.[Status],
	j.IssueDate
FROM Mechanics m
	JOIN Jobs j ON j.MechanicId = m.MechanicId
ORDER BY m.MechanicId ASC, j.IssueDate ASC, j.JobId ASC

--P06
SELECT
	c.FirstName + ' ' + c.LastName AS [Client],
	DATEDIFF(DAY, j.IssueDate, '2017-04-24') AS [Days going],
	j.[Status]
FROM Clients c
	JOIN Jobs j ON j.ClientId = c.ClientId
WHERE j.[Status] != 'Finished'
ORDER BY [Days going] DESC , c.ClientId ASC

--P07
SELECT
	m.FirstName + ' ' + m.LastName AS [Mechanic],
	AVG(DATEDIFF(DAY, j.IssueDate, j.FinishDate)) AS [Average Days]
FROM Mechanics m
	JOIN Jobs j ON j.MechanicId = m.MechanicId
GROUP BY m.MechanicId, m.FirstName, m.LastName

--P08
SELECT
	m.FirstName + ' ' + m.LastName AS [Available]
FROM Mechanics m
	LEFT JOIN Jobs j ON j.MechanicId = m.MechanicId
WHERE j.[Status] = NULL OR (SELECT COUNT(JobId)
							FROM Jobs
							WHERE [Status] != 'Finished' AND MechanicId = m.MechanicId
							GROUP BY MechanicId, [Status]) IS NULL
GROUP BY m.MechanicId, (m.FirstName + ' ' + m.LastName)

--P09
SELECT 
	j.JobId,
	ISNULL(SUM(p.Price * op.Quantity),0) AS [Total]
FROM Jobs j
	LEFT JOIN Orders o ON o.JobId = j.JobId
	LEFT JOIN OrderParts op ON op.OrderId = o.OrderId
	LEFT JOIN Parts p ON p.PartId = op.PartId
WHERE j.[Status] = 'Finished'
GROUP BY j.JobId
ORDER BY [Total] DESC, j.JobId ASC

--P10
SELECT
	p.PartId,
	p.[Description],
	pn.Quantity AS [Required],
	p.StockQty AS [InStock]
FROM Parts p
	JOIN PartsNeeded pn ON pn.PartId = p.PartId
	JOIN OrderParts op ON op.PartId = p.PartId
	LEFT JOIN Jobs j ON j.JobId = pn.JobId
WHERE j.[Status] != 'Finished'

--P11
CREATE PROC usp_PlaceOrder(@jobId INT, @serialNumber VARCHAR(50), @qty INT)
AS

DECLARE @status VARCHAR(10) = (SELECT [Status] FROM Jobs WHERE JobId = 1)

DECLARE @partId VARCHAR(10) = (SELECT PartId FROM Parts WHERE SerialNumber = @serialNumber)

IF (@status = 'Finished')
THROW 50011 , 'This job is not active!', 1
ELSE IF (@qty <= 0)
THROW 50012, 'Part quantity must be more than zero!', 1
ELSE IF (@status IS NULL)
THROW 50013, 'Job not found!', 1
ELSE IF (@partId IS NULL)
THROW 50014, 'Part not found', 1

DECLARE @orderId INT = (SELECT OrderId FROM Orders WHERE JobId = @jobId)

IF (@orderId IS NULL)
BEGIN
INSERT INTO Orders (JobId, IssueDate) VALUES
(@jobId, NULL)

SET @orderId = (SELECT OrderId FROM Orders WHERE JobId = @jobId)

INSERT INTO OrderParts (OrderId, PartId, Quantity) VALUES
(@orderId, @partId, @qty)
END

ELSE
BEGIN
DECLARE @issueDate DATE = (SELECT * FROM Orders WHERE OrderId = @orderId)

IF (@issueDate IS NULL)
INSERT INTO OrderParts(OrderId, PartId, Quantity) VALUES
(@orderId, @partId, @qty)

ELSE
UPDATE OrderParts
SET Quantity += @qty
WHERE OrderId = @orderId AND PartId = @partId
END