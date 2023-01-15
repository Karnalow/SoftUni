--Part I
USE SoftUni
--P01
SELECT TOP(5)
e.EmployeeId,
e.JobTitle,
e.AddressID,
a.AddressText
FROM Employees e
	JOIN Addresses a ON a.AddressID = e.AddressID
	ORDER BY AddressID ASC

--P02
SELECT TOP(50) 
	e.FirstName AS [First Name],
	e.LastName AS [Last Name],
	t.Name AS Town,
	a.AddressText
 FROM Employees e
	LEFT JOIN Addresses a ON e.AddressID = a.AddressID
	LEFT JOIN Towns t ON a.TownID = t.TownID
	ORDER BY [FirstName], [LastName]

--P03
SELECT 
	EmployeeID,
	FirstName AS [First Name],
	LastName AS [Last Name],
	d.[Name] AS [Department Name]
FROM Employees e
	JOIN Departments d ON e.DepartmentID = d.DepartmentID
	WHERE d.[Name] = 'Sales'
	ORDER BY e.EmployeeID

--P04
SELECT TOP(5)
	e.EmployeeID,
	e.FirstName,
	e.Salary,
	d.[Name] AS [DepartmentName]
FROM Employees e
	JOIN Departments d ON e.DepartmentID = d.DepartmentID
WHERE e.Salary > 15000
ORDER BY e.DepartmentID

--P05
SELECT TOP(3)
	e.EmployeeID,
	e.FirstName
FROM Employees e
	LEFT JOIN EmployeesProjects ep ON e.EmployeeID = ep.EmployeeID
WHERE ep.ProjectID IS NULL
ORDER BY e.EmployeeID

--P06
SELECT
	FirstName AS [First Name],
	LastName AS [Last Name],
	e.HireDate,
	d.[Name] AS [Department Name]
FROM Employees e
	JOIN Departments d ON e.DepartmentID = d.DepartmentID
WHERE e.HireDate > '1999-01-01' AND
	d.[Name] IN ('Sales', 'Finance')
ORDER BY e.HireDate ASC

--P07
SELECT TOP(5)
	e.EmployeeID,
	e.FirstName,
	p.[Name] AS [ProjectName]
FROM Employees e
	JOIN EmployeesProjects ep ON ep.EmployeeID = e.EmployeeID
	JOIN Projects p ON p.ProjectID = ep.ProjectID
WHERE p.StartDate > '2002-08-13'
ORDER BY e.EmployeeID

--P08
SELECT
	e.EmployeeID,
	e.FirstName,
	CASE
		WHEN DATEPART(YEAR, p.StartDate) >= 2005 THEN NULL
		ELSE p.[Name]
	END AS [ProjectName]
FROM Employees e
	JOIN EmployeesProjects ep ON ep.EmployeeID = e.EmployeeID
	JOIN Projects p ON p.ProjectID = ep.ProjectID
WHERE e.EmployeeID = 24

--P09
SELECT
	e.EmployeeID,
	e.FirstName,
	e.ManagerID,
	m.FirstName AS [ManagerName]
FROM Employees e
	JOIN Employees m ON m.EmployeeID = e.ManagerID
WHERE e.ManagerID IN (3,7)
ORDER BY e.EmployeeID

--P10
SELECT TOP(50)
	e.EmployeeID,
	CONCAT(e.FirstName, ' ', e.LastName) AS [EmployeeName],
	CONCAT(m.FirstName, ' ', m.LastName) AS [ManagerName],
	d.[Name] AS [DepartmentName]
FROM Employees e
	LEFT JOIN Employees m ON e.ManagerID = m.EmployeeID
	LEFT JOIN Departments d ON e.DepartmentID = d.DepartmentID
ORDER BY e.EmployeeID

--P11
SELECT TOP(1)
	(SELECT AVG(Salary) FROM Employees WHERE DepartmentID = d.DepartmentID) AS [MinAverageSalary]
FROM Departments d
ORDER BY [MinAverageSalary]

--Part II
USE [Geography]
--P12
SELECT 
	c.CountryCode, 
	m.MountainRange, 
	p.PeakName, 
	p.Elevation 
FROM Countries c
	JOIN MountainsCountries mc ON c.CountryCode = mc.CountryCode
	JOIN Mountains m ON mc.MountainId = m.Id
	JOIN Peaks p ON p.MountainId = m.Id
WHERE c.CountryCode = 'BG' AND p.Elevation > 2835
ORDER BY p.Elevation DESC

--P13
SELECT 
	c.CountryCode, 
	COUNT(MountainId) AS [MountainRanges]
FROM Countries c
	JOIN MountainsCountries mc ON c.CountryCode = mc.CountryCode
	JOIN Mountains m ON mc.MountainId = m.Id
WHERE c.CountryCode IN ('BG', 'RU', 'US')
GROUP BY c.CountryCode

--P14
SELECT TOP(5)
	c.CountryName,
	r.RiverName
FROM Countries c
	LEFT JOIN CountriesRivers cr ON cr.CountryCode = c.CountryCode
	LEFT JOIN Rivers r ON r.Id = cr.RiverId
WHERE c.ContinentCode = 'AF'
ORDER BY c.CountryName

--P15
SELECT 
	ContinentCode, 
	CurrencyCode, 
	CurrencyCount AS CurrencyUsage 
FROM
(
	SELECT 
		ContinentCode, 
		CurrencyCode,
		CurrencyCount, 
		DENSE_RANK() OVER (PARTITION BY ContinentCode ORDER BY CurrencyCount DESC) AS CurrencyRank
	FROM
	(
		SELECT 
			ContinentCode, 
			CurrencyCode, 
			COUNT(*) AS CurrencyCount
		FROM Countries
		GROUP BY ContinentCode, CurrencyCode
	) AS CurrencyCountQuery
	WHERE CurrencyCount > 1
) AS CurrencyRankingQuery
WHERE CurrencyRank = 1

--P16
SELECT
COUNT(c.CountryCode) AS [Count]
FROM Countries c
	LEFT JOIN MountainsCountries mc ON mc.CountryCode = c.CountryCode
	LEFT JOIN Mountains m ON m.Id = mc.CountryCode
WHERE mc.CountryCode IS NULL

--P17
SELECT TOP(5)
	c.CountryName,
	MAX(p.Elevation) AS [HighestPeakElevation],
	MAX(r.[Length]) AS [LongestRiverLength]
FROM Countries c
	LEFT JOIN CountriesRivers cr ON c.CountryCode = cr.CountryCode
	LEFT JOIN Rivers r ON r.Id = cr.RiverId
	LEFT JOIN MountainsCountries mc ON c.CountryCode = mc.CountryCode
	LEFT JOIN Mountains m ON mc.MountainId = m.Id
	LEFT JOIN Peaks p ON p.MountainId = m.Id
GROUP BY c.CountryName
ORDER BY [HighestPeakElevation] DESC, LongestRiverLength DESC, c.CountryName

--P18
SELECT TOP(5) Country,
	CASE
		WHEN PeakName IS NULL THEN '(no highest peak)'
		ELSE PeakName
	END AS [Highest Peak Name],
	CASE
		WHEN Elevation IS NULL THEN 0
		ELSE Elevation
	END AS [Highest Peak Elevation], 
	CASE
		WHEN MountainRange IS NULL THEN '(no mountain)'
		ELSE MountainRange
	END AS [Mountain]
FROM
(
	SELECT *,
	DENSE_RANK() OVER (PARTITION BY Country ORDER BY Elevation DESC) AS PeakRank
	FROM
	(
		SELECT c.CountryName AS Country, 
		p.PeakName, p.Elevation, m.MountainRange
		FROM Countries AS c
		LEFT JOIN MountainsCountries AS mc ON c.CountryCode = mc.CountryCode
		LEFT JOIN Mountains AS m ON mc.MountainId = m.Id
		LEFT JOIN Peaks AS p ON p.MountainId = m.Id
	) AS FullInformationQuery
) AS PeakRankingQuery
WHERE PeakRank = 1
ORDER BY Country, [Highest Peak Elevation]