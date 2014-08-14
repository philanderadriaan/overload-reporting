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

            /*
            List<object[]> data = manager.getData();
            foreach (object[] values in data)
            {
                Console.WriteLine(string.Join(",", values));
            }
            */

            DataManager m2 = new DataManager();
            m2.read("staff.sql");
            List<object[]> staff = m2.getData();
            foreach (object[] i in staff)
            {
                Formatter f = new Formatter();
                string name = f.generateFileName(i);
                manager.write(name);
            }
        }
    }
}