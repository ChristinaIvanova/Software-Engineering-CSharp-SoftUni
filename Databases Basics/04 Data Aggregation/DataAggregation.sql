Exercises: Data Aggregation

/*****************************************************
Problem 1.	Records’ Count
Import the database and send the total count of records from the one and only table to Mr. Bodrog. Make sure nothing got lost.
*****************************************************/
SELECT COUNT(Id) AS [Count]
FROM WizzardDeposits


/*****************************************************
Problem 2.	Longest Magic Wand
Select the size of the longest magic wand. Rename the new column appropriately.
*****************************************************/
SELECT MAX(MagicWandSize) AS [LongestMagicWand]
FROM WizzardDeposits


/*****************************************************
Problem 3.	Longest Magic Wand per Deposit Groups
For wizards in each deposit group show the longest magic wand. Rename the new column appropriately.
*****************************************************/
SELECT w.DepositGroup,
       MAX(w.MagicWandSize) AS [LongestMagicWand]
FROM WizzardDeposits AS w
GROUP BY w.DepositGroup


/*****************************************************
Problem 4.	* Smallest Deposit Group per Magic Wand Size
Select the two deposit groups with the lowest average wand size.
*****************************************************/
SELECT TOP(2)
        w.DepositGroup
FROM WizzardDeposits AS w
GROUP BY w.DepositGroup
ORDER BY AVG(w.MagicWandSize)


/*****************************************************
Problem 5.	Deposits Sum
Select all deposit groups and their total deposit sums.
*****************************************************/
SELECT w.DepositGroup,
	   SUM(DepositAmount) AS TotalSum
FROM WizzardDeposits AS w
GROUP BY w.DepositGroup


/*****************************************************
Problem 6.	Deposits Sum for Ollivander Family
Select all deposit groups and their total deposit sums but only for the wizards who have their magic wands crafted by Ollivander family.
*****************************************************/
SELECT w.DepositGroup,
	   SUM(DepositAmount) AS TotalSum
FROM WizzardDeposits AS w
WHERE MagicWandCreator = 'Ollivander family'
GROUP BY w.DepositGroup


/*****************************************************
Problem 7.	Deposits Filter
Select all deposit groups and their total deposit sums but only for the wizards who have their magic wands crafted by Ollivander family. Filter total deposit amounts lower than 150000. Order by total deposit amount in descending order.
*****************************************************/
SELECT w.DepositGroup,
	   SUM(DepositAmount) AS TotalSum
FROM WizzardDeposits AS w
WHERE MagicWandCreator = 'Ollivander family'
GROUP BY w.DepositGroup
HAVING SUM(DepositAmount) < 150000
ORDER BY TotalSum DESC


/*****************************************************
Problem 8.	 Deposit Charge
Create a query that selects:
•	Deposit group 
•	Magic wand creator
•	Minimum deposit charge for each group 
Select the data in ascending ordered by MagicWandCreator and DepositGroup.
*****************************************************/
SELECT DepositGroup,
       MagicWandCreator,
	   MIN(DepositCharge) AS MinDepositCharge
FROM WizzardDeposits
GROUP BY DepositGroup, MagicWandCreator
ORDER BY MagicWandCreator,
         DepositGroup



/*****************************************************
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
*****************************************************/
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



/*****************************************************
Problem 10.	First Letter
Write a query that returns all unique wizard first letters of their first names only if they have deposit of type Troll Chest. Order them alphabetically. Use GROUP BY for uniqueness.
*****************************************************/
SELECT DISTINCT LEFT(FirstName, 1) AS [e.FirstLetter]
      FROM WizzardDeposits 
      WHERE DepositGroup = 'Troll Chest'

-----OR----:
SELECT *
FROM (
      SELECT LEFT(FirstName, 1) AS [e.FirstLetter]
      FROM WizzardDeposits 
      WHERE DepositGroup = 'Troll Chest'
	  ) AS e
GROUP BY e. [e.FirstLetter]



/*****************************************************
Problem 11.	Average Interest 
Mr. Bodrog is highly interested in profitability. He wants to know the average interest of all deposit groups split by whether the deposit has expired or not. But that’s not all. He wants you to select deposits with start date after 01/01/1985. Order the data descending by Deposit Group and ascending by Expiration Flag.
The output should consist of the following columns:
*****************************************************/
SELECT DepositGroup,
       IsDepositExpired,
	AVG(DepositInterest) AS AverageInterest
FROM WizzardDeposits
WHERE DepositStartDate > '01/01/1985'
GROUP BY DepositGroup,
         IsDepositExpired
ORDER BY DepositGroup DESC,
         IsDepositExpired



/*****************************************************
Problem 12.	* Rich Wizard, Poor Wizard
Mr. Bodrog definitely likes his werewolves more than you. This is your last chance to survive! Give him some data to play his favorite game Rich Wizard, Poor Wizard. The rules are simple: You compare the deposits of every wizard with the wizard after him. If a wizard is the last one in the database, simply ignore it. In the end you have to sum the difference between the deposits.
Host Wizard	Host Wizard Deposit	Guest Wizard	Guest Wizard Deposit	Difference
Harry	10 000	Tom	12 000	-2000
Tom	12 000	…	…	…
At the end your query should return a single value: the SUM of all differences.
*****************************************************/
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


----OR----:
SELECT SUM(diff.Difference)
FROM 
(
 SELECT (DepositAmount - LEAD(DepositAmount) OVER(ORDER BY Id)) AS [Difference]
 FROM WizzardDeposits
 ) AS diff


/*****************************************************
Problem 13.	Departments Total Salaries
That’s it! You no longer work for Mr. Bodrog. You have decided to find a proper job as an analyst in SoftUni. 
It’s not a surprise that you will use the SoftUni database. Things get more exciting here!
Create a query that shows the total sum of salaries for each department. Order by DepartmentID.
*****************************************************/
SELECT DepartmentID,
       SUM(Salary)
FROM Employees
GROUP BY DepartmentID
ORDER BY DepartmentID


/*****************************************************
Problem 14.	Employees Minimum Salaries
Select the minimum salary from the employees for departments with ID (2, 5, 7) but only for those hired after 01/01/2000.
*****************************************************/
SELECT DepartmentID,
       MIN(Salary) AS MinimumSalary
FROM Employees
WHERE HireDate > '01/01/2000'
GROUP BY DepartmentID
HAVING DepartmentID IN (2, 5, 7)
ORDER BY DepartmentID



/*****************************************************
Problem 15.	Employees Average Salaries
Select all employees who earn more than 30000 into a new table. Then delete all employees who have ManagerID = 42 (in the new table). Then increase the salaries of all employees with DepartmentID=1 by 5000. Finally, select the average salaries in each department.
*****************************************************/
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


/*****************************************************
Problem 16.	Employees Maximum Salaries
Find the max salary for each department. Filter those, which have max salaries NOT in the range 30000 – 70000.
*****************************************************/
SELECT DepartmentID,
       MAX(Salary) AS MaxSalary
FROM Employees
GROUP BY DepartmentID
HAVING MAX(Salary) NOT BETWEEN 30000 AND 70000
ORDER BY DepartmentID


/*****************************************************
Problem 17.	Employees Count Salaries
Count the salaries of all employees who don’t have a manager.
*****************************************************/
SELECT COUNT(EmployeeID)
FROM Employees
WHERE ManagerID IS NULL


/*****************************************************
Problem 18.	*3rd Highest Salary
Find the third highest salary in each department if there is such. 
*****************************************************/
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


/*****************************************************
Problem 19.	**Salary Challenge
Write a query that returns:
•	FirstName
•	LastName
•	DepartmentID
Select all employees who have salary higher than the average salary of their respective departments. Select only the first 10 rows. Order by DepartmentID.
*****************************************************/
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


