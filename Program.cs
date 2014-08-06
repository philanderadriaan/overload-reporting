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

            string output = "";
            SqlConnection connection = new SqlConnection("server = skywarddata; integrated security = true;");
            connection.Open();
            SqlDataReader reader = new SqlCommand(query, connection).ExecuteReader();

            string folder = "report\\" + DateTime.Now.Year + "\\" + DateTime.Now.Month;
            Directory.CreateDirectory(folder);

            while (reader.Read())
            {
                if (!reader["firstname"].ToString().Contains('/') && !reader["lastname"].ToString().Contains('/'))
                {
                    //output += reader["School"] + "," + reader["Section"] + '\n';
                    File.WriteAllText(folder + "\\" + reader["FirstName"] + " " + reader["LastName"] + ".csv", output);
                    Console.WriteLine(folder + "\\" + reader["FirstName"] + " " + reader["LastName"] + ".csv");
                }
            }
            connection.Close();
            reader.Close();
        }
    }
}