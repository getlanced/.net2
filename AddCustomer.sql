USE [PMS]
GO
/****** Object:  StoredProcedure [Customer].[AddCustomer]    Script Date: 10/22/2019 6:10:17 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

ALTER procedure [Customer].[AddCustomer]
(
@Cust_FirstName varchar(256),
@Cust_LastName varchar(50),
@Cust_Gender varchar(1),
@Cust_Address varchar(256),
@Cust_City varchar(50),
@Cust_Contact_No bigint,
@Cust_Pet_Capacity int
)
as
begin
INSERT Customer.Customer(Cust_FirstName,Cust_LastName,Cust_Gender,Cust_Address, Cust_City, Cust_Contact_No, Cust_DateRegistered,Cust_Pet_Capacity)
VALUES (@Cust_FirstName,@Cust_LastName, @Cust_Gender, @Cust_Address, @Cust_City, @Cust_Contact_No, GETDATE(), @Cust_Pet_Capacity)

end