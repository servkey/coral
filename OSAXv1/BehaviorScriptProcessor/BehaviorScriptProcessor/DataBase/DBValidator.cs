using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace DataBase
{
    class DBValidator
    {        
        private int domainID;
        private string database;
        private DBConnection conn;
        private SQLManager sql;
        private string query;

        public DBValidator(int domain_id)
        {
            domainID = domain_id;
            conn = new DBConnection();
            sql = new SQLManager(conn);
            query = "";
        }

        public DBValidator(string database)
        {
            this.database = database;
            conn = new DBConnection(database);
            sql = new SQLManager(conn);
            query = "";
        }

        public bool validateMeta(string meta)
        {
            meta = meta.ToLower();
            if (meta == "actor" 
                || meta == "object" 
                || meta == "category" 
                || meta == "role" 
                || meta == "activity" 
                || meta == "task" 
                || meta == "objective"
                || meta == "goal"
                || meta == "team") return true;
            return false;
        }
        
        public bool validateModel(string meta, string  model)
        {
            if (!validateMeta(meta)) return false;
            query = "SELECT t.name FROM sys.tables AS t WHERE (t.name LIKE '%" + model + "%')";
            //String.Format(query, meta, model);
            System.Console.WriteLine(query);
            return check();
        }
                
        public bool validateInstances(string meta, string model, LinkedList<string> instances)
        {
            if (!validateMeta(meta)) return false;
            query = "SELECT name FROM " + model + " WHERE (";
            foreach (string instance in instances) query += "name = " + instance + ") AND (";
            query = query.Remove(query.Length - 7);
            //String.Format(query, task);
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
    }
}
