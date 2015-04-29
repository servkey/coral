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
        Dictionary<string,int> tasks; //tasks and frecuencies
        public List<string> results; // results if script accomplishes
        //constraints
        List<string> comparisons;
        List<string> pertenences;
        string studyCase;
        public string scriptName;

        private struct elemData
        {
            public string meta { get; set; }
            public string model { get; set; }
            public List<string> instances { get; set; }
        }

        private struct comparisonDataEl
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

        public BehaviorScript(string studyCase, string scriptName, bool usesFrecs)
        {
            this.studyCase = studyCase;
            this.scriptName = scriptName;
            if (usesFrecs) recoverRules(); else recoverRulesFrecless();
        }
        
        public bool pushTask(string task)
        {
            if (tasks.ContainsKey(task)) tasks[task]--;
            
            Console.WriteLine("{0}:", scriptName);
            foreach (KeyValuePair<string, int> kvp in tasks)
            {
                Console.WriteLine("\t{0}->{1}",kvp.Key,kvp.Value);
            }

            return scriptAccomplished();
        }

        private bool scriptAccomplished()
        {
            foreach (KeyValuePair<string, int> kvp in tasks)
            {
                if (tasks[kvp.Key] > 0) return false;
            }
            return constraintsMatch();
        }

        private bool constraintsMatch()
        {
            comparisonDataEl cd;
            pertenenceData pd;
            foreach (string c in comparisons)
            {
                cd = extractComp(c);
                if (!validateConstraint(cd)) return false;
            }
            foreach (string p in pertenences)
            {
                pd = extractPert(p);
                if (!validateConstraint(pd)) return false;
            }
            return true;
        }

        private void recoverRules()
        {
            tasks = new Dictionary<string, int>();
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

                if (isResult == 'y') results.Add(rule);
                else if (frecuency != -1) tasks.Add(rule, frecuency);
                else if (rule.Contains('.')) comparisons.Add(rule);
                else pertenences.Add(rule);
            }
            cn.closeConnection();
        }

        private void recoverRulesFrecless()
        {
            tasks = new Dictionary<string, int>();
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

                if (isResult == 'y') results.Add(rule);
                else if (frecuency != -1) tasks.Add(rule, 1);
                else if (rule.Contains('.')) comparisons.Add(rule);
                else pertenences.Add(rule);
            }
            cn.closeConnection();
        }

        private comparisonDataEl extractComp(string rule)
        {
            comparisonDataEl compData = new comparisonDataEl();
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

        private pertenenceData extractPert(string rule)
        {
            pertenenceData perData = new pertenenceData();
            string super = "", sub = "";
            int c = 0;
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

        private bool validateConstraint(object constraintData)
        {
            bool res = false;
            string query = "SELECT * FROM {0} INNER JOIN {1} ON {0}.{0}_id={1}.{0}_id WHERE ({1}.{2}{3}'{4}')";
            DBConnection cn = new DBConnection(studyCase);
            SQLManager sql = new SQLManager(cn);

            if (constraintData is comparisonDataEl)
            {
                comparisonDataEl c = (comparisonDataEl)constraintData;
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

    }
}
