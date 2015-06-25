using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using taskSender.taskModel;
using taskSender.ServiceReference1;
using taskSender.views;
using System.Windows.Forms;
namespace taskSender
{
    class Program
    {
        static void Main(string[] args)
        {
            //ParsedTasks pt = new ParsedTasks();
            //Application.Run(new ParsedTasks()); 
            Application.Run(new ScriptMonitor());
            /*
            ServiceReference1.TaskCatcherClient tc = new ServiceReference1.TaskCatcherClient();
            int currentWindow = 0;
            int aux = 1;
            randomServiceTask rt = new randomServiceTask();
            taskGen tg = new taskGen();
            string input = "notExit";
            List<Task> tareas = new List<Task>();
            string results;
            while (input != "exit")
            {
                if (aux == 6)
                {
                    aux = 0;
                    currentWindow++;
                }
                input = Console.ReadLine();
                tareas = tg.GenerateTaks();
                foreach(Task k in tareas)
                {
                    //Console.WriteLine(showTask(k));
                    //results = tc.recieveTask(k);//
                    results = tc.recieveTaskWithWindow(k,currentWindow);
                    if (results!="\n")
                    {
                        Console.WriteLine(results);
                    }
                    //Console.WriteLine(results);
                }
                aux++;
                //t = rt.generate();
                //t.showTask();
                //if (tc.recieveTask(t)) Console.WriteLine("ok");
                //Console.WriteLine(tc.recieveTask(t));
            }
            tc.Close();*/
        }

        public static string showTask(Task k)
        {
            string res = "";
            if (k.assistanceObject == null)
            {
                res = String.Format("{0}-Task({1})", showElem(k.executorActor), k.taskName);
            }
            else
            {
                res = String.Format("{0}-Task({1},{2})", showElem(k.executorActor), k.taskName, showElem(k.assistanceObject));
                if (k.affecttedActors != null)
                {
                    res += "\nAffected Actors: ";
                    foreach (Element s in k.affecttedActors) res += String.Format("\n\t{0}", showElem(s));
                }
            }
            res += String.Format("\nAttributes\n\teffectiveness: {0}\n\tassignement: {1}\n\tinvolvement: {2}\n\toutcome: {3}", k.effective, k.assign, k.involve, k.outcome);
            return res;
        }

        public static string showElem(Element e)
        {
            string res = e.conceptualElement + '(' + e.domainElement + '{';
            foreach (string s in e.instances) res += s + ",";
            res = res.Remove(res.Length - 1);
            return res + "})";
        }
    }
}
