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
    class Skyward
    {
        List<object[]> data = new List<object[]>();

        public Skyward()
        {

        }

        public void read(string query_file)
        {
            string query = "";
            IEnumerable<string> lines = File.ReadLines(query_file);
            foreach (string line in lines)
            {
                query += line + "\n";
            }
            string server_info = "server = skywarddata; integrated security = true;";
            SqlConnection connection = new SqlConnection(server_info);
            connection.Open();
            SqlCommand command = new SqlCommand(query, connection);
            SqlDataReader reader = command.ExecuteReader();

            string output = "";
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

        }
    }
}
