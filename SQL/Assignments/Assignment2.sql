create database AssignmentDB
use AssignmentDB

create table dept(
deptno int primary key,
dname varchar(30),
loc varchar(30)
)

insert into dept values(10,'ACCOUNTING','NEW YORK'),
(20,'RESEARCH','DALLAS'),
(30,'SALES','CHICAGO' ),
(40,'OPERATIONS','BOSTON')

create table emp(
empno int primary key,
ename varchar(30) not null,
job varchar(30) not null,
mgr_id int,
hire_date varchar(30),
salary int,
comm int,
deptno int references dept(deptno)
)

insert into emp values (7369, 'SMITH', 'CLERK', 7902, '17-DEC-80', 800, NULL, 20),
(7499, 'ALLEN', 'SALESMAN', 7698, '20-FEB-81', 1600, 300, 30),
(7521, 'WARD', 'SALESMAN', 7698, '22-FEB-81', 1250, 500, 30),
(7566, 'JONES', 'MANAGER', 7839, '02-APR-81', 2975, NULL, 20),
(7654, 'MARTIN', 'SALESMAN', 7698, '28-SEP-81', 1250, 1400, 30),
(7698, 'BLAKE', 'MANAGER', 7839, '01-MAY-81', 2850, NULL, 30),
(7782, 'CLARK', 'MANAGER', 7839, '09-JUN-81', 2450, NULL, 10),
(7788, 'SCOTT', 'ANALYST', 7566, '19-APR-87', 3000, NULL, 20),
(7839, 'KING', 'PRESIDENT', NULL, '17-NOV-81', 5000, NULL, 10),
(7844, 'TURNER', 'SALESMAN', 7698, '08-SEP-81', 1500, 0, 30),
(7876, 'ADAMS', 'CLERK', 7788, '23-MAY-87', 1100, NULL, 20),
(7900, 'JAMES', 'CLERK', 7698, '03-DEC-81', 950, NULL, 30),
(7902, 'FORD', 'ANALYST', 7566, '03-DEC-81', 3000, NULL, 20),
(7934, 'MILLER', 'CLERK', 7782, '23-JAN-82', 1300, NULL, 10)

select * from dept 
select * from emp

--1. List all employees whose name begins with 'A'.
select * from emp where ename like 'A%'

--2. Select all those employees who don't have a manager.
select * from emp where mgr_id is null

--3. List employee name, number and salary for those employees who earn in the range 1200 to 1400. 
select ename as 'Employee Name', empno as 'Employee_Id', salary 
from emp
where salary between 1200 and 1400

--4. Give all the employees in the RESEARCH department a 10% pay rise. Verify that this has been done by listing all their details before and after the rise.
select ename, salary as 'Salary_Before_Rise',
salary + 0.1 * salary as 'Salary_After_Rise'
from emp 
where deptno = (select deptno from dept where dname = 'Research')

--5. Find the number of CLERKS employed. Give it a descriptive heading.
select count(*) as 'Count of Clerks' from emp
where job = 'Clerk' 

--6. Find the average salary for each job type and the number of people employed in each job.
select job, avg(salary) as 'Average of Salary', count(*) as 'Employee count in each job' from emp
group by job

--7. List the employees with the lowest and highest salary. 
select * from emp
where salary = (select min(salary) from emp) or salary = (select max(salary) from emp)

--8. List full details of departments that don't have any employees. 
select * from dept
where deptno not in (select deptno from emp)

--9. Get the names and salaries of all the analysts earning more than 1200 who are based in department 20. Sort the answer by ascending order of name.
select ename, salary from emp
where job = 'Analyst' and  salary > 1200 and deptno = 20
order by ename 

--10. For each department, list its name and number together with the total salary paid to employees in that department. 
select dept.dname, dept.deptno, sum(emp.salary) as 'Total Salary' from dept
join emp on emp.deptno = dept.deptno
group by dname, dept.deptno

--11. Find out salary of both MILLER and SMITH.
select ename, salary from emp
where ename in ('Miller', 'Smith')

--12. Find out the names of the employees whose name begin with ‘A’ or ‘M’.
select ename from emp 
where ename like 'A%' or ename like 'M%'

--13. Compute yearly salary of SMITH. 
select salary as 'Monthly salary of smith', salary * 12 as 'Yearly Salary of Smith' from emp 
where ename = 'Smith'

--14. List the name and salary for all employees whose salary is not in the range of 1500 and 2850.
select ename, salary from emp 
where salary not between 1500 and 2850

--15. Find all managers who have more than 2 employees reporting to them
select mgr_id, count(*) 'Count of Employees Reporting'  from emp
group by mgr_id
having count(*) > 2
