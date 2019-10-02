Data Types:
	Numeric
	BIT (1-bit), INT (32-bit), BIGINT (64-bit)
	FLOAT, REAL, DECIMAL(scale, precision)
	MONEY – for money (precise) operations (DEPRICATED)
	Textual
	CHAR(size) – fixed size string
	VARCHAR(size) – variable size string
	NVARCHAR(size) – Unicode variable size string
	TEXT / NTEXT – text data block (unlimited size)

 

•	CHAR Заделя памет 10, колкото му е оказана;
•	VARCHAR заделя памет 4, колкото са чаровете в Test;
•	NVARCHAR заделя двойна памет и за UniCode-а, който включва и кирилица.
Ако се посочи свички да са с памет 3, ще задели толкова и ще се изпише до третия символ – Test.

	Binary data
	BINARY(size) – fixed length sequence of bits
	VARBINARY(size) – a sequence of bits, 1-8000 bytes or MAX 
(2GB)
	Date and time
	DATE – date in range 0001-01-01 through 9999-12-31
	DATETIME – date and time with precision of 1/300 sec
	SMALLDATETIME – date and time (1 minute precision)

Създаване на база:
CREATE DATABASE Employees

CREATE TABLE People
(
  Id INT NOT NULL,
  Email VARCHAR(50) NOT NULL,
  FirstName VARCHAR(50),
  LastName VARCHAR(50)
)

Вземане на всички данни от таблица:
SELECT * FROM Employees

Задаване на брой редове и колони:
SELECT TOP (5) FirstName, LastName
FROM Employees

Задаване на Primary Key:
Id INT NOT NULL PRIMARY KEY

Задаване на Identity:
Id INT PRIMARY KEY IDENTITY

Задаване на уникални стойности:
Email VARCHAR(50) UNIQUE

Задаване на default стойности:
Balance DECIMAL(10,2) DEFAULT 0

Задаване на ограничени стойностите:
Kelvin DECIMAL(10,2) CHECK (Kelvin > 0)

Промени в създадена таблица:
ALTER TABLE Employees

Добавяне на колона:
ALTER TABLE Employees
ADD Salary DECIMAL(15, 2)

Изтриване на съществуваща колона:
ALTER TABLE People
DROP COLUMN FullName
Промяна на типа данни в съществуваща колона:
ALTER TABLE People
ALTER COLUMN Email VARCHAR(100)

Задаване на уникални ограничения:
ALTER TABLE People
ADD CONSTRAINT uq_Email
UNIQUE (Email)

Задаване на default стойност:
ALTER TABLE People
ADD DEFAULT 0
FOR Balance

Задаване на ограничения:
ALTER TABLE InstrumentReadings
ADD CONSTRAINT PositiveValue
CHECK (Kelvin > 0)

Изтриване на всички записи от таблицата:
TRUNCATE TABLE Employees

Изтриване на данните и структурата на таблицата:
DROP TABLE Employees

Изтриване на цялата база данни:
DROP DATABASE AMS

Премахване на primary key, ограничения и уникалност:
ALTER TABLE Employees
DROP CONSTRAINT PK_Id

Премахване на default стойности (съответно при непопълнени данни – Null):
ALTER TABLE Employees
ALTER COLUMN Clients
DROP DEFAULT

Exercises: Data Definition and Data Types
Problem 1.	Create Database
You now know how to create database using the GUI of the SSMS. Now it’s time to create it using SQL queries. In that task (and the several following it) you will be required to create the database from the previous exercise using only SQL queries. Firstly, just create new database named Minions.
CREATE DATABASE Minions
Problem 2.	Create Tables
In the newly created database Minions add table Minions (Id, Name, Age). Then add new table Towns (Id, Name). Set Id columns of both tables to be primary key as constraint.
GO

USE Minions

GO

CREATE TABLE Minions
(
  Id INT NOT NULL PRIMARY KEY IDENTITY,
  [Name] NVARCHAR(50) NOT NULL,
  Age INT 
)

CREATE TABLE Towns
(
  Id INT NOT NULL PRIMARY KEY IDENTITY,
  [NAME] NVARCHAR(50) NOT NULL
)
Problem 3.	Alter Minions Table
Change the structure of the Minions table to have new column TownId that would be of the same type as the Id column of Towns table. Add new constraint that makes TownId foreign key and references to Id column of Towns table.
ALTER TABLE Minions 
ADD TownId INT NOT NULL

ALTER TABLE Minions
ADD CONSTRAINT FK_MinionTownId
FOREIGN KEY (TownId) REFERENCES Towns(Id)

ALTER TABLE Minions
ALTER COLUMN TownId INT NULL
Problem 4.	Insert Records in Both Tables
Populate both tables with sample records given in the table below.
Minions		Towns
Id	Name	Age	TownId		Id	Name
1	Kevin	22	1		1	Sofia
2	Bob	15	3		2	Plovdiv
3	Steward	NULL	2		3	Varna
Use only SQL queries. Insert the Id manually (don’t use identity).
GO

INSERT INTO Towns(Id, [Name]) VALUES
 (1, 'Sofia'),
 (2, 'Plovdiv'),
 (3, 'Varna')

 SELECT * FROM Towns

 INSERT INTO Minions(Id, [Name], Age, TownId) VALUES
 (1, 'Kevin', 22, 1),
 (2, 'Bob', 15, 3),
 (3, 'Steward', Null, 2)

 SELECT * FROM Minions
Problem 5.	Truncate Table Minions
Delete all the data from the Minions table using SQL query.
TRUNCATE TABLE Minions
Problem 6.	Drop All Tables
Delete all tables from the Minions database using SQL query.
DROP TABLE Minions 
 
DROP TABLE Towns
Problem 7.	Create Table People
Using SQL query create table People with columns:
•	Id – unique number for every person there will be no more than 231-1 people. (Auto incremented)
•	Name – full name of the person will be no more than 200 Unicode characters. (Not null)
•	Picture – image with size up to 2 MB. (Allow nulls)
•	Height –  In meters. Real number precise up to 2 digits after floating point. (Allow nulls)
•	Weight –  In kilograms. Real number precise up to 2 digits after floating point. (Allow nulls)
•	Gender – Possible states are m or f. (Not null)
•	Birthdate – (Not null)
•	Biography – detailed biography of the person it can contain max allowed Unicode characters. (Allow nulls)
Make Id primary key. Populate the table with only 5 records. Submit your CREATE and INSERT statements as Run queries & check DB.

CREATE TABLE People
 (
  Id INT PRIMARY KEY IDENTITY,
  [Name] NVARCHAR(200) NOT NULL,
  Picture VARBINARY(MAX) CHECK(DATALENGTH(Picture) <= 2 * 1024 * 1024),
  Height NUMERIC(3,2),
  [Weight] NUMERIC(3,2),
  Gender CHAR(1) NOT NULL,
  Birthdate DATE NOT NULL,
  Biography NVARCHAR(MAX)
  )

  INSERT INTO People([Name], Gender, Birthdate, Biography) VALUES
  ('Ivan Ivanov', 'm', '12-21-1965', 'Nothing important. Useless'),
  ('Petar Petrov', 'm', '10-10-1985', ''),
  ('Gergana Georgieva', 'f', '03-05-1996', 'Nothing to share.'),
  ('Nikolai Nikolov', 'm', '08-06-2001', 'I do not want to speak about it...'),
  ('Mihaila Ivanova', 'f', '10-01-1965', '')
  
Problem 8.	Create Table Users
Using SQL query create table Users with columns:
•	Id – unique number for every user. There will be no more than 263-1 users. (Auto incremented)
•	Username – unique identifier of the user will be no more than 30 characters (non Unicode). (Required)
•	Password – password will be no longer than 26 characters (non Unicode). (Required)
•	ProfilePicture – image with size up to 900 KB. 
•	LastLoginTime
•	IsDeleted – shows if the user deleted his/her profile. Possible states are true or false.
Make Id primary key. Populate the table with exactly 5 records. Submit your CREATE and INSERT statements as Run queries & check DB.

CREATE TABLE Users
  (
   Id BIGINT PRIMARY KEY IDENTITY,
   Username VARCHAR(30) UNIQUE NOT NULL,
   [Password] VARCHAR(26) NOT NULL,
   ProfilePicture VARBINARY(MAX) CHECK(DATALENGTH(ProfilePicture) <= 900 * 1024),
   LastLoginTime DATETIME2,
   IsDeleted BIT NOT NULL DEFAULT(0)
   )

   INSERT INTO Users(Username, [Password]) VALUES
   ('firstname','FPass'),
   ('secondname','SPass'),
   ('thirdname','TPass'),
   ('FOURTHname','FouPass'),
   ('Fifthname','FPassword')
Problem 9.	Change Primary Key
Using SQL queries modify table Users from the previous task. First remove current primary key then create new primary key that would be the combination of fields Id and Username.
   ALTER TABLE Users
   DROP PK__Users__3214EC074C6FB346

   ALTER TABLE Users
   ADD CONSTRAINT PK_IdUsername PRIMARY KEY(Id, Username)
Problem 10.	Add Check Constraint
Using SQL queries modify table Users. Add check constraint to ensure that the values in the Password field are at least 5 symbols long. 

   ALTER TABLE Users 
   ADD CONSTRAINT CH_PasswordLenght CHECK(LEN([Password]) >= 5)
Problem 11.	Set Default Value of a Field
Using SQL queries modify table Users. Make the default value of LastLoginTime field to be the current time.
   ALTER TABLE Users
   ADD CONSTRAINT DF_LastLogin
   DEFAULT GETDATE() FOR LastLoginTime
Problem 12.	Set Unique Field
Using SQL queries modify table Users. Remove Username field from the primary key so only the field Id would be primary key. Now add unique constraint to the Username field to ensure that the values there are at least 3 symbols long. 
ALTER TABLE Users
DROP PK_IdUsername

ALTER TABLE Users
ADD PRIMARY KEY(Id)

ALTER TABLE Users
ADD CONSTRAINT uq_Username 
UNIQUE (Username) 

ALTER TABLE Users
ADD CONSTRAINT UsernameLenght
CHECK(LEN(Username) >= 3)
Problem 13.	Movies Database
Using SQL queries create Movies database with the following entities:
•	Directors (Id, DirectorName, Notes)
•	Genres (Id, GenreName, Notes)
•	Categories (Id, CategoryName, Notes)
•	Movies (Id, Title, DirectorId, CopyrightYear, Length, GenreId, CategoryId, Rating, Notes)
Set most appropriate data types for each column. Set primary key to each table. Populate each table with exactly 5 records. Make sure the columns that are present in 2 tables would be of the same data type. Consider which fields are always required and which are optional. Submit your CREATE TABLE and INSERT statements as Run queries & check DB.
CREATE TABLE Directors 
(
 Id INT PRIMARY KEY NOT NULL,
 DirectorName NVARCHAR(MAX) NOT NULL,
 Notes NVARCHAR(MAX)
)

 CREATE TABLE Genres 
(
 Id INT PRIMARY KEY NOT NULL,
 GenreName NVARCHAR(MAX) NOT NULL,
 Notes NVARCHAR(MAX)
)

 CREATE TABLE Categories 
(
 Id INT PRIMARY KEY NOT NULL,
 CategoryName NVARCHAR(MAX) NOT NULL,
 Notes NVARCHAR(MAX)
)

 CREATE TABLE Movies 
(
 Id INT PRIMARY KEY NOT NULL,
 Title NVARCHAR(MAX) NOT NULL,
 DirectorId INT FOREIGN KEY REFERENCES Directors(Id) NOT NULL,
 CopyrightYear INT,
 Lenght TIME,
 GenreId INT FOREIGN KEY REFERENCES Genres(Id) NOT NULL,
 CategoryId INT FOREIGN KEY REFERENCES Categories(Id) NOT NULL,
 Rating INT NOT NULL,
 Notes NVARCHAR(MAX)
 )

 INSERT INTO Directors (Id, DirectorName, Notes) Values
(1,'Jack','Notes1'),
(3,'Steward','Notes2'),
(5,'Stesward','Notes3'),
(2,'Stewward','Notes4'),
(4,'Stewarrd','Notes5');

INSERT INTO Genres(Id, GenreName, Notes) VALUES
(1, 'Comedy','Funny'),
(2, 'Drama','Sad'),
(3, 'Love','love'),
(4, 'Action','BS'),
(5, 'Documental','Learning');

INSERT INTO Categories(Id, CategoryName, Notes) VALUES
(1, 'nz1','notesnz1'),
(2, 'nz2','notesnz2'),
(3, 'nz3','notesnz3'),
(4, 'nz4','notesnz4'),
(5, 'nz5','notesnz5');

INSERT INTO Movies(Id,Title, DirectorId, CopyrightYear, Lenght, GenreId, CategoryId, Rating, Notes) VALUES
(1, 'Titanic', 1, 1998,'2:10:00', 4, 2, 4,'TItanicNotes'),
(2, 'Interstellar', 3, 2011,'2:20:36', 2, 1, 5, 'InterstellarNotes'),
(3, 'IDK', 2, 2014, '1:30:25', 5, 3, 5,'IDKNotes'),
(4, 'Suits', 4, 2015, '0:48:35', 1, 4,  2, 'SuitsNotes'),
(5, 'The100', 5, 2012,'0:49:00', 3, 1, 5,'The100Notes')

Problem 14.	Car Rental Database
Using SQL queries create CarRental database with the following entities:
•	Categories (Id, CategoryName, DailyRate, WeeklyRate, MonthlyRate, WeekendRate)
•	Cars (Id, PlateNumber, Manufacturer, Model, CarYear, CategoryId, Doors, Picture, Condition, Available)
•	Employees (Id, FirstName, LastName, Title, Notes)
•	Customers (Id, DriverLicenceNumber, FullName, Address, City, ZIPCode, Notes)
•	RentalOrders (Id, EmployeeId, CustomerId, CarId, TankLevel, KilometrageStart, KilometrageEnd, TotalKilometrage, StartDate, EndDate, TotalDays, RateApplied, TaxRate, OrderStatus, Notes)
Set most appropriate data types for each column. Set primary key to each table. Populate each table with only 3 records. Make sure the columns that are present in 2 tables would be of the same data type. Consider which fields are always required and which are optional. Submit your CREATE TABLE and INSERT statements as Run queries & check DB.

CREATE TABLE Categories 
 (
  Id INT PRIMARY KEY IDENTITY NOT NULL, 
  CategoryName NVARCHAR(MAX), 
  DailyRate INT,
  WeeklyRate INT, 
  MonthlyRate INT, 
  WeekendRate INT
  )

 CREATE TABLE Cars 
 (
  Id INT PRIMARY KEY IDENTITY NOT NULL, 
  PlateNumber NVARCHAR(10) UNIQUE, 
  Manufacturer NVARCHAR(MAX), 
  Model NVARCHAR(MAX), 
  CarYear INT, 
  CategoryId INT FOREIGN KEY REFERENCES Categories(Id) NOT NULL, 
  Doors INT, 
  Picture VARBINARY, 
  Condition NVARCHAR(50), 
  Available BIT NOT NULL DEFAULT(0)
 )

 CREATE TABLE Employees 
 (
  Id INT PRIMARY KEY IDENTITY NOT NULL, 
  FirstName NVARCHAR(50) NOT NULL, 
  LastName NVARCHAR(50) NOT NULL, 
  Title NVARCHAR(MAX), 
  Notes NVARCHAR(MAX)
  )

CREATE TABLE Customers 
(
 Id INT PRIMARY KEY IDENTITY NOT NULL, 
 DriverLicenceNumber NVARCHAR(20), 
 FullName NVARCHAR(100) NOT NULL,
 [Address] NVARCHAR(MAX),
 City NVARCHAR(50),
 ZIPCode NVARCHAR(4),
 Notes NVARCHAR(MAX)
)

CREATE TABLE RentalOrders 
(
 Id INT PRIMARY KEY IDENTITY NOT NULL,
 EmployeeId INT FOREIGN KEY REFERENCES Employees(Id), 
 CustomerId INT FOREIGN KEY REFERENCES Customers(Id), 
 CarId INT FOREIGN KEY REFERENCES Cars(Id), 
 TankLevel DECIMAL(5,2), 
 KilometrageStart INT, 
 KilometrageEnd INT, 
 TotalKilometrage INT, 
 StartDate DATETIME2, 
 EndDate DATETIME2,
 TotalDays AS DATEDIFF(DAY, StartDate, EndDate),
 RateApplied INT, 
 TaxRate INT, 
 OrderStatus NVARCHAR(10), 
 Notes NVARCHAR(MAX)
)

Insert INTO Categories(CategoryName,DailyRate,WeeklyRate,MonthlyRate,WeekendRate) VALUES
('Sport',20,120,400,50),
('Van',10,60,200,30),
('Jeep',15,80,300,40);

Insert into Cars(PlateNumber,Manufacturer,Model,CarYear,CategoryId,Doors,Condition,Available) VALUES	
('CA1234CP','Renault','Laguna2',2003,1,5,'Used',0),
('CA4321PC','Peugeot','307',2007,2,5,'New',1),
('CD9876OC','Subaru','WSX',2009,3,3,'Used',0)

Insert into Employees(FirstName,LastName,Title) VALUES
('Damian','Ivanov','nz'),
('Ivanov','Ivanov','ddz'),
('Pesho','Petrov','rabotnik')

Insert into Customers(DriverLicenceNumber,FullName,ZIPCode) VALUES
('123456789','Damian Ivanov',1281),
('987654321','Ivan Ivanov',1280),
('654321789','Pesho Petrov',1212)

Insert into RentalOrders(EmployeeId,CustomerId,CarId,TankLevel,KilometrageStart,KilometrageEnd,TotalKilometrage,StartDate,EndDate,RateApplied,TaxRate,OrderStatus) VALUES
(1,1,1,0.7,1200,1500,1500-1200,'2019-07-30','2019-08-03',15,20,'ready'),
(2,2,2,0.5,1200,1500,1500-1200,'2019-07-31','2019-08-04',20,30,'not ready'),
(3,3,3,0.3,1200,1500,1500-1200,'2019-08-01','2019-08-05',25,40,'not ready')
Problem 15.	Hotel Database
Using SQL queries create Hotel database with the following entities:
•	Employees (Id, FirstName, LastName, Title, Notes)
•	Customers (AccountNumber, FirstName, LastName, PhoneNumber, EmergencyName, EmergencyNumber, Notes)
•	RoomStatus (RoomStatus, Notes)
•	RoomTypes (RoomType, Notes)
•	BedTypes (BedType, Notes)
•	Rooms (RoomNumber, RoomType, BedType, Rate, RoomStatus, Notes)
•	Payments (Id, EmployeeId, PaymentDate, AccountNumber, FirstDateOccupied, LastDateOccupied, TotalDays, AmountCharged, TaxRate, TaxAmount, PaymentTotal, Notes)
•	Occupancies (Id, EmployeeId, DateOccupied, AccountNumber, RoomNumber, RateApplied, PhoneCharge, Notes)
Set most appropriate data types for each column. Set primary key to each table. Populate each table with only 3 records. Make sure the columns that are present in 2 tables would be of the same data type. Consider which fields are always required and which are optional. Submit your CREATE TABLE and INSERT statements as Run queries & check DB.
Problem 16.	Create SoftUni Database
Now create bigger database called SoftUni. You will use same database in the future tasks. It should hold information about
•	Towns (Id, Name)
•	Addresses (Id, AddressText, TownId)
•	Departments (Id, Name)
•	Employees (Id, FirstName, MiddleName, LastName, JobTitle, DepartmentId, HireDate, Salary, AddressId)
Id columns are auto incremented starting from 1 and increased by 1 (1, 2, 3, 4…). Make sure you use appropriate data types for each column. Add primary and foreign keys as constraints for each table. Use only SQL queries. Consider which fields are always required and which are optional.
CREATE DATABASE SoftUni

GO

USE SoftUni

GO

CREATE TABLE Towns 
(
 Id INT PRIMARY KEY IDENTITY NOT NULL, 
 [Name] NVARCHAR(100) NOT NULL
)

CREATE TABLE Addresses 
(
 Id INT PRIMARY KEY IDENTITY NOT NULL, 
 AddressText NVARCHAR(MAX), 
 TownId INT FOREIGN KEY REFERENCES Towns(Id) NOT NULL
 )

CREATE TABLE Departments
(
 Id INT PRIMARY KEY IDENTITY NOT NULL, 
 [Name] NVARCHAR(100) NOT NULL
)

CREATE TABLE Employees 
(
 Id INT PRIMARY KEY IDENTITY NOT NULL, 
 FirstName NVARCHAR(50) NOT NULL, 
 MiddleName NVARCHAR(50) NOT NULL, 
 LastName NVARCHAR(50) NOT NULL, 
 JobTitle NVARCHAR(50), 
 DepartmentId INT FOREIGN KEY REFERENCES Departments(Id) NOT NULL, 
 HireDate DATE, 
 Salary DECIMAL(6,2),
 AddressId INT FOREIGN KEY REFERENCES Addresses(Id)
 )
Problem 17.	Backup Database
Backup the database SoftUni from the previous tasks into a file named “softuni-backup.bak”. Delete your database from SQL Server Management Studio. Then restore the database from the created backup.
Hint: https://support.microsoft.com/en-gb/help/2019698/how-to-schedule-and-automate-backups-of-sql-server-databases-in-sql-se

BACKUP DATABASE SoftUni TO DISK = 'D:\softuni-backup.bak';
DROP DATABASE SoftUni; 
RESTORE DATABASE SoftUni FROM DISK = 'D:\softuni-backup.bak'
Problem 18.	Basic Insert
Use the SoftUni database and insert some data using SQL queries.
•	Towns: Sofia, Plovdiv, Varna, Burgas
•	Departments: Engineering, Sales, Marketing, Software Development, Quality Assurance
•	Employees:
Name	Job Title	Department	Hire Date	Salary
Ivan Ivanov Ivanov	.NET Developer	Software Development	01/02/2013	3500.00
Petar Petrov Petrov	Senior Engineer	Engineering	02/03/2004	4000.00
Maria Petrova Ivanova	Intern	Quality Assurance	28/08/2016	525.25
Georgi Teziev Ivanov	CEO	Sales	09/12/2007	3000.00
Peter Pan Pan	Intern	Marketing	28/08/2016	599.88
INSERT INTO Towns ([Name]) VALUES
 ('Sofia'), ('Plovdiv'), ('Varna'), ('Burgas')

 INSERT INTO Departments([Name]) VALUES
  ('Engineering'), ('Sales'), ('Marketing'), ('Software Development'), ('Quality Assurance')

INSERT INTO Employees (FirstName, MiddleName, LastName, JobTitlE, DepartmentId, HireDate, Salary) VALUES
('Ivan','Ivanov', 'Ivanov',	'.NET Developer', 4, CONVERT(DATE, '01/02/2013', 103), 3500.00),
('Petar', 'Petrov', 'Petrov', 'Senior Engineer', 1, CONVERT(DATE, '02/03/2004', 103), 4000.00),
('Maria', 'Petrova', 'Ivanova',	'Intern',	5, CONVERT(DATE, '28/08/2016', 103), 525.25),
('Georgi', 'Teziev', 'Ivanov',	'CEO', 2, CONVERT(DATE,	'09/12/2007', 103),	3000.00),
('Peter', 'Pan', 'Pan',	'Intern',	3,	CONVERT(DATE, '28/08/2016', 103),	599.88)
Problem 19.	Basic Select All Fields
Use the SoftUni database and first select all records from the Towns, then from Departments and finally from Employees table. Use SQL queries and submit them to Judge at once. Submit your query statements as Prepare DB & Run queries.
SELECT * FROM Towns

SELECT * FROM Departments

SELECT * FROM Employees
Problem 20.	Basic Select All Fields and Order Them
Modify queries from previous problem by sorting:
•	Towns - alphabetically by name
•	Departments - alphabetically by name
•	Employees - descending by salary
Submit your query statements as Prepare DB & Run queries.
SELECT * FROM Towns
ORDER BY [NAME] ASC

SELECT * FROM Departments
ORDER BY [NAME] ASC

SELECT * FROM Employees
ORDER BY Salary DESC
Problem 21.	Basic Select Some Fields
Modify queries from previous problem to show only some of the columns. For table:
•	Towns – Name
•	Departments – Name
•	Employees – FirstName, LastName, JobTitle, Salary
Keep the ordering from the previous problem. Submit your query statements as Prepare DB & Run queries.
SELECT [NAME] FROM Towns
ORDER BY [NAME] ASC

SELECT [NAME] FROM Departments
ORDER BY [NAME] ASC

SELECT FirstName, LastName, JobTitle, Salary FROM Employees
ORDER BY Salary DESC
Problem 22.	Increase Employees Salary
Use SoftUni database and increase the salary of all employees by 10%. Then show only Salary column for all in the Employees table. Submit your query statements as Prepare DB & Run queries.
UPDATE Employees 
 SET
    Salary *= 1.1;

SELECT [Salary] FROM Employees
Problem 23.	Decrease Tax Rate
Use Hotel database and decrease tax rate by 3% to all payments. Then select only TaxRate column from the Payments table. Submit your query statements as Prepare DB & Run queries.
GO

USE Hotel

GO 

UPDATE Payments
 SET
   TaxRate *= 0.97

SELECT [TaxRate] FROM Payments
Problem 24.	Delete All Records
Use Hotel database and delete all records from the Occupancies table. Use SQL query. Submit your query statements as Run skeleton, run queries & check DB.

Basic CRUD
Ако не може да се създаде диаграма:
EXEC sp_changedbowner 'sa'
Селектиране/филтриране на данни при определено условие:
SELECT * FROM Projects WHERE StartDate = '1/1/2006'

Обновяване/изтриване на данни при определено условие:
UPDATE Projects
   SET EndDate = '8/31/2006'
 WHERE StartDate = '1/1/2006'

DELETE FROM Projects
      WHERE StartDate = '1/1/2006'
Процедура:
CREATE PROCEDURE EmpDump AS
DECLARE @EmpId INT, EmpFName NVARCHAR(100),
        @EmpLName NVARCHAR(100)
DECLARE emps CURSOR FOR
  SELECT EmployeeID, FirstName, LastName FROM Employees
OPEN emps
FETCH NEXT FROM emps INTO @EmpId, @EmpFName, @EmpLName
WHILE (@@FETCH_STATUS = 0)
BEGIN
  PRINT CAST(@EmpId AS VARCHAR(10)) + ' ' 
    + @EmpFName + ' ' + @EmpLName
  FETCH NEXT FROM emps INTO @EmpId, @EmpFName, @EmpLName
END
CLOSE emps
DEALLOCATE emps

Преименуване на таблица или колона при показването й:
SELECT EmployeeID AS ID,
       FirstName,
       LastName
  FROM Employees

Свързване на колони в една:
SELECT FirstName + ' ' + LastName AS [Full Name],
       EmployeeID AS [No.]
  FROM Employees

Премахване на повтарящи се стойности:
SELECT DISTINCT DepartmentID
  FROM Employees

Филтриране на редове при определено условие:
SELECT LastName, DepartmentID 
  FROM Employees 
 WHERE DepartmentID = 1

SELECT LastName, Salary FROM Employees
 WHERE Salary <= 20000

SELECT LastName, Salary FROM Employees
WHERE Salary BETWEEN 20000 AND 22000

SELECT LastName FROM Employees
WHERE NOT (ManagerID = 3 OR ManagerID = 4)

SELECT FirstName, LastName, ManagerID FROM Employees
WHERE ManagerID IN (109, 3, 16)

NULL означава, че липсва стойност, а не че е 0 или blank space
Проверка за NULL стойности:
SELECT LastName, ManagerId FROM Employees
WHERE ManagerId = NULL

SELECT LastName, ManagerId FROM Employees
WHERE ManagerId IS NULL

SELECT LastName, ManagerId FROM Employees
WHERE ManagerId IS NOT NULL

Създаване на View:
CREATE VIEW v_HighestPeak AS 
 SELECT TOP(1) *
   FROM Peaks
ORDER BY Elevation DESC
Вмъкване на данни:
INSERT INTO Towns VALUES (33, 'Paris')
INSERT INTO Projects (Name, StartDate)
     VALUES ('Reflective Jacket', GETDATE())

Вмъкване на данни от друга таблица:
INSERT INTO Projects (Name, StartDate)
     SELECT Name + ' Restructuring', GETDATE()
       FROM Departments

Създаване на нова таблица от съществуващи данни:
SELECT CustomerID, FirstName, Email, Phone
  INTO CustomerContacts
  FROM Customers

Създаване на incremented value:
CREATE SEQUENCE seq_Customers_CustomerID 
             AS INT
     START WITH 1
   INCREMENT BY 1

CREATE SEQUENCE seq_Customers_CustomerID 
             AS INT
     START WITH 10
   INCREMENT BY 10
   MINVALUE     10
   MAXVALUE     50
   CYCLE

Разлика между Delete и Truncate:
1.	Truncate работи по-бързо от Delete, защото при него не се запазват никакви логове.
2.	Когато искаме да изтрием САМО определни редове от таблица, използваме Delete.
3.	Когато искаме да изтрием всички редове, използваме Truncate.
4.	Delete е част от Data Manipulation Language(манипулират се самите данни), а Truncate от Data Definition Language(дефинират се самата таблица), което означава, че ако използваме Delete новото ID ще продължи от там, докъдето е бил последният изтрит запис. Докато при Truncate – всичко ще започне от начало без да се взимат предвид предходните изтрите данни.
Exercises: Basic CRUD
This document defines the exercise assignments for the "Databases Basics - MSSQL" course @ Software University. 
Problem 1.	Examine the Databases
Download and get familiar with the SoftUni, Diablo and Geography database schemas and tables. You will use them in the current and following exercises to write queries. Find All Information About Departments
Write a SQL query to find all available information about the Departments.
SELECT * FROM Departments
Example
DepartmentID	Name	ManagerID
1	Engineering	12
2	Tool Design	4
3	Sales	273
…	…	…
Problem 2.	Find all Department Names
Write SQL query to find all Department names.
Example
Name
Engineering
Tool Design
Sales
…
SELECT [Name] FROM Departments
Problem 3.	Find Salary of Each Employee
Write SQL query to find the first name, last name and salary of each employee.
Example
FirstName	LastName	Salary
Guy	Gilbert	12500.00
Kevin	Brown	13500.00
Roberto	Tamburello	43300.00
…	…	…
SELECT [FirstName], [LastName], [Salary]
FROM Employees
Problem 4.	Find Full Name of Each Employee
Write SQL query to find the first, middle and last name of each employee. 
Example
FirstName	MiddleName	LastName
Guy	R	Gilbert
Kevin	F	Brown
Roberto	NULL	Tamburello
SELECT [FirstName], [MiddleName], [LastName]
FROM Employees
Problem 5.	Find Email Address of Each Employee
Write a SQL query to find the email address of each employee. (By his first and last name). Consider that the email domain is softuni.bg. Emails should look like “John.Doe@softuni.bg". The produced column should be named "Full Email Address". 
Example
Full Email Address
Guy.Gilbert@softuni.bg
Kevin.Brown@softuni.bg
Roberto.Tamburello@softuni.bg
SELECT FirstName + '.' + LastName + '@softuni.bg' AS [Full Email Address]
FROM Employees
Problem 6.	Find All Different Employee’s Salaries
Write a SQL query to find all different employee’s salaries. Show only the salaries.
Example
Salary
9000.00
9300.00
9500.00
SELECT DISTINCT [Salary]
FROM Employees
Problem 7.	Find all Information About Employees
Write a SQL query to find all information about the employees whose job title is “Sales Representative”. 
Example
ID	First
Name	Last
Name	Middle
Name	Job Title	DeptID	Mngr
ID	HireDate	Salary	AddressID
275	Michael	Blythe	G	Sales Representative	3	268	…	23100.00	60
276	Linda	Mitchell	C	Sales Representative	3	268	…	23100.00	170
277	Jillian	Carson	NULL	Sales Representative	3	268	…	23100.00	61
SELECT * FROM Employees
WHERE JobTitle = 'Sales Representative'
Problem 8.	Find Names of All Employees by Salary in Range
Write a SQL query to find the first name, last name and job title of all employees whose salary is in the range [20000, 30000].
Example
FirstName	LastName	JobTitle
Rob	Walters	Senior Tool Designer
Thierry	D'Hers	Tool Designer
JoLynn	Dobney	Production Supervisor
SELECT [FirstName], [LastName], [JobTitle] FROM Employees
WHERE Salary BETWEEN 20000 AND 30000
Problem 9.	 Find Names of All Employees 
Write a SQL query to find the full name of all employees whose salary is 25000, 14000, 12500 or 23600. Full Name is combination of first, middle and last name (separated with single space) and they should be in one column called “Full Name”.
Example
Full Name
Guy R Gilbert
Thierry B D'Hers
JoLynn M Dobney
SELECT FirstName + ' ' + MiddleName + ' ' + LastName AS [Full Name] 
FROM Employees
WHERE Salary IN (25000, 14000, 12500, 23600)
Problem 10.	 Find All Employees Without Manager
Write a SQL query to find first and last names about those employees that does not have a manager. 
Example
FirstName	LastName
Ken	Sanchez
Svetlin	Nakov
SELECT [FirstName], [LastName]
FROM Employees
WHERE ManagerId IS NULL
Problem 11.	 Find All Employees with Salary More Than 50000
Write a SQL query to find first name, last name and salary of those employees who has salary more than 50000. Order them in decreasing order by salary. 
Example
FirstName	LastName	Salary
Ken	Sanchez	125500.00
James	Hamilton	84100.00
SELECT [FirstName], [LastName], [Salary]
FROM Employees
WHERE Salary > 50000
ORDER BY Salary DESC
Problem 12.	 Find 5 Best Paid Employees.
Write SQL query to find first and last names about 5 best paid Employees ordered descending by their salary.
Example
FirstName	LastName
Ken	Sanchez
James	Hamilton
SELECT TOP (5) [FirstName], [LastName]
FROM Employees
ORDER BY Salary DESC
Problem 13.	Find All Employees Except Marketing
Write a SQL query to find the first and last names of all employees whose department ID is different from 4.
Example
FirstName	LastName
Guy	Gilbert
Roberto	Tamburello
Rob	Walters
SELECT [FirstName], [LastName]
FROM Employees
WHERE DepartmentId <> 4
Problem 14.	Sort Employees Table
Write a SQL query to sort all records in the Employees table by the following criteria: 
•	First by salary in decreasing order
•	Then by first name alphabetically
•	Then by last name descending
•	Then by middle name alphabetically
Example
ID	First
Name	Last
Name	Middle
Name	Job Title	DeptID	Mngr
ID	HireDate	Salary	AddressID
109	Ken	Sanchez	J	Chief Executive Officer	16	NULL	…	125500.00	177
148	James	Hamilton	R	Vice President of Production	7	109	…	84100.00	158
273	Brian	Welcker	S	Vice President of Sales	3	109	…	72100.00	134
SELECT * FROM Employees
ORDER BY Salary DESC, 
         FirstName ASC,
         LastName DESC,
         MiddleName ASC
Problem 15.	 Create View Employees with Salaries
Write a SQL query to create a view V_EmployeesSalaries with first name, last name and salary for each employee.
Example
FirstName	LastName	Salary
Guy	Gilbert	12500.00
Kevin	Brown	13500.00
CREATE VIEW V_EmployeesSalaries AS
SELECT [FirstName], [LastName], [Salary] FROM Employees
Problem 16.	Create View Employees with Job Titles
Write a SQL query to create view V_EmployeeNameJobTitle with full employee name and job title. When middle name is NULL replace it with empty string (‘’).
Example
Full Name	Job Title
Guy R Gilbert	Production Technician
Kevin F Brown	Marketing Assistant
Roberto  Tamburello	Engineering Manager
CREATE VIEW V_EmployeeNameJobTitle AS
SELECT FirstName + ' ' + ISNULL(MiddleName, '') + ' ' + LastName AS [Full Name], 
       JobTitle AS [Job Title] 
FROM Employees

ИЛИ:
CREATE VIEW V_EmployeeNameJobTitle AS
SELECT CONCAT(FirstName,' ', MiddleName, ' ', LastName) AS [Full Name], 
       JobTitle AS [Job Title] 
FROM Employees

Problem 17.	 Distinct Job Titles
Write a SQL query to find all distinct job titles.
Example
JobTitle
Accountant
Accounts Manager
Accounts Payable Specialist
SELECT DISTINCT JobTitle
FROM Employees
Problem 18.	Find First 10 Started Projects
Write a SQL query to find first 10 started projects. Select all information about them and sort them by start date, then by name.
Example
ID	Name	Description	StartDate	EndDate
6	HL Road Frame	Research, design and development of HL Road …	1998-05-02 00:00:00	2003-06-01 00:00:00
2	Cycling Cap	Research, design and development of C…	2001-06-01 00:00:00	2003-06-01 00:00:00
5	HL Mountain Frame	Research, design and development of HL M…	2001-06-01 00:00:00	2003-06-01 00:00:00
SELECT TOP(10) *
FROM Projects
ORDER BY StartDate, 
         [Name]
Problem 19.	 Last 7 Hired Employees
Write a SQL query to find last 7 hired employees. Select their first, last name and their hire date.
Example
FirstName	LastName	HireDate
Rachel	Valdez	2005-07-01 00:00:00
Lynn	Tsoflias	2005-07-01 00:00:00
Syed	Abbas	2005-04-15 00:00:00
SELECT TOP(7) [FirstName], [LastName], [HireDate]
FROM Employees
ORDER BY HireDate DESC
Problem 20.	Increase Salaries
Write a SQL query to increase salaries of all employees that are in the Engineering, Tool Design, Marketing or Information Services department by 12%. Then select Salaries column from the Employees table. After that exercise restore your database to revert those changes.
Example
Salary
12500.00
15120.00
48496.00
33376.00
UPDATE Employees
SET Salary *= 1.12
WHERE DepartmentId IN (1, 2, 4, 11)

SELECT [Salary]
FROM Employees

Problem 21.	All Mountain Peaks
Display all mountain peaks in alphabetical order.
Example
PeakName
Aconcagua
Banski Suhodol
Batashki Snezhnik
SELECT [PeakName] FROM Peaks
ORDER BY PeakName
Problem 22.	 Biggest Countries by Population
Find the 30 biggest countries by population from Europe. Display the country name and population. Sort the results by population (from biggest to smallest), then by country alphabetically.
Example
CountryName	Population
Russia	140702000
Germany	81802257
France	64768389
SELECT TOP(30) [CountryName], [Population] FROM Countries AS e
INNER JOIN Continents AS d ON d.ContinentCode = e.ContinentCode
WHERE d.ContinentName = 'Europe'
ORDER BY e.Population DESC,
         e.CountryName
Problem 23.	 *Countries and Currency (Euro / Not Euro)
Find all countries along with information about their currency. Display the country name, country code and information about its currency: either "Euro" or "Not Euro". Sort the results by country name alphabetically.
*Hint: Use CASE … WHEN.
Example
CountryName	CountryCode	Currency
Afghanistan	AF	Not Euro
Åland	AX	Euro
Albania	AL	Not Euro
SELECT [CountryName], [CountryCode],
         CASE WHEN CurrencyCode = 'EUR' THEN 'Euro'
	  ELSE 'Not Euro'
	  END AS [Currency]
FROM Countries
ORDER BY CountryName
Problem 24.	All Diablo Characters
Display all characters in alphabetical order. 
Example
Name
Amazon
Assassin
Barbarian
SELECT [Name] FROM Characters
ORDER BY [Name]

Built-in Functions
Свързване на текст:
SELECT CONCAT_WS(' ', FirstName, LastName)
    AS [Full Name]
  FROM Employee
Substring:
SUBSTRING(String, StartIndex, Length)
SUBSTRING('SoftUni', 5, 3) => Uni
Replace: 
REPLACE(String, Pattern, Replacement)

Местене на празни пространства:
LTRIM & RTRIM – remove spaces from either side of string
LTRIM(String)
TRIM(String)

Намиране на брой символи:
LEN(String)
Намиране на използваните байти:
DATALENGTH(String)

LEFT & RIGHT – get characters from the beginning or the  end of a string
LEFT(String, Count)

Показване на първите символи и скриване на останалите със *:
CONCAT(SUBSTRING(PaymentNumber, 1, 6), REPLICATE('*', LEN(PaymentNumber)-6))
      AS PaymentNumber
FROM Customers
ИЛИ:
SELECT CustomerID,
       FirstName,
       LastName,
       LEFT(PaymentNumber, 6) + '**********' 
  FROM Customers

Смяна на малки и големи букви:
LOWER(String)
UPPER(String)

Смяна на подредбата на символите:
REVERSE(String)

Повтаряне на стринг:
REPLICATE(String, Count)

Търсене на определен текст/символи:
CHARINDEX(Pattern, String, [StartIndex])

Вмъкване на текст на конкретна позиция:
STUFF(String, StartIndex, Length, Substring)
SELECT STUFF('This a bad idea', 8, 3, 'good') -> This a good idea
SELECT STUFF('This a bad idea', 8, 4, 'good') -> This a goodidea
Задаване на формат:
FORMAT ( value, format [, culture ] ) 
The format argument must contain a valid .NET Framework 
format string
SELECT FORMAT(67.23, 'C', 'bg-BG') -> 67,23 лв.
SELECT FORMAT(CAST('2019-1-21' AS date), 'D', 'bg-BG') -> 21 януари 2019 г.
TRANSLATE ( inputString, characters, translations)
SELECT TRANSLATE('2*[3+4]/{7-2}', '[]{}', '()()’);
// 2*(3+4)/(7-2)

PI
SELECT PI() --3.14159265358979

Абсолютна стойност:
ABS(Value)

Корен квадратен:
SQRT(Value)

Повдигане на втора степен:
SQUARE(Value)

Повдигане на степени:
POWER(Value, Exponent)

Закръгляване:
ROUND(Value, Precision)
Negative precision rounds characters before the decimal point
FLOOR(Value)
CEILING(Value)







SELECT
  CEILING(
    CEILING(
      CAST(Quantity AS float) / 
      BoxCapacity) / PalletCapacity)
    AS [Number of pallets]
  FROM Products

Показване на знак:
SIGN(Value)

Генериране на случайни числа:
RAND(2)
RAND()

DATEPART – вадене на част от дата като integer:
SELECT DATEPART(QUARTER,'2019-01-21')
SELECT * FROM Projects WHERE DATEPART(QUARTER,StartDate) = 3
  
SELECT InvoiceId, Total,
       DATEPART(QUARTER, InvoiceDate) AS Quarter,
       DATEPART(MONTH, InvoiceDate) AS Month,
       DATEPART(YEAR, InvoiceDate) AS Year,
       DATEPART(DAY, InvoiceDate) AS Day
  FROM Invoice

Намира разликата между дати:
DATEDIFF(Part, FirstDate, SecondDate)
SELECT ID, FirstName, LastName,
       DATEDIFF(YEAR, HireDate, '2017/01/25')
    AS [Years In Service]
  FROM Employees

Изкарванеe на наименование на част от датата:
DATENAME(Part, Date)
SELECT DATENAME(weekday, '2017/01/27') -> Friday
SELECT DATENAME(DAYOFYEAR, '2017/02/27') -> 58
Добавяне на дата:
DATEADD(Part, Number, Date)
SELECT DATEADD(DAY,5, '05-21-2019') -> 2019-05-26 00:00:00.000

Определяне на дата:
SELECT GETDATE()

Показване на последен ден от месец:
EOMONTH ( start_date [, month_to_add ] )
SELECT EOMONTH('2017/01/27’) -> 2017-01-31

Kонвериране на data types:
CAST & CONVERT – conversion between data types
CAST(Data AS NewType)
CONVERT(NewType, Data)

	Example: Display “Not Finished” for projects with no EndDate
SELECT ProjectID, Name,
       ISNULL(CAST(EndDate AS varchar), 'Not Finished')
  FROM Projects
Връщане на първа стойност, която не е NULL
SELECT COALESCE(NULL, NULL, 'third_value', 'fourth_value') -> third_value

Вземи и пропусни:
SELECT ID, FirstName, LastName
    FROM Employees
ORDER BY ID
  OFFSET 10 ROWS
   FETCH NEXT 5 ROWS ONLY

	ROW_NUMBER – always generate unique values without any   gaps, even if there are ties
 
	 RANK – can have gaps in its sequence and when values are the same, they get the same rank
 
	DENSE_RANK – returns the same rank for ties, but it doesn’t    have any gaps in the sequence
 
Wildcard:
%    -- any string, including zero-length
_    -- any single character
[…]  -- any character within range
[^…] -- any character not in the range

SELECT ID, Name
  FROM Tracks
 WHERE Name LIKE '%max!%' ESCAPE '!'


Exercises: Built-in Functions

Problem 1.	Find Names of All Employees by First Name
Write a SQL query to find first and last names of all employees whose first name starts with “SA”. 
Example
FirstName	LastName
Sariya	Harnpadoungsataya
Sandra	Reategui Alayo
SELECT [FirstName], [LastName]
 FROM Employees
WHERE FirstName LIKE 'SA%'
Problem 2.	  Find Names of All employees by Last Name 
Write a SQL query to find first and last names of all employees whose last name contains “ei”. 
Example
FirstName	LastName
Kendall	Keil
Christian	Kleinerman
SELECT [FirstName], [LastName]
 FROM Employees
WHERE LastName LIKE '%ei%'
Problem 3.	Find First Names of All Employees
Write a SQL query to find the first names of all employees in the departments with ID 3 or 10 and whose hire year is between 1995 and 2005 inclusive.
Example
FirstName
Deborah
Wendy
Candy
SELECT [FirstName]
 FROM Employees
WHERE DepartmentID IN (3, 10)
      AND DATEPART(YEAR, HireDate) BETWEEN 1995 AND 2005
Problem 4.	Find All Employees Except Engineers
Write a SQL query to find the first and last names of all employees whose job titles does not contain “engineer”. 
Example
FirstName	LastName
Guy	Gilbert
Kevin	Brown
Rob	Walters
SELECT [FirstName], [LastName]
 FROM Employees
WHERE JobTitle NOT LIKE '%engineer%'
Problem 5.	Find Towns with Name Length
Write a SQL query to find town names that are 5 or 6 symbols long and order them alphabetically by town name. 
Example
Name
Berlin
Duluth
Duvall
SELECT [Name]
 FROM Towns
WHERE LEN([Name]) IN (5, 6)
ORDER BY [Name]
Problem 6.	 Find Towns Starting With
Write a SQL query to find all towns that start with letters M, K, B or E. Order them alphabetically by town name. 
Example
TownID	Name
5	Bellevue
31	Berlin
30	Bordeaux
SELECT [TownID], [Name]
FROM Towns
WHERE [Name] LIKE 'M%' OR 
      [Name] LIKE 'K%' OR 
      [Name] LIKE 'B%' OR 
      [NAME] LIKE 'E%'
ORDER BY [Name]

ИЛИ:
SELECT [TownID], [Name]
FROM Towns
WHERE LEFT([Name],1) IN ('M', 'K', 'B', 'E')
ORDER BY [Name]

ИЛИ:
SELECT [TownID], [Name]
 FROM Towns
WHERE [Name] LIKE '[MKBE]%'
ORDER BY [Name]
Problem 7.	 Find Towns Not Starting With
Write a SQL query to find all towns that does not start with letters R, B or D. Order them alphabetically by name. 
Example
TownID	Name
2	Calgary
23	Cambridge
15	Carnation
SELECT [TownID], [Name]
 FROM Towns
WHERE [Name] NOT LIKE '[RBD]%'
ORDER BY [Name]

ИЛИ:
SELECT [TownID], [Name]
 FROM Towns
WHERE [Name] LIKE '[^RBD]%'
ORDER BY [Name]

ИЛИ:
SELECT [TownID], [Name]
FROM Towns
WHERE LEFT([Name],1) NOT IN ('R', 'B', 'D')
ORDER BY [Name]

Problem 8.	Create View Employees Hired After 2000 Year
Write a SQL query to create view V_EmployeesHiredAfter2000 with first and last name to all employees hired after 2000 year. 
Example
FirstName	LastName
Steven	Selikoff
Peter	Krebs
Stuart	Munson
CREATE VIEW V_EmployeesHiredAfter2000 AS
SELECT [FirstName], [LastName]
 FROM Employees
WHERE DATEPART(YEAR, HireDate) > 2000
Problem 9.	Length of Last Name
Write a SQL query to find the names of all employees whose last name is exactly 5 characters long.
Example
FirstName	LastName
Kevin	Brown
Terri	Duffy
Jo	Brown
Diane	Glimp
SELECT [FirstName], [LastName]
 FROM Employees
WHERE LEN(LastName) = 5
Problem 10.	
Rank Employees by Salary
Write a query that ranks all employees using DENSE_RANK. In the DENSE_RANK function, employees need to be partitioned by Salary and ordered by EmployeeID. You need to find only the employees whose Salary is between 10000 and 50000 and order them by Salary in descending order.
Example
EmployeeID	FirstName	LastName	Salary	Rank
268	Stephen	Jiang	48100.00	1
284	Amy	Alberts	48100.00	2
288	Syed	Abbas	48100.00	3
SELECT [EmployeeID], [FirstName], [LastName], [Salary], 
       DENSE_RANK() OVER (PARTITION BY Salary ORDER BY EmployeeID) AS [Rank]
 FROM Employees
WHERE Salary BETWEEN 10000 AND 50000
ORDER BY Salary DESC
268	Stephen	Jiang	48100.00	1
284	Amy	Alberts	48100.00	2
288	Syed	Abbas	       48100.00     3
291	Svetlin	Nakov	48000.00	1
292	Martin	Kulov	       48000.00     2
293	George	Denchev	48000.00	3
71	Wendy	Kahn	       43300.00	1
3	Roberto Tamburello	42676.48	1
217	Michael	Raheem	42500.00	1
79	Diane	Margheim	40900.00	1
114	Gigi	Matthew	40900.00	2
150	Stephanie	Conroy	39128.32	1
......
Problem 11.	Find All Employees with Rank 2 *
Use the query from the previous problem and upgrade it, so that it finds only the employees whose Rank is 2 and again, order them by Salary (descending).
Example
EmployeeID	FirstName	LastName	Salary	Rank
284	Amy	Alberts	48100.00	2
292	Martin	Kulov	48000.00	2
71	Wendy	Kahn	43300.00	2
SELECT * FROM (
SELECT [EmployeeID], [FirstName], [LastName], [Salary], 
DENSE_RANK() OVER (PARTITION BY Salary ORDER BY EmployeeID) AS [Rank]
FROM Employees
WHERE Salary BETWEEN 10000 AND 50000) AS Sorted
WHERE SorteD.Rank = 2
ORDER BY Salary DESC
Problem 12.	Countries Holding ‘A’ 3 or More Times
Find all countries that holds the letter 'A' in their name at least 3 times (case insensitively), sorted by ISO code. Display the country name and ISO code. 
Example
Country Name	ISO Code
Afghanistan	AFG
Albania	ALB
…	…
SELECT CountryName AS [Country Name], 
       IsoCode AS [Iso Code]
FROM Countries
WHERE LEN(CountryName) - LEN(REPLACE(CountryName, 'A', '')) >= 3
ORDER BY IsoCode

ИЛИ:
SELECT CountryName AS [Country Name], 
       IsoCode AS [Iso Code]
FROM Countries
WHERE CountryName LIKE '%A%A%A%'
ORDER BY IsoCode
Problem 13.	 Mix of Peak and River Names
Combine all peak names with all river names, so that the last letter of each peak name is the same as the first letter of its corresponding river name. Display the peak names, river names, and the obtained mix (mix should be in lowercase). Sort the results by the obtained mix.
Example
PeakName	RiverName	Mix
Aconcagua	Amazon	aconcaguamazon
Aconcagua	Amur	aconcaguamur
Banski Suhodol	Lena	banski suhodolena
SELECT Peaks.PeakName,
       Rivers.RiverName,
	   LOWER(CONCAT(LEFT(Peaks.PeakName, LEN(Peaks.PeakName) - 1), Rivers.RiverName)) AS Mix
FROM Peaks, 
     Rivers
WHERE RIGHT(PeakName, 1) = LEFT(RiverName, 1)
ORDER BY MIX

или:
SELECT p.PeakName, r.RiverName,
LOWER(CONCAT(LEFT(p.PeakName, LEN(p.PeakName) - 1), r.RiverName)) AS Mix
 FROM Peaks AS p
JOIN Rivers AS r ON RIGHT(p.PeakName, 1) = LEFT(r.RiverName, 1)
ORDER BY Mix
Problem 14.	Games from 2011 and 2012 year
Find the top 50 games ordered by start date, then by name of the game. Display only games from 2011 and 2012 year. Display start date in the format “yyyy-MM-dd”. 
Example
Name	Start
Rose Royalty	2011-01-05
London	2011-01-13
Broadway	2011-01-16
SELECT TOP(50) [Name], 
               FORMAT([Start], 'yyyy-MM-dd') AS [Start]
FROM Games
WHERE DATEPART(YEAR, Start) IN (2011, 2012)
ORDER BY [Start],
         [Name]
Problem 15.	 User Email Providers
Find all users along with information about their email providers. Display the username and email provider. Sort the results by email provider alphabetically, then by username. 
Example
Username	Email Provider
Pesho	abv.bg
monoxidecos	astonrasuna.com
bashsassafras	balibless
SELECT Username,
      SUBSTRING(Email, CHARINDEX('@', Email) + 1, LEN(Email) - CHARINDEX('@', Email))
	  AS [Email Provider]
FROM Users
ORDER BY [Email Provider],
         [Username]

ИЛИ:
SELECT [Username],
       RIGHT(Email, LEN(Email) - CHARINDEX('@', Email))
	  AS [Email Provider]
FROM Users
ORDER BY [Email Provider],
         [Username]

Problem 16.	 Get Users with IPAdress Like Pattern
Find all users along with their IP addresses sorted by username alphabetically. Display only rows that IP address matches the pattern: “***.1^.^.***”. 
Legend: * - one symbol, ^ - one or more symbols
Example
Username	IP Address
bindbawdy	192.157.20.222
evolvingimportant	223.175.227.173
inguinalself	255.111.250.207
SELECT Username,
       IpAddress
FROM Users
WHERE IpAddress LIKE '___.1_%._%.___'
ORDER BY [Username]
Problem 17.	 Show All Games with Duration and Part of the Day
Find all games with part of the day and duration sorted by game name alphabetically then by duration (alphabetically, not by the timespan) and part of the day (all ascending). Parts of the day should be Morning (time is >= 0 and < 12), Afternoon (time is >= 12 and < 18), Evening (time is >= 18 and < 24). Duration should be Extra Short (smaller or equal to 3), Short (between 4 and 6 including), Long (greater than 6) and Extra Long (without duration). 
Example
Game	Part of the Day	Duration
Ablajeck	Morning	Long
Ablajeck	Afternoon	Short
Abregado Rae	Afternoon	Long
Abrion	Morning	Extra Short
Acaeria	Evening	Long
SELECT [Name] AS [Game],
       CASE
		WHEN DATEPART(HOUR, [Start]) >= 0 AND DATEPART(HOUR, [Start]) < 12 THEN 'Morning'
		WHEN DATEPART(HOUR, [Start]) >= 12 AND DATEPART(HOUR, [Start]) < 18 THEN 'Afternoon'
		ELSE 'Evening'
	END AS [Part of the Day],
	CASE 
		WHEN Duration <= 3 THEN 'Extra Short'
		WHEN Duration BETWEEN 4 AND 6 THEN 'Short'
		WHEN Duration >= 6 THEN 'Long'
		ELSE 'Extra Long'
	END AS [Duration]
FROM Games
ORDER BY Game,
         Duration,
	  [Part of the Day] ASC
Problem 18.	Orders Table
You are given a table Orders(Id, ProductName, OrderDate) filled with data. Consider that the payment for that order must be accomplished within 3 days after the order date. Also the delivery date is up to 1 month. Write a query to show each product’s name, order date, pay and deliver due dates. 
Original Table
Id	ProductName	OrderDate
1	Butter	2016-09-19 00:00:00.000
2	Milk	2016-09-30 00:00:00.000
3	Cheese	2016-09-04 00:00:00.000
4	Bread	2015-12-20 00:00:00.000
5	Tomatoes	2015-12-30 00:00:00.000
SELECT [ProductName],
       [OrderDate],
       DATEADD(DAY, 3, OrderDate) AS [Pay Due],
	DATEADD(MONTH, 1, OrderDate) AS [Deliver Due]
FROM Orders
Output
ProductName	OrderDate	Pay Due	Deliver Due
Butter	2016-09-19 00:00:00.000	2016-09-22 00:00:00.000	2016-10-19 00:00:00.000
Milk	2016-09-30 00:00:00.000	2016-10-03 00:00:00.000	2016-10-30 00:00:00.000
Cheese	2016-09-04 00:00:00.000	2016-09-07 00:00:00.000	2016-10-04 00:00:00.000
Bread	2015-12-20 00:00:00.000	2015-12-23 00:00:00.000	2016-01-20 00:00:00.000
Tomatoes	2015-12-30 00:00:00.000	2016-01-02 00:00:00.000	2016-01-30 00:00:00.000
…	…	…	…
Problem 19.	 People Table
Create a table People(Id, Name, Birthdate). Write a query to find age in years, months, days and minutes for each person for the current time of executing the query.
Original Table
Id	Name	Birthdate
1	Victor	2000-12-07 00:00:00.000
2	Steven	1992-09-10 00:00:00.000
3	Stephen	1910-09-19 00:00:00.000
4	John	2010-01-06 00:00:00.000
…	…	…
Example Output
Name	Age in Years	Age in Months	Age in Days	Age in Minutes
Victor	16	189	5754	8286787
Steven	24	288	8764	12621187
Stephen	106	1272	38706	55737667
John	6	80	2437	3510307
…	…	…	…	…

CREATE TABLE People(
                    Id INT PRIMARY KEY IDENTITY NOT NULL, 
					[Name] NVARCHAR(50) NOT NULL, 
					Birthdate DATETIME2 NOT NULL
					)

INSERT INTO People ([Name], Birthdate) VALUES
('Victor',	'2000-12-07 00:00:00.000'),
('Steven',	'1992-09-10 00:00:00.000'),
('Stephen',	'1910-09-19 00:00:00.000'),
('John',	'2010-01-06 00:00:00.000')

SELECT [Name],
       DATEDIFF(YEAR, Birthdate, GETDATE()) AS [Age in Years],
	DATEDIFF(MONTH, Birthdate, GETDATE()) AS [Age in Months],
	DATEDIFF(DAY, Birthdate, GETDATE()) AS [Age in Days],
	 DATEDIFF(MINUTE, Birthdate, GETDATE()) AS [Age in Minutes]
FROM People

Data Aggregation
Групиране:
  SELECT e.DepartmentID 
    FROM Employees AS e
GROUP BY e.DepartmentID

Може да се използват и други агрегиращи функции:
SELECT e.DepartmentID, SUM(Salary)
    FROM Employees AS e
GROUP BY e.DepartmentID

Вадене на допълнителни данни при групиране
SELECT e.DepartmentID,
       SUM(e.Salary) AS TotalSalary,
       AVG(e.Salary) AS AvgSalary,
       MIN(e.Salary) AS MinSalary,
       MAX(e.Salary) AS MaxSalary,
       STRING_AGG(e.FirstName + ' ' + e.LastName, ', ') AS Employees
FROM Employees AS e
GROUP BY e.DepartmentID

Изкарване на допълнитени данни:
SELECT DepositGroup,
       IsDepositExpired,
	AVG(DepositInterest) AS AverageInterest
FROM WizzardDeposits
WHERE DepositStartDate > '01/01/1985'
GROUP BY DepositGroup,
         IsDepositExpired
ORDER BY DepositGroup DESC,
         IsDepositExpired

Сортиране:
SELECT e.DepartmentID, 
  SUM(e.Salary) AS TotalSalary
FROM Employees AS e
GROUP BY e.DepartmentID
ORDER BY e.DepartmentID

Взимане на уникални стойности:
SELECT DISTINCT e.DepartmentID 
  FROM Employees AS e

HAVING:
SELECT e.DepartmentID,
       SUM(e.Salary) AS TotalSalary,
       AVG(e.Salary) AS AvgSalary,
       MIN(e.Salary) AS MinSalary,
       MAX(e.Salary) AS MaxSalary,
	   STRING_AGG(e.FirstName + ' ' + e.LastName, ', ') AS Employees
FROM Employees AS e
GROUP BY e.DepartmentID
HAVING SUM(e.Salary) >= 15000
Exercises: Data Aggregation

Mr. Bodrog is a greedy small goblin who is in charge of Gringotts – the biggest wizard bank. His most precious possession is a small database of the deposits in the wizard’s world. Taking money is his hobby. He wants your money as well but unfortunately you are not a wizard. The only magic you know is how to work with databases. That’s how you got access to the precious data. Mr. Bodrog wants you to send him some reports otherwise he will send a pack of hungry werewolves after you. You don’t want to confront pack of hungry werewolves, do you?
Before going on the next task make sure to download the Gringotts database.
Problem 1.	Records’ Count
Import the database and send the total count of records from the one and only table to Mr. Bodrog. Make sure nothing got lost.
Example:
Count
162
SELECT COUNT(Id) AS [Count]
FROM WizzardDeposits
Problem 2.	Longest Magic Wand
Select the size of the longest magic wand. Rename the new column appropriately.
Example:
LongestMagicWand
31
SELECT MAX(MagicWandSize) AS [LongestMagicWand]
FROM WizzardDeposits
Problem 3.	Longest Magic Wand per Deposit Groups
For wizards in each deposit group show the longest magic wand. Rename the new column appropriately.
Example:
DepositGroup	LongestMagicWand
Blue Phoenix	31
SELECT w.DepositGroup,
       MAX(w.MagicWandSize) AS [LongestMagicWand]
FROM WizzardDeposits AS w
GROUP BY w.DepositGroup

Problem 4.	* Smallest Deposit Group per Magic Wand Size
Select the two deposit groups with the lowest average wand size.
Example:
DepositGroup
Troll Chest
Venomous Tongue
SELECT TOP(2)
        w.DepositGroup
FROM WizzardDeposits AS w
GROUP BY w.DepositGroup
ORDER BY AVG(w.MagicWandSize)

Problem 5.	Deposits Sum
Select all deposit groups and their total deposit sums.
Example:
DepositGroup	TotalSum
Blue Phoenix	819598.73
Human Pride	1041291.52
SELECT w.DepositGroup,
	   SUM(DepositAmount) AS TotalSum
FROM WizzardDeposits AS w
GROUP BY w.DepositGroup
Problem 6.	Deposits Sum for Ollivander Family
Select all deposit groups and their total deposit sums but only for the wizards who have their magic wands crafted by Ollivander family.
Example:
DepositGroup	TotalSum
Blue Phoenix	52968.96
Human Pride	188366.86
SELECT w.DepositGroup,
	   SUM(DepositAmount) AS TotalSum
FROM WizzardDeposits AS w
WHERE MagicWandCreator = 'Ollivander family'
GROUP BY w.DepositGroup
Problem 7.	Deposits Filter
Select all deposit groups and their total deposit sums but only for the wizards who have their magic wands crafted by Ollivander family. Filter total deposit amounts lower than 150000. Order by total deposit amount in descending order.
Example:
DepositGroup	TotalSum
Troll Chest	126585.18
SELECT w.DepositGroup,
	   SUM(DepositAmount) AS TotalSum
FROM WizzardDeposits AS w
WHERE MagicWandCreator = 'Ollivander family'
GROUP BY w.DepositGroup
HAVING SUM(DepositAmount) < 150000
ORDER BY TotalSum DESC
Problem 8.	 Deposit Charge
Create a query that selects:
•	Deposit group 
•	Magic wand creator
•	Minimum deposit charge for each group 
Select the data in ascending ordered by MagicWandCreator and DepositGroup.
Example:
DepositGroup	MagicWandCreator	MinDepositCharge
Blue Phoenix	Antioch Peverell	30.00
SELECT DepositGroup,
       MagicWandCreator,
	   MIN(DepositCharge) AS MinDepositCharge
FROM WizzardDeposits
GROUP BY DepositGroup, MagicWandCreator
ORDER BY MagicWandCreator,
         DepositGroup

Blue Phoenix	Antioch Peverell	30.00
Human Pride	Antioch Peverell	23.00
Troll Chest	Antioch Peverell	46.00
Venomous Tongue	Antioch Peverell	27.00
Blue Phoenix	Arturo Cephalopos	17.00
Human Pride	Arturo Cephalopos	6.00
Troll Chest	Arturo Cephalopos	11.00
Venomous Tongue	Arturo Cephalopos	22.00
Blue Phoenix	Death	36.00
Human Pride	Death	3.00
Troll Chest	Death	16.00
Venomous Tongue	Death	1.00
Blue Phoenix	Jimmy Kiddell	4.00
Human Pride	Jimmy Kiddell	15.00
Troll Chest	Jimmy Kiddell	1.00
Venomous Tongue	Jimmy Kiddell	35.00
Blue Phoenix	Mykew Gregorovitch	7.00
Human Pride	Mykew Gregorovitch	42.00
Troll Chest	Mykew Gregorovitch	17.00
Venomous Tongue	Mykew Gregorovitch	5.00
Blue Phoenix	Ollivander family	21.00
Human Pride	Ollivander family	7.00
Troll Chest	Ollivander family	21.00
Venomous Tongue	Ollivander family	23.00
Problem 9.	Age Groups
Write down a query that creates 7 different groups based on their age.
Age groups should be as follows:
•	[0-10]
•	[11-20]
•	[21-30]
•	[31-40]
•	[41-50]
•	[51-60]
•	[61+]
The query should return
•	Age groups
•	Count of wizards in it
Example:
AgeGroup	WizardCount
[11-20]	21
SELECT grouped.AgeGroups,
      COUNT(*) AS WizzardCount
FROM
(
  SELECT CASE 
            WHEN Age BETWEEN 0 AND 10 THEN '[0-10]'
            WHEN Age BETWEEN 11 AND 20 THEN '[11-20]'
	     WHEN Age BETWEEN 21 AND 30 THEN '[21-30]'
	     WHEN Age BETWEEN 31 AND 40 THEN '[31-40]'
            WHEN Age BETWEEN 41 AND 50 THEN '[41-50]'	
	     WHEN Age BETWEEN 51 AND 60 THEN '[51-60]'
            ELSE '[61+]'
	     END AS AgeGroups 
   FROM WizzardDeposits) AS grouped
GROUP BY grouped.AgeGroups
Problem 10.	First Letter
Write a query that returns all unique wizard first letters of their first names only if they have deposit of type Troll Chest. Order them alphabetically. Use GROUP BY for uniqueness.
Example:
FirstLetter
A
SELECT DISTINCT LEFT(FirstName, 1) AS [e.FirstLetter]
      FROM WizzardDeposits 
      WHERE DepositGroup = 'Troll Chest'

или:
SELECT *
FROM (
      SELECT LEFT(FirstName, 1) AS [e.FirstLetter]
      FROM WizzardDeposits 
      WHERE DepositGroup = 'Troll Chest'
	  ) AS e
GROUP BY e. [e.FirstLetter]

Problem 11.	Average Interest 
Mr. Bodrog is highly interested in profitability. He wants to know the average interest of all deposit groups split by whether the deposit has expired or not. But that’s not all. He wants you to select deposits with start date after 01/01/1985. Order the data descending by Deposit Group and ascending by Expiration Flag.
The output should consist of the following columns:
Example:
DepositGroup	IsDepositExpired	AverageInterest
Venomous Tongue	0	16.698947
SELECT DepositGroup,
       IsDepositExpired,
	AVG(DepositInterest) AS AverageInterest
FROM WizzardDeposits
WHERE DepositStartDate > '01/01/1985'
GROUP BY DepositGroup,
         IsDepositExpired
ORDER BY DepositGroup DESC,
         IsDepositExpired
Problem 12.	* Rich Wizard, Poor Wizard
Mr. Bodrog definitely likes his werewolves more than you. This is your last chance to survive! Give him some data to play his favorite game Rich Wizard, Poor Wizard. The rules are simple: You compare the deposits of every wizard with the wizard after him. If a wizard is the last one in the database, simply ignore it. In the end you have to sum the difference between the deposits.
Host Wizard	Host Wizard Deposit	Guest Wizard	Guest Wizard Deposit	Difference
Harry	10 000	Tom	12 000	-2000
Tom	12 000	…	…	…
At the end your query should return a single value: the SUM of all differences.
Example:
SumDifference
44393.97
SELECT SUM(sums.Difference)
FROM
(
 SELECT DepositAmount -
       (
        SELECT DepositAmount
        FROM WizzardDeposits AS wd
        WHERE wd.Id = resulted.Id + 1
       ) AS [Difference]
 FROM WizzardDeposits AS resulted
) AS sums


или:
SELECT SUM(diff.Difference)
FROM 
(
 SELECT (DepositAmount - LEAD(DepositAmount) OVER(ORDER BY Id)) AS [Difference]
 FROM WizzardDeposits
 ) AS diff
Problem 13.	Departments Total Salaries
That’s it! You no longer work for Mr. Bodrog. You have decided to find a proper job as an analyst in SoftUni. 
It’s not a surprise that you will use the SoftUni database. Things get more exciting here!
Create a query that shows the total sum of salaries for each department. Order by DepartmentID.
Your query should return:	
•	DepartmentID
Example:
DepartmentID	TotalSalary
1	241000.00
SELECT DepartmentID,
       SUM(Salary)
FROM Employees
GROUP BY DepartmentID
ORDER BY DepartmentID
Problem 14.	Employees Minimum Salaries
Select the minimum salary from the employees for departments with ID (2, 5, 7) but only for those hired after 01/01/2000.
Your query should return:	
•	DepartmentID
Example: 
DepartmentID	MinimumSalary
2	25000.00
5	12800.00
SELECT DepartmentID,
       MIN(Salary) AS MinimumSalary
FROM Employees
WHERE HireDate > '01/01/2000'
GROUP BY DepartmentID
HAVING DepartmentID IN (2, 5, 7)
ORDER BY DepartmentID
Problem 15.	Employees Average Salaries
Select all employees who earn more than 30000 into a new table. Then delete all employees who have ManagerID = 42 (in the new table). Then increase the salaries of all employees with DepartmentID=1 by 5000. Finally, select the average salaries in each department.
Example:
DepartmentID	AverageSalary
1	45166.6666
SELECT *
INTO EmployeesAvgSalariesTable
FROM Employees
WHERE Salary > 30000

DELETE FROM EmployeesAvgSalariesTable
WHERE ManagerID = 42

UPDATE EmployeesAvgSalariesTable
SET Salary += 5000
WHERE DepartmentID = 1

SELECT DepartmentID,
       AVG(Salary)
FROM EmployeesAvgSalariesTable
GROUP BY DepartmentID
Problem 16.	Employees Maximum Salaries
Find the max salary for each department. Filter those, which have max salaries NOT in the range 30000 – 70000.
Example:
DepartmentID	MaxSalary
2	29800.00
SELECT DepartmentID,
       MAX(Salary) AS MaxSalary
FROM Employees
GROUP BY DepartmentID
HAVING MAX(Salary) NOT BETWEEN 30000 AND 70000
ORDER BY DepartmentID
Problem 17.	Employees Count Salaries
Count the salaries of all employees who don’t have a manager.
Example:
Count
4
SELECT COUNT(EmployeeID)
FROM Employees
WHERE ManagerID IS NULL
Problem 18.	*3rd Highest Salary
Find the third highest salary in each department if there is such. 
Example:
DepartmentID	ThirdHighestSalary
1	36100.00
SELECT DepartmentID,
       Salary
FROM
(
   SELECT DepartmentID,
          Salary,
   	      DENSE_RANK() OVER (PARTITION BY DepartmentID ORDER BY Salary DESC) 
   	      AS Ranking
   FROM Employees
) AS ranked
WHERE ranked.Ranking = 3
GROUP BY ranked.DepartmentID,
         ranked.Salary
Problem 19.	**Salary Challenge
Write a query that returns:
•	FirstName
•	LastName
•	DepartmentID
Select all employees who have salary higher than the average salary of their respective departments. Select only the first 10 rows. Order by DepartmentID.
Example:
FirstName	LastName	DepartmentID
Roberto	Tamburello	1
SELECT TOP(10) FirstName,
               LastName,
	        DepartmentID
FROM Employees AS e1
WHERE Salary >
             (
	       SELECT AVG(Salary)
		FROM Employees AS e2
		WHERE e1.DepartmentID = e2.DepartmentID
	       )
ORDER BY e1.DepartmentID

Table Relations
JOIN:
SELECT * FROM Towns
  JOIN Countries ON 
    Countries.Id = Towns.CountryId
Каскадно търсене:
CREATE TABLE Drivers(
  DriverID INT PRIMARY KEY,
  DriverName VARCHAR(50)
)
CREATE TABLE Cars(
  CarID INT PRIMARY KEY,
  DriverID INT,
  CONSTRAINT FK_Car_Driver FOREIGN KEY(DriverID)
  REFERENCES Drivers(DriverID) ON DELETE CASCADE
)





Exercises: Table Relations
This document defines the exercise assignments for the "Databases Basics - MSSQL" course @ Software University. 
Problem 1.	One-To-One Relationship
Create two tables as follows. Use appropriate data types.
Persons		Passports
PersonID	FirstName	Salary	PassportID		PassportID	PassportNumber
1  	Roberto                                            	43300.00	102		101	N34FG21B
2	Tom	56100.00	103		102	K65LO4R7
3	Yana	60200.00	101		103	ZE657QP2
Insert the data from the example above.
Alter the customers table and make PersonID a primary key. Create a foreign key between Persons and Passports by using PassportID column.

CREATE TABLE Persons
(
 PersonID INT IDENTITY NOT NULL,
 FirstName NVARCHAR(50) NOT NULL,
 Salary DECIMAL(8, 2),
 PassportID INT NOT NULL
 )

 CREATE TABLE Passports
 (
  PassportID INT NOT NULL,
  PassportNumber VARCHAR(20) NOT NULL
  )

  INSERT INTO Persons VALUES
  ('Roberto', 43300, 102),
  ('Tom', 56100, 103),
  ('Yana', 60200, 101)

  INSERT INTO Passports VALUES
  (101,	'N34FG21B'),
  (102, 'K65LO4R7'),
  (103, 'ZE657QP2')

  ALTER TABLE Persons
  ADD CONSTRAINT PK_Persons
  PRIMARY KEY (PersonID)

  ALTER TABLE Passports
  ADD CONSTRAINT PK_Passports
  PRIMARY KEY (PassportID)

  ALTER TABLE Persons
  ADD CONSTRAINT FK_PERSONS_PASSPORTS
  FOREIGN KEY(PassportID) REFERENCES Passports(PassportID)
Problem 2.	One-To-Many Relationship
Create two tables as follows. Use appropriate data types.
Models		Manufacturers
ModelID	Name	ManufacturerID		ManufacturerID	Name	EstablishedOn
101	X1	1		1  	BMW	07/03/1916
102	i6	1		2	Tesla	01/01/2003
103	Model S	2		3	Lada	01/05/1966
104	Model X	2		
105	Model 3	2		
106	Nova	3		
Insert the data from the example above. Add primary keys and foreign keys.
CREATE TABLE Manufacturers
  (
   ManufacturerID INT PRIMARY KEY NOT NULL,
   [Name] NVARCHAR(20) NOT NULL,
   EstablishedOn DATE
   )

  CREATE TABLE Models
  (
   ModelID INT PRIMARY KEY NOT NULL,
   [Name] VARCHAR(50) NOT NULL,
   ManufacturerID INT NOT NULL 
   )

   INSERT INTO Models VALUES
   (101,'X1', 1),
   (102,'i6', 1),
   (103, 'Model S', 2),
   (104, 'Model X', 2),
   (105, 'Model 3', 2),
   (106, 'Nova', 3 )

   INSERT INTO Manufacturers VALUES
   (1, 'BMW', '07/03/1916'),
   (2, 'Tesla', '01/01/2003'),
   (3, 'Lada', '01/05/1966')

   ALTER TABLE Models
   ADD CONSTRAINT FK_Models_Manufactories
   FOREIGN KEY (ManufacturerID) REFERENCES Manufacturers(ManufacturerID)
Problem 3.	Many-To-Many Relationship
Create three tables as follows. Use appropriate data types.
Students		Exams		StudentsExams
StudentID	Name		ExamID	Name		StudentID	ExamID
1  	Mila                                      		101	SpringMVC		1	101
2	Toni		102	Neo4j		1	102
3	Ron		103	Oracle 11g		2	101
				3	103
				2	102
				2	103
Insert the data from the example above.
Add primary keys and foreign keys. Have in mind that table StudentsExams should have a composite primary key.
CREATE TABLE Students
   (
    StudentID INT PRIMARY KEY NOT NULL,
	[Name] NVARCHAR(20) NOT NULL
   )

   CREATE TABLE Exams
   (
    ExamID INT PRIMARY KEY NOT NULL,
	[Name] NVARCHAR(50) NOT NULL
   )

    CREATE TABLE StudentsExams
   (
    StudentID INT FOREIGN KEY REFERENCES Students(StudentID) NOT NULL,
	ExamID INT FOREIGN KEY REFERENCES Exams(ExamID) NOT NULL,
	CONSTRAINT PK_StudentsExams PRIMARY KEY(StudentID, ExamID)
   )

   INSERT INTO Students Values
   (1, 'Mila'),                                     
   (2, 'Toni'),
   (3, 'Ron	')

   INSERT INTO Exams VALUES
   (101,'SpringMVC'),
   (102,' Neo4j'),
   (103,' Oracle 11g')

    INSERT INTO StudentsExams VALUES
    (1,	101),
    (1,	102),
    (2,	101),
    (3,	103),
    (2,	102),
    (2,	103)
Problem 4.	Self-Referencing 
Create a single table as follows. Use appropriate data types.
Teachers
TeacherID	Name	ManagerID
101	John	NULL
102	Maya	106
103	Silvia	106
104	Ted	105
105	Mark	101
106	Greta	101
Insert the data from the example above. Add primary keys and foreign keys. The foreign key should be between ManagerId and TeacherId.
Problem 5.	Online Store Database
Create a new database and design the following structure:
 
Problem 6.	University Database
Create a new database and design the following structure:
 
Problem 7.	SoftUni Design
Create an E/R Diagram of the SoftUni Database. There are some special relations you should check out: Employees are self-referenced (ManagerID) and Departments have One-to-One with the Employees (ManagerID) while the Employees have One-to-Many (DepartmentID). You might find it interesting how it looks on the diagram. 
Problem 8.	Geography Design
Create an E/R Diagram of the Geography Database.
Problem 9.	*Peaks in Rila
Display all peaks for "Rila" mountain. Include:
•	MountainRange
•	PeakName
•	Elevation
Peaks should be sorted by elevation descending.
Example
MountainRange	PeakName	Elevation
Rila	Musala	2925
…	…	…



