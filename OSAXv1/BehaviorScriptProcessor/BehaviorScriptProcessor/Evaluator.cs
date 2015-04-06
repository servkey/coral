using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace BehaviorScriptProcessor
{
    class Evaluator
    {
        List<BehaviorScript> scripts;

        public Evaluator(string studyCase)
        {
            scripts = new List<BehaviorScript>();
            DataBase.DBConnection cn = new DataBase.DBConnection(studyCase);
            DataBase.SQLManager sql = new DataBase.SQLManager(cn);
            string scriptName;
            SqlDataReader result = sql.readData("SCRIPTS", null, null);
            
            while(result.Read())
            {
                scriptName = result.GetString(1);
                scripts.Add(new BehaviorScript(studyCase, scriptName, false));
            }
            cn.closeConnection();
        }

        public bool eval(string task)
        {
            foreach (BehaviorScript script in scripts)
            {
                if (script.pushTask(task))
                {
                    Console.WriteLine("{0} matches!! result executions: \n", script.scriptName);
                    foreach (string result in script.results)
                    {
                        Console.WriteLine("\t{0}",result);
                    }
                    return true;
                }
            }
            return false;
        }
    }
}
