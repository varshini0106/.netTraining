create database CodeChallengedb
use CodeChallengedb

create table Books(
Id int primary key,
Title char(30),
Author char(30),
isbn numeric unique,
Published_date datetime
)

select * from Books

insert into Books values(1, 'My First SQL Book', 'Mary Parker', 981483029127, '2012-02-22 12:08:17'),
(2, 'My Second SQL Book', 'John Mayer', 857300923713, '1972-07-03 09:22:45'),
(3, 'My Third SQL Book', 'Cary Flint', 523120967812, '2015-10-18 14:05:44')

create table Reviews(
Id int not null,
Bood_id int references Books(ID),
Reviewer_Name char(30),
Content char(30),
Rating int,
Published_date date
)

select * from Reviews

insert into Reviews values(1, 1, 'John Smith', 'My First Review', 4, '2017-12-10'),
(2, 2, 'John Smith', 'My Second Review', 5, '2017-10-13'),
(3, 3, 'Alice Walker', 'Another Review', 1, '2017-10-22')


--query 1
--Write a query to fetch the details of the books written by author whose name ends with er

select * from Books where Author like '%er'

--query 2
--Display the Title ,Author and ReviewerName for all the books from the above table

select Title, Author, Reviewer_Name from Books, Reviews
where Books.id = Reviews.Bood_id

--query 3
--Display the reviewer name who reviewed more than one book.

select Reviewer_Name from Reviews
group by Reviewer_Name
having count(*) > 1


create table Customers(
Id int primary key,
Name char(30),
Age int,
Address char(30),
Salary float
)

select * from Customers

insert into Customers values
(1, 'Ramesh', 32, 'Ahmedabad', 2000.00),
(2, 'Khilan', 25, 'Delhi', 1500.00), 
(3, 'Kaushik', 23, 'Kota', 2000.00),
(4, 'Chaitali', 25, 'Mumbai', 6500.00),
(5, 'Hardik', 27, 'Bhopal', 8500.00),
(6, 'Komal', 22, 'MP', 4500.00),
(7, 'Muffy', 24, 'Indore', 10000.00)

create table Orders(
O_Id int not null,
order_receive_date date,
Customer_Id int references Customers(Id),
Amount int
)

select * from Orders

insert into Orders values (102, '2009-10-08', 3, 3000),
(100, '2009-10-08', 3, 1500),
(101, '2009-11-20', 2, 1560),
(103, '2008-05-20', 4, 2060)

--query 4
--Display the Name for the customer from above customer table who live in same address which has character o anywhere in address

select Name, Address from Customers
where Address like '%o%'

--query 5
--Write a query to display the Date,Total no of customer placed order on same Date

select order_receive_date as 'Date' , Count(Customer_Id) 'Count of Customers ordered on same date' 
from Orders
group by order_receive_date 

create table Employees(
Id int primary key,
Name char(30),
Age int,
Address char(30),
Salary float
)

select * from Employees

insert into Employees values
(1, 'Ramesh', 32, 'Ahmedabad', 2000.00),
(2, 'Khilan', 25, 'Delhi', 1500.00), 
(3, 'Kaushik', 23, 'Kota', 2000.00),
(4, 'Chaitali', 25, 'Mumbai', 6500.00),
(5, 'Hardik', 27, 'Bhopal', 8500.00),
(6, 'Komal', 22, 'MP', null),
(7, 'Muffy', 24, 'Indore', null)

--query 6
--Display the Names of the Employee in lower case, whose salary is null

select lower(Name) 'Employee Name'
from Employees 
where Salary is null

create table StudentDetails(
RegisterNo int primary key,
Name char(30),
Age int,
Qualification varchar(20),
Mobile_No numeric unique,
Mail_Id varchar(20) unique,
Location char(20),
Gender char(7)
)

select * from StudentDetails

insert into StudentDetails values (2, 'Sai', 22, 'B.E', 9952836777, 'Sai@gmail.com', 'Chennai', 'M'),
(3, 'Kumar', 20, 'BSC', 7890125648, 'Kumar@gmail.com', 'Madurai', 'M'),
(4, 'Selvi', 22, 'B.Tech', 8904567342, 'Selvi@gmail.com', 'Selam', 'F'),
(5, 'Nisha', 25, 'M.E', 7834672310, 'Nisha@gmail.com', 'Theni', 'F'),
(6, 'Sai Saran', 21, 'B.A', 7890345678, 'Saran@gmail.com', 'Madurai', 'F'),
(7, 'Tom', 23, 'BCA', 8901234675, 'Tom@gmail.com', 'Pune', 'M')

--query 7
--Write a sql server query to display the Gender,Total no of male and female from the above relation

select Gender, count(gender) as 'Count_of_Gender' 
from StudentDetails
group by Gender