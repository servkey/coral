using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using taskSender.ServiceReference1;
using System.IO;
using MySql.Data.MySqlClient;
using MySql.Data;


namespace taskSender.taskModel
{
    public class taskGen
    {
        MySqlConnection cxn;
        private MySqlDataReader results;
        private readonly Dictionary<int, string> weapons;
        private Dictionary<string, int> usersFlags;
        int window;
        int aux;
        int lastCapturedFlag;
        public taskGen()
        {
            window = 1;
            aux = 5;
            cxn = new MySqlConnection();
            weapons = new Dictionary<int, string>();
            weapons[0] = "combatBlade";
            weapons[1] = "pistol";
            weapons[2] = "shotgun";
            weapons[3] = "submachineGun";
            weapons[4] = "grenade";
            weapons[5] = "assaultRifle";
            weapons[6] = "sniper";
            weapons[7] = "carbine";
            weapons[8] = "NULL1";
            weapons[9] = "akimbo";
            weapons[10] = "NULL3";
            results = readData();
            usersFlags = new Dictionary<string, int>();
            usersFlags["kavir"] = 0;
            usersFlags["nakata"] = 0;
            usersFlags["Alex"] = 0;
            usersFlags["Zutu"] = 0;
            usersFlags["pepe"] = 0;
            usersFlags["user6"] = 0;
        }

        private MySqlDataReader readData()
        {
            
            cxn.ConnectionString = "Server=localhost; database=dbcontext; UID=root; password=123456";
            cxn.Open();
            MySqlCommand command = new MySqlCommand("getLessData", cxn);
            command.CommandType = System.Data.CommandType.StoredProcedure;
            MySqlDataReader res = command.ExecuteReader();

            return res;
        }

        public List<Task> GenerateTaks()
        {
            List<Task> tasks = new List<Task>();
            string username;
            int shots, capturedFlag, pickedItems, destroy, die, wp;
            if (results.Read())
            {
                //to show window number
                if (aux-- == 0)
                {
                    Console.WriteLine("Window {0}", window++);
                    aux = 5;
                }
                username = results.GetString("UN");
                wp = results.GetInt32("WP");
                shots = results.GetInt32("SH");
                pickedItems = results.GetInt32("RB");
                die = results.GetInt32("K");
                destroy = results.GetInt32("D");
                capturedFlag = results.GetInt32("CF");
                #region "Shots"
                if (shots > 0)
                {
                    int ESH, ESHT, ESHE, ESHSB, FSH;
                    ESH = results.GetInt32("ESH");
                    ESHT = results.GetInt32("ESHT");
                    ESHE = results.GetInt32("ESHE");
                    ESHSB = results.GetInt32("ESHSB");
                    FSH = shots - ESH;
                    while (ESHT != 0)
                    {
                        Random r = new Random();
                        Task tsk = new Task();
                        tsk.taskName = "shoot";
                        tsk.executorActor = createUser(username);
                        tsk.assistanceObject = createWeapon(wp);
                        tsk.assign = (r.Next(0, 1) == 1) ? Task.assignemnet.unassigned : Task.assignemnet.assigned;
                        tsk.effective = Task.effectiveness.effective;
                        tsk.affecttedActors = null;
                        tsk.involve = (r.Next(0, 1) == 1) ? Task.involvement.direct : Task.involvement.indirect;
                        string outcome = "[SH,ESH,ESHT]";
                        tsk.outcome = outcome;
                        ESHT--;
                        tasks.Add(tsk);
                    }
                    while (ESHE != 0)
                    {
                        Random r = new Random();
                        Task tsk = new Task();
                        tsk.taskName = "shoot";
                        tsk.executorActor = createUser(username);
                        tsk.assistanceObject = createWeapon(wp);
                        tsk.assign = (r.Next(0, 1) == 1) ? Task.assignemnet.unassigned : Task.assignemnet.assigned;
                        tsk.effective = Task.effectiveness.effective;
                        tsk.affecttedActors = null;
                        tsk.involve = (r.Next(0, 1) == 1) ? Task.involvement.direct : Task.involvement.indirect;
                        string outcome = "[SH,ESH,ESHE]";
                        tsk.outcome = outcome;
                        ESHE--;
                        tasks.Add(tsk);
                    }
                    while (FSH != 0)
                    {
                        Random r = new Random();
                        Task tsk = new Task();
                        tsk.taskName = "shoot";
                        tsk.executorActor = createUser(username);
                        tsk.assistanceObject = createWeapon(wp);
                        tsk.assign = Task.assignemnet.nill;
                        tsk.effective = Task.effectiveness.uneffective;
                        tsk.affecttedActors = null;
                        tsk.involve = Task.involvement.nill;
                        string outcome = "nill";
                        tsk.outcome = outcome;
                        FSH--;
                        tasks.Add(tsk);
                    }
                }
#endregion
                #region "Piked Items"
                if (pickedItems > 0)
                {
                    int health, helmet, armour, akimbo, clips, ammo, grenade;
                    health = results.GetInt32("HL");
                    helmet = results.GetInt32("HM");
                    armour = results.GetInt32("AR");
                    akimbo = results.GetInt32("AK");
                    clips = results.GetInt32("CL");
                    ammo = results.GetInt32("AM");
                    grenade = results.GetInt32("GR");
                    while (health-- > 0) tasks.Add(createPickTask("health", username));
                    while (helmet-- > 0) tasks.Add(createPickTask("helmetarmour", username));
                    while (armour-- > 0) tasks.Add(createPickTask("kevlararmour", username));
                    while (akimbo-- > 0) tasks.Add(createPickTask("akimbo", username));
                    while (clips-- > 0) tasks.Add(createPickTask("pistolmagazine", username));
                    while (ammo-- > 0) tasks.Add(createPickTask("ammobox", username));
                    while (grenade-- > 0) tasks.Add(createPickTask("i_grenade", username));
                }
#endregion
                #region "Destroyed Enemies"
                if (destroy > 0)
                {
                    int ED, TMD, AD;
                    ED = results.GetInt32("ED");
                    TMD = results.GetInt32("TD");
                    AD = results.GetInt32("AD");
                    while (ED-- > 0) tasks.Add(CreateDestroyTask(username,wp,"[D,ED]"));
                    while (TMD-- > 0) tasks.Add(CreateDestroyTask(username, wp, "[D,TD]"));
                    while (AD-- > 0) tasks.Add(CreateDestroyTask(username, wp, "[D,AD]"));
                }
#endregion
                #region "Deaths"
                while (die-- > 0)
                {
                    Task dietk = new Task();
                    dietk.affecttedActors = null;
                    dietk.assign = Task.assignemnet.nill;
                    dietk.assistanceObject = null;
                    dietk.effective = Task.effectiveness.nill;
                    dietk.executorActor = createUser(username);
                    dietk.involve = Task.involvement.nill;
                    dietk.outcome = "[]";
                    dietk.taskName = "die";
                    tasks.Add(dietk);
                }
#endregion
                #region "Captured Flags"
                if (capturedFlag > usersFlags[username])
                {
                    Task cftsk = new Task();
                    cftsk.affecttedActors = null;
                    cftsk.assign = Task.assignemnet.nill;
                    cftsk.assistanceObject = null;
                    cftsk.effective = Task.effectiveness.nill;
                    cftsk.executorActor = createUser(username);
                    cftsk.involve = Task.involvement.nill;
                    cftsk.outcome = "[]";
                    cftsk.taskName = "captureFlag";
                    tasks.Add(cftsk);
                    usersFlags[username]++;
                }
#endregion
            }
            else
            {
                results.Close();
                cxn.Close();
            }
                return tasks;
        }

        private Element createUser(string user)
        {
            Element e = new Element();
            e.conceptualElement = "Actor";
            e.domainElement = "Player";
            string[] i = new string[1];
            i[0] = user;
            e.instances = i;
            return e;
        }
        private Element createWeapon(int wp)
        {
            Element obj = new Element();
            obj.conceptualElement = "Object";
            obj.domainElement = "Weapon";
            List<string> instances = new List<string>();
            instances.Add(weapons[wp]);
            obj.instances = instances.ToArray();
            return obj;
        }
        private Element createItem(string it)
        {
            Element e = new Element();
            e.conceptualElement = "Object";
            e.domainElement = "Item";
            string[] i = new string[1];
            i[0] = it;
            e.instances = i;
            return e;
        }

        private Task createPickTask(string item, string actor)
        {
            Task pick = new Task();
            pick.affecttedActors = null;
            pick.assign = Task.assignemnet.unassigned;
            pick.assistanceObject = createItem(item);
            pick.effective = Task.effectiveness.nill;
            pick.executorActor = createUser(actor);
            pick.involve = Task.involvement.nill;
            pick.outcome = "[]";
            pick.taskName = "pickItem";
            return pick;
        }

        private Task CreateDestroyTask(string user, int weapon, string outcome)
        {
            Task pick = new Task();
            Random r = new Random();
            pick.affecttedActors = null;
            pick.assign = (r.Next(0, 1) == 1) ? Task.assignemnet.unassigned : Task.assignemnet.assigned;
            pick.assistanceObject = createWeapon(weapon);
            pick.effective = Task.effectiveness.nill;
            pick.executorActor = createUser(user);
            pick.involve = (r.Next(0, 1) == 1) ? Task.involvement.direct : Task.involvement.indirect;
            pick.outcome = outcome;
            pick.taskName = "kill";
            return pick;
        }
    }
}
