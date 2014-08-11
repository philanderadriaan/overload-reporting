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
            DataManager manager = new DataManager();
            manager.read("test.sql");
            manager.write("mike smith");

            /*
            string query = "";

            string file_name = "sql-query\\test.sql";
            IEnumerable<string> lines = File.ReadLines(file_name);

            foreach (string line in lines)
            {
                query += line + "\n";
            }

            string server_info = "server = skywarddata; integrated security = true;";
            SqlConnection connection = new SqlConnection(server_info);
            connection.Open();
            SqlCommand command = new SqlCommand(query, connection);
            SqlDataReader reader = command.ExecuteReader();

            string folder_name = "report\\" + DateTime.Now.Year + "\\" + DateTime.Now.Month;
            Directory.CreateDirectory(folder_name);

            string output = "";

            while (reader.Read())
            {
                int column_count = reader.FieldCount;
                object[] values = new object[column_count];
                reader.GetValues(values);
                string row = string.Join(", ", values);
                output += row + "\n";

                string first = Regex.Replace(reader["firstname"].ToString(), "[^a-zA-Z0-9]+", " ");
                string last = Regex.Replace(reader["lastname"].ToString(), "[^a-zA-Z0-9]+", " ");
                string path = folder_name + "\\" + first + " " + last + ".csv"; 
                File.WriteAllText(path, output);
            }

            connection.Close();
            reader.Close();
             * */
        }
    }
}