using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nksd_overload_reporting
{
    class Formatter
    {
        private string my_folder;

        public Formatter()
        {

        }

        public string generateReportPath(string name)
        {
            return my_folder + name + ".csv";
        }
    }


}
