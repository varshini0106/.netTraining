//1.Write a stored Procedure that inserts records in the Employee_Details table
 
//The procedure should generate the EmpId automatically to insert and should return the generated value to the user
 
//Also the Salary Column is a calculated column (Salary is givenSalary - 10%)
 
//Table: Employee_Details(Empid, Name, Salary, Gender)
//Hint(User should not give the EmpId)


//Test the Procedure using ADO classes and show the generated Empid and Salary

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace Code_Challenge_1
{
    class question1
    {
        static void Main(string[] args)
        {

            string connect = "Data Source = ICS-LT-CGQZC64\\SQLEXPRESS; Initial Catalog = AssignmentDB; user id = sa; password = Karthikavarshini2004;";

            using (SqlConnection conn = new SqlConnection(connect))
            {
                SqlCommand cmd = new SqlCommand("InsertEmployeeDetails", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Name", "Arun");
                cmd.Parameters.AddWithValue("@Salary", 25000);
                cmd.Parameters.AddWithValue("@Gender", "Male");


                SqlParameter id = new SqlParameter("@EmpId", SqlDbType.Int)
                {
                    Direction = ParameterDirection.Output
                };
                cmd.Parameters.Add(id);

                SqlParameter netSal = new SqlParameter("@NetSalary", SqlDbType.Decimal)
                {
                    Direction = ParameterDirection.Output
                };

                cmd.Parameters.Add(netSal);

                conn.Open();
                cmd.ExecuteNonQuery();

                int gen_id = (int)cmd.Parameters["@EmpId"].Value;                
                decimal gen_sal = (decimal)cmd.Parameters["@NetSalary"].Value;


                Console.WriteLine("The generated values are: ");
                Console.WriteLine($"Generated EmpId: {gen_id}");                
                Console.WriteLine($"Net Salary after 10% deduction: {gen_sal}");
                Console.Read();
            }
        }
    }
}
