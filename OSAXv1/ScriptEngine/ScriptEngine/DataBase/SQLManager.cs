using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace ScriptEngine.DataBase
{
    public class SQLManager
    {
        DBConnection cn;

        public SQLManager(DBConnection cn)
        {
            this.cn = cn;
        }

        public SqlDataReader readData(string query)
        {
            SqlCommand sql = new SqlCommand(query, cn.getOpenedConnection());
            SqlDataReader res = sql.ExecuteReader();
            return res;
        }

        public SqlDataReader readData(string table, string[] fields, Dictionary<string, string> conditions)
        {
            string query = "select ";
            if (fields == null)
                query += "* from " + table;
            else
            {
                query += "(";
                foreach (string field in fields)
                    query += field + ",";
                query = query.Remove(query.Length - 2);
                query += ") from " + table;
            }
            if (conditions != null)
            {
                query += " where ";
                string and;
                if (conditions.Count > 1) and = "and "; else and = "";
                foreach (KeyValuePair<string, string> cond in conditions)
                    query += cond.Key + "='" + cond.Value + "' " + and;
            }

            SqlCommand sql = new SqlCommand(query, cn.getOpenedConnection());
            SqlDataReader res = sql.ExecuteReader();
            return res;
        }

        public bool addRecord(string table, Dictionary<string, string> fieldValue)
        {
            string query = "insert into " + table + "(";
            string fields = "", values = "";
            bool res = false;
            foreach (KeyValuePair<string, string> pair in fieldValue)
            {
                fields += pair.Key + ",";
                values += "'" + pair.Value + "',";
            }
            fields = fields.Remove(fields.Length - 1);
            values = values.Remove(values.Length - 1);
            query += fields + ") values(" + values + ")";
            SqlCommand cm = new SqlCommand(query, cn.getOpenedConnection());
            if (cm.ExecuteNonQuery() > 0) res = true;
            cn.closeConnection();
            return res;
        }
    }
}
