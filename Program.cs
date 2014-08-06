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
            Console.WriteLine("test");
            IEnumerable<string> e = File.ReadLines("sql-2000-query-1");
        }
    }
}