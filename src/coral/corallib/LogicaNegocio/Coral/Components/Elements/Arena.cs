using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Collections.Generic;
using DataAccess;
using MARS;


namespace MARS
{
    /// <summary>
    /// Descripción breve de Arena
    /// Clase en la que se definen todos los elementos del regulación actores,funcionalidades,...
    /// </summary>
    public class Arena : ElementMARS, IArena
    {
        //atributos privados
        private List<Role> roles;
        private List<RoleActancial> rolesactancial;
        private List<Actor> actors;
        private List<Object> objects;
        private List<Scenario> scenarios;
        private List<ActionMARS> actions;

        //constructor
        public Arena()
        {
        }

        public void createArena()
        {
            roles = new List<Role>();
            rolesactancial = new List<RoleActancial>();
            objects = new List<Object>();
            actors = new List<Actor>();
            scenarios = new List<Scenario>();
            actions = new List<ActionMARS>();

        }

        public List<Role> Roles
        {
            set { }
            get { return roles; }
        }

        public List<RoleActancial> RolesActancial
        {
            set { }
            get { return rolesactancial; }
        }


        public List<Actor> Actors
        {
            set { }
            get { return actors; }
        }

        public List<Scenario> Scenarios
        {
            set { }
            get { return scenarios; }
        }


        public List<ActionMARS> Actions
        {
            set { }
            get { return actions; }
        }


        //Inician métodos para validar datos cadenas,enteros, atributos de la clase
        public static Boolean ValidateVal(string cad)
        {
            if (cad.CompareTo("") != 0)
                return true;
            else
                return false;
        }

        public static Boolean ValidateVal(int value)
        {
            if (value != -1)
                return true;
            else
                return false;
        }

        //Metódos para validar
        private Boolean ValidateIdArena()
        {
            if (Id != -1)
                return true;
            else
                return false;
        }

        private Boolean ValidateNameArena()
        {
            if (Name.CompareTo("") != 0)
                return true;
            else
                return false;
        }

        //Terminan métodos para validar


        //Agregar arena
        public int addArena()
        {
            if (ValidateVal(Name))
                return new AccesoDatos().AddArena(Name);
            return -1;
        }

        //Metódos para definir arena
        //Método para agregar actor a  una arena usando el nombre de la arena
        public int addActorToArena(Actor actor) //regresa 0 si es agregado
        {
            if (ValidateVal(Name) && ValidateVal(actor.Name))
                return new AccesoDatos().AddActorToArena(Name, actor.Name);
            return -1;
        }


        //Método para obtener dataset actores de una arena usando el nombre de la arena
        public DataSet getActorsOfArena() //regresa 0 si es agregado
        {
            if (ValidateVal(Name))
                return new AccesoDatos().GetActorsOfArena(Name);
            return null;
        }


        //Metódos para definir arena
        //Método para agregar acción o funcionalidad a una arena usando el nombre de la arena
        public int addActionToArena(ActionMARS action) //regresa 0 si es agregado
        {
            if (ValidateVal(Name) && ValidateVal(action.Name))
                return new AccesoDatos().AddActionToArena(Name, action.Name);
            return -1;
        }



        //Método para obtener dataset acciones de una arena usando el nombre de la arena
        public DataSet getActionsOfArena() //regresa 0 si es agregado
        {
            if (ValidateVal(Name))
                return new AccesoDatos().GetActionsOfArena(Name);
            return null;
        }


        //Elimina actor de la arena, primero si intenta eliminar el actor con el id
        //si no se establece id se elimina con nombre o login

        public int delActorOfArena(Actor actor) //regresa 0 si es agregado
        {
            if (ValidateVal(actor.Id) && ValidateVal(Id))
                return new AccesoDatos().DelActorOfArena(Id, actor.Id);

            else
                if (ValidateVal(Name) && ValidateVal(actor.Name))
                    return new AccesoDatos().DelActorOfArena(Name, actor.Name);

            return -1;
        }


        public int delArena() //regresa 0 si es eliminado
        {
            if (ValidateVal(Id))
                return new AccesoDatos().DelArena(Id);

            else
                if (ValidateVal(Name))
                    return new AccesoDatos().DelArena(Name);

            return -1;
        }


        public int updateArena() //regresa diferente de 0 si es modificado
        {
            if (ValidateVal(Id) && ValidateVal(Name))
                return new AccesoDatos().updateArena(Id, Name);

            return -1;
        }



        //Elimina action de la arena, primero si intenta eliminar la action con el id
        //si no se establece id se elimina con nombre 

        public int delActionOfArena(ActionMARS action) //regresa 0 si es agregado
        {
            if (ValidateVal(Id) && ValidateVal(action.Id))
                return new AccesoDatos().DelActionOfArena(Id, action.Id);

            else
                if (ValidateVal(Name) && ValidateVal(action.Name))
                    return new AccesoDatos().DelActionOfArena(Name, action.Name);

            return -1;
        }



        //Metódos para definir arena
        //Método para agregar objeto a  una arena usando el nombre de la arena
        public int addObjectToArena(Object obj) //regresa 0 si es agregado
        {
            if (ValidateVal(Name) && ValidateVal(obj.Name))
                return new AccesoDatos().AddObjectToArena(Name, obj.Name);
            return -1;
        }

        //Add Role Actancial a una arena
        public int addRoleActToArena(RoleActancial role) //regresa 0 si es agregado
        {
            if (ValidateVal(Name) && ValidateVal(role.Name))
                return new AccesoDatos().AddRoleActToArena(Name, role.Name);
            return -1;
        }


        //Método para obtener dataset objetos de una arena usando el nombre de la arena
        public DataSet getObjectsOfArena() //regresa null si hay error
        {
            if (ValidateVal(Name))
                return new AccesoDatos().GetObjectsOfArena(Name);
            return null;
        }


        //Método para obtener dataset arenas de una arena usando el nombre de la arena
        public DataSet getArenas() //regresa null si hay error
        {
            return new AccesoDatos().GetArenas();

        }

        ///<summary>
        /// Método para obtener dataset de una arena con id
        ///</summary>
        public DataSet getScenariosOfArena() //regresa null si hay error
        {
            if (Arena.ValidateVal(Name))
                return new AccesoDatos().GetScenariosOfArena(Name);
            else
                return null;
        }

        ///<summary>
        ///Método para obtener dataset de una arena con id
        ///</summary>
        public DataSet getArena() //regresa null si hay error
        {
            if (Arena.ValidateVal(Id))
                return new AccesoDatos().GetArena(Id);
            else
                return null;
        }

        ///<summary>
        ///Método para obtener id de una arena,
        /// regresa 0 si no existe
        ///</summary>
        public string getArenaId() //regresa 0 si hay error
        {
            string id = "";
            if (Arena.ValidateVal(Name))
            {
                try
                {
                    id = new AccesoDatos().GetArenaId(Name).Tables[0].Rows[0]["IdArena"].ToString();
                }
                catch
                {
                    ;
                }
            }
            return id;
        }


        ///<summary>
        ///Método para obtener id de una scenario,
        /// regresa 0 si no existe
        ///</summary>
        public string getScenarioId(string namescenario) //regresa 0 si hay error
        {
            Scenario scenario = new Scenario(); 
            scenario.Name = namescenario;
            string id = "0";
            if (Arena.ValidateVal(Name))
            {
                try
                {
                    id = scenario.getScenarioId(namescenario);
                }
                catch
                {
                    
                }
            }
            return id;
        }


        ///<summary>
        /// Método para obtener datos de un scenario,
        /// regresa 0 si no existe
        ///</summary>
        public DataSet getScenarioData(string nameaction, string namescenario) //regresa 0 si hay error
        {
            Scenario scenario = new Scenario();
            scenario.Name = namescenario;
            
            if (Arena.ValidateVal(Name))
            {
                try
                {
                    return scenario.getScenarioData(Name,nameaction);
                }
                catch
                {

                }
            }
            return null;
        }


        
        //Elimina object de la arena, primero si intenta eliminar el objeto con el id
        //si no se establece id se elimina con nombre
        public int delObjectOfArena(Object obj) //regresa 0 si es agregado
        {
            if (ValidateVal(Id) && ValidateVal(obj.Id))
                return new AccesoDatos().DelObjectOfArena(Id, obj.Id);

            else
                if (ValidateVal(Name) && ValidateVal(obj.Name))
                    return new AccesoDatos().DelObjectOfArena(Name, obj.Name);

            return -1;
        }


        //Método para agregar rol a  una arena usando el nombre de la arena 
        public int addRoleToArena(Role role) //regresa 0 si es agregado
        {
            if (Arena.ValidateVal(Name) && Arena.ValidateVal(role.Name))
                return new AccesoDatos().AddRoleToArena(Name, role.Name);
            return -1;
        }

        //Método para obtener dataset roles de una arena usando el nombre de la arena
        public DataSet getRolesOfArena() //regresa 0 si es agregado
        {
            if (ValidateVal(Name))
                return new AccesoDatos().GetRolesOfArena(Name);
            return null;
        }

        //Método para obtener dataset roles de una arena usando el nombre de la arena
        public DataSet getRoleOfActor(Actor actor)
        {
            if (ValidateVal(Name) && ValidateVal(actor.Name))
                return new AccesoDatos().GetRoleOfActor(Name, actor.Name);
            return null;
        }

        //Método para obtener dataset roles actanciales de una arena usando el nombre de la arena
        public DataSet getRolesActOfArena() //regresa 0 si es agregado
        {
            if (ValidateVal(Name))
                return new AccesoDatos().GetRolesActOfArena(Name);
            return null;
        }


        //Elimina role de la arena, primero si intenta eliminar el role con el id
        //si no se establece id se elimina con nombre  role
        public int delRoleOfArena(Role role) //regresa 0 si es agregado
        {
            if (Arena.ValidateVal(Id) && Arena.ValidateVal(role.Id))
                return new AccesoDatos().DelRoleOfArena(Id, role.Id);

            else
                if (Arena.ValidateVal(Name) && Arena.ValidateVal(role.Name))
                    return new AccesoDatos().DelRoleOfArena(Name, role.Name);

            return -1;
        }

        //Eliminar role actancial de la arena
        public int delRoleActOfArena(RoleActancial role) //regresa 0 si es agregado
        {
            if (Arena.ValidateVal(Name) && Arena.ValidateVal(role.Name))
                return new AccesoDatos().DelRoleActOfArena(Name, role.Name);

            return -1;
        }

    }
}