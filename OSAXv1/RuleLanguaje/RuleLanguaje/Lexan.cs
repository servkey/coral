using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace RuleLanguaje
{
    class Lexan
    {
        public const int COMPARISSON = 1001;
        public const int PERTENENCE = 1002;
        public const int EXECUTION1 = 1003;
        public const int EXECUTION2 = 1004;
        public const int ELEMENT = 1005;
        public const int ERROR = 1006;

        Regex per;
        Regex cmp;
        Regex simple_ex;
        Regex complex_ex;
        Regex elem;

        private DBValidator dbvalidator;
        string result;
        public int sc_id { get; set; }

        public Lexan()
        {            
            result = "";
            dbvalidator = new DBValidator("AssaultCube"); //change to deal with any study case
            per = new Regex(@"[a-zA-Z{}\(\)\*]+[-~]>[a-zA-Z{}\(\)\*]");
            cmp = new Regex(@"[a-zA-Z{}\(\)\*]+\.\w+[=<>¬][\w+\d+(\d+\.\d+)]");
            simple_ex = new Regex(@".+-Task\(\w+(,.+)?\)");
            complex_ex = new Regex(@".+-Task\(\w+(,.+)?\).\w+[=<>¬][\w+\d+(\d+\.\d+)]");
            elem = new Regex(@"\w+\(\w+(\{(\*|[\w\s-]+(,[\w\s-]*)*)\})?\)");            
        }

        public Lexan(string domainName)
        {
            result = "";
            dbvalidator = new DBValidator(domainName); //change to deal with any study case
            per = new Regex(@"[a-zA-Z{}\(\)\*]+[-~]>[a-zA-Z{}\(\)\*]");
            cmp = new Regex(@"[a-zA-Z{}\(\)\*]+\.\w+[=<>¬][\w+\d+(\d+\.\d+)]");
            simple_ex = new Regex(@".+-Task\(\w+(,.+)?\)");
            complex_ex = new Regex(@".+-Task\(\w+(,.+)?\).\w+[=<>¬][\w+\d+(\d+\.\d+)]");
            elem = new Regex(@"\w+\(\w+(\{(\*|[\w\s-]+(,[\w\s-]*)*)\})?\)");
        }

        public string Analize(string input)
        {
            if (!input.Contains(":="))
            {
                return "Consecuence is missing";
            }
            string condition = split(input)[0];
            string consecuence = split(input)[1];            
            //para condición

            string[] members = condition.Split('&');
            int i;            
            foreach (string m in members)
            {           
                switch (kindOf(m))
                {                    
                    case COMPARISSON:///////////////////////////////////////////////////////////////////////////
                        string element = "";
                        string attribute = "";
                        string value = "";
                        i = 0;
                        while (m[i] != '.') element += m[i++];
                        i++;
                        while (m[i] != '=' && m[i] != '>' && m[i] != '<' && m[i] != '¬') attribute += m[i++];
                        char op = m[i++];                        
                        while (i < m.Length) value += m[i++];
                        string elemType = getElemTipe(element);
                        Console.WriteLine("Comparisson : \n\tElement:{0}\n\tAttribute:{1}\n\tValue:{2}",element,attribute,value);
                        //validate elements
                        if (validateElement(element)) result += elemType + " . a " + op + " v & "; else result += m + " not valid";
                        break;
                    case PERTENENCE:///////////////////////////////////////////////////////////////////////////
                        string elem1 = "", elem2 = "";
                        i = 0;
                        while (m[i] != '-' && m[i] != '~') elem1 += m[i++];
                        string cop = " " + m[i] + " " + m[i + 1] + " ";
                        i+=2;
                        while (i < m.Length) elem2 += m[i++];
                        string et1 = getElemTipe(elem1);
                        string et2 = getElemTipe(elem2);
                        Console.WriteLine("Pertenence: \n\tElement1:{0}\n\tElement2({3}):{1}", elem1, elem2,et1,et2);
                        if (validateElement(elem1) && validateElement(elem2)) result += et1 + cop + et2 + " & "; else result += m + " not valid; ";
                        
                        break;
                    case EXECUTION1: ///////////////////////////////////////////////////////////////////////////
                        string elem3="";
                        string elem4 = "";
                        string elem5 = "";
                        string elem6 = "";
                        string task = "";
                        string auxop = "";
                        i = 0;
                        if (m[0] == '[')
                        {
                            i++;
                            while (m[i] != '-' && m[i] != '~') elem3 += m[i++];
                            auxop = " " + m[i] + " " + m[i+1] + " ";
                            i += 2;
                            while (m[i] != ']') elem4 += m[i++];
                            i++;
                        }
                        else
                        {
                            while (m[i] != '-') elem3 += m[i++];
                        }
                        i += 6;//passing "-task("
                        while (m[i] != '-' && m[i] != ')') task += m[i++];

                        if (m[i] == ',')// si hay un objeto asistente
                        {
                            if (m[++i] == '[')
                            {
                                while (m[i] != '-' && m[i] != '~') elem5 += m[i++];
                                i += 2;
                                while (m[i] != ']') elem6 += m[i++];
                                i++;
                            }
                            else
                            {
                                while (m[i] != ')') elem5 += m[i++];
                            }
                        }
                        string elt1 = getElemTipe(elem3);
                        string elt2 = getElemTipe(elem4);
                        string auxres = " ";
                        Console.WriteLine("Simple Execution: ");
                        Console.WriteLine("\tMain Element: {0} {1}",elem3,elem4, elt1, elt2);
                        bool ok = true;
                        if (!validateElement(elem3)) ok = false; else auxres = elt1 + " ";
                        if (elem4 != "") { if (!validateElement(elem4)) ok = false; else auxres = "[ " + elt1 + auxop + elt2 + " ] "; }
                        auxres += "- t ( n ";
                        elt1 = getElemTipe(elem5);
                        elt2 = getElemTipe(elem6);
                        Console.WriteLine("\tTask Name: {0}", task);
                        Console.WriteLine("\tAssistance Element({2})({3}): {0} {1}", elem5, elem6,elt1, elt2);
                        if (elem6 != "") if (!validateElement(elem6)) ok = false; else auxres += " , " + elt1;
                        if (elem5 != "") if (!validateElement(elem5)) ok = false;
                        auxres += ") & ";
                        if (ok) result += auxres; else result += m + " not valid; ";
                        //validate elements
                        break;
                    case EXECUTION2: ///////////////////////////////////////////////////////////////////////
                        string celem3="";
                        string celem4 = "";
                        string celem5 = "";
                        string celem6 = "";
                        string ctask = "";
                        string xop = "";
                        i = 0;
                        if (m[0] == '[')
                        {
                            i++;
                            while (m[i] != '-' && m[i] != '~') celem3 += m[i++];
                            xop = " " + m[i] + " " + m[i+1] + " ";
                            i += 2;
                            while (m[i] != ']') celem4 += m[i++];
                            i++;
                        }
                        else
                        {
                            while (m[i] != '-') celem3 += m[i++];
                        }
                        i += 6;//passing "-task("
                        while (m[i] != '-' && m[i] != ')') ctask += m[i++];

                        if (m[i] == ',')// si hay un objeto asistente
                        {
                            if (m[++i] == '[')
                            {
                                while (m[i] != '-' && m[i] != '~') celem5 += m[i++];
                                i += 2;
                                while (m[i] != ']') celem6 += m[i++];
                                i++;
                            }
                            else
                            {
                                while (m[i] != ')') celem5 += m[i++];
                            }
                        }

                        i += 2; //skiping '.'
                        bool cok = true;
                        string cres = "";
                        string ctattribute = "";
                        string ctvalue = "";
                        while (m[i] != '=' && m[i] != '>' && m[i] != '<' && m[i] != '¬') ctattribute += m[i++];
                        char top = m[i];
                        i++;
                        while (i < m.Length) ctvalue += m[i++];
                        string elt3 = getElemTipe(celem3);
                        string elt4 = getElemTipe(celem4);
                        Console.WriteLine("Complex Execution: ");
                        Console.WriteLine("\tMain Element: {0} {1}",celem3,celem4,elt3,elt4);
                        if (!validateElement(celem3)) ok = false; else cres = elt3 + " ";
                        if (celem4 != "") { if (!validateElement(celem4)) cok = false; else cres = "[ " + elt3 + xop + elt4 + " ] "; }
                        cres += "- t ( n ";
                        Console.WriteLine("\tTask Name: {0}", ctask);
                        elt3 = getElemTipe(celem5);
                        elt4 = getElemTipe(celem6);
                        Console.WriteLine("\tAssistance Element: {0} {1}", celem5, celem6,elt3,elt4);                        
                        if (celem6 != "") if (!validateElement(celem6)) cok = false; else cres += " , " + elt3;
                        if(!validateElement(celem5)) cok = false;
                        cres += ") . a " + top + " v & ";
                        Console.WriteLine("\tAttribute:{0}\n\tValue:{1}", ctattribute, ctvalue);
                        if (cok) result += cres; else result += m + " not valid; ";
                        break;
                    default:
                        return result;
                }
            }

            /////////////////////////CONSECUENCIA///////////////////////////////
            result = result.Remove(result.Length - 2) + ": = ";
            members = consecuence.Split('&');
            foreach (string m in members)
            {
                switch (kindOf(m))
                {
                    case EXECUTION1: ///////////////////////////////////////////////////////////////////////////
                        string elem3 = "";
                        string elem4 = "";
                        string elem5 = "";
                        string elem6 = "";
                        string task = "";
                        string auxop = "";
                        i = 0;
                        if (m[0] == '[')
                        {
                            i++;
                            while (m[i] != '-' && m[i] != '~') elem3 += m[i++];
                            auxop = " " + m[i] + " " + m[i + 1] + " ";
                            i += 2;
                            while (m[i] != ']') elem4 += m[i++];
                            i++;
                        }
                        else
                        {
                            while (m[i] != '-') elem3 += m[i++];
                        }
                        i += 6;//passing "-task("
                        while (m[i] != '-' && m[i] != ')') task += m[i++];

                        if (m[i] == ',')// si hay un objeto asistente
                        {
                            if (m[++i] == '[')
                            {
                                while (m[i] != '-' && m[i] != '~') elem5 += m[i++];
                                i += 2;
                                while (m[i] != ']') elem6 += m[i++];
                                i++;
                            }
                            else
                            {
                                while (m[i] != ')') elem5 += m[i++];
                            }
                        }
                        string elt1 = getElemTipe(elem3);
                        string elt2 = getElemTipe(elem4);
                        string auxres = " ";
                        //Console.WriteLine("Simple Execution: ");
                        //Console.WriteLine("\tMain Element: {0} {1}",elem3,elem4, elt1, elt2);
                        bool ok = true;
                        if (!validateElement(elem3)) ok = false; else auxres = elt1 + " ";
                        if (elem4 != "") { if (!validateElement(elem4)) ok = false; else auxres = "[ " + elt1 + auxop + elt2 + " ] "; }
                        auxres += "- t ( n ";
                        elt1 = getElemTipe(elem5);
                        elt2 = getElemTipe(elem6);
                        //Console.WriteLine("\tTask Name: {0}", task);
                        //Console.WriteLine("\tAssistance Element({2})({3}): {0} {1}", elem5, elem6,elt1, elt2);
                        if (elem6 != "") if (!validateElement(elem6)) ok = false; else auxres += " , " + elt1;
                        if (elem5 != "") if (!validateElement(elem5)) ok = false;
                        auxres += ") & ";
                        if (ok) result += auxres; else result += m + " not valid; ";
                        //validate elements
                        break;
                    case EXECUTION2: ///////////////////////////////////////////////////////////////////////
                        string celem3 = "";
                        string celem4 = "";
                        string celem5 = "";
                        string celem6 = "";
                        string ctask = "";
                        string xop = "";
                        i = 0;
                        if (m[0] == '[')
                        {
                            i++;
                            while (m[i] != '-' && m[i] != '~') celem3 += m[i++];
                            xop = " " + m[i] + " " + m[i + 1] + " ";
                            i += 2;
                            while (m[i] != ']') celem4 += m[i++];
                            i++;
                        }
                        else
                        {
                            while (m[i] != '-') celem3 += m[i++];
                        }
                        i += 6;//passing "-task("
                        while (m[i] != '-' && m[i] != ')') ctask += m[i++];

                        if (m[i] == ',')// si hay un objeto asistente
                        {
                            if (m[++i] == '[')
                            {
                                while (m[i] != '-' && m[i] != '~') celem5 += m[i++];
                                i += 2;
                                while (m[i] != ']') celem6 += m[i++];
                                i++;
                            }
                            else
                            {
                                while (m[i] != ')') celem5 += m[i++];
                            }
                        }

                        i += 2; //skiping '.'
                        bool cok = true;
                        string cres = "";
                        string ctattribute = "";
                        string ctvalue = "";
                        while (m[i] != '=' && m[i] != '>' && m[i] != '<' && m[i] != '¬') ctattribute += m[i++];
                        char top = m[i];
                        i++;
                        while (i < m.Length) ctvalue += m[i++];
                        string elt3 = getElemTipe(celem3);
                        string elt4 = getElemTipe(celem4);
                        //Console.WriteLine("Complex Execution: ");
                        //Console.WriteLine("\tMain Element: {0} {1}",celem3,celem4,elt3,elt4);
                        if (!validateElement(celem3)) ok = false; else cres = elt3 + " ";
                        if (celem4 != "") { if (!validateElement(celem4)) cok = false; else cres = "[ " + elt3 + xop + elt4 + " ] "; }
                        cres += "- t ( n ";
                        //Console.WriteLine("\tTask Name: {0}", ctask);
                        elt3 = getElemTipe(celem5);
                        elt4 = getElemTipe(celem6);
                        //Console.WriteLine("\tAssistance Element: {0} {1}", celem5, celem6,elt3,elt4);                        
                        if (celem6 != "") if (!validateElement(celem6)) cok = false; else cres += " , " + elt3;
                        if (!validateElement(celem5)) cok = false;
                        cres += ") . a " + top + " v & ";
                        //Console.WriteLine("\tAttribute:{0}\n\tValue:{1}", ctattribute, ctvalue);
                        if (cok) result += cres; else result += m + " not valid; ";
                        break;
                    default:
                        return result;
                }
            }
            result = result.Remove(result.Length - 3);
            return result;
        }

        private int kindOf(string member)
        {
            if (complex_ex.IsMatch(member) && (member.Contains("Task"))) { Console.WriteLine("{0} matches complex task exec!", member); return EXECUTION2; }
            else if (simple_ex.IsMatch(member) && (member.Contains("Task"))) { Console.WriteLine("{0} matches simple task exec!", member); return EXECUTION1; }
            else if (cmp.IsMatch(member) && !(member.Contains("Task"))) { Console.WriteLine("{0} matches comparation!", member); return COMPARISSON; }
            else if (per.IsMatch(member) && !(member.Contains("Task"))) { Console.WriteLine("{0} matches pertenence!", member); return PERTENENCE; }
            else Console.WriteLine("expresion \"{0}\" does not match with any sintactic rule!", member);
            return ERROR;
        }


        private bool validateElemAttrValue(string element, string attribute, string value)
        {
            return true;
        }

        private bool validateElement(string element)
        {
            if (element == "") return false;
            string meta="", model="";
            LinkedList<string> instances = new LinkedList<string>();
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
                    instances.AddLast(instance);
                    if (element[c] == ',') c++;
                }
            }
            Console.WriteLine("\t\tMetaElement: {0}", meta);
            Console.WriteLine("\t\tModelElement: {0}", model);
            Console.Write("\t\tInstances: ");
            foreach (string i in instances) Console.Write(i + ' ');
            Console.Write('\n');
            if (meta == "*") return dbvalidator.validateMeta(meta);
            if ((instances.Count == 1 && instances.First.Value == "*") || instances.Count == 0 ) return dbvalidator.validateModel(meta, model);
            return dbvalidator.validateInstances(meta, model, instances);
            
        }

        private string[] split(string cadena)
        {
            string[] res = new string[2];
            res[0] = "";
            res[1] = "";
            int i=0;
            while (cadena[i] != ':') res[0] += cadena[i++];
            i+=2;
            while (i < cadena.Length) res[1] += cadena[i++];
            return res;
        }
                
        private string clean(string c)
        {
            return String.Join("", c.Split('(',')'));
        }

        private string getElemTipe(string elem)
        {
            if (elem == "") return "";
            string res = "m (";
            int c = 0;
            while (elem[c++] != '(') ;
            if (elem[c] == '*') return res += " * ) ";
            
            while (elem[c] != ',' && elem[c] != '{' && elem[c] != ')' ) c++;
            
            if (elem[c] == ')') return res += " i )";
            
            if (elem[c] == ',')
            {                
                while (elem[c++] != ')')
                {
                    if (elem[c] == ',') res += " i ,";
                }
                return res += " i )";
            }
            c++;
            
            if (elem[c] == '*') return res += " e { * } )";
            
            while (elem[c++] != ')')
            {
                if (elem[c] == ',') res += " i ,";
            }
            return res += " i )";
            
        }
    }
}


