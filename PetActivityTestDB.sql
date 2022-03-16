--Create User table
DROP TABLE IF EXISTS dbo.Users
CREATE TABLE Users(
	UserID int NOT NULL IDENTITY,
	UserName varchar(50) NOT NULL,
	Password varchar(50) NOT NULL,
	CONSTRAINT PK_Users PRIMARY KEY (UserID)
);
GO

--Create Pet Table
DROP TABLE IF EXISTS dbo.Pet
CREATE TABLE Pet(
	PetID int NOT NULL,
	UserID int NOT NULL,
	PetName varchar(50) NOT NULL,
	CONSTRAINT PK_Pet PRIMARY KEY (PetID, UserID),
	CONSTRAINT FK_Pet_Users FOREIGN KEY (UserID) REFERENCES Users(UserID)
);
GO

--Create Pet Activity Table
DROP TABLE IF EXISTS dbo.PetActivity
CREATE TABLE PetActivity(
	PetID int NOT NULL,
	StartTime date NOT NULL,
	EndTime date NOT NULL,
	FoodConsumed float NOT NULL,
	CONSTRAINT PK_PetActivity PRIMARY KEY (PetID)
);
GO

--Populate Users Table
INSERT INTO Users
VALUES
(1, 'JSmith01', 'ILoveCats123'),
(2, 'JDoe01', 'ILoveDigs321');
GO

--Populate Pet Table
INSERT INTO Pet
VALUES
(1, 1, 'Doggo'),
(2, 1, 'Catto'),
(3, 2, 'Mr.Meowers');
GO

--Populate Pet Activity Table
INSERT INTO PetActivity
VALUES
(1, CAST('2022-03-18 06:34:25 AM') AS 'datetime',
CAST('2022-03-18 10:34:09 AM') AS 'datetime', 72),
(2, CAST('2022-03-18 10:34:09 AM') AS 'datetime',
CAST('2022-03-18 10:34:09 AM') AS 'datetime', 55);
GO