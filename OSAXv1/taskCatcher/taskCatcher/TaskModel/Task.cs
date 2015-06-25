using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace taskCatcher.TaskModel
{
    [DataContract]
    public class Task
    {
        [DataContract]
        public enum effectiveness 
        { 
            [EnumMember]
            effective, 
            [EnumMember]
            uneffective,
            [EnumMember]
            nill 
        }
        [DataContract]
        public enum assignemnet 
        { 
            [EnumMember]
            unassigned, 
            [EnumMember]
            assigned, 
            [EnumMember]
            nill 
        }
        [DataContract]
        public enum involvement 
        {
            [EnumMember]
            indirect, 
            [EnumMember]
            direct, 
            [EnumMember]
            nill 
        }
        [DataMember]
        public string taskName { get; set; }
        [DataMember]
        public Element executorActor { get; set; }
        [DataMember]
        public Element assistanceObject { get; set; }
        [DataMember]
        public string outcome { get; set; }
        [DataMember]
        public effectiveness effective { get; set; }
        [DataMember]
        public assignemnet assign { get; set; }
        [DataMember]
        public involvement involve { get; set; }
        [DataMember]
        public List<Element> affecttedActors { get; set; }
        
        public string showTask()
        {
            string res = "";
            if (assistanceObject == null)
            {
                res =  String.Format("{0}-Task({1})", executorActor.toString(), taskName);
            }
            else
            {
                res = String.Format("{0}-Task({1},{2})", executorActor.toString(), taskName, assistanceObject.toString());
                if (affecttedActors != null)
                {
                    res += "\nAffected Actors: ";
                    foreach (Element s in affecttedActors) res += String.Format("\n\t{0}", s.toString());
                }
            }
            res += String.Format("\nAttributes\n\teffectiveness: {0}\n\tassignement: {1}\n\tinvolvement: {2}\n\toutcome: {3}", effective, assign, involve, outcome);
            return res;
        }
    }
}