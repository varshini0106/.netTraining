use AssignmentDB

--1.	Write a query to display your birthday( day of week)
select '06-01-2004' as 'Birthdate', datename(weekday, '2004-06-01') as 'Day of the week'

--2.	Write a query to display your age in days
select datediff(day, '2004-06-01', getdate()) as 'Age in days'

--3.	Write a query to display all employees information those who joined before 5 years in the current month
select * from emp select * from dept

update emp set hire_date = '20-JUL-19' where empno = 7499
update emp set hire_date = '02-JUL-24' where empno = 7566
update emp set hire_date = '28-JUL-81' where empno = 7654
update emp set hire_date = '17-JUL-17' where empno = 7839
update emp set hire_date = '09-JUL-22' where empno = 7782
update emp set hire_date = '23-JUL-07' where empno = 7934

select * from emp
where
month(hire_date) = month(getdate()) and 
datediff(year, hire_date, getdate()) >= 5

--4.	Create table Employee with empno, ename, sal, doj columns or use your emp table and perform 
--the following operations in a single transaction
create table CC2_Employee(
Empno int primary key,
Ename varchar(20),
salary float,
date_of_joining date)

--a. First insert 3 rows
insert into CC2_Employee values 
(201, 'Aruna', 25000, '23-OCT-21'),
(202, 'Vithika', 20000, '06-MAR-19'),
(203, 'Kamala', 28000, '10-JUL-19')
select * from CC2_Employee

--b. Update the second row sal with 15% increment
		--select ename , salary as 'Before updation', (salary * 1.15) as 'After Updation' from CC2_Employee
		--where empno = 202   (for output)
update CC2_Employee set salary = salary * 1.15 where empno = 202
select * from CC2_Employee

--c. Delete first row.
delete from CC2_Employee
where empno = 201
select * from CC2_Employee

--After completing above all actions, recall the deleted row without losing increment of second row.
commit

--5.      Create a user defined function calculate Bonus for all employees of a  given dept using 	following conditions
	--a.     For Deptno 10 employees 15% of sal as bonus.
	--b.     For Deptno 20 employees  20% of sal as bonus
	--c      For Others employees 5%of sal as bonus

select * from emp
create or alter function fn_calculateBonus(@deptno int, @salary int)
returns int
as begin
	declare @bonus int
    if @deptno = 10
	begin
        set @bonus = @salary * 0.15
    end
	else if @deptno = 20
	begin
        set @bonus = @salary * 0.20
    end
	else
	begin
        set @bonus = @salary * 0.05
	end
    return @bonus
end
 
select empno 'Employee Id', ename 'Employee Name', deptno 'Department No', Salary, 
dbo.fn_calculateBonus(deptno, salary) 'Bonus' from emp



--6. Create a procedure to update the salary of employee by 500 whose dept name is Sales and current salary is below 1500 (use emp table)
create or alter proc sp_sales_salary_update 
as begin 
	update emp set salary = salary + 500 where deptno = (select deptno from dept where dname = 'SALES') and salary < 1500
end
 
exec sp_sales_salary_update
 
select * from emp where deptno = (select deptno from dept where dname = 'SALES')