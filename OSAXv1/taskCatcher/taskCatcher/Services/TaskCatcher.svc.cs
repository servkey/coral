using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using ScriptEngine;
using ScriptEngine.TaskModel;

namespace taskCatcher.Services
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "TaskCatcher" en el código, en svc y en el archivo de configuración a la vez.
    public class TaskCatcher : ITaskCatcher
    {
        public SingleEvaluator eval { get; set; }
        //public Evaluator eval;
        public int numero { get; set; }
        public TaskCatcher()
        {
            //eval = new Evaluator("AssaultCube");
            eval = SingleEvaluator.GetInstance;
        }
        public void DoWork()
        {
        }

        public string recieveTask(taskCatcher.TaskModel.Task tsk)
        {
            //eval.eval(et);
            return eval.evalS(convertTaskToLocal(tsk));
            //return tsk.showTask();
        }

        public string recieveTaskWithWindow(taskCatcher.TaskModel.Task tsk, int window)
        {
            return eval.evalWithResetS(convertTaskToLocal(tsk),window);
        }

        private ScriptEngine.TaskModel.Task convertTaskToLocal(taskCatcher.TaskModel.Task tsk)
        {
            ScriptEngine.TaskModel.Task et = new Task();
            List<ScriptEngine.TaskModel.Element> affectedActors = new List<Element>();
            ScriptEngine.TaskModel.Element ee;
            if (tsk.affecttedActors != null && tsk.affecttedActors.Count > 0)
            {
                foreach (taskCatcher.TaskModel.Element e in tsk.affecttedActors)
                {
                    ee = new Element();
                    ee.conceptualElement = e.conceptualElement;
                    ee.domainElement = e.domainElement;
                    ee.instances = e.instances;
                    affectedActors.Add(ee);
                }
                et.affecttedActors = affectedActors;
            }
            else
            {
                et.affecttedActors = null;
            }

            et.assign = (ScriptEngine.TaskModel.Task.assignemnet)tsk.assign;
            if (tsk.assistanceObject != null)
            {
                ee = new Element();
                ee.conceptualElement = tsk.assistanceObject.conceptualElement;
                ee.domainElement = tsk.assistanceObject.domainElement;
                ee.instances = tsk.assistanceObject.instances;
                et.assistanceObject = ee;
            }
            else
            {
                et.assistanceObject = null;
            }
            et.effective = (ScriptEngine.TaskModel.Task.effectiveness)tsk.effective;
            ee = new Element();
            ee.conceptualElement = tsk.executorActor.conceptualElement;
            ee.domainElement = tsk.executorActor.domainElement;
            ee.instances = tsk.executorActor.instances;
            et.executorActor = ee;
            et.involve = (ScriptEngine.TaskModel.Task.involvement)tsk.involve;
            et.outcome = tsk.outcome;
            et.taskName = tsk.taskName;
            return et;
        }
    }
}
