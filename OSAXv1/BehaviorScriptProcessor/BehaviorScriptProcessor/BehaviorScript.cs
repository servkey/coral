using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using DataBase;
namespace BehaviorScriptProcessor
{
    class BehaviorScript
    {
        private struct elemData
        {
            public string meta { get; set; }
            public string model { get; set; }
            public List<string> instances { get; set; }
        }

        private struct comparisonData
        {
            public elemData instance { get; set; }
            public string op { get; set; }
            public string attribute { get; set; }
            public string value { get; set; }
        }

        private struct pertenenceData
        {
            public elemData subelement { get; set; }
            public elemData superelement { get; set; }
            public char op { get; set; }
        }

        private struct taskData
        {
            public string def { get; set; }
            public string name { get; set; }
            public elemData assistanceObject { get; set; }
            public elemData actor { get; set; }
            public bool hasAtt { get; set; }
            public string attribute { get; set; }
            public string value { get; set; }
            public char op { get; set; }
            public int frecuency { get; set; }
            public Dictionary<string, int> usersFrecuecnies { get; set; }
            public bool hasPert { get; set; }
            public pertenenceData pert { get; set; }
        }

        List<taskData> tasks; //tasks and frecuencies
        public List<string> results; // results if script accomplishes
        //constraints
        List<string> comparisons;
        List<string> pertenences;
        string studyCase;
        public string scriptName;

        public BehaviorScript(string studyCase, string scriptName, bool usesFrecs)
        {
            this.studyCase = studyCase;
            this.scriptName = scriptName;
            recoverRules(usesFrecs);
            Console.Write("ok");
        }
        
        public bool pushTask(string task)
        {
            task = task.ToUpper();
            taskData recievedTask = getTaskData(task, 0);
            string elem = task.Substring(0,task.IndexOf("-TASK")-1);
            elemData ed  = getElemData(elem);
            foreach(taskData td in tasks)
            {
                if (td.name == recievedTask.name)
                {
                    if (!td.hasPert)
                    {
                        foreach (string ac in recievedTask.actor.instances)
                        {
                            if (td.usersFrecuecnies.ContainsKey(ac))
                            {
                                td.usersFrecuecnies[ac]++;
                            }
                            else
                            {
                                td.usersFrecuecnies[ac] = 1;
                            }
                        }
                    }
                    else
                    {
                        pertenenceData pd = new pertenenceData();
                        pd.subelement = td.pert.subelement;
                        pd.op = td.pert.op;
                        pd.superelement = recievedTask.actor;
                        if (validateConstraint(pd))
                        {
                            foreach (string ac in recievedTask.actor.instances)
                            {
                                if (td.usersFrecuecnies.ContainsKey(ac))
                                {
                                    td.usersFrecuecnies[ac]++;
                                }
                                else
                                {
                                    td.usersFrecuecnies[ac] = 1;
                                }
                            }
                        }
                    }
                }
            }

            showUsersFrecs();
            return scriptAccomplished();
        }

        private bool scriptAccomplished()
        {//redefine look for who
            /*foreach (KeyValuePair<string, int> kvp in tasks)
            {
                if (tasks[kvp.Key] > 0) return false;
            }*/
            return false; // constraintsMatch();
        }

        private bool constraintsMatch()
        {
            comparisonData cd;
            pertenenceData pd;
            foreach (string c in comparisons)
            {
                cd = getCompData(c);
                if (!validateConstraint(cd)) return false;
            }
            foreach (string p in pertenences)
            {
                pd = getPertData(p);
                if (!validateConstraint(pd)) return false;
            }
            return true;
        }

        private void recoverRules(bool usesFrecuencies)
        {
            tasks = new List<taskData>();
            comparisons = new List<string>();
            pertenences = new List<string>();
            results = new List<string>();

            DBConnection cn = new DBConnection(studyCase);
            SQLManager sql = new SQLManager(cn);
            SqlDataReader sqlRes = sql.readData
                (
                "SELECT c.definition,c.frecuency,c.res FROM SCRIPT_HAS_RULES a "
                + "inner join SCRIPTS b ON a.script_id=b.script_id "
                + "inner join RULES c ON a.rule_id=c.rule_id "
                + "WHERE b.name = '"+scriptName+"'"
                );

            int frecuency;
            char isResult;
            string rule;

            while(sqlRes.Read())
            {
                rule = sqlRes.GetString(0);
                frecuency = sqlRes.GetInt32(1);
                isResult = sqlRes.GetString(2)[0];

                if (isResult == 'y') results.Add(rule.ToUpper());
                else if (frecuency != -1)
                {
                    if (!usesFrecuencies) frecuency = 1;
                    tasks.Add(getTaskData(rule.ToUpper(), frecuency));
                }
                else if (rule.Contains('.')) comparisons.Add(rule.ToUpper());
                else pertenences.Add(rule);
            }
            cn.closeConnection();
        }

        private comparisonData getCompData(string rule)
        {
            comparisonData compData = new comparisonData();
            string elem = "", attr = "", value = "";
            int c = 0;
            char op;
            while (rule[c] != '.') elem += rule[c++];
            c++;
            while (rule[c] != '=' && rule[c] != '¬' && rule[c] != '<' && rule[c] != '>') attr += rule[c++];
            op = rule[c++];
            while (c < rule.Length) value += rule[c++];
            compData.attribute = attr;
            compData.instance = getElemData(elem);
            if (op == '¬') compData.op = "<>"; else compData.op = "" + op;
            compData.value = value;
            return compData;
        }

        private pertenenceData getPertData(string rule)
        {
            pertenenceData perData = new pertenenceData();
            string super = "", sub = "";
            int c = 1;
            char ope;
            while (rule[c] != '-' && rule[c] != '~') super += rule[c++];
            ope = rule[c++];
            c++;
            while (c < rule.Length - 1) sub += rule[c++];
            perData.subelement = getElemData(sub);
            perData.superelement = getElemData(super);
            perData.op = ope;
            return perData;
        }

        private taskData getTaskData(string rule, int frec)
        {
            rule = rule.ToUpper();

            taskData td = new taskData();
            td.def = rule;
            td.name = "";
            td.assistanceObject = new elemData();
            td.actor = new elemData();
            td.attribute = "";
            td.op = ' ';
            td.value = "";
            td.frecuency = frec;
            td.pert = new pertenenceData();

            int i = rule.IndexOf("-TASK");

            if (rule[0] == '[')
            {
                td.hasPert = true;
                td.pert = getPertData(rule.Substring(0, rule.IndexOf(']') + 1));
            }
            else
            {
                td.actor = getElemData(rule.Substring(0, i));
            }
            
            i += 6;
            while (rule[i] != ',' && rule[i] != ')') td.name += rule[i++];
            if (rule[i] == ',')
            {
                i++;
                string obj = "";
                while (rule[i] != ')') obj += rule[i++];
                td.assistanceObject = getElemData(obj);
            }
            i++;
            if (i < rule.Length)
            {
                while (rule[i] != '=' && rule[i] != '¬' && rule[i] != '<' && rule[i] != '>') td.attribute += rule[i++];
                td.op = rule[i++];
                while (i < rule.Length) td.value += rule[i++];
            }
            td.usersFrecuecnies = new Dictionary<string, int>();
            return td;
        }

        private bool validateConstraint(object constraintData)
        {
            bool res = false;
            string query = "SELECT * FROM {0} INNER JOIN {1} ON {0}.{0}_id={1}.{0}_id WHERE ({1}.{2}{3}'{4}')";
            DBConnection cn = new DBConnection(studyCase);
            SQLManager sql = new SQLManager(cn);

            if (constraintData is comparisonData)
            {
                comparisonData c = (comparisonData)constraintData;
                query = String.Format(query, c.instance.meta.ToUpper(), c.instance.model, c.attribute, c.op, c.value);
                if (c.instance.instances.Count > 0)
                {
                    string op = "=";
                    query += " AND (";
                    foreach (string i in c.instance.instances)
                    {
                        if (i == "*") op = "<>";
                        query += " (" + c.instance.meta.ToUpper() + "." + c.instance.meta.ToUpper() + "_name "+ op +" '" + i + "') OR";
                    }
                    query = query.Remove(query.Length - 3) + " )";
                }
                if (sql.readData(query).HasRows) return true;
            }
            else if (constraintData is pertenenceData)
            {
                pertenenceData p = (pertenenceData)constraintData;
                // under construction
                query = "select {0}.{0}_name,{1}.{1}_name from {0} join {0}_HAS_{1} on {0}.{0}_id = {0}_HAS_{1}.{0}_id join {1} on {1}.{1}_id = {0}_HAS_{1}.{1}_id";
                query = String.Format(query, p.subelement.meta, p.superelement.meta);
                bool pert = true;
                if (p.op == '~') pert = false;
                if (p.subelement.instances.Count > 0 && p.superelement.instances.Count > 0)
                {
                    query += " WHERE(" + p.subelement.meta + "." + p.subelement.meta + "_name = '" + p.subelement.instances[0] + "') AND (";
                    foreach (string i in p.superelement.instances)
                    {
                        query += " (" + p.superelement.meta + "." + p.superelement.meta + "_name = '" + i + "') OR";
                    }
                    query = query.Remove(query.Length - 3) + " )";
                    if ((pert && sql.readData(query).HasRows)||((!pert && !sql.readData(query).HasRows))) return true;
                }
                
            }
            return res;
        }

        private elemData getElemData(string element)
        {
            elemData ed = new elemData();
            string model = "", meta = "";
            List<string> instances = new List<string>();

            int c = 0;
            while (element[c] != '(') meta += element[c++];
            c++;
            while (element[c] != '{' && element[c] != ')') model += element[c++];
            if (element[c] == '{')
            {
                string instance;
                c++;
                while (element[c] != '}')
                {
                    instance = "";
                    while (element[c] != ',' && element[c] != '}') instance += element[c++];
                    instances.Add(instance);
                    if (element[c] == ',') c++;
                }
            }
            ed.instances = instances;
            ed.model = model;
            ed.meta = meta;
            return ed;
        }

        private void showUsersFrecs()
        {
            Console.WriteLine("\n{0}:", this.scriptName);
            foreach (taskData td in tasks)
            {
                Console.WriteLine("\t{0}:",td.def);
                foreach (KeyValuePair<string, int> uf in td.usersFrecuecnies)
                {
                    Console.WriteLine("\t\t{0}: {1}", uf.Key, uf.Value);
                }
            }
        }

        private void addFrecuency(ref taskData td, taskData recievedTask)
        {
            foreach (string ac in recievedTask.actor.instances)
            {
                if (td.usersFrecuecnies.ContainsKey(ac))
                {
                    td.usersFrecuecnies[ac]++;
                }
                else
                {
                    td.usersFrecuecnies[ac] = 1;
                }
            }
        }
    }
}
