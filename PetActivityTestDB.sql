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
(1, 'Doggo', 680, 1700),
(1, 'Catto', 140, 280),
(2, 'Small cat', 130, 250),
(2, 'Big cat', 150, 275)
GO

--https://www.omnicalculator.com/biology/dog-calorie
--	Populate Pet Activity Table
INSERT INTO PetActivity
VALUES
--	Pet Number one : Doggo
--	Day one
(1, 'Food', '20220330 06:34:09 AM', '20220330 06:35:09 AM', 340),
(1, 'Food', '20220330 07:34:09 PM', '20220330 07:35:09 PM', 340),
(1, 'Water', '20220330 06:34:09 AM', '20220330 06:35:09 AM', 567),
(1, 'Water', '20220330 12:34:09 PM', '20220330 12:35:09 PM', 567),
(1, 'Water', '20220330 06:34:09 PM', '20220330 06:35:09 PM', 567),
--	Day two
(1, 'Food', '20220331 06:34:09 AM', '20220331 06:35:09 AM', 340),
(1, 'Food', '20220331 07:34:09 PM', '20220331 07:35:09 PM', 340),
(1, 'Water', '20220331 06:34:09 AM', '20220331 06:35:09 AM', 567),
(1, 'Water', '20220331 12:34:09 PM', '20220331 12:35:09 PM', 567),
(1, 'Water', '20220331 06:34:09 PM', '20220331 06:35:09 PM', 567),
--	Day three
(1, 'Food', '20220401 06:34:09 AM', '20220401 06:35:09 AM', 320),
(1, 'Food', '20220401 07:34:09 PM', '20220401 07:35:09 PM', 240),
(1, 'Water', '20220401 06:34:09 AM', '20220401 06:35:09 AM', 567),
(1, 'Water', '20220401 12:34:09 PM', '20220401 12:35:09 PM', 567),
(1, 'Water', '20220401 06:34:09 PM', '20220401 06:35:09 PM', 567),


--	Pet Number Two : Catto
--	Day One
(2, 'Food', '20220330 06:34:09 AM', '20220330 06:35:09 AM', 69),
(2, 'Food', '20220330 12:34:09 PM', '20220330 12:35:09 PM', 71),
(2, 'Water', '20220330 06:34:09 AM', '20220330 06:35:09 AM', 94),
(2, 'Water', '20220330 12:34:09 PM', '20220330 12:35:09 PM', 94),
(2, 'Water', '20220330 07:34:09 PM', '20220330 07:35:09 PM', 94),
--	Day Two
(2, 'Food', '20220331 06:34:09 AM', '20220331 06:35:09 AM', 69),
(2, 'Food', '20220331 12:34:09 PM', '20220331 12:35:09 PM', 71),
(2, 'Water', '20220331 06:34:09 AM', '20220331 06:35:09 AM', 94),
(2, 'Water', '20220331 12:34:09 PM', '20220331 12:35:09 PM', 94),
(2, 'Water', '20220331 07:34:09 PM', '20220331 07:35:09 PM', 94),
--	Day Three
(2, 'Food', '20220401 06:34:09 AM', '20220401 06:35:09 AM', 69),
(2, 'Food', '20220401 12:34:09 PM', '20220401 12:35:09 PM', 71),
(2, 'Water', '20220401 06:34:09 AM', '20220401 06:35:09 AM', 94),
(2, 'Water', '20220401 12:34:09 PM', '20220401 12:35:09 PM', 86),
(2, 'Water', '20220401 07:34:09 PM', '20220401 07:35:09 PM', 75),

--	Pet Number Three : Small cat
(3, 'Food', '20220330 06:34:09 AM', '20220330 06:35:09 AM', 65),
(3, 'Food', '20220330 07:34:09 PM', '20220330 07:35:09 PM', 65),
(3, 'Water', '20220330 06:34:09 AM', '20220330 06:35:09 AM', 84),
(3, 'Water', '20220330 12:34:09 PM', '20220330 12:35:09 PM', 84),
(3, 'Water', '20220330 07:34:09 PM', '20220330 07:35:09 PM', 84),
--	Day Two
(3, 'Food', '20220331 06:34:09 AM', '20220331 06:35:09 AM', 65),
(3, 'Food', '20220331 07:34:09 PM', '20220331 07:35:09 PM', 65),
(3, 'Water', '20220331 06:34:09 AM', '20220331 06:35:09 AM', 84),
(3, 'Water', '20220331 12:34:09 PM', '20220331 12:35:09 PM', 84),
(3, 'Water', '20220331 07:34:09 PM', '20220331 07:35:09 PM', 84),
--	Day Two
(3, 'Food', '20220401 06:34:09 AM', '20220401 06:35:09 AM', 56),
(3, 'Food', '20220401 07:34:09 PM', '20220401 07:35:09 PM', 55),
(3, 'Water', '20220401 06:34:09 AM', '20220401 06:35:09 AM', 78),
(3, 'Water', '20220401 12:34:09 PM', '20220401 12:35:09 PM', 73),
(3, 'Water', '20220401 07:34:09 PM', '20220401 07:35:09 PM', 68),

--	Pet Number Four : Big cat
(4, 'Food', '20220330 06:34:09 AM', '20220318 06:35:09 AM', 75),
(4, 'Food', '20220330 07:34:09 PM', '20220318 07:35:09 PM', 75),
(4, 'Water', '20220330 06:34:09 AM', '20220318 06:35:09 AM', 92),
(4, 'Water', '20220330 12:34:09 PM', '20220318 12:35:09 PM', 93),
(4, 'Water', '20220330 07:34:09 PM', '20220318 07:35:09 PM', 92),
--	Day Two
(4, 'Food', '20220331 06:34:09 AM', '20220331 06:35:09 AM', 75),
(4, 'Food', '20220331 07:34:09 PM', '20220331 07:35:09 PM', 75),
(4, 'Water', '20220331 06:34:09 AM', '20220331 06:35:09 AM', 92),
(4, 'Water', '20220331 12:34:09 PM', '20220331 12:35:09 PM', 93),
(4, 'Water', '20220331 07:34:09 PM', '20220331 07:35:09 PM', 92),
--	Day Three
(4, 'Food', '20220401 06:34:09 AM', '20220401 06:35:09 AM', 90),
(4, 'Food', '20220401 07:34:09 PM', '20220401 07:35:09 PM', 90),
(4, 'Water', '20220401 06:34:09 AM', '20220401 06:35:09 AM', 110),
(4, 'Water', '20220401 12:34:09 PM', '20220401 12:35:09 PM', 110),
(4, 'Water', '20220401 07:34:09 PM', '20220401 07:35:09 PM', 110)
GO