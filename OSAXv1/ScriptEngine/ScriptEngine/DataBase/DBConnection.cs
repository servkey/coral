using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace ScriptEngine.DataBase
{
    public class DBConnection
    {
        SqlConnection cx;
        public string host { get; set; }
        public string initCat { get; set; }
        public string user { get; set; }
        public string pass { get; set; }


        public DBConnection()
        {
            cx = new SqlConnection();
            host = "localhost\\SQLEXPRESS";
            initCat = "AssaultCube";
            user = "SA";
            pass = "a1s2d3";
        }

        public DBConnection(string initCat)
        {
            cx = new SqlConnection();
            host = "localhost\\SQLEXPRESS";
            this.initCat = initCat;
            user = "SA";
            pass = "a1s2d3";
        }

        public DBConnection(string host, string initCat, string user, string pass)
        {
            cx = new SqlConnection();
            this.host = host;
            this.initCat = initCat;
            this.user = user;
            this.pass = pass;
        }

        public SqlConnection getOpenedConnection()
        {
            try
            {
                cx.ConnectionString = "Data Source=" + host + ";Initial Catalog=" + initCat + ";User ID=" + user + ";Password=" + pass;
                cx.Open();
                return cx;
            }
            catch (Exception e)
            {
                Console.WriteLine("DB Message: {0}", e);
                return null;
            }

        }

        public void closeConnection()
        {
            cx.Close();
        }
    }
}
