USE Company;  

GO
--Add primary key auto increment constraint--

DROP PROCEDURE IF EXISTS usp_CreateDepartment
DROP PROCEDURE IF EXISTS usp_UpdateDepartmentName
DROP PROCEDURE IF EXISTS usp_UpdateDepartmentManager
DROP PROCEDURE IF EXISTS usp_DeleteDepartment
DROP PROCEDURE IF EXISTS usp_GetDepartment
DROP PROCEDURE IF EXISTS usp_GetAllDepartments
GO

--Alter table Department
--add EmpCount int Count(Select * from Employee where Dno = DNumber)
GO

-- Opg a
CREATE PROCEDURE usp_CreateDepartment   
    @DName nvarchar(50),   
    @MgrSSN numeric(9,0)
AS   
BEGIN
	if((SELECT MgrSSN from Department WHERE MgrSSN = @MgrSSN) IS NOT NULL)
		THROW 50002, 'Used Manager Social Security Number is already a department manager.', 1;

	if((SELECT DName from Department WHERE DName = @DName) IS NOT NULL)
		THROW 50001, 'Department already exists', 1;

	INSERT INTO Department (DName, MgrSSN, MgrStartDate, DNumber)
	OUTPUT Inserted.DNumber
	VALUES(@DName, @MgrSSN, GETDATE(), (SELECT MAX(DNumber) FROM Department)+1)
	END
GO  




-- Opg b
CREATE PROCEDURE usp_UpdateDepartmentName   
    @DNumber int,   
    @DName varchar(50)
AS   
BEGIN
	if((SELECT DName from Department WHERE DName = @DName) IS NOT NULL)
		THROW 50003, 'Department name already in use.', 1;

	Update Department set DName = @DName where Dnumber = @DNumber
	END
GO  

-- Opg c
CREATE PROCEDURE usp_UpdateDepartmentManager
    @DNumber int,   
    @MgrSSN numeric(9,0)
AS   
BEGIN
	if((SELECT MgrSSN from Department WHERE MgrSSN = @MgrSSN) IS NOT NULL)
		THROW 50002, 'Used Manager Social Security Number is already a department manager.', 1;

	Update Department set MgrSSN = @MgrSSN, MgrStartDate = GetDate() where DNumber = @DNumber
	Update Employee set SuperSSN = @MgrSSN where Dno = @DNumber AND SSN != @MgrSSN
	END
Go

-- Opg d
CREATE PROCEDURE usp_DeleteDepartment
    @DNumber int
AS   
BEGIN
	if((SELECT Dnumber FROM Department WHERE DNumber = @DNumber) IS NULL)
		THROW 50001, 'Department does not exist.', 1;

	Update Employee SET Dno = null WHERE Dno = @DNumber
	Delete From Works_On Where Pno IN (SELECT PNumber from Project where DNum = @DNumber)
	Delete from Project where DNum = @DNumber
	DELETE FROM Dept_Locations WHERE DNUmber = @DNumber
	Delete from Department where DNumber = @DNumber
	END
Go


-- Opg e
CREATE PROCEDURE usp_GetDepartment
    @DNumber int
AS   
BEGIN
	if((SELECT Dnumber FROM Department WHERE DNumber = @DNumber) IS NULL)
		THROW 50001, 'Department does not exist.', 1;

		Select Dnumber, Dname, MgrSSN, MgrStartDate, count(emp.SSN) as Employees
		FROM Department 
		Inner join Employee emp on emp.Dno = Department.DNumber
		where Department.DNumber = @DNumber
		Group by DNumber, DName, MgrSSN, MgrStartDate
End
Go



-- Opg e
CREATE PROCEDURE usp_GetAllDepartments
AS   
BEGIN
		Select DNumber, DName, MgrSSN, MgrStartDate, count(emp.SSN) as Employees
		FROM Department
		Inner join Employee emp on emp.Dno = Department.DNumber
		Group by DNumber, DName, MgrSSN, MgrStartDate
End
Go

-- TEST Opg a --
EXEC usp_CreateDepartment 'Rejefabrikken i esbjerg', 987987987


-- TEST Opg b --
EXEC usp_UpdateDepartmentName 1, 'Rejefabrikken'


-- TEST Opg c --
EXEC usp_UpdateDepartmentManager 1, 666884444

-- TEST Opg d --
EXEC usp_DeleteDepartment 1

-- TEST Opg e --
EXEC usp_GetDepartment 4
-- TEST Opg f --
EXEC usp_GetAllDepartments

