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
	StartTime date NOT NULL,
	EndTime date NOT NULL,
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

--Populate Pet Table
INSERT INTO Pet
VALUES
(1, 'Doggo', 75, 75),
(1, 'Catto', 50, 75),
(2, 'Mr.Meowers', 60, 70)
GO

--Populate Pet Activity Table
INSERT INTO PetActivity
VALUES
(1, 'Food', GETDATE(), GETDATE(), 72),
(2, 'Water', GETDATE(), GETDATE(), 55)
GO