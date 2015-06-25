using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using taskSender.ServiceReference1;

namespace taskSender.taskModel
{
    class randomServiceTask
    {
        private Dictionary<int, string> players;
        private Dictionary<int, string> tasks;
        private Dictionary<int, string> objects;
        private Dictionary<int, ServiceReference1.Task.effectiveness> effe;
        private Dictionary<int, ServiceReference1.Task.assignemnet> assi;
        private Dictionary<int, ServiceReference1.Task.involvement> invo;
        private int outcome;
        private int aux;

        private void initInstances()
        {
            players = new Dictionary<int, string>();
            players[1] = "PlayerOne";
            players[2] = "PlayerTwo";
            players[3] = "PlayerThree";
            players[4] = "PlayerFour";
            players[5] = "PlayerFive";
            players[6] = "PlayerSix";
            tasks = new Dictionary<int, string>();
            tasks[1] = "jump";
            tasks[2] = "shoot";
            tasks[3] = "kill";
            tasks[4] = "die";
            tasks[5] = "pickItem";
            tasks[6] = "reloadWeapon";
            tasks[7] = "changeWeapon";
            tasks[8] = "captureFlag";
            tasks[9] = "loseFlag";
            tasks[10] = "scoreFlag";
            tasks[11] = "viewMap";
            tasks[12] = "move";
            objects = new Dictionary<int, string>();
            objects[1] = "combat blade";
            objects[2] = "pistol";
            objects[3] = "shotgun";
            objects[4] = "submachine gun";
            objects[5] = "sniper";
            objects[6] = "assault rifle";
            objects[7] = "grenade";
            objects[8] = "carbine";
            effe = new Dictionary<int, ServiceReference1.Task.effectiveness>();
            effe[1] = ServiceReference1.Task.effectiveness.effective;
            effe[2] = ServiceReference1.Task.effectiveness.nill;
            effe[3] = ServiceReference1.Task.effectiveness.uneffective;
            invo = new Dictionary<int, ServiceReference1.Task.involvement>();
            invo[1] = ServiceReference1.Task.involvement.direct;
            invo[2] = ServiceReference1.Task.involvement.nill;
            invo[3] = ServiceReference1.Task.involvement.indirect;
            assi = new Dictionary<int, ServiceReference1.Task.assignemnet>();
            assi[1] = ServiceReference1.Task.assignemnet.assigned;
            assi[2] = ServiceReference1.Task.assignemnet.nill;
            assi[3] = ServiceReference1.Task.assignemnet.unassigned;
            aux = 0;
        }

        private ServiceReference1.Element generateActor()
        {
            ServiceReference1.Element actor = new ServiceReference1.Element();
            actor.conceptualElement = "Actor";
            actor.domainElement = "Player";
            List<string> instances = new List<string>();
            Random r = new Random();
            int x = r.Next(1, 6);
            while (x == aux) x = r.Next(1, 6);
            aux = x;
            instances.Add(players[aux]);
            actor.instances = instances.ToArray();
            return actor;
        }

        private ServiceReference1.Element generateObject()
        {
            ServiceReference1.Element obj = new ServiceReference1.Element();
            obj.conceptualElement = "Object";
            obj.domainElement = "Weapon";
            List<string> instances = new List<string>();
            Random r = new Random();
            instances.Add(objects[r.Next(1, 4)]);
            obj.instances = instances.ToArray();
            return obj;
        }

        public ServiceReference1.Task generate()
        {
            initInstances();
            ServiceReference1.Task tsk = new ServiceReference1.Task();
            Random r = new Random();
            tsk.taskName = tasks[r.Next(1, 12)];
            tsk.executorActor = generateActor();
            if (tsk.taskName == "shot" || tsk.taskName == "kill")
            {
                tsk.assistanceObject = generateObject();
                List<ServiceReference1.Element> aa = new List<ServiceReference1.Element>();
                aa.Add(generateActor());
                tsk.affecttedActors = aa.ToArray();
            }
            tsk.assign = assi[r.Next(1, 3)];
            tsk.effective = effe[r.Next(1, 3)];
            tsk.involve = invo[r.Next(1, 3)];
            tsk.outcome = "";
            return tsk;
        }
    }
}
