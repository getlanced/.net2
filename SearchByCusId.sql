USE [PMS]
GO
/****** Object:  StoredProcedure [Customer].[SearchByCustId]    Script Date: 10/22/2019 9:27:59 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [Customer].[SearchByCustId]
(
@Cust_Id bigint
)
AS
BEGIN
SELECT Cust_FirstName, Cust_LastName, Cust_Gender, Cust_Address, Cust_City, Cust_Contact_No
FROM Customer.Customer
WHERE Cust_ID = @Cust_Id

END
EXEC Customer.SearchByCustId 1