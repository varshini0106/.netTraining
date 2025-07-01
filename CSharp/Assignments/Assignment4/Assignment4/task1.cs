//Scenario: Employee Management System(Console - Based)
//---------------------------------------------------- -
//You are tasked with developing a simple console-based Employee Management System using C# that allows users to manage a list of employees. Use a menu-driven approach to perform CRUD operations on a List<Employee>.

//Each Employee has the following properties:

//int Id

//string Name

//string Department

//double Salary
// Functional Requirements
//Design a menu that repeatedly prompts the user to choose one of the following actions:


//===== Employee Management Menu =====
//1. Add New Employee
//2. View All Employees
//3. Search Employee by ID
//4. Update Employee Details
//5. Delete Employee
//6. Exit
//====================================
//Enter your choice:

// Task:
//Write a C# program using:

//A class Employee with the above properties.

//A List<Employee> to hold all employee records.

//A menu-based loop to allow the user to perform the following:

//✅ Expected Functionalities (CRUD)

//1.Prompt the user to enter details for a new employee and add it to the list.


//2.Display all employees 

//3.Allow searching an employee by Id and display their details.

//4.Search for an employee by Id, and if found, allow the user to update name, department, or salary.

//5.Search for an employee by Id and remove the employee from the list.

//6.Cleanly exit the program.

//Use Exception handling Mechanism


using System;
using System.Collections.Generic;

namespace Assignment4
{
    // Employee class with properties
    class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Department { get; set; }
        public double Salary { get; set; }
    }

    class task1
    {
        // List to store employee records
        static List<Employee> employeeList = new List<Employee>();

        static void Main(string[] args)
        {
            while (true) // Loop until the user chooses to exit
            {
                // Display menu options
                Console.WriteLine("\nEmployee Management Menu");
                Console.WriteLine("1. Add New Employee");
                Console.WriteLine("2. View All Employees");
                Console.WriteLine("3. Search Employee by ID");
                Console.WriteLine("4. Update Employee Details");
                Console.WriteLine("5. Delete Employee");
                Console.WriteLine("6. Exit");
                Console.Write("Enter your choice: ");

                try
                {
                    int choice = int.Parse(Console.ReadLine()); // Read user choice

                    switch (choice)
                    {
                        case 1:
                            AddEmployee();
                            break;
                        case 2:
                            ViewAllEmployees();
                            break;
                        case 3:
                            SearchEmployee();
                            break;
                        case 4:
                            UpdateEmployee();
                            break;
                        case 5:
                            DeleteEmployee();
                            break;
                        case 6:
                            Console.WriteLine("Exiting the program. Goodbye!");
                            return; // Exit the program
                        default:
                            Console.WriteLine("Invalid choice. Please select from 1 to 6.");
                            break;
                    }
                }
                catch (FormatException) // Handle invalid input type
                {
                    Console.WriteLine("Invalid input! Please enter a valid number.");
                }
            }
        }

        // Method to add a new employee
        static void AddEmployee()
        {
            try
            {
                Employee emp = new Employee(); // Create new employee object

                Console.Write("Enter Employee ID: ");
                emp.Id = int.Parse(Console.ReadLine());

                Console.Write("Enter Name: ");
                emp.Name = Console.ReadLine();

                Console.Write("Enter Department: ");
                emp.Department = Console.ReadLine();

                Console.Write("Enter Salary: ");
                emp.Salary = double.Parse(Console.ReadLine());

                employeeList.Add(emp); // Add employee to the list
                Console.WriteLine("Employee added successfully!");
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid data format! Please enter correct types.");
            }
        }

        // Method to display all employees
        static void ViewAllEmployees()
        {
            if (employeeList.Count == 0)
            {
                Console.WriteLine("No employees to display.");
                return;
            }

            Console.WriteLine("\nEmployee List:");
            foreach (Employee emp in employeeList)
            {
                Console.WriteLine($"ID: {emp.Id}, Name: {emp.Name}, Department: {emp.Department}, Salary: {emp.Salary}");
            }
        }

        // Method to search for an employee by ID
        static void SearchEmployee()
        {
            try
            {
                Console.Write("Enter Employee ID to search: ");
                int id = int.Parse(Console.ReadLine());

                Employee emp = employeeList.Find(e => e.Id == id); // Find employee by ID

                if (emp != null)
                {
                    Console.WriteLine($"ID: {emp.Id}, Name: {emp.Name}, Department: {emp.Department}, Salary: {emp.Salary}");
                }
                else
                {
                    Console.WriteLine("Employee not found.");
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid ID format!");
            }
        }

        // Method to update employee details
        static void UpdateEmployee()
        {
            try
            {
                Console.Write("Enter Employee ID to update: ");
                int id = int.Parse(Console.ReadLine());

                Employee emp = employeeList.Find(e => e.Id == id);

                if (emp != null)
                {
                    Console.Write("Enter new Name (leave blank to keep current): ");
                    string name = Console.ReadLine();
                    if (!string.IsNullOrWhiteSpace(name)) emp.Name = name;

                    Console.Write("Enter new Department (leave blank to keep current): ");
                    string dept = Console.ReadLine();
                    if (!string.IsNullOrWhiteSpace(dept)) emp.Department = dept;

                    Console.Write("Enter new Salary (leave blank to keep current): ");
                    string salaryInput = Console.ReadLine();
                    if (!string.IsNullOrWhiteSpace(salaryInput))
                    {
                        emp.Salary = double.Parse(salaryInput);
                    }

                    Console.WriteLine("Employee updated successfully.");
                }
                else
                {
                    Console.WriteLine("Employee not found.");
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid input format.");
            }
        }

        // Method to delete an employee by ID
        static void DeleteEmployee()
        {
            try
            {
                Console.Write("Enter Employee ID to delete: ");
                int id = int.Parse(Console.ReadLine());

                Employee emp = employeeList.Find(e => e.Id == id);

                if (emp != null)
                {
                    employeeList.Remove(emp); // Remove employee from the list
                    Console.WriteLine("Employee deleted successfully.");
                }
                else
                {
                    Console.WriteLine("Employee not found.");
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid ID format!");
            }
        }
    }
}
