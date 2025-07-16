using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code_Challenge_1
{

    class Employee
    {
        public int EmployeeID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Title { get; set; }
        public DateTime DOB { get; set; }
        public DateTime DOJ { get; set; }
        public string City { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<Employee> emplist = new List<Employee>();
            Console.WriteLine("Enter count of employees");
            int count = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < count; i++)
            {
                Console.WriteLine($"Enter details for Employee {i + 1}:");
                Console.WriteLine("Employee ID: ");
                int EmpID = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Enter First Name: ");
                string fname = Console.ReadLine();
                Console.WriteLine("Enter Last Name: ");
                string lname = Console.ReadLine();
                Console.WriteLine("Enter title: ");
                string title = Console.ReadLine();
                Console.WriteLine("Enter DOB: ");
                DateTime dob = Convert.ToDateTime(Console.ReadLine());
                Console.WriteLine("Enter DOJ: ");
                DateTime doj = Convert.ToDateTime(Console.ReadLine());
                Console.WriteLine("Enter City: ");
                string city = Console.ReadLine();

                emplist.Add(new Employee
                {
                    EmployeeID = EmpID,
                    FirstName = fname,
                    LastName = lname,
                    Title = title,
                    DOB = dob,
                    DOJ = doj,
                    City = city
                });
            }
            //a. Details of all employees
            show(emplist);

            //b.Display details of all employees whose location is not mumbai
            Console.WriteLine("List of people not in Mumbai");
            var emplist2 = (from e in emplist
                            where e.City != "Mumbai"
                            select e).ToList();
            show(emplist2);

            //c.Display details of all the employee whose title is AsstManager
            Console.WriteLine("List of people whose title is asstmanager");
            var emplist3 = (from e in emplist
                            where e.Title == "AsstManager"
                            select e).ToList();
            show(emplist3);


            //d.Display details of all the employee whose Last Name start with S
            var emplist4 = emplist.Where(e => e.LastName.StartsWith("S")).ToList();
            show(emplist4);

            Console.Read();
        }


        static void show(List<Employee> employeelist)
        {
            foreach (var e in employeelist)
            {
                Console.WriteLine($"{e.EmployeeID}, {e.FirstName} {e.LastName}, {e.Title}, DOB: {e.DOB}, DOJ: {e.DOJ}, City: {e.City}");
            }
        }

    }
}