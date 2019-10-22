USE [PMS]
GO
/****** Object:  StoredProcedure [Customer].[UpdateByCustomerId]    Script Date: 10/22/2019 9:24:37 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [Customer].[UpdateByCustomerId]
(
@Cust_Id bigint,
@Cust_FirstName varchar(256),
@Cust_LastName varchar(50),
@Cust_Gender varchar(1),
@Cust_Address varchar(256),
@Cust_City varchar(50),
@Cust_Contact_No bigint
)
AS
BEGIN
UPDATE Customer.Customer
SET Cust_FirstName = @Cust_FirstName,
Cust_LastName = @Cust_LastName,
Cust_Address = @Cust_Address,
Cust_Gender = @Cust_Gender,
Cust_City = @Cust_City,
Cust_Contact_No = @Cust_Contact_No
WHERE Cust_ID = @Cust_Id

END

EXEC Customer.UpdateByCustomerId 2, 'Almer Dave', 'Dizon', 'M', 'Dona Isaura', 'Quezon City', 12345 