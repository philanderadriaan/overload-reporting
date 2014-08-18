using System;
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
            /*
            DataManager manager = new DataManager();
            manager.read("test.sql");

            DataManager m2 = new DataManager();
            m2.read("staff.sql");
            List<object[]> staff = m2.getData();
            foreach (object[] i in staff)
            {
                Formatter f = new Formatter();
                string name = f.generateFileName(i);
                manager.write(name);
            }
             * */

            Retrieve();
        }


        private static void Retrieve()
        {
            string con = "DRIVER={MySQL ODBC 3.51 Driver};" +
            "SERVER=skywarddata;" +
            "DATABASE=nkitsas;" +
            "UID=roODBCUser01;" +
            "PASSWORD=Pupl3P1aneD0wn;" +
            "OPTION=0";

            OdbcConnection Conn = new System.Data.Odbc.OdbcConnection(con);

            //OdbcCommand catCMD = new OdbcCommand("SELECT * FROM [Enter table name here]", Conn);

            Conn.Open();

            //OdbcDataReader myReader = catCMD.ExecuteReader();

            //while (myReader.Read())
            {
                //the SqlDataReader returns typed data.  You must use the
                //proper get method for the type you are retrieving.
                //(GetInt32, GetString, GetBoolean etc.)
                //Response.Write(myReader.GetString(myReader.GetOrdinal("[Enter column name here]")));
                //Response.Write("<BR>");
            }

            //myReader.Close();
            //Conn.Close();
        }
    }
}