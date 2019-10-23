
------------------------------------------------------------
----------------------ADD NEW EMPLOYEE----------------------
------------------------------------------------------------

CREATE procedure [Employee].AddNewEmployee
	@FirstName varchar(256),
	@LastName varchar(256),
	@GenderID int,
	@AddLine1 varchar(MAX),
	@AddLine2 varchar(MAX),
	@Mobile bigint, 
	@HouseNo bigint,
	@PrivelegeID bit,
	@Password varchar(256),
	@LastLogin datetime
AS
	INSERT INTO Employee.Employee(Emp_FirstName, Emp_LastName, Emp_GenderID, Emp_AddLine1,
	Emp_AddLine2, Emp_MobileNo, Emp_HouseNo, Emp_PrivelegeID, Emp_Password, Emp_LastLogin)
	VALUES (@FirstName, @LastName, @GenderID, @AddLine1, @AddLine2, @Mobile, @HouseNo, @PrivelegeID,
	@Password, @LastLogin)
	
	
	
------------------------------------------------------------
-------------------DELETE BY EMPLOYEE ID--------------------
------------------------------------------------------------

CREATE procedure [Employee].DeleteEmployee
	@Id bigint
AS
	DELETE Employee.Employee
	WHERE Employee.EmployeeID = @Id


------------------------------------------------------------
--------------SAVE CHANGES TO EMPLOYEE----------------------
------------------------------------------------------------

CREATE procedure [Employee].SaveChangesToEmployee
	@Id bigint,
	@FirstName varchar(256),
	@LastName varchar(256),
	@GenderID int,
	@AddLine1 varchar(MAX),
	@AddLine2 varchar(MAX),
	@Mobile bigint, 
	@HouseNo bigint,
	@PrivelegeID bit,
	@Password varchar(256),
	@LastLogin datetime
AS
	UPDATE Employee.Employee
	SET Emp_FirstName = @FirstName, Emp_LastName = @LastName, Emp_GenderID = @GenderID, Emp_AddLine1 = @AddLine1,
	Emp_AddLine2 = @AddLine2, Emp_MobileNo = @Mobile, Emp_HouseNo = @HouseNo, Emp_PrivelegeID = @PrivelegeID, Emp_Password = @Password, Emp_LastLogin = @LastLogin
	WHERE EmployeeID = @Id