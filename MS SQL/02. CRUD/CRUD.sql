USE SoftUni

--P02
SELECT * FROM Departments

--P03
SELECT [Name] From Departments

--P04
SELECT FirstName, LastName, Salary FROM Employees

--P05
SELECT FirstName, MiddleName, LastName FROM Employees

--P06
SELECT FirstName + '.' + LastName + '@softuni.bg' AS [Full Email Address]
	FROM Employees

--P07
SELECT DISTINCT Salary FROM Employees
	ORDER BY Salary

--P08
SELECT * FROM Employees
	WHERE JobTitle = 'Sales Representative'

--P09
SELECT FirstName, LastName, JobTitle FROM Employees
	WHERE Salary >= 20000 AND Salary <= 30000

--P10
SELECT FirstName + ' ' + MiddleName + ' ' + LastName AS [Full Name]
	FROM Employees
		WHERE Salary = 25000 OR Salary = 14000 OR Salary = 12500 OR Salary = 23600

--P11
SELECT FirstName, LastName FROM Employees
	WHERE ManagerID IS NULL

--P12
SELECT FirstName, LastName, Salary
	FROM Employees
		WHERE Salary > 50000
		ORDER BY Salary DESC

--P13
SELECT TOP 5 FirstName, LastName
	FROM Employees
		ORDER BY Salary DESC

--P14
SELECT FirstName, LastName
	FROM Employees
		WHERE DepartmentID != 4

--P15
SELECT * FROM Employees
	ORDER BY Salary DESC,
	FirstName,
	LastName DESC,
	MiddleName