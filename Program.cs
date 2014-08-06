using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nksd_overload_reporting
{
    class Program
    {
        static void Main(string[] args)
        {
            StringBuilder query_builder = new StringBuilder();
            foreach (string line in File.ReadLines("test.sql"))
            {
                query_builder.Append(line);
                query_builder.Append('\n');
            }

            string queryString = query_builder.ToString();
            string connectionString = "Server=SKYWARDDATA; Integrated Security=True;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(queryString, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                try
                {
                    while (reader.Read())
                    {
                        Console.WriteLine(String.Format("{0}, {1}",
                        reader["School"], reader["Section"]));// etc
                    }
                }
                finally
                {
                    // Always call Close when done reading.
                    reader.Close();
                }
            }

            string folder = "reports\\" + DateTime.Now.Year + "\\" + DateTime.Now.Month;
            Directory.CreateDirectory(folder);
            File.WriteAllLines(folder + "\\mike-smith.csv", File.ReadLines("sql-2000-query-1.sql"));
        }
    }
}