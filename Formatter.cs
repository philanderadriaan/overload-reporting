using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nksd_overload_reporting
{
    class Formatter
    {
        private string my_folder = "";

        public Formatter()
        {
            string path_file_name = "report-path.txt";
            IEnumerable<string> lines = File.ReadLines(path_file_name);
            foreach (string line in lines)
            {
                my_folder += line;
            }
        }

        public string generateReportPath(string file_name)
        {
            return my_folder + file_name + ".csv";
        }
    }


}
