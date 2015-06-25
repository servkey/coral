using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace ScriptEngine.TaskModel
{
    public class Task
    {
        public enum effectiveness { effective, uneffective, nill }
        public enum assignemnet { unassigned, assigned, nill }
        public enum involvement { indirect, direct, nill }
        public string taskName { get; set; }
        public Element executorActor { get; set; }
        public Element assistanceObject { get; set; }
        public string outcome { get; set; }
        public effectiveness effective { get; set; }
        public assignemnet assign { get; set; }
        public involvement involve { get; set; }
        public List<Element> affecttedActors { get; set; }


        public Task()
        {
            executorActor = null;
            assistanceObject = null;
            outcome = "nill";
            effective = effectiveness.nill;
            assign = assignemnet.nill;
            involve = involvement.nill;
            affecttedActors = null;
        }

        public static void displayEnums()
        {
            Console.Write("effectiveness: {0}, {1}", effectiveness.effective, effectiveness.uneffective);
        }

        public void showTask()
        {
            if (assistanceObject == null)
            {
                Console.WriteLine("{0}-Task({1})", executorActor.toString(), taskName);
            }
            else
            {
                Console.WriteLine("{0}-Task({1},{2})", executorActor.toString(), taskName, assistanceObject.toString());
                Console.WriteLine("Affected Actors: ");
                foreach (Element s in affecttedActors) Console.WriteLine("\t{0}", s.toString());
            }
            Console.WriteLine("Attributes\n\teffectiveness: {0}\n\tassignement: {1}\n\tinvolvement: {2}\n\toutcome: {3}", effective, assign, involve, outcome);
        }
    }
}
