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
            foreach (string line in File.ReadLines("sql-2000-query-1.sql"))
            {
                query_builder.Append(line);
                query_builder.Append('\n');
            }

            string folder = "reports\\" + DateTime.Now.Year + "\\" + DateTime.Now.Month;

            Directory.CreateDirectory(folder);
            File.WriteAllLines(folder + "\\mike-smith.csv", File.ReadLines("sql-2000-query-1.sql"));
        }
    }
}