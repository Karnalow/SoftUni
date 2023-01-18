--Part I
USE Gringotts
--P01
SELECT 
	COUNT(*) AS [Count]
FROM WizzardDeposits

--P02
SELECT 
	MAX(MagicWandSize) AS [LongestMagicWand]
FROM WizzardDeposits

--P03
SELECT 
	DepositGroup,
	MAX(MagicWandSize) AS [LongestMagicWand]
FROM WizzardDeposits
GROUP BY DepositGroup

--P04
SELECT TOP(2)
	DepositGroup
FROM WizzardDeposits
GROUP BY DepositGroup
ORDER BY AVG(MagicWandSize)

--P05
SELECT
	DepositGroup,
	SUM(DepositAmount) AS [TotalSum]
FROM WizzardDeposits
GROUP BY DepositGroup

--P06
SELECT
	DepositGroup,
	SUM(DepositAmount) AS [TotalSum]
FROM WizzardDeposits
WHERE MagicWandCreator = 'Ollivander family'
GROUP BY DepositGroup

--P07
SELECT
	DepositGroup,
	SUM(DepositAmount) AS [TotalSum]
FROM WizzardDeposits
WHERE MagicWandCreator = 'Ollivander family'
GROUP BY DepositGroup
HAVING SUM(DepositAmount) < 150000
ORDER BY [TotalSum] DESC

--P08
SELECT
	DepositGroup,
	MagicWandCreator,
	MIN(DepositCharge) AS [MinDepositCharge]
FROM WizzardDeposits
GROUP BY DepositGroup, MagicWandCreator
ORDER BY MagicWandCreator ASC, DepositGroup ASC

--P09
SELECT AgeGroup, COUNT(*) AS WizardCount FROM
(
	SELECT
		CASE
			WHEN Age <= 10 THEN '[0-10]'
			WHEN Age BETWEEN 11 AND 20 THEN '[11-20]'
			WHEN Age BETWEEN 21 AND 30 THEN '[21-30]'
			WHEN Age BETWEEN 31 AND 40 THEN '[31-40]'
			WHEN Age BETWEEN 41 AND 50 THEN '[41-50]'
			WHEN Age BETWEEN 51 AND 60 THEN '[51-60]'
			ELSE '[61+]'
		END AS [AgeGroup], *
	FROM WizzardDeposits
) AS [AgeGroupQuery]
GROUP BY AgeGroup

--P10
SELECT
	DISTINCT(LEFT(FirstName, 1)) AS FirstLetter
FROM WizzardDeposits
WHERE DepositGroup = 'Troll Chest'

--P11
SELECT
	DepositGroup,
	IsDepositExpired,
	AVG(DepositInterest) AS [AverageInterest]
FROM WizzardDeposits
WHERE DepositStartDate >= '01-01-1985'
GROUP BY DepositGroup, IsDepositExpired
ORDER BY DepositGroup DESC, IsDepositExpired ASC

--P12
SELECT SUM([Difference]) AS SumDifference FROM
(
	SELECT FirstName AS [Host Wizard], 
			DepositAmount AS [Host Wizard Deposit],
			LEAD(FirstName) OVER(ORDER BY Id ASC) AS [Guest Wizard],
			LEAD(DepositAmount) OVER(ORDER BY Id ASC) AS [Guest Wizard Deposit],
			DepositAmount - LEAD(DepositAmount) OVER(ORDER BY Id ASC) AS [Difference]
	FROM WizzardDeposits
) AS LeadQuery
WHERE [Guest Wizard] IS NOT NULL

--Part II
USE SoftUni
--P13
SELECT
	e.DepartmentID,
	SUM(e.Salary) AS [SalarySum]
FROM Employees e
GROUP BY e.DepartmentID
ORDER BY e.DepartmentID

--P14
SELECT
	DepartmentID,
	MIN(Salary) AS [MinimumSalary]
FROM Employees
WHERE HireDate > '01-01-2000' AND DepartmentID IN (2, 5, 7) 
GROUP BY DepartmentID

--P15
SELECT * INTO EmployeesWithHighSalaries FROM Employees
WHERE Salary > 30000

DELETE FROM EmployeesWithHighSalaries
WHERE ManagerID = 42

UPDATE EmployeesWithHighSalaries
SET Salary += 5000
WHERE DepartmentID = 1

SELECT
	DepartmentID,
	AVG(Salary) AS [AverageSalary]
FROM EmployeesWithHighSalaries
GROUP BY DepartmentID

--P16
SELECT
	DepartmentID,
	MAX(Salary) AS [MaxSalary]
FROM Employees
GROUP BY DepartmentID
HAVING MAX(Salary) NOT BETWEEN 30000 AND 70000

--P17
SELECT 
	COUNT(Salary) AS [Count] 
FROM Employees
GROUP BY ManagerID
HAVING ManagerID IS NULL

--P18
SELECT DISTINCT
	DepartmentID,
	Salary AS [ThirdHighestSalary]
FROM
(
	SELECT 
		DepartmentID,
		Salary,
		DENSE_RANK() OVER(PARTITION BY DepartmentID ORDER BY Salary DESC) AS [SalaryRank]
	FROM Employees
) AS SalaryRankQuery
WHERE SalaryRank = 3

--P19
SELECT TOP(10) 
	e.FirstName,
	e.LastName, 
	e.DepartmentID
FROM Employees AS e
WHERE e.Salary > (
			SELECT AVG(Salary) AS AverageSalary
			FROM Employees AS em
			WHERE em.DepartmentID = e.DepartmentID
			GROUP BY DepartmentID
)
ORDER BY DepartmentID