using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace WebApplication1.Controllers
{   
    public class Connection
    {       
        SqlConnection cx;
        public string host { get; set; }
        public string initCat { get; set; }
        public string user { get; set; }
        public string pass { get; set; }
        

        public Connection() 
        {
            cx = new SqlConnection();
            host = "localhost\\SQLEXPRESS";
            initCat = "osaxx";
            user = "SA";
            pass = "a1s2d3";
        }

        public Connection(string host, string initCat, string user, string pass)
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
            catch(Exception e)
            {
                
                return null;
            }
            
        }

        public void closeConnection()
        {
            cx.Close();
        }
   
    }
}