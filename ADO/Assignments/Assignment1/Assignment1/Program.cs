using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1
{
    public class Employee
    {

        public int EmployeeID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Title { get; set; }
        public DateTime DOB { get; set; }
        public DateTime DOJ { get; set; }
        public string City { get; set; }

        public static void DisplayEmployees(IEnumerable<Employee> employees)
        {
            foreach (var e in employees)
            {
                Console.WriteLine($"ID: {e.EmployeeID}, Name: {e.FirstName} {e.LastName}, Title: {e.Title}, DOB: {e.DOB.ToShortDateString()}, DOJ: {e.DOJ.ToShortDateString()}, City: {e.City}");
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            List<Employee> empList = GetEmployees();

            //1. Display a list of all the employee who have joined before 1/1/2015
            Console.WriteLine("List of employees who have joined before 1/1/2015: ");
            Employee.DisplayEmployees(empList.Where(e => e.DOJ < new DateTime(2015, 1, 1)));

            //2. Display a list of all the employee whose date of birth is after 1/1/1990
            Console.WriteLine("\nList of all employees whose date of birth is after 1/1/1990: ");
            Employee.DisplayEmployees(empList.Where(e => e.DOB > new DateTime(1990, 1, 1)));            

            //3. Display a list of all the employee whose designation is Consultant and Associate
            Console.WriteLine("\nList of employees whose designation is Consultant and Associate: ");
            Employee.DisplayEmployees(empList.Where(e => e.Title == "Consultant" || e.Title == "Associate"));

            //4. Display total number of employees
            Console.WriteLine("\nTotal number of employees: ");
            Console.WriteLine(empList.Count);

            //5. Display total number of employees belonging to “Chennai”
            Console.WriteLine("\nTotal number of employees belonging to Chennai: ");
            Console.WriteLine(empList.Count(e => e.City == "Chennai"));

            //6. Display highest employee id from the list
            Console.WriteLine("\nHighest employee id: ");
            Console.WriteLine(empList.Max(e => e.EmployeeID));

            //7. Display total number of employee who have joined after 1/1/2015
            Console.WriteLine("\nList of employees joined after 1/1/2015: ");
            Console.WriteLine(empList.Count(e => e.DOJ > new DateTime(2015, 1, 1)));

            //8. Display total number of employee whose designation is not “Associate”
            Console.WriteLine("\nTotal number of employees whose designation is not Associate: ");
            Console.WriteLine(empList.Count(e => e.Title != "Associate"));

            //9. Display total number of employee based on City
            Console.WriteLine("\nTotal number of employees based on city: ");
            var Employees_By_City = empList.GroupBy(e => e.City);
            foreach (var city in Employees_By_City)
            {
                Console.WriteLine($"{city.Key}: {city.Count()}");
            }

            //10. Display total number of employee based on city and title
            Console.WriteLine("\nTotal number of employees based on city and title: ");
            var EmployeesByCityAndTitle = empList.GroupBy(e => new { e.City, e.Title });
            foreach (var group in EmployeesByCityAndTitle)
            {
                Console.WriteLine($"{group.Key.City} - {group.Key.Title}: {group.Count()}");
            }

            //11. Display total number of employee who is youngest in the list
            Console.WriteLine("\nTotal number of employees who is youngest in the list: ");
            var youngest = empList.OrderByDescending(e => e.DOB).FirstOrDefault();
            Console.WriteLine($"{youngest.EmployeeID}   {youngest.FirstName}   {youngest.LastName}   {youngest.Title}   {youngest.DOB.ToShortDateString()}   {youngest.DOJ.ToShortDateString()}   {youngest.City}");

            Console.Read();
        }

        static List<Employee> GetEmployees() 
        { 
            return new List<Employee>
            {
                new Employee { EmployeeID = 1001, FirstName = "Malcolm", LastName = "Daruwalla", Title = "Manager", DOB = DateTime.Parse("16/11/1984"), DOJ = DateTime.Parse("8/6/2011"), City = "Mumbai" },
                new Employee { EmployeeID = 1002, FirstName = "Asdin", LastName = "Dhalla", Title = "AsstManager", DOB = DateTime.Parse("20/08/1984"), DOJ = DateTime.Parse("7/7/2012"), City = "Mumbai" },
                new Employee { EmployeeID = 1003, FirstName = "Madhavi", LastName = "Oza", Title = "Consultant", DOB = DateTime.Parse("14/11/1987"), DOJ = DateTime.Parse("12/4/2015"), City = "Pune" },
                new Employee { EmployeeID = 1004, FirstName = "Saba", LastName = "Shaikh", Title = "SE", DOB = DateTime.Parse("3/6/1990"), DOJ = DateTime.Parse("2/2/2016"), City = "Pune" },
                new Employee { EmployeeID = 1005, FirstName = "Nazia", LastName = "Shaikh", Title = "SE", DOB = DateTime.Parse("8/3/1991"), DOJ = DateTime.Parse("2/2/2016"), City = "Mumbai" },
                new Employee { EmployeeID = 1006, FirstName = "Amit", LastName = "Pathak", Title = "Consultant", DOB = DateTime.Parse("7/11/1989"), DOJ = DateTime.Parse("8/8/2014"), City = "Chennai" },
                new Employee { EmployeeID = 1007, FirstName = "Vijay", LastName = "Natrajan", Title = "Consultant", DOB = DateTime.Parse("2/12/1989"), DOJ = DateTime.Parse("1/6/2015"), City = "Mumbai" },
                new Employee { EmployeeID = 1008, FirstName = "Rahul", LastName = "Dubey", Title = "Associate", DOB = DateTime.Parse("11/11/1993"), DOJ = DateTime.Parse("6/11/2014"), City = "Chennai" },
                new Employee { EmployeeID = 1009, FirstName = "Suresh", LastName = "Mistry", Title = "Associate", DOB = DateTime.Parse("12/8/1992"), DOJ = DateTime.Parse("3/12/2014"), City = "Chennai" },
                new Employee { EmployeeID = 1010, FirstName = "Sumit", LastName = "Shah", Title = "Manager", DOB = DateTime.Parse("12/4/1991"), DOJ = DateTime.Parse("2/1/2016"), City = "Pune" }
            };            
        }
    }
}
