using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using ScriptEngine.DataBase;
using ScriptEngine.TaskModel;

namespace ScriptEngine
{
    public class SingleEvaluator
    {
        private static SingleEvaluator instance = null;
        static List<BehaviorScript> scripts;
        int currentWindow;
        int aux;  // numero de ventanas que tienen que pasar antes de que se reinicien los scripts
        private SingleEvaluator(string studyCase) 
        {
            currentWindow = 0;
            aux = 1;
            scripts = new List<BehaviorScript>();
            DataBase.DBConnection cn = new DataBase.DBConnection(studyCase);
            DataBase.SQLManager sql = new DataBase.SQLManager(cn);
            string scriptName;
            SqlDataReader result = sql.readData("SCRIPTS", null, null);

            while (result.Read())
            {
                scriptName = result.GetString(1);
                scripts.Add(new BehaviorScript(studyCase, scriptName, true)); // true = uses frecuencies;
            }
            cn.closeConnection();
            resetActorAttributes();
        }
        
        public static SingleEvaluator GetInstance
        {
            get
            {
                if (instance == null) instance = new SingleEvaluator("AssaultCube");
                return instance;
            }
        }

        public bool eval(TaskModel.Task task)
        {
            registerTask(task);
            updateActorAttributes(task);
            foreach (BehaviorScript script in scripts)
            {
                if (script.pushTask(task))
                {
                    Console.WriteLine("{0} matches!! result executions: \n", script.scriptName);
                    foreach (string result in script.scriptResults)
                    {
                        Console.WriteLine("\t{0}", result);
                    }
                    //return true;
                }
            }
            return false;
        }

        public void resetActorAttributes()
        {
            DBConnection con = new DBConnection();
            SqlCommand cmd = new SqlCommand("ResetAllPlayers", con.getOpenedConnection());
            cmd.ExecuteNonQuery();
            con.closeConnection();
        }

        public void registerTask(TaskModel.Task tsk)
        {
            DBConnection con = new DBConnection();
            SqlCommand cmd = new SqlCommand("recordTask", con.getOpenedConnection());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@taskName", SqlDbType.VarChar).Value = tsk.taskName;
            cmd.Parameters.Add("@assignment", SqlDbType.VarChar).Value = tsk.assign;
            cmd.Parameters.Add("@involvement", SqlDbType.VarChar).Value = tsk.involve;
            cmd.Parameters.Add("@outcome", SqlDbType.VarChar).Value = tsk.outcome + "";
            cmd.Parameters.Add("@effective", SqlDbType.VarChar).Value = tsk.effective;
            cmd.Parameters.Add("@executor", SqlDbType.VarChar).Value = tsk.executorActor.instances[0];
            string recordTaskId = cmd.ExecuteScalar().ToString();
            con.closeConnection();
            if (tsk.assistanceObject != null)
            {
                cmd = new SqlCommand("recordAssistanceObject", con.getOpenedConnection());
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@objectname", SqlDbType.VarChar).Value = tsk.assistanceObject.instances[0];
                cmd.Parameters.Add("@recordTask", SqlDbType.VarChar).Value = recordTaskId + "";
                cmd.ExecuteNonQuery();
                con.closeConnection();
            }
            else
            {
                cmd = new SqlCommand("recordAssistanceObject", con.getOpenedConnection());
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@objectname", SqlDbType.VarChar).Value = DBNull.Value;
                cmd.Parameters.Add("@recordTask", SqlDbType.VarChar).Value = recordTaskId + "";
                cmd.ExecuteNonQuery();
                con.closeConnection();
            }
            if (tsk.affecttedActors != null)
            {
                foreach (ScriptEngine.TaskModel.Element actor in tsk.affecttedActors)
                {
                    foreach (string instance in actor.instances)
                    {
                        cmd = new SqlCommand("recordAffectedActor", con.getOpenedConnection());
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@actorname", SqlDbType.VarChar).Value = instance;
                        cmd.Parameters.Add("@recordTask", SqlDbType.VarChar).Value = recordTaskId + "";
                        cmd.ExecuteNonQuery();
                        con.closeConnection();
                    }
                }
            }
            else
            {
                cmd = new SqlCommand("recordAffectedActor", con.getOpenedConnection());
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@actorname", SqlDbType.VarChar).Value = DBNull.Value;
                cmd.Parameters.Add("@recordTask", SqlDbType.VarChar).Value = recordTaskId + "";
                cmd.ExecuteNonQuery();
                con.closeConnection();
            }

        }

        public void updateActorAttributes(TaskModel.Task tsk)
        {
            if (tsk.taskName != "captureFlag" && tsk.taskName != "die" && tsk.taskName != "kill") return;
            DBConnection con = new DBConnection();
            SqlCommand cmd = new SqlCommand("updatePlayerState", con.getOpenedConnection());
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@username", SqlDbType.VarChar).Value = tsk.executorActor.instances[0];
            if (tsk.taskName == "captureFlag")
            {
                cmd.Parameters.Add("@option", SqlDbType.Int).Value = 3;
            }
            else if (tsk.taskName == "die")
            {
                cmd.Parameters.Add("@option", SqlDbType.Int).Value = 2;
            }
            else if (tsk.taskName == "kill")
            {
                if (tsk.outcome == "[D,ED]") cmd.Parameters.Add("@option", SqlDbType.Int).Value = 0;
                if (tsk.outcome == "[D,TD]") cmd.Parameters.Add("@option", SqlDbType.Int).Value = 1;
                if (tsk.outcome == "[D,AD]") cmd.Parameters.Add("@option", SqlDbType.Int).Value = 2;
            }
            cmd.ExecuteNonQuery();
            con.closeConnection();
        }

        public string evalS(TaskModel.Task task)
        {
            string res="";
            registerTask(task);
            updateActorAttributes(task);
            foreach (BehaviorScript script in scripts)
            {
                res += script.pushTaskS(task) + '\n';
            }
            return res;
        }

        public string evalWithResetS(TaskModel.Task task, int window)
        {

            resetScripts(window);
            string res = "";
            registerTask(task);
            updateActorAttributes(task);
            foreach (BehaviorScript script in scripts)
            {
                res += script.pushTaskS(task) + '\n';
            }
            return res;
        }

        private void resetScripts(int window)
        {
            if (window != currentWindow)
            {
                if (aux == 3) // numero de ventanas para reiniciar contadores
                {
                    foreach (BehaviorScript script in scripts)
                    {
                        script.restartFrecuencies();
                    }
                    aux = 1;
                }
                currentWindow = window;
                aux++;
            }
        }
    }
}
