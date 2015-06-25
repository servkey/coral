using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ScriptEngine.DataBase;
using System.Data.SqlClient;
using ScriptEngine.TaskModel;

namespace ScriptEngine
{
    public class BehaviorScript
    {
        private struct comparisonData
        {
            public Element instance { get; set; }
            public string op { get; set; }
            public string attribute { get; set; }
            public string value { get; set; }
        }

        private struct pertenenceData
        {
            public Element subelement { get; set; }
            public Element superelement { get; set; }
            public char op { get; set; }
        }

        private struct taskData
        {
            public string def { get; set; }
            public string name { get; set; }
            public Element assistanceObject { get; set; }
            public Element actor { get; set; }
            public bool hasAtt { get; set; }
            public string attribute { get; set; }
            public string value { get; set; }
            public char op { get; set; }
            public int frecuency { get; set; }
            public Dictionary<string, int> usersFrecuecnies { get; set; }
            public bool hasPert { get; set; }
            public pertenenceData pert { get; set; }
        }

        List<taskData> scriptTasks;
        public List<string> scriptResults;
        List<comparisonData> scrpitComparisons;
        List<pertenenceData> scriptPertenences;

        string studyCase;
        public string scriptName;

        public BehaviorScript(string studyCase, string scriptName, bool usesFrecs)
        {
            this.studyCase = studyCase;
            this.scriptName = scriptName;
            recoverRules(usesFrecs);
        }

        public bool pushTask(TaskModel.Task recievedTask)
        {
            foreach (taskData td in scriptTasks)
            {
                if (td.name == recievedTask.taskName.ToUpper())
                {
                    if (!td.hasPert && !td.hasAtt)
                    {
                        taskData tempo = td;
                        addFrecuency(ref tempo, recievedTask);
                    }
                    else if(td.hasPert)
                    {
                        pertenenceData pd = new pertenenceData();
                        pd.subelement = td.pert.subelement;
                        pd.op = td.pert.op;
                        pd.superelement = recievedTask.executorActor;
                        if (validateConstraint(pd) && checkAttribute(td,recievedTask))
                        {
                            taskData tempo = td;
                            addFrecuency(ref tempo, recievedTask);
                        }
                    }
                    else if (td.hasAtt)
                    {
                        if (checkAttribute(td, recievedTask))
                        {
                            taskData tempo = td;
                            addFrecuency(ref tempo, recievedTask);
                        }
                    }
                }
            }
            //showUsersFrecs();
            return scriptAccomplished();
        }

        private bool scriptAccomplished()
        {
            foreach (taskData kvp in scriptTasks) //foreach task rule
            {       
                foreach(KeyValuePair<string, int> user in kvp.usersFrecuecnies) //for each user in task rule
                {
                    if (user.Value < kvp.frecuency) return false;
                }
            }
            return true;// constraintsMatch();
        }

        private string scriptAcomplishedS()
        {
            string res = "";

            if (userAcomplishesScript("kavir") && userconstraintsMatch("kavir")) res = String.Format("{0};{1}\n", "kavir", scriptName);
            if (userAcomplishesScript("nakata") && userconstraintsMatch("nakata")) res = String.Format("{0};{1}\n", "nakata", scriptName);
            if (userAcomplishesScript("Alex") && userconstraintsMatch("Alex")) res = String.Format("{0};{1}\n", "Alex", scriptName);
            if (userAcomplishesScript("user6") && userconstraintsMatch("user6")) res = String.Format("{0};{1}\n", "user6", scriptName);
            if (userAcomplishesScript("pepe") && userconstraintsMatch("pepe")) res = String.Format("{0};{1}\n", "pepe", scriptName);
            if (userAcomplishesScript("Zutu") && userconstraintsMatch("Zutu")) res = String.Format("{0};{1}\n", "Zutu", scriptName);

            return res;
        }

        private bool userAcomplishesScript(string user)
        {
            foreach (taskData kvp in scriptTasks) //foreach task rule
            {
                if (kvp.usersFrecuecnies.ContainsKey(user))
                {
                    if (kvp.usersFrecuecnies[user] < kvp.frecuency) return false;
                }
            }
            return true;
        }

        private bool userconstraintsMatch(string user)
        {
            foreach (comparisonData cd in scrpitComparisons)
            {
                if(!validateUserAttribute(user,cd)) return false;
            }
            foreach (pertenenceData pd in scriptPertenences)
            {
                if(!validatePertenence(pd,user)) return false;
            }
            return true;
        }

        /*private bool constraintsMatch()
        {
            comparisonData cd;
            pertenenceData pd;
            foreach (string c in scrpitComparisons)
            {
                cd = getCompData(c);
                if (!validateConstraint(cd)) return false;
            }
            foreach (string p in scriptPertenences)
            {
                pd = getPertData(p);
                if (!validateConstraint(pd)) return false;
            }
            return true;
        }*/

        private void recoverRules(bool usesFrecuencies)
        {
            scriptTasks = new List<taskData>();
            scrpitComparisons = new List<comparisonData>();
            scriptPertenences = new List<pertenenceData>();
            scriptResults = new List<string>();

            DBConnection cn = new DBConnection(studyCase);
            SQLManager sql = new SQLManager(cn);
            SqlDataReader sqlRes = sql.readData
                (
                "SELECT c.definition,c.frecuency,c.res FROM SCRIPT_HAS_RULES a "
                + "inner join SCRIPTS b ON a.script_id=b.script_id "
                + "inner join RULES c ON a.rule_id=c.rule_id "
                + "WHERE b.name = '" + scriptName + "'"
                );

            int frecuency;
            char isResult;
            string rule;

            while (sqlRes.Read())
            {
                rule = sqlRes.GetString(0);
                frecuency = sqlRes.GetInt32(1);
                isResult = sqlRes.GetString(2)[0];

                if (isResult == 'y') scriptResults.Add(rule.ToUpper());
                else if (frecuency != -1)
                {
                    if (!usesFrecuencies) frecuency = 1;
                    scriptTasks.Add(getTaskData(rule.ToUpper(), frecuency));
                }
                else if (rule.Contains('.')) scrpitComparisons.Add(getCompData(rule.ToUpper()));
                else scriptPertenences.Add(getPertData(rule.ToUpper()));
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
            int c = 0;
            if (rule[0] == '[') c = 1;
            char ope;
            while (rule[c] != '-' && rule[c] != '~') sub += rule[c++];
            ope = rule[c++];
            c++;
            while (c < rule.Length - 1) super += rule[c++];
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
            td.assistanceObject = null;
            td.actor = null;
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
                i++;
                while (rule[i] != '=' && rule[i] != '¬' && rule[i] != '<' && rule[i] != '>') td.attribute += rule[i++];
                td.op = rule[i++];
                while (i < rule.Length) td.value += rule[i++];
                td.hasAtt = true;
            }
            td.usersFrecuecnies = new Dictionary<string, int>();
            return td;
        }

        private bool validateUserAttribute(string username, comparisonData cd)
        {
            bool res = false;
            string query = "SELECT * FROM ACTOR a INNER JOIN PLAYER b on a.actor_id = b.actor_id WHERE a.actor_name='{0}' AND b.{1} {2} '{3}'";
            query = String.Format(query, username, cd.attribute, cd.op, cd.value);
            DBConnection cn = new DBConnection(studyCase);
            SQLManager sql = new SQLManager(cn);
            if (sql.readData(query).HasRows) res = true;
            cn.closeConnection();
            return res;
        }

        private bool validatePertenence(pertenenceData pd, string username)
        {
            bool res = false;
            string query = "select a.{0}_name,c.{1}_name from {0} a join {0}_HAS_{1} b on a.{0}_id = b.{0}_id join {1} c on c.{1}_id = b.{1}_id WHERE a.{0}_name = '{2}' AND c.{1}_name = '{3}'";
            query = String.Format(query
                , pd.superelement.conceptualElement
                , pd.subelement.conceptualElement
                , pd.superelement.instances[0]
                , username//pd.subelement.instances[0]
                );
            bool pert = true;
            if (pd.op == '~') pert = false;
            DBConnection cn = new DBConnection(studyCase);
            SQLManager sql = new SQLManager(cn);
            if ((pert && sql.readData(query).HasRows) || ((!pert && !sql.readData(query).HasRows))) res = true;
            cn.closeConnection();
            return res;
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
                query = String.Format(query, c.instance.conceptualElement.ToUpper(), c.instance.conceptualElement, c.attribute, c.op, c.value);
                if (c.instance.instances.Count > 0)
                {
                    string op = "=";
                    query += " AND (";
                    foreach (string i in c.instance.instances)
                    {
                        if (i == "*") op = "<>";
                        query += " (" + c.instance.conceptualElement.ToUpper() + "." + c.instance.conceptualElement.ToUpper() + "_name " + op + " '" + i + "') OR";
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
                query = String.Format(query, p.subelement.conceptualElement, p.superelement.conceptualElement);
                bool pert = true;
                if (p.op == '~') pert = false;
                if (p.subelement.instances.Count > 0 && p.superelement.instances.Count > 0)
                {
                    query += " WHERE(" + p.subelement.conceptualElement + "." + p.subelement.conceptualElement + "_name = '" + p.subelement.instances[0] + "') AND (";
                    foreach (string i in p.superelement.instances)
                    {
                        query += " (" + p.superelement.conceptualElement + "." + p.superelement.conceptualElement + "_name = '" + i + "') OR";
                    }
                    query = query.Remove(query.Length - 3) + " )";
                    if ((pert && sql.readData(query).HasRows) || ((!pert && !sql.readData(query).HasRows))) return true;
                }

            }
            return res;
        }

        private Element getElemData(string element)
        {
            Element ed = new Element();
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
            ed.domainElement = model;
            ed.conceptualElement = meta;
            return ed;
        }

        private string showUsersFrecs()
        {
            string res = String.Format("\n{0}:\n", this.scriptName);
            foreach (taskData td in scriptTasks)
            {
                res += String.Format("\t{0}:\n", td.def);
                foreach (KeyValuePair<string, int> uf in td.usersFrecuecnies)
                {
                    res += String.Format("\t\t{0}: {1}\n", uf.Key, uf.Value);
                }
            }
            return res;
        }

        private string showUsersFrecs(taskData task)
        {
            string res = "";
            foreach (taskData td in scriptTasks)
            {
                if (td.Equals(task))
                {
                    res = String.Format("\n{0}:\n", this.scriptName);
                    res += String.Format("\t{0}:\n", td.def);
                    foreach (KeyValuePair<string, int> uf in td.usersFrecuecnies)
                    {
                        res += String.Format("\t\t{0}: {1}\n", uf.Key, uf.Value);
                    }
                }
            }
            return res;
        }

        private string showUsersFrecsGUIFormat(taskData task)
        {
            string res = "";
            foreach (taskData td in scriptTasks)
            {
                if (td.Equals(task))
                {
                    foreach (KeyValuePair<string, int> uf in td.usersFrecuecnies)
                    {
                        res += String.Format("{0};{1};{2};{3}\n", this.scriptName, td.def, uf.Key, uf.Value);
                    }
                }
            }
            return res;
        }

        private void addFrecuency(ref taskData td, Task recievedTask)
        {
            foreach (string ac in recievedTask.executorActor.instances)
            {
                if (td.usersFrecuecnies.ContainsKey(ac))
                {
                    if (td.hasAtt)
                    {
                        if (checkAttribute(td, recievedTask)) td.usersFrecuecnies[ac]++;
                    }
                    else td.usersFrecuecnies[ac]++;
                }
                else
                {
                    td.usersFrecuecnies[ac] = 1;
                }
            }
        }

        public void restartFrecuencies()
        {
            foreach (taskData kvp in scriptTasks)
            {
                /*foreach (KeyValuePair<string, int> user in kvp.usersFrecuecnies)
                {
                    kvp.usersFrecuecnies[user.Key] = 0;
                }*/
                kvp.usersFrecuecnies["kavir"] = 0;
                kvp.usersFrecuecnies["nakata"] = 0;
                kvp.usersFrecuecnies["Alex"] = 0;
                kvp.usersFrecuecnies["user6"] = 0;
                kvp.usersFrecuecnies["pepe"] = 0;
                kvp.usersFrecuecnies["Zutu"] = 0;
            }
        }

        private bool checkAttribute(taskData scriptTask, Task recievedTaks)
        {
            if (scriptTask.attribute.ToUpper() == "EFFECTIVENESS")
            {
                switch (scriptTask.op)
                {
                    case '=':
                        return (recievedTaks.effective.ToString() == scriptTask.value);
                    case '>':
                        return (recievedTaks.effective.ToString() != scriptTask.value);
                    case '<':
                        return (recievedTaks.effective.ToString() != scriptTask.value);
                    case '¬':
                        return (recievedTaks.effective.ToString() != scriptTask.value);
                    default:
                        return (recievedTaks.effective.ToString() != scriptTask.value);
                }
            }
            if (scriptTask.attribute.ToUpper() == "INVOLVEMENT")
            {
                switch (scriptTask.op)
                {
                    case '=':
                        return (recievedTaks.involve.ToString() == scriptTask.value);
                    case '>':
                        return (recievedTaks.involve.ToString() != scriptTask.value);
                    case '<':
                        return (recievedTaks.involve.ToString() != scriptTask.value);
                    case '¬':
                        return (recievedTaks.involve.ToString() != scriptTask.value);
                    default:
                        return (recievedTaks.involve.ToString() != scriptTask.value);
                }
            }
            if (scriptTask.attribute.ToUpper() == "OUTCOME")
            {
                switch (scriptTask.op)
                {
                    case '=':
                        return (recievedTaks.outcome.ToString() == scriptTask.value);
                    case '>':
                        return (recievedTaks.outcome.ToString() != scriptTask.value);
                    case '<':
                        return (recievedTaks.outcome.ToString() != scriptTask.value);
                    case '¬':
                        return (recievedTaks.outcome.ToString() != scriptTask.value);
                    default:
                        return (recievedTaks.outcome.ToString() != scriptTask.value);
                }
            }
            if (scriptTask.attribute.ToUpper() == "ASSIGNMENT")
            {
                switch (scriptTask.op)
                {
                    case '=':
                        return (recievedTaks.assign.ToString() == scriptTask.value);
                    case '>':
                        return (recievedTaks.assign.ToString() != scriptTask.value);
                    case '<':
                        return (recievedTaks.assign.ToString() != scriptTask.value);
                    case '¬':
                        return (recievedTaks.assign.ToString() != scriptTask.value);
                    default:
                        return (recievedTaks.assign.ToString() != scriptTask.value);
                }
            }
            return true;
        }

        public string pushTaskS(TaskModel.Task recievedTask)
        {
            string res = "";
            taskData matchedTask = new taskData(); //auxiliar variable to store matched task
            bool matched = false; 
            foreach (taskData td in scriptTasks) // for each task rule of the script
            {
                if (td.name == recievedTask.taskName.ToUpper()) //if task matches a task rule
                {
                    if (!td.hasPert && !td.hasAtt) //it has no pertenence and no attribute
                    {
                        taskData tempo = td; //auxiliar variable to change values inside the iterations
                        addFrecuency(ref tempo, recievedTask);
                        matchedTask = td;
                        matched = true;
                    }
                    else if (td.hasPert && td.hasAtt) //it has pertenence and attribute
                    {
                        pertenenceData pd = new pertenenceData();
                        pd.subelement = td.pert.subelement;
                        pd.op = td.pert.op;
                        pd.superelement = recievedTask.executorActor;
                        if (validateConstraint(pd) && checkAttribute(td, recievedTask))
                        {
                            taskData tempo = td;//auxiliar variable to change values inside the iterations
                            addFrecuency(ref tempo, recievedTask);
                            matchedTask = td;
                            matched = true;
                        }
                    }
                    else if (td.hasPert) //it has ONLY pertenence
                    {
                        pertenenceData pd = new pertenenceData();
                        pd.subelement = td.pert.subelement;
                        pd.op = td.pert.op;
                        pd.superelement = recievedTask.executorActor;
                        if (validateConstraint(pd))
                        {
                            taskData tempo = td;//auxiliar variable to change values inside the iterations
                            addFrecuency(ref tempo, recievedTask);
                            matchedTask = td;
                            matched = true;
                        }
                    }
                    else if (td.hasAtt) // has ONLY attribute
                    {
                        if (checkAttribute(td, recievedTask))
                        {
                            taskData tempo = td;//auxiliar variable to change values inside the iterations
                            addFrecuency(ref tempo, recievedTask);
                            matchedTask = td;
                            matched = true;
                        }
                    }
                }
            }
            //showUsersFrecs();
            //if (matched) return showUsersFrecs(matchedTask); else return "";
            if (matched)
            {
                res += showUsersFrecsGUIFormat(matchedTask);
                string acomplished = scriptAcomplishedS();
                if (acomplished != "")
                {
                    res += '$';
                    res += acomplished;
                }
            }
            return res;
        }
    }
}
