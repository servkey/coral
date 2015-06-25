using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ScriptEngine.TaskModel
{
    [Serializable]
    public class Element
    {
        public string conceptualElement { get; set; }
        public string domainElement { get; set; }
        public List<string> instances { get; set; }

        public string toString()
        {
            string res = conceptualElement + '(' + domainElement + '{';
            foreach (string s in instances) res += s + ",";
            res = res.Remove(res.Length - 1);
            return res + "})";
        }
    }
}
