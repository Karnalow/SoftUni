--Part I
USE SoftUni
--P01
CREATE PROC usp_GetEmployeesSalaryAbove35000
AS
BEGIN
	SELECT 
		FirstName,
		LastName
	FROM Employees
	WHERE Salary > 35000
END

--P02
CREATE PROC usp_GetEmployeesSalaryAboveNumber(@Number DECIMAL(18,4))
AS
BEGIN
	SELECT 
		FirstName,
		LastName
	FROM Employees
	WHERE Salary >= @Number
END

--P03
CREATE PROC usp_GetTownsStartingWith(@StartingString VARCHAR(MAX))
AS
BEGIN
	SELECT 
		[Name]
	FROM Towns
	WHERE [Name] LIKE (@StartingString + '%')
END

--P04
CREATE PROC usp_GetEmployeesFromTown(@TownName VARCHAR(MAX))
AS
BEGIN
	SELECT 
		FirstName,
		LastName
	FROM Employees e
		JOIN Addresses a ON a.AddressID = e.AddressID
		JOIN Towns t ON t.TownID = a.TownID
	WHERE t.[Name] = @TownName
END

--P05
CREATE FUNCTION ufn_GetSalaryLevel(@Salary MONEY)
RETURNS VARCHAR(10)
AS
BEGIN
	IF @Salary < 30000
		RETURN 'Low'
	ELSE IF @Salary <= 50000
		RETURN 'Average'
	RETURN 'High'
END

--P06
CREATE PROC usp_EmployeesBySalaryLevel(@LevelOfSalary NVARCHAR(10))
AS
BEGIN
	SELECT 
		FirstName,
		LastName
	FROM Employees
	WHERE dbo.ufn_GetSalaryLevel(Salary) = @LevelOfSalary
END

--P07
CREATE FUNCTION ufn_IsWordComprised(@SetOfLetters NVARCHAR(MAX), @Word NVARCHAR(MAX))
RETURNS BIT
AS
BEGIN
	DECLARE @Result BIT	= 1;
	DECLARE @Index INT = 1;

	WHILE (@Index <= LEN(@word))
	BEGIN
		IF CHARINDEX(SUBSTRING(@word, @Index, 1),@setOfLetters) <= 0
		BEGIN
			SET @Result = 0;
			RETURN @Result;
		END

		SET @Index += 1
	END
	RETURN @Result;
END

--P08
CREATE PROC usp_DeleteEmployeesFromDepartment(@DepartmentId INT)
AS
BEGIN
	DELETE FROM EmployeesProjects
	WHERE EmployeeID IN 
	(
		SELECT 
			EmployeeID 
		FROM Employees
		WHERE DepartmentID = @DepartmentId
	)

	UPDATE Employees
	SET ManagerID = NULL
	WHERE ManagerID IN
	(
		SELECT 
			EmployeeID 
		FROM Employees
		WHERE DepartmentID = @DepartmentId
	)

	ALTER TABLE Departments
	ALTER COLUMN ManagerID INT

	UPDATE Departments
	SET ManagerID = NULL
	WHERE DepartmentID = @DepartmentId

	DELETE FROM Employees
	WHERE DepartmentID = @DepartmentId

	DELETE FROM Departments
	WHERE DepartmentID = @DepartmentId

	SELECT 
		COUNT(*) 
	FROM Employees
	WHERE DepartmentID = @DepartmentId
END

--Part II
USE Bank
--P09
CREATE PROC usp_GetHoldersFullName
AS
BEGIN
	SELECT 
		first_name + ' ' + last_name AS [Full Name]
	FROM account_holders
END

--P10
CREATE PROC usp_GetHoldersWithBalanceHigherThan(@Balace INT)
AS
BEGIN
	SELECT 
		first_name AS [First Name],
		last_name AS [LastName]
	FROM account_holders ah
		JOIN accounts a ON a.account_holder_id = ah.id
	WHERE a.balance > @Balace
	GROUP BY first_name, last_name
	ORDER BY first_name, last_name
END

--P11
CREATE FUNCTION ufn_CalculateFutureValue(@Sum DECIMAL(18, 4), @YearlyInterestRate FLOAT, @NumberOfYears INT)
RETURNS DECIMAL
AS
BEGIN
	DECLARE @FutureValue DECIMAL(18, 4);

	SET @FutureValue = @Sum * (POWER((1 + @YearlyInterestRate), @NumberOfYears))
	RETURN @FutureValue
END

--P12
CREATE OR ALTER PROC ufn_CalculateFutureValueForAccount(@AccountId INT, @InterestRate DECIMAL(18,4))
AS
BEGIN
	SELECT
		a.id AS [Account Id],
		ah.first_name AS [First Name],
		ah.last_name AS [LastName],
		a.balance AS [Current Balance],
		dbo.ufn_CalculateFutureValue(a.balance, @InterestRate, 5) AS [Balance in 5 years]
	FROM account_holders ah
		JOIN accounts a ON a.account_holder_id = ah.id
	WHERE a.id = @AccountId
END

--Part III
USE Diablo

--P13
CREATE FUNCTION ufn_CashInUsersGames(@GameName NVARCHAR(100))
RETURNS TABLE
AS
	RETURN 
		SELECT SUM(Cash) AS [SumCash] FROM
		(
			SELECT 
				g.[Name], 
				ug.Cash,
				ROW_NUMBER() OVER (PARTITION BY g.[Name] ORDER BY ug.Cash DESC) AS [RowNum]
			FROM Games g
				JOIN UsersGames AS ug ON g.Id = ug.GameId
				WHERE g.[Name] = @GameName
		) AS [RowNumQuery]
		WHERE RowNum % 2 != 0