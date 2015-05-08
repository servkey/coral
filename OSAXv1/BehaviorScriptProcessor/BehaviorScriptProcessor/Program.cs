using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BehaviorScriptProcessor
{
    class Program
    {
        static void Main(string[] args)
        {
            string task = "";
            //task = Console.ReadLine();
            Evaluator e = new Evaluator("AssaultCube");
            while (task != "exit")
            {
                task = Console.ReadLine();
                e.eval(task);
            }
        }
    }
}
