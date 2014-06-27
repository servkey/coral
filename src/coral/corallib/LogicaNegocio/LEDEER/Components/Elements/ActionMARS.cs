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

namespace MARS
{
    /// <summary>
    /// Descripción breve de Action
    /// </summary>
    public class ActionMARS : ElementMARS, IAction
    {
        private RoleActancial roleact;
        private AccesoDatos ledeer_data;
        private List<Scenario> scenarios;
        public ActionMARS()
        {
            //
            // TODO: Agregar aquí la lógica del constructor
            ledeer_data = new AccesoDatos();
            //
        }

        public void createScenarios()
        {
            scenarios = new List<Scenario>();
        }

        //Métodos para trabajar con la capa de Acceso a Datos
        //Agregar action
        public int addAction() //regresa 0 si es agregado
        {
            if (Arena.ValidateVal(Name))
            {
                return ledeer_data.AddAction(Name);
            }
            else
                return -1;
        }

        //Método para eliminar action,
        //Elimina  el action si se ha establecido el atributo Id,
        //En caso de que el atributo Id no sea inicializado
        //Se elimina el role de acuerdo al atributo Name,
        //Si ningúno de los atributos ha sido definido no sé elimina.
        public int delAction() //regresa 0 si es agregado
        {
            if (Arena.ValidateVal(Id))
                return ledeer_data.DelAction(Id);
            else
                if (Arena.ValidateVal(Name))
                    return ledeer_data.DelAction(Name);
            return -1; //No es insertado
        }

        public int updateAction() //regresa diferente de 0 si es actualizado
        {
            if (Arena.ValidateVal(Id) && Arena.ValidateVal(Name))
                return ledeer_data.updateAction(Id, Name);
            return -1;
        }


        //Método para agregar rol actancial a  una acción usando el nombre de la arena 
        public int addRoleActToAction(string namearena, RoleActancial role) //regresa 0 si es agregado
        {
            roleact = role;
            if (Arena.ValidateVal(namearena) && Arena.ValidateVal(Name) && Arena.ValidateVal(roleact.Name))
                return new AccesoDatos().AddRoleActToAction(namearena, Name, roleact.Name);
            return -1;
        }

        //Método para agregar scenario a  una acción usando el nombre de la arena 
        public int addScenarioToAction(string namearena, Scenario scenario) //regresa 0 si es agregado
        {
            if (Arena.ValidateVal(namearena) && Arena.ValidateVal(Name) && Arena.ValidateVal(scenario.Name))
                return new AccesoDatos().AddScenarioToAction(namearena, Name, scenario.Name, scenario.Description);
            return -1;
        }


        //Método para get scenario a  una acción usando el nombre de la arena 
        public DataSet getScenarioOfAction(string namearena) //regresa DataSet
        {
            if (Arena.ValidateVal(namearena) && Arena.ValidateVal(Name))
                return new AccesoDatos().GetScenarioOfAction(namearena, Name);
            return null;
        }



        //Método para eliminar scenario de una acción usando el nombre de la arena, nombre del escenario 
        public int delScenarioOfAction(string namearena, string namescenario) //regresa 0 si es eliminado
        {
            if (Arena.ValidateVal(namearena) && Arena.ValidateVal(Name) && Arena.ValidateVal(namescenario))
                return new AccesoDatos().DelScenarioOfAction(namearena, Name, namescenario);
            return -1;
        }
        //Método para eliminar scenario de una acción usando llaves de la arena, nombre del escenario 
        public int delScenarioOfAction(int idarena, int idscenario) //regresa 0 si es eliminado
        {
            if (Arena.ValidateVal(idarena) && Arena.ValidateVal(Id) && Arena.ValidateVal(idscenario))
                return new AccesoDatos().DelScenarioOfAction(idarena, Id, idscenario);
            return -1;
        }


        //Elimina role actancial de la arena, 
        //Se eliminan el rol actancial asociado a la arena y a la funcionalidad

        public int delRoleActOfAction(int idarena) //regresa 0 si es agregado
        {
            if (Arena.ValidateVal(Id))
                return new AccesoDatos().DelRolesActOfAction(idarena, Id);

            return -1;
        }

        //Elimina role actancial de la arena, acción, 
        //Se eliminan el rol actancial asociado a la arena y a la funcionalidad

        public int delRoleActOfAction(string namearena) //regresa 0 si es agregado
        {
            if (Arena.ValidateVal(Name))
                return new AccesoDatos().DelRolesActOfAction(namearena, Name);
            return -1;
        }


        //Elimina role actancial de la arena, 
        //Se eliminan el rol actancial asociado a la arena y a la funcionalidad
        public int delRoleActOfAction(RoleActancial role) //regresa 0 si es agregado
        {
            roleact = role;
            if (Arena.ValidateVal(Id) && Arena.ValidateVal(roleact.Id))
                return new AccesoDatos().DelRoleActOfAction(Id, roleact.Id);

            else
                if (Arena.ValidateVal(Name) && Arena.ValidateVal(roleact.Name))
                    return new AccesoDatos().DelRoleActOfAction(Name, roleact.Name);

            return -1;
        }

        //Método para obtener DataSet rol actancial a  una acción usando el nombre de la arena 
        public DataSet getRoleActOfAction(string namearena) //regrese dataset diferente de null
        {
            if (Arena.ValidateVal(namearena) && Arena.ValidateVal(Name))
                return new AccesoDatos().GetRoleActancialOfAction(namearena, Name);
            return null;
        }

        //Método para obtener actions
        public DataSet getActions()
        {
            return ledeer_data.GetActions();
        }



    }
}