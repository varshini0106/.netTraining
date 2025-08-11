using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.SqlClient;

namespace RailwayReservationSystem
{
    public static class DbConnection
    {
        private static string connectionString = "Data Source = ICS-LT-CGQZC64\\SQLEXPRESS; Initial Catalog = RailwayDB; user id = sa; password = Karthikavarshini2004;";

        public static SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }
    }
}