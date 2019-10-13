--1
CREATE DATABASE Bitbucket
USE Bitbucket
CREATE TABLE Users
(
Id INT Identity PRIMARY KEY,
Username NVARCHAR(30) NOT NULL,
[Password]	NVARCHAR(30) NOT NULL,
Email	NVARCHAR(50) NOT NULL
)

CREATE TABLE Repositories
(
Id INT Identity PRIMARY KEY,
[Name] NVARCHAR(50) NOT NULL
)

CREATE TABLE RepositoriesContributors
(
RepositoryId INT FOREIGN KEY REFERENCES Repositories(Id) NOT NULL,
ContributorId INT FOREIGN KEY REFERENCES Users(Id) NOT NULL,
CONSTRAINT PK_RepositoriesContributors PRIMARY KEY(RepositoryId,ContributorId)
)

CREATE TABLE Issues
(
Id	INT PRIMARY KEY Identity,
Title	NVARCHAR(255) NOT NULL,
IssueStatus	NVARCHAR(6)  NOT NULL, 
RepositoryId	INT FOREIGN KEY REFERENCES Repositories(Id) NOT NULL,
AssigneeId	INT FOREIGN KEY REFERENCES Users(Id) NOT NULL
)

CREATE TABLE Commits
(
Id INT PRIMARY KEY Identity,
[Message]	NVARCHAR(255) NOT NULL,
IssueId	INT FOREIGN KEY REFERENCES Issues(Id),
RepositoryId INT FOREIGN KEY REFERENCES	 Repositories(Id) NOT NULL,
ContributorId	INT FOREIGN KEY REFERENCES Users(Id) NOT NULL
)

CREATE TABLE Files
(
Id	INT PRIMARY KEY Identity,
[Name]	NVARCHAR(100) NOT NULL,
Size	Decimal(8,2) NOT NULL ,
ParentId INT FOREIGN KEY REFERENCES	Files(Id),
CommitId INT FOREIGN KEY REFERENCES Commits(Id) NOT NULL
)

 --2
 INSERT INTO Files ([Name], Size, ParentId, CommitId) VALUES
 ('Trade.idk',	2598.0,	1,	1),
('menu.net',	9238.31,	2,	2),
('Administrate.soshy',	1246.93,	3,	3),
('Controller.php',	7353.15,	4,	4),
('Find.java',	9957.86,	5,	5),
('Controller.json',	14034.87,	3,	6),
('Operate.xix',	7662.92,	7,	7)

INSERT INTO Issues (Title,IssueStatus, RepositoryId, AssigneeId) VALUES
('Critical Problem with HomeController.cs file',	'open',	1,	4),
('Typo fix in Judge.html', 'open',	4,	3),
('Implement documentation for UsersService.cs', 'closed',	8,	2),
('Unreachable code in Index.cs', 'open',	9,	8)

--3
UPDATE Issues
SET IssueStatus = 'closed'
WHERE AssigneeId = 6

--4
DELETE Issues
WHERE RepositoryId =(
SELECT Id
FROM Repositories
WHERE [Name] ='Softuni-Teamwork'
)

DELETE RepositoriesContributors
WHERE RepositoryId =(
SELECT Id
FROM Repositories
WHERE [Name] ='Softuni-Teamwork'
)

--5
SELECT Id,
       [Message],
	   RepositoryId,
	   ContributorId
FROM Commits
ORDER BY Id,
         [Message],
		 RepositoryId,
		 ContributorId

--6
SELECT Id,
       [Name],
	   Size
FROM Files
WHERE Size > 1000 AND
      [Name] LIKE '%html%'
ORDER BY Size DESC,
         Id,
		 [Name]

--7
SELECT i.Id,
       CONCAT(u.Username, ' : ', i.Title) AS IssueAssignee
FROM Issues AS i
JOIN Users AS u ON i.AssigneeId = u.Id
ORDER BY i.Id DESC,
         IssueAssignee

--8
SELECT f.Id,
       f.[Name],
	   CONCAT(f.Size, 'KB') AS Size
FROM Files AS f
lEFT JOIN Files AS p ON f.Id = p.ParentId
WHERE p.Id IS NULL
 ORDER BY Id,
         [Name],
		 Size DESC


--9
SELECT TOP(5) r.Id, 
       r.[Name],
	   COUNT(c.RepositoryId)
FROM Repositories AS r
LEFT JOIN Commits AS c ON r.Id = c.RepositoryId
LEFT JOIN RepositoriesContributors AS rc ON r.Id = rc.RepositoryId
GROUP BY r.Id, r.[Name]
ORDER BY Count(c.RepositoryId) DESC, 
         r.Id,
		 r.[Name]

 --10

 SELECT u.Username,
       AVG(f.Size) AS Size
 FROM Commits AS c
 JOIN Users AS u ON c.ContributorId = u.Id
 JOIN Files AS f ON c.Id = f.CommitId
 GROUP BY u.Username
 ORDER BY AVG(f.Size) DESC,
          Username    

--11
CREATE FUNCTION udf_UserTotalCommits(@username NVARCHAR(30))
RETURNS INT
AS
BEGIN
     DECLARE @userTotalCommintments INT
     DECLARE @userID INT
	 SET @userID = 
	            (
				  SELECT Id
				  FROM Users
				  WHERE Username = @username
				  )

     SET @userTotalCommintments = 
	 (SELECT  COUNT(*)
	 FROM Commits
	 WHERE ContributorId = @userID)
	 RETURN @userTotalCommintments
END

--12
CREATE PROC usp_FindByExtension(@extension NVARCHAR(MAX))
AS
BEGIN
     SELECT Id,
	        [Name],
			CONCAT(Size, 'KB') AS Size
	 FROM Files
	 WHERE [Name] LIKE ('%' + '.' + @extension)
END

EXEC usp_FindByExtension 'txt'

