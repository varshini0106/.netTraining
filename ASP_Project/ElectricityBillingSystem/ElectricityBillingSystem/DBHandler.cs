using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;

namespace ElectricityBillingSystem
{
    public class DBHandler
    {
        public SqlConnection GetConnection()
        {
            string cs = ConfigurationManager.ConnectionStrings["ElectricityBillDB"].ConnectionString;
            return new SqlConnection(cs);
        }
    }
}