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
            string query = "";
            foreach (string line in File.ReadLines("test.sql"))
            {
                query += line + "\n";
            }

            string connectionString = "Server=SKYWARDDATA; Integrated Security=True;";


            string output = "";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    output += reader["School"] + "," + reader["Section"] + '\n';
                }

                reader.Close();
            }

            string folder = "report\\" + DateTime.Now.Year + "\\" + DateTime.Now.Month;
            Directory.CreateDirectory(folder);
            File.WriteAllText(folder + "\\mike-smith.csv", output);
        }
    }
}