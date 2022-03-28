--Drop Tables
DROP TABLE IF EXISTS dbo.PetActivity
DROP TABLE IF EXISTS dbo.Pet
DROP TABLE IF EXISTS dbo.Users

--Create User table
CREATE TABLE Users(
	UserID int NOT NULL IDENTITY,
	UserName varchar(50) NOT NULL,
	Password varchar(50) NOT NULL,
	CONSTRAINT PK_Users PRIMARY KEY (UserID)
)
GO

--Create Pet Table
CREATE TABLE Pet(
	PetID int NOT NULL IDENTITY,
	UserID int NOT NULL,
	PetName varchar(50) NOT NULL,
	FoodConsumption int,
	WaterConsumption int,
	CONSTRAINT PK_Pet PRIMARY KEY (PetID),
	CONSTRAINT FK_Pet_Users FOREIGN KEY (UserID) REFERENCES Users(UserID)
)
GO

--Create Pet Activity Table
CREATE TABLE PetActivity(
	PetActivityID int NOT NULL IDENTITY,
	PetID int NOT NULL,
	Activity varchar(50) NOT NULL,
	StartTime datetime NOT NULL,
	EndTime datetime NOT NULL,
	Consumption float NOT NULL,
	CONSTRAINT PK_PetActivity PRIMARY KEY (PetActivityID),	
	CONSTRAINT FK_PetActivity_Pet FOREIGN KEY (PetID) REFERENCES Pet(PetID)
)
GO

--Populate Users Table
INSERT INTO Users
VALUES
('JSmith01', 'ILoveCats123'),
('JDoe01', 'ILoveDigs321')
GO

--	Populate Pet Table
INSERT INTO Pet
VALUES
(1, 'Doggo', 75, 75),
(1, 'Catto', 50, 75),
(2, 'Small cat', 50, 60),
(2, 'Big cat', 65, 75)
GO

--	Populate Pet Activity Table
INSERT INTO PetActivity
VALUES
--	Pet Number one : Doggo
(1, 'Food', '20220318 06:34:09 AM', '20220318 06:35:09 AM', 72),
(1, 'Water', '20220318 06:34:09 AM', '20220318 06:35:09 AM', 72),
(1, 'Food', '20220318 12:34:09 AM', '20220318 12:35:09 AM', 72),
(1, 'Water', '20220318 12:34:09 AM', '20220318 12:35:09 AM', 72),
(1, 'Food', '20220318 07:34:09 AM', '20220318 07:35:09 AM', 72),
(1, 'Food', '20220318 06:34:09 AM', '20220318 06:35:09 AM', 72),
--	Pet Number Two : Catto
(2, 'Water', '20220318 06:34:09 AM', '20220318 06:35:09 AM', 72),
(2, 'Food', '20220318 12:34:09 AM', '20220318 12:35:09 AM', 72),
(2, 'Water', '20220318 12:34:09 AM', '20220318 12:35:09 AM', 72),
(2, 'Food', '20220318 07:34:09 AM', '20220318 07:35:09 AM', 72),
(2, 'Water', '20220318 07:34:09 AM', '20220318 07:35:09 AM', 72),
--	Pet Number Three : Small cat
(3, 'Water', '20220318 06:34:09 AM', '20220318 06:35:09 AM', 72),
(3, 'Food', '20220318 12:34:09 AM', '20220318 12:35:09 AM', 72),
(3, 'Water', '20220318 12:34:09 AM', '20220318 12:35:09 AM', 72),
(3, 'Food', '20220318 07:34:09 AM', '20220318 07:35:09 AM', 72),
(3, 'Water', '20220318 07:34:09 AM', '20220318 07:35:09 AM', 72),
--	Pet Number Four : Big cat
(4, 'Water', '20220318 06:34:09 AM', '20220318 06:35:09 AM', 72),
(4, 'Food', '20220318 12:34:09 AM', '20220318 12:35:09 AM', 72),
(4, 'Water', '20220318 12:34:09 AM', '20220318 12:35:09 AM', 72),
(4, 'Food', '20220318 07:34:09 AM', '20220318 07:35:09 AM', 72),
(4, 'Water', '20220318 07:34:09 AM', '20220318 07:35:09 AM', 72),
(4, 'Water', GETDATE(), GETDATE(), 55)
GO