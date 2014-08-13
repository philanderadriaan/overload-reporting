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
        private string folder = "";

        public Formatter()
        {
            string path_file_name = "report-path.config";
            IEnumerable<string> lines = File.ReadLines(path_file_name);
            foreach (string line in lines)
            {
                folder += line;
            }
            folder += "report\\" + DateTime.Now.Year + "\\" + DateTime.Now.Month + "\\";
        }

        public string generateReportPath(string file_name)
        {
            Directory.CreateDirectory(folder);
            return folder + file_name;
        }
    }


}
