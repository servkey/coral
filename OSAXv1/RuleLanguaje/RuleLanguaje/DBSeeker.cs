using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace RuleLanguaje
{
    class DBSeeker
    {        
        private int domainID;
        private string database;
        private DBConnection conn;
        private SQLManager sql;
        private string query;

        public DBSeeker(int domain_id)
        {
            domainID = domain_id;
            conn = new DBConnection();
            sql = new SQLManager(conn);
            query = "";
        }

        public DBSeeker(string database)
        {
            this.database = database;
            conn = new DBConnection(database);
            sql = new SQLManager(conn);
            query = "";
        }
        
        public bool validateActor(string actor)
        {
            query = "SELECT t.name FROM sys.tables AS t WHERE (t.name LIKE '%Actor_"+actor+"%')";
            String.Format(query,actor);
            System.Console.WriteLine(query);
            return check();
        }
        
        public bool validateObject(string obj)
        {
            query = "SELECT t.name FROM sys.tables AS t WHERE (t.name LIKE '%Object_"+obj+"%')";
            String.Format(query, obj);
            System.Console.WriteLine(query);
            return check();
        }
                
        public bool validateTask(string task)
        {
            query = "SELECT name FROM Tasks WHERE (name = '"+task+"')";
            String.Format(query, task);
            System.Console.WriteLine(query);
            return check();
        }
        
        public bool validateExpression(string element, string attribute)
        {
            query = "SELECT t.name AS table_name, SCHEMA_NAME(schema_id) AS schema_name, c.name AS column_name FROM sys.tables AS t INNER JOIN sys.columns c ON t.OBJECT_ID = c.OBJECT_ID WHERE (c.name LIKE '%"+attribute+"%') AND (t.name LIKE '%"+element+"%')";
            String.Format(query, attribute, element);
            System.Console.WriteLine(query);
            return check();            
        }

        private bool check()
        {
            SqlDataReader data = sql.readData(query);
            if (!data.HasRows)
            {
                conn.closeConnection();
                return false;                
            }
            conn.closeConnection();
            return true;
        }

        /* DISMISS
        //check whether an objective is in the domain model
        public bool validateObjective(string objv)
        {
            return true;
        }
        
         * DISMISS
        //check whether a role is in the domain model
        public bool validateRole(string rol)
        {
            return true;
        }
        
         * DISMISS
        //check whether a goal is in the domain model
        public bool validateGoal(string goal)
        {
            return true;
        }
        
         * DISMISS
        //check whether a commmunity is in the domain model
        public bool validateCommunity(string comm)
        {
            return true;
        }
         
         * DISMISS
        //check whether an interaction is in the domain model
        public bool validateInteraction(string inter)
        {
            return true;
        }
        
         * DISMISS
        //check whether an activity is in the domain model
        public bool validateActivity(string activ)
        {
            return true;
        }
        */
    }
}
