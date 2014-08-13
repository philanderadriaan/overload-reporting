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
    class DataManager
    {
        List<object[]> data = new List<object[]>();

        public DataManager()
        {

        }

        public void read(string query_file)
        {
            string query = "";
            string query_path = "sql-query\\" + query_file;
            IEnumerable<string> lines = File.ReadLines(query_path);
            foreach (string line in lines)
            {
                query += line + "\n";
            }
            string server_info = "server = skywarddata; integrated security = true;";
            SqlConnection connection = new SqlConnection(server_info);
            connection.Open();
            SqlCommand command = new SqlCommand(query, connection);
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                int column_count = reader.FieldCount;
                object[] values = new object[column_count];
                reader.GetValues(values);
                data.Add(values);
            }

            connection.Close();
            reader.Close();
        }

        public void write(string output_file)
        {
            string output_path = "";
            IEnumerable<string> lines = File.ReadLines("report-path.config");
            foreach (string line in lines)
            {
                output_path += line;
            }
            Directory.CreateDirectory(output_path);
            output_path += output_file;

            string output = "";
            foreach (object[] values in data)
            {
                string row = string.Join(",", values);
                output += row;
                output += "\n";
            }


            Console.WriteLine(output);
            Console.WriteLine(output_path);

            File.WriteAllText(output_path, output);
        }
    }
}