using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
                File.WriteAllText(folder + "\\" + Regex.Replace(reader["firstname"].ToString(), "[^a-zA-Z0-9]+", " ") + " " + Regex.Replace(reader["lastname"].ToString(), "[^a-zA-Z0-9]+", " ") + ".csv", output);
            }

            connection.Close();
            reader.Close();
        }
    }
}