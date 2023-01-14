--PART I
--P01
USE SoftUni

SELECT FirstName, LastName
FROM Employees
	WHERE FirstName LIKE 'Sa%'

--P02
SELECT FirstName, LastName
FROM Employees
	WHERE LastName LIKE '%ei%'

--P03
SELECT FirstName
FROM Employees
	WHERE (DepartmentID = 3 OR DepartmentID = 10) AND (YEAR(HireDate) >= 1995 AND YEAR(HireDate) <= 2005)

--P04
SELECT FirstName, LastName
FROM Employees
	WHERE JobTitle NOT LIKE '%engineer%'

--P05
SELECT [Name]
FROM Towns
	WHERE LEN([Name]) = 5 OR LEN([Name]) = 6
	ORDER BY [Name] ASC

--P06
SELECT TownID, [Name]
FROM Towns
	WHERE LEFT([Name], 1) IN ('M','K','B','E')
	ORDER BY [Name]

--P07
SELECT TownID, [Name]
FROM Towns
	WHERE LEFT([Name], 1) NOT IN ('R','D','B')
	ORDER BY [Name]

--P08
CREATE VIEW [V_EmployeesHiredAfter2000] AS
	SELECT FirstName, LastName
	FROM Employees
		WHERE YEAR(HireDate) > 2000

--P09
SELECT FirstName, LastName
FROM Employees
	WHERE LEN(LastName) = 5

--P10
SELECT EmployeeID, 
FirstName, 
LastName, 
Salary, 
DENSE_RANK() OVER (PARTITION BY Salary ORDER BY EmployeeID) AS [Rank]
FROM Employees
	WHERE Salary >= 10000 AND Salary <= 50000
	ORDER BY Salary DESC

--P11
SELECT * FROM
	(SELECT EmployeeID, 
	FirstName, 
	LastName, 
	Salary, 
	DENSE_RANK() OVER (PARTITION BY Salary ORDER BY EmployeeID) AS [Rank]
	FROM Employees
		WHERE Salary >= 10000 AND Salary <= 50000) AS [t]
	WHERE RANK = 2
	ORDER BY Salary DESC

--PART II
--P12
USE Geography

SELECT CountryName, IsoCode
FROM Countries
	WHERE LEN(CountryName) - LEN(REPLACE(CountryName, 'A', '')) >= 3
	ORDER BY IsoCode

--P13
SELECT PeakName, RiverName, LOWER(CONCAT(PeakName, RiverName)) AS [Mix]
FROM Peaks, Rivers
	WHERE RIGHT(PeakName, 1) = LEFT(RiverName, 1)
	ORDER BY Mix

--PART III
--P14
USE Diablo

SELECT TOP(50) [Name], FORMAT([Start], 'yyyy-MM-dd') AS [Start]
FROM Games
	WHERE YEAR([Start]) = 2011 OR YEAR([Start]) = 2012
	ORDER BY [Start], [Name]

--P15
SELECT Username, 
SUBSTRING ([Email], CHARINDEX('@', [Email]) + 1,LEN([Email])) AS [Email Provider]
FROM Users
	ORDER BY [Email Provider], Username

--P16
SELECT Username, IpAddress
FROM Users
	WHERE IpAddress LIKE '___.1%.%.___'
	ORDER BY Username

--P17
SELECT [Name],
	CASE
		WHEN DATEPART(HOUR, [Start]) BETWEEN 0 AND 11 THEN 'Morning'
		WHEN DATEPART(HOUR, [Start]) BETWEEN 12 AND 17 THEN 'Afternoon'
		WHEN DATEPART(HOUR, [Start]) BETWEEN 18 AND 24 THEN 'Evening'
	END AS [Part of the Day],
	CASE
		WHEN Duration <= 3 THEN 'Extra Short'
		WHEN Duration BETWEEN 4 AND 6 THEN 'Short'
		WHEN Duration > 6 THEN 'Long'
		ELSE 'Extra Long'
	END AS [Duration]
FROM Games
	ORDER BY [Name], Duration, [Part of the Day]

--Part IV
--P18
CREATE DATABASE Orders
USE Orders

SELECT [ProductName], OrderDate, 
DATEADD(DAY, 3, OrderDate) AS [Pay Due],
DATEADD(MONTH, 1, OrderDate) AS [Deliver Due]
FROM Orders