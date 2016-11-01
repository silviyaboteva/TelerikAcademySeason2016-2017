-- 1. Create a database with two tables: Persons(Id(PK), FirstName, LastName, SSN) and Accounts(Id(PK), PersonId(FK), Balance).
--Insert few records for testing.
--Write a stored procedure that selects the full names of all persons.

CREATE DATABASE Bank
GO

USE Bank
GO

CREATE TABLE Persons (
	PersonId INT IDENTITY PRIMARY KEY,
	FirstName NVARCHAR(50) NOT NULL,
	LastName NVARCHAR(50) NOT NULL,
	SSN NVARCHAR(50) NOT NULL
)
GO

CREATE TABLE Accounts (
	AccountId INT IDENTITY PRIMARY KEY,
	PersonId INT NOT NULL,
	Balance MONEY,
	CONSTRAINT FK_Persons_Accounts
		FOREIGN KEY (PersonId)
		REFERENCES Persons(PersonId)
)
GO

DECLARE @counter INT;
SET @counter = 20;
WHILE @counter > 0
BEGIN
	INSERT INTO Persons(FirstName, LastName, SSN)
	VALUES ('FirstName ' + CONVERT(varchar(10), @counter),
		'LastName ' + CONVERT(varchar(10), @counter),
		@counter + 123456)
	SET @counter = @counter - 1
END
GO

DECLARE @counter INT;
SET @counter = 20;
WHILE @counter > 0
BEGIN
	DECLARE @randomNumber int
    SELECT @randomNumber = ABS(CAST(NEWID() AS binary(6)) % 10000) + 1

    INSERT INTO Accounts(PersonId, Balance)
    VALUES (@counter, @randomNumber)
    SET @counter = @counter - 1
END
GO

CREATE PROC usp_SelectFullNameOfPersons
AS
    SELECT CONCAT(FirstName, ' ', LastName) AS FullName
    FROM Persons
GO

EXEC usp_SelectFullNameOfPersons

-- 2. Create a stored procedure that accepts a number as a parameter and returns all persons who have
--more money in their accounts than the supplied number.

CREATE PROC usp_SelectPersonsWithBalance(@MinMoneyInAccount MONEY)
AS
	SELECT p.FirstName, p.LastName, p.SSN, a.Balance
    FROM Persons p
    JOIN Accounts a
        ON p.PersonId = a.PersonId
    WHERE a.Balance >= @minMoneyInAccount
    ORDER BY a.Balance
GO

EXEC usp_SelectPersonsWithBalance 2000;

-- 3. Create a function that accepts as parameters � sum, yearly interest rate and number of months.
--It should calculate and return the new sum.
--Write a SELECT to test whether the function works as expected.

CREATE FUNCTION dbo.ufn_CalculateBonus(@sum MONEY, @yearlyInterestRate FLOAT, @numOfMonths INT)
	RETURNS MONEY
AS
BEGIN
	RETURN @sum + (@yearlyInterestRate / 12) * @numOfMonthS * @sum
END
GO

-- 4. Create a stored procedure that uses the function from the previous example to give an interest to a person's account for one month.
--It should take the AccountId and the interest rate as parameters.

CREATE PROC dbo.usp_CalculateBonusPerMonth(@accountId INT, @interestRate FLOAT)
AS
	DECLARE @balance MONEY
	SELECT @balance = Balance
	FROM Accounts
	WHERE AccountId = @accountId

	DECLARE @newBalance MONEY
	SELECT @newBalance = dbo.ufn_CalculateBonus(@balance, @interestRate, 1)

	SELECT p.FirstName, p.LastName, a.Balance AS [Balance], @newBalance AS [New Balance]
	FROM Accounts a
	JOIN Persons p
		ON a.AccountId = p.PersonId
	WHERE AccountId = @accountId
GO

EXEC usp_CalculateBonusPerMonth 1, 0.1;

-- 5. Add two more stored procedures WithdrawMoney(AccountId, money) and DepositMoney(AccountId, money) that operate in transactions.
CREATE PROC dbo.usp_WithdrawMoney(@accountId INT, @money MONEY)
AS
	BEGIN TRAN
        UPDATE Accounts
        SET Balance -= @money
        WHERE AccountId = @accountId
    COMMIT TRAN
GO

EXEC usp_WithdrawMoney 1, 1000


CREATE PROC dbo.usp_DepositMoney(@accountId INT, @money MONEY)
AS
	BEGIN TRAN
		UPDATE Accounts
		SET Balance += @money
		WHERE AccountId = @accountId
	COMMIT TRAN
GO

EXEC usp_DepositMoney 2, 2000


-- 6. Create another table � Logs(LogID, AccountID, OldSum, NewSum).
--Add a trigger to the Accounts table that enters a new entry into the Logs table every time the sum on an account changes.
CREATE TABLE Logs(
	LogsId INT IDENTITY PRIMARY KEY,
	AccountId INT NOT NULL,
	OldSum MONEY NOT NULL,
	NewSum MONEY NOT NULL
	CONSTRAINT FK_Logs_Accounts
		FOREIGN KEY(AccountId)
		REFERENCES Accounts(AccountId)
)

CREATE TRIGGER tr_UpdateAccountBalance ON Accounts FOR UPDATE
AS
	DECLARE @oldSum MONEY
	SELECT @oldSum = Balance FROM deleted

	INSERT INTO Logs(AccountId, OldSum, NewSum)
	SELECT AccountId, @oldSum, Balance
	FROM inserted
GO

EXEC usp_WithdrawMoney 1, 1000

EXEC usp_DepositMoney 2, 2000

-- 7. Define a function in the database TelerikAcademy that returns all Employee's names
--(first or middle or last name) and all town's names that are comprised of given set of letters.
--Example: 'oistmiahf' will return 'Sofia', 'Smith', � but not 'Rob' and 'Guy'.

IF NOT EXISTS (
    SELECT value
    FROM sys.configurations
    WHERE name = 'clr enabled' AND value = 1
)
BEGIN
    EXEC sp_configure @configname = clr_enabled, @configvalue = 1
    RECONFIGURE
END
GO

IF EXISTS (SELECT * FROM sys.objects WHERE name = 'RegExpLike') 
    DROP FUNCTION RegExpLike;
GO 

IF EXISTS (SELECT * FROM sys.assemblies WHERE name = 'SqlRegularExpressions') 
    DROP assembly SqlRegularExpressions; 
GO      

IF EXISTS (SELECT * FROM sys.objects WHERE name = 'udf_AllMatchingNames') 
    DROP FUNCTION udf_AllMatchingNames;
GO  

CREATE Assembly SqlRegularExpressions 
   FROM 'C:\SqlRegularExpressions.dll' 
   WITH PERMISSION_SET = SAFE; 
GO 

CREATE FUNCTION RegExpLike(@Text nvarchar(MAX), @Pattern nvarchar(255)) RETURNS BIT
    AS EXTERNAL NAME SqlRegularExpressions.SqlRegularExpressions.[Like]
GO

CREATE FUNCTION udf_AllMatchingNames(@pattern nvarchar(255))
    RETURNS @MatchedNames TABLE ( Name varchar(50) )
AS
BEGIN
    INSERT @MatchedNames
    SELECT * FROM 
        (SELECT e.FirstName FROM Employees e
        UNION
        SELECT e.LastName FROM Employees e
        UNION 
        SELECT t.Name FROM Towns t) as temp(name)
    WHERE 1 = dbo.RegExpLike(LOWER(Name), @pattern)
    RETURN
END
GO

SELECT * FROM udf_AllMatchingNames('^[oistmiahf]+') --- all allowed matches

SELECT * FROM udf_AllMatchingNames('^[oistmiahf]+') WHERE Name = 'Sofia' --- allowed
UNION
SELECT * FROM udf_AllMatchingNames('^[oistmiahf]+') WHERE Name = 'Smith' --- allowed
UNION
SELECT * FROM udf_AllMatchingNames('^[oistmiahf]+') WHERE Name = 'Rob' --- forbidden
UNION
SELECT * FROM udf_AllMatchingNames('^[oistmiahf]+') WHERE Name = 'Guy' --- forbidden
GO

DROP FUNCTION RegExpLike;
DROP assembly SqlRegularExpressions; 
DROP FUNCTION [dbo].[udf_AllMatchingNames];
GO



--- 8. Using database cursor write a T-SQL script that scans all employees
--- and their addresses and prints all pairs of employees that live in the same town.

DECLARE empCursor CURSOR READ_ONLY FOR
    SELECT emp1.FirstName, emp1.LastName, t1.Name, emp2.FirstName, emp2.LastName
    FROM Employees emp1
    JOIN Addresses a1
        ON emp1.AddressID = a1.AddressID
    JOIN Towns t1
        ON a1.TownID = t1.TownID,
        Employees emp2
        JOIN Addresses a2
            ON emp2.AddressID = a2.AddressID
        JOIN Towns t2
            ON a2.TownID = t2.TownID
    WHERE t1.TownID = t2.TownID AND emp1.EmployeeID != emp2.EmployeeID
    ORDER BY emp1.FirstName, emp2.FirstName

OPEN empCursor

DECLARE @firstName1 nvarchar(50), 
        @lastName1 nvarchar(50),
        @townName nvarchar(50),
        @firstName2 nvarchar(50),
        @lastName2 nvarchar(50)
FETCH NEXT FROM empCursor INTO @firstName1, @lastName1, @townName, @firstName2, @lastName2

DECLARE @counter int;
SET @counter = 0;

WHILE @@FETCH_STATUS = 0
BEGIN
    SET @counter = @counter + 1;

    PRINT @firstName1 + ' ' + @lastName1 + 
          '     ' + @townName + '       ' +
          @firstName2 + ' ' + @lastName2;

    FETCH NEXT FROM empCursor 
    INTO @firstName1, @lastName1, @townName, @firstName2, @lastName2
END

print 'Total records: ' + CAST(@counter AS nvarchar(10));

CLOSE empCursor
DEALLOCATE empCursor

--- 9. * Write a T-SQL script that shows for each town 
--- a list of alL employees that live in it. Sample output:
---
---     Sofia -> Svetlin Nakov, Martin Kulov, George Denchev
---     Ottawa -> Jose Saraiva, ...

IF NOT EXISTS (
    SELECT value
    FROM sys.configurations
    WHERE name = 'clr enabled' AND value = 1
)
BEGIN
    EXEC sp_configure @configname = clr_enabled, @configvalue = 1
    RECONFIGURE
END
GO

IF (OBJECT_ID('dbo.concat') IS NOT NULL) 
    DROP Aggregate concat; 
GO 

IF EXISTS (SELECT * FROM sys.assemblies WHERE name = 'concat_assembly') 
    DROP assembly concat_assembly; 
GO      

CREATE Assembly concat_assembly 
   AUTHORIZATION dbo 
   FROM 'C:\SqlStringConcatenation.dll'
GO 

CREATE AGGREGATE dbo.concat ( 
    @Value NVARCHAR(MAX),
    @Delimiter NVARCHAR(4000) 
) 
    RETURNS NVARCHAR(MAX) 
    EXTERNAL Name concat_assembly.concat; 
GO 

DECLARE empCursor CURSOR READ_ONLY FOR
    SELECT t.Name, dbo.concat(e.FirstName + ' ' + e.LastName, ', ')
    FROM Towns t
    JOIN Addresses a
        ON t.TownID = a.TownID
    JOIN Employees e
        ON a.AddressID = e.AddressID
    GROUP BY t.Name
    ORDER BY t.Name

OPEN empCursor

DECLARE @townName nvarchar(50), 
        @employeesNames nvarchar(max)        
FETCH NEXT FROM empCursor INTO @townName, @employeesNames

WHILE @@FETCH_STATUS = 0
BEGIN
    PRINT @townName + ' -> ' + @employeesNames;

    FETCH NEXT FROM empCursor 
    INTO @townName, @employeesNames
END

CLOSE empCursor
DEALLOCATE empCursor
GO

DROP Aggregate concat; 
DROP assembly concat_assembly; 
GO

--- 10. Define a .NET aggregate function StrConcat that takes 
--- as input a sequence of strings and return a single string that
--- consists of the input strings separated by ','.
--- For example the following SQL statement should return a single string:

IF NOT EXISTS (
    SELECT value
    FROM sys.configurations
    WHERE name = 'clr enabled' AND value = 1
)
BEGIN
    EXEC sp_configure @configname = clr_enabled, @configvalue = 1
    RECONFIGURE
END
GO

IF (OBJECT_ID('dbo.concat') IS NOT NULL) 
    DROP Aggregate concat; 
GO 

IF EXISTS (SELECT * FROM sys.assemblies WHERE name = 'concat_assembly') 
    DROP assembly concat_assembly; 
GO      

CREATE Assembly concat_assembly 
   AUTHORIZATION dbo 
   FROM 'C:\SqlStringConcatenation.dll'
   WITH PERMISSION_SET = SAFE; 
GO 

CREATE AGGREGATE dbo.concat ( 
    @Value NVARCHAR(MAX),
    @Delimiter NVARCHAR(4000) 
) 
    RETURNS NVARCHAR(MAX) 
    EXTERNAL Name concat_assembly.concat; 
GO 

SELECT dbo.concat(FirstName + ' ' + LastName, ', ')
FROM Employees
GO

DROP Aggregate concat; 
DROP assembly concat_assembly; 
GO
