﻿using System;
using System.Collections.Generic;
using System.Data.Odbc;
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

            DataManager m2 = new DataManager();
            m2.read("staff.sql");
            List<object[]> staff = m2.getData();
            foreach (object[] i in staff)
            {
                Formatter f = new Formatter();
                string name = i[0].ToString();
                name += ".csv";
                manager.write(name);
            }
        }
    }
}