USE Bank
GO

--Part I
--P01
CREATE TABLE Logs(
	LogId INT PRIMARY KEY IDENTITY,
	AccountId INT REFERENCES Accounts(Id) NOT NULL,
	OldSum MONEY,
	NewSum MONEY
)

CREATE OR ALTER TRIGGER tr_EntersAccountChanges 
ON Accounts FOR UPDATE
AS
BEGIN
	DECLARE @accountId INT;
	DECLARE @oldSum MONEY;
	DECLARE @newSum MONEY;

	SET @accountId = (SELECT i.Id 
					  FROM inserted i)

	SET @oldSum = (SELECT d.Balance
				   FROM deleted d)

	SET @newSum = (SELECT i.Balance
				   FROM inserted i)

	INSERT INTO Logs(AccountId, OldSum, NewSum) VALUES
	(@accountId, @oldSum, @newSum)
END

UPDATE Accounts
SET Balance += 1000
WHERE Id = 2

--P02
CREATE TABLE NotificationEmails(
	Id INT PRIMARY KEY IDENTITY,
	Recipient INT REFERENCES Accounts(Id),
	[Subject] VARCHAR(MAX),
	Body VARCHAR(MAX)
)

GO

CREATE OR ALTER TRIGGER tr_CreateNewEmail
ON Logs FOR INSERT
AS
BEGIN
	DECLARE @accountId INT;
	DECLARE @subject VARCHAR(MAX);
	DECLARE @body VARCHAR(MAX);

	SET @accountId = (SELECT i.AccountId
						FROM inserted i)

	SET @subject = 'Balance change for account: ' + CAST(@accountId AS VARCHAR(MAX))

	SET @body = 'On ' + CAST(GETDATE() AS VARCHAR(MAX)) + ' your balance was changed from '
	+ CAST((SELECT i.OldSum FROM inserted i) AS VARCHAR(MAX)) + ' to ' + CAST((SELECT i.NewSum FROM inserted i) AS VARCHAR(MAX))

	INSERT INTO NotificationEmails(Recipient, [Subject], Body) VALUES	    
	(@accountId, @subject, @body)
END

UPDATE Accounts
SET Balance += 1000
WHERE Id = 1

--P03
CREATE PROC usp_DepositMoney(@accountId INT, @moneyAmount DECIMAL(15,4))
AS
BEGIN TRANSACTION
	IF (@moneyAmount < 0 OR @accountId IS NULL)
	BEGIN
		ROLLBACK
	END

	IF (NOT EXISTS(SELECT a.Id FROM Accounts a
				   WHERE a.Id = @accountId))
	BEGIN
		ROLLBACK
	END

	UPDATE Accounts
	SET Balance += @moneyAmount
	WHERE Id = @accountId
COMMIT

EXEC usp_DepositMoney 1, 1000

--P04
CREATE OR ALTER PROC usp_WithdrawMoney (@accountId INT, @moneyAmount DECIMAL(15,4))
AS
BEGIN TRANSACTION
	IF (@moneyAmount > (SELECT a.Balance FROM Accounts a WHERE a.Id = @accountId) OR @accountId IS NULL)
	BEGIN
		ROLLBACK
	END

	IF (NOT EXISTS(SELECT a.Id FROM Accounts a
				   WHERE a.Id = @accountId))
	BEGIN
		ROLLBACK
	END

	UPDATE Accounts
	SET Balance -= @moneyAmount
	WHERE Id = @accountId
COMMIT

--P05
CREATE OR ALTER PROC usp_TransferMoney(@senderId INT, @receiverId INT, @amount DECIMAL(15,4))
AS
BEGIN TRANSACTION
	IF (@amount < 0 OR @amount IS NULL)
	BEGIN
		ROLLBACK
	END

	IF (NOT EXISTS(SELECT a.Id FROM Accounts a WHERE a.Id = @senderId) OR @senderId IS NULL)
	BEGIN
		ROLLBACK
	END

	IF (NOT EXISTS(SELECT a.Id FROM Accounts a WHERE a.Id = @receiverId) OR @receiverId IS NULL)
	BEGIN
		ROLLBACK
	END

	EXEC dbo.usp_DepositMoney @receiverId, @amount
	EXEC dbo.usp_WithdrawMoney @senderId, @amount
COMMIT

--Part III
USE SoftUni
GO
--P06
CREATE OR ALTER PROC usp_AssignProject(@emloyeeId INT, @projectID INT)
AS
BEGIN TRANSACTION
	DECLARE @projectsCount INT

	SET @projectsCount = (SELECT COUNT(ep.EmployeeID)
							FROM EmployeesProjects AS ep
                               WHERE ep.EmployeeID = @emloyeeId)

	IF(@projectsCount >= 3)
	BEGIN
		ROLLBACK
		RAISERROR('The employee has too many projects!', 16, 1)
		RETURN
	END

	INSERT INTO EmployeesProjects(EmployeeID, ProjectID) VALUES	    
	(@emloyeeId, @projectID)
COMMIT

--P07
CREATE TABLE Deleted_Employees(
	EmployeeId INT PRIMARY KEY IDENTITY,
	FirstName VARCHAR(100) NOT NULL,
	LastName VARCHAR(100) NOT NULL,
	MiddleName VARCHAR(100),
	JobTitle VARCHAR(MAX),
	DepartmentId INT REFERENCES Departments(DepartmentId) NOT NULL,
	Salary MONEY NOT NULL
)
GO

CREATE OR ALTER TRIGGER tr_DeletedEmployees
ON Employees FOR DELETE
AS
BEGIN
	INSERT INTO Deleted_Employees(FirstName, LastName, MiddleName, JobTitle, DepartmentId, Salary)
	SELECT d.FirstName, d.LastName, d.MiddleName, d.JobTitle, d.DepartmentID, d.Salary 
	FROM deleted d
END