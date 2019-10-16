---1
CREATE DATABASE Airport
GO 
USE Airport
GO

CREATE TABLE Planes
(
Id	INT PRIMARY KEY IDENTITY,
[Name]	VARCHAR(30) NOT NULL,
Seats INT NOT NULL,
[Range]	INT NOT NULL
)

CREATE TABLE Flights
(
Id INT PRIMARY KEY IDENTITY,
DepartureTime	DATETIME2,
ArrivalTime	DATETIME2,
[Origin] VARCHAR(50) NOT NULL,
Destination	VARCHAR(50) NOT NULL,
PlaneId	INT FOREIGN KEY REFERENCES Planes(Id) NOT NULL
)

CREATE TABLE Passengers
(
Id INT PRIMARY KEY IDENTITY,
FirstName VARCHAR(30) NOT NULL,
LastName VARCHAR(30) NOT NULL,
Age	INT NOT NULL,
[Address] VARCHAR(30) NOT NULL,
PassportId	CHAR(11) NOT NULL
)

CREATE TABLE LuggageTypes
(
Id INT PRIMARY KEY IDENTITY,
[Type]	VARCHAR(30) NOT NULL
)

CREATE TABLE Luggages
(
Id INT PRIMARY KEY IDENTITY,
LuggageTypeId INT FOREIGN KEY REFERENCES LuggageTypes(Id) NOT NULL,
PassengerId	INT FOREIGN KEY REFERENCES Passengers(Id) NOT NULL
)

CREATE TABLE Tickets
(
Id INT PRIMARY KEY IDENTITY,
PassengerId	INT FOREIGN KEY REFERENCES Passengers(Id) NOT NULL,
FlightId	INT FOREIGN KEY REFERENCES Flights(Id) NOT NULL,
LuggageId	INT FOREIGN KEY REFERENCES Luggages(Id) NOT NULL,
Price DECIMAL(18,2) NOT NULL
)
  
---2

INSERT INTO Planes VALUES 
('Airbus 336',	112, 5132),
('Airbus 330',	432, 5325),
('Boeing 369',	231, 2355),
('Stelt 297',	254, 2143),
('Boeing 338',	165, 5111),
('Airbus 558',	387, 1342),
('Boeing 128',	345, 5541)

INSERT INTO LuggageTypes VALUES
('Crossbody Bag'),
('School Backpack'),
('Shoulder Bag')


---3
UPDATE Tickets
SET Price *= 1.13
WHERE FlightId IN(
                  SELECT Id
	              FROM Flights 
	              WHERE Destination = 'Carlsbad'
	              )

---4
DELETE Tickets
WHERE FlightId IN(
                  SELECT Id
				  FROM Flights
				  WHERE Destination = 'Ayn Halagim'
				  )
DELETE FROM Flights
WHERE Destination = 'Ayn Halagim'

---5
SELECT *
FROM Planes
WHERE [Name] LIKE '%tr%'
ORDER BY Id,
         [Name],
		 Seats,
		 [Range]

---6 
SELECT FlightId,
	   SUM(Price) AS Price
FROM Tickets
GROUP BY FlightId
ORDER BY SUM(Price) DESC,
         FlightId

---7
SELECT CONCAT(p.FirstName, ' ', p.LastName) AS 'Full Name',
       f.Origin,
	   f.Destination 
FROM Passengers AS p
JOIN Tickets AS t ON p.Id = t.PassengerId
JOIN Flights AS f ON t.FlightId = f.Id
ORDER BY CONCAT(p.FirstName, ' ', p.LastName),
         Origin,
		 Destination

---8
SELECT p.FirstName AS 'First Name',
       p.LastName AS 'Last Name',
       p.Age
FROM Passengers AS p
LEFT JOIN Tickets AS t ON p.Id = t.PassengerId
WHERE t.PassengerId IS NULL
ORDER BY Age DESC,
         FirstName,
		 LastName

---9
SELECT CONCAT(p.FirstName, ' ', p.LastName) AS 'Full Name',
       pl.[Name] AS 'Plane Name',
	   CONCAT(f.Origin, ' - ', f.Destination) AS Trip,
	   lt.[Type] AS 'Luggage Type'
FROM Passengers AS p
JOIN Tickets AS t ON p.Id = t.PassengerId
JOIN Flights AS f ON t.FlightId = f.Id
JOIN Planes AS pl ON f.PlaneId = pl.Id
JOIN Luggages AS l ON t.LuggageId = l.Id
JOIN LuggageTypes AS lT ON  l.LuggageTypeId = lt.[Id]
ORDER BY [Full Name],
         [Plane Name],
		 Origin,
		 Destination,
		 [Luggage Type]

---10
SELECT p.[Name],
       p.Seats,
	   COUNT(t.PassengerId) AS 'Passengers Count'
FROM Planes AS p
LEFT JOIN Flights AS f ON p.Id = f.PlaneId
LEFT JOIN Tickets AS t ON f.Id = t.FlightId
GROUP BY p.[Name],
       p.Seats
ORDER BY [Passengers Count] DESC,
         [Name],
		 Seats

---11
CREATE FUNCTION udf_CalculateTickets(@origin VARCHAR(50), @destination VARCHAR(50), @peopleCount INT)
RETURNS VARCHAR(50)
AS
BEGIN
     DECLARE @totalPrice DECIMAL(18,2)
     DECLARE @flightId INT = ( 
	                          SELECT TOP(1) Id
							  FROM  Flights
							  WHERE Origin = @origin AND 
							        Destination = @destination
							  )
	 IF(@flightId IS NULL)
	 BEGIN
	     RETURN 'Invalid flight!'
	 END
     IF(@peopleCount <= 0)
	 BEGIN
	      RETURN 'Invalid people count!'
	 END
	 DECLARE @PricePerPerson DECIMAL(18,2) = (
	                                          SELECT TOP(1) Price
					                          FROM Tickets
						                      WHERE FlightId = @flightId
						                      )
	 SET @totalPrice = @peopleCount * @PricePerPerson
	 RETURN CONCAT('Total price ', @totalPrice)
END

---12
CREATE PROC usp_CancelFlights
AS
BEGIN
     UPDATE Flights
	 SET ArrivalTime = NULL,
	     DepartureTime = NULL
	 WHERE DATEDIFF(SECOND, DepartureTime, ArrivalTime) > 0
END

EXEC usp_CancelFlights