using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nksd_overload_reporting
{
    class Formatter
    {
        private string folder = "";

        public Formatter()
        {
            string path_file_name = "report-path.config";
            IEnumerable<string> lines = File.ReadLines(path_file_name);
            string[] line_array = lines.ToArray<string>();
            folder += line_array[0] + DateTime.Now.Year + "\\" + DateTime.Now.Month + "\\";
        }

        public string generateReportPath(string file_name)
        {
            Directory.CreateDirectory(folder);
            return folder + file_name;
        }

        public string generateFileName(string[] s)
        {
            string name = "";
            Boolean first = true;
            foreach (string i in s)
            {
                if (i.Length > 0)
                {
                    if (first)
                    {
                        first = false;
                    }
                    else
                    {
                        name += " " + i;
                    }
                }
            }
            name += ".csv";
            return name;
        }
    }
}
