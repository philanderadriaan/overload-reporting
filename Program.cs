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

            List<object[]> data = manager.getData();
            foreach (object[] values in data)
            {
                Console.WriteLine(string.Join(",", values));
            }

            manager.write("Mike Smith.csv");
        }
    }
}