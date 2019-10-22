USE PMS

----------------------------------------------------------------------
---------------------------- SEARCH BY PET ID ------------------------
----------------------------------------------------------------------
CREATE PROCEDURE [Customer].[SearchByPetID]
(
@PetID bigint
)
AS
BEGIN
select P.Pet_ID, P.Pet_Name, P.Pet_Breed, P.Pet_Type, P.Pet_Gender, P.Pet_DateRegistered, R.Room_ID, RE.Room_LastCheckedIn, RE.Room_LastCheckedOut
from Customer.Pet as P
inner join Customer.Room as R on R.Room_ID = P.Pet_RoomID
inner join Customer.RoomEntry as RE on RE.Room_ID = R.Room_ID
where P.Pet_ID = @PetID
END
GO

----------------------------------------------------------------------
----------------------- SEARCH BY CUSTOMER ID ------------------------
----------------------------------------------------------------------

CREATE PROCEDURE [Customer].[SearchByCustomerID]
(
@CustID bigint
)
AS
BEGIN
select P.Pet_Name
from Customer.Pet as P
inner join Customer.Customer as C on C.Cust_ID = P.Pet_CurrentCustID
where C.Cust_ID = @CustID
END
GO

----------------------------------------------------------------------
------------------------------ MODIFY --------------------------------
----------------------------------------------------------------------

CREATE PROCEDURE [Customer].[Modify]
(
@CustID bigint,
@PetName varchar(50)
)
AS
BEGIN
select P.Pet_ID, P.Pet_Name, P.Pet_Breed, P.Pet_Type, P.Pet_Gender, P.Pet_DateRegistered, R.Room_ID, RE.Room_LastCheckedIn, RE.Room_LastCheckedOut
from Customer.Pet as P
inner join Customer.Customer as C on C.Cust_ID = P.Pet_CurrentCustID
inner join Customer.Room as R on R.Room_ID = P.Pet_RoomID
inner join Customer.RoomEntry as RE on RE.Room_ID = R.Room_ID
where C.Cust_ID = @CustID and P.Pet_Name = @PetName
END
GO

----------------------------------------------------------------------
------------------------ UPDATE PET DETAILS --------------------------
----------------------------------------------------------------------

CREATE PROCEDURE [Customer].[UpdatePetDetails]
(
@PetID bigint,
@PetName varchar(50),
@PetBreed varchar(50),
@PetType varchar(3),
@PetGender varchar(1)
)
AS
BEGIN
update Customer.Pet 
set 
	Pet_Name = @PetName,
	Pet_Breed = @PetBreed,
	Pet_Type = @PetType,
	Pet_Gender = @PetGender
where Pet_ID = @PetID
END
GO

----------------------------------------------------------------------
----------------------- REDUCE ROOM CAPACITY -------------------------
----------------------------------------------------------------------

CREATE PROCEDURE [Customer].[UpdateAsAssign]
(
@RoomID bigint
)
AS
BEGIN
update Customer.Room
set Room.Room_CurrentCapacity = Room.Room_CurrentCapacity - 1
where Room.Room_ID = @RoomID
END
GO

----------------------------------------------------------------------
------------------------ UPDATE AS CHECKOUT --------------------------
----------------------------------------------------------------------

CREATE PROCEDURE [Customer].[UpdateAsCheckOut]
(
@RoomID bigint
)
AS
BEGIN
update Customer.Room
set Room.Room_CurrentCapacity = Room.Room_CurrentCapacity + 1
where Room.Room_ID = @RoomID
END
GO

----------------------------------------------------------------------
------------------- UPDATE ROOM ENTRY CHECKIN ------------------------
----------------------------------------------------------------------

Create PROCEDURE [Customer].[RoomEntryUpdate_CheckIn]
(
@RoomID bigint
)
AS
BEGIN
Update Customer.RoomEntry
Set Room_LastCheckedIn = getdate()
select *
from Customer.Pet
inner join Customer.Customer on Customer.Cust_ID = Pet.Pet_CurrentCustID 
inner join Customer.RoomEntry on Pet.Pet_RoomID = RoomEntry.Room_ID
Where Room_ID = @RoomID
END
GO

----------------------------------------------------------------------
------------------- UPDATE ROOM ENTRY CHECKOUT -----------------------
----------------------------------------------------------------------

CREATE PROCEDURE [Customer].[RoomEntryUpdate_Checkout]
(
@RoomID bigint
)
AS
BEGIN
Update Customer.RoomEntry
Set Room_LastCheckedOut = getdate()
select *
from Customer.Pet
inner join Customer.Customer on Customer.Cust_ID = Pet.Pet_CurrentCustID 
inner join Customer.RoomEntry on Pet.Pet_RoomID = RoomEntry.Room_ID
Where Room_ID = 301
END
GO

----------------------------------------------------------------------
----------------------- PET DATE REGISTERED --------------------------
----------------------------------------------------------------------

ALTER PROCEDURE [Customer].[PetDateRegistered]
@PetID bigint
AS
BEGIN
Update Customer.Pet
Set Pet_DateRegistered = getdate()
select *
from Customer.Customer
inner join Customer.Pet on Pet.Pet_CurrentCustID = Customer.Cust_ID
where Pet_ID = @PetID
END

----------------------------------------------------------------------
-------------------- CUSTOMER DATE REGISTERED ------------------------
----------------------------------------------------------------------

CREATE PROCEDURE [Customer].[CustomerDateRegistered]
(
@CustID bigint
)
AS
BEGIN
Update Customer.Customer
Set Cust_DateRegistered = getdate()
where Cust_ID = @CustID
END
GO

----------------------------------------------------------------------
---------------------- SHOW AVAILABLE ROOMS --------------------------
----------------------------------------------------------------------

CREATE PROCEDURE [Customer].[ShowAvailableRooms]
(
@PetType varchar(3),
@RoomType int
)
AS
BEGIN
IF (@PetType = 'CAT' and @RoomType = 1)
	begin
		select Room_ID 
		from Customer.Room
		where Room_ID between 101 and 110 and Room_CurrentCapacity = 1
	end
ELSE IF (@PetType = 'CAT' and @RoomType = 2)
	begin
		select Room_ID 
		from Customer.Room
		where Room_ID between 201 and 202 and Room_CurrentCapacity != 0
	end
ELSE IF (@PetType = 'DOG' and @RoomType = 3)
	begin
		select Room_ID 
		from Customer.Room
		where Room_ID between 301 and 308 and Room_CurrentCapacity = 1
	end
ELSE IF (@PetType = 'DOG' and @RoomType = 4)
	begin
		select Room_ID 
		from Customer.Room
		where Room_ID between 401 and 404 and Room_CurrentCapacity != 0
	end
END
GO
