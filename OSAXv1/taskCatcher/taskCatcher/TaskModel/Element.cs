using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace taskCatcher.TaskModel
{
    [DataContract]
    public class Element
    {
        [DataMember]
        public string conceptualElement { get; set; }
        [DataMember]
        public string domainElement { get; set; }
        [DataMember]
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