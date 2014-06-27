using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using DataAccess;

namespace MARS
{
    /// <summary>
    /// Descripción de actor
    /// clase de actores -los actores interactúan en ledeer y la herramienta groupware
    /// </summary>
    public class Actor : ElementMARS, IActor
    {
        private AccesoDatos ledeer_data;

        public Actor()
        {
            ledeer_data = new AccesoDatos();
        }

        public Boolean ValidateIdActor()
        {
            if (Id != -1)
                return true;
            else
                return false;
        }

        public Boolean ValidateNameActor()
        {
            if (Name.CompareTo("") != 0)
                return true;
            else
                return false;
        }

        //Terminan métodos para validar




        //Métodos para trabajar con la capa de Acceso a Datos
        public int addActor() //regresa 0 si es agregado
        {
            if (Arena.ValidateVal(Name))
            {
                return ledeer_data.AddActor(Name);
            }
            else
                return -1;
        }

        //Agregar role a actor
        public int addRoleToActor(string namearena, Role role)
        {
            if (Arena.ValidateVal(namearena) && Arena.ValidateVal(Name) && Arena.ValidateVal(role.Name))
                return ledeer_data.AddRoleToActor(namearena, Name, role.Name);
            else
                return -1;
        }


        //Eliminar role a actor
        public int delRoleOfActor(string namearena)
        {
            if (Arena.ValidateVal(namearena) && Arena.ValidateVal(Name))
                return ledeer_data.DelRoleOfActor(namearena, Name);
            else
                return -1;
        }

        //Método para obtener actores
        public DataSet getActors()
        {
            return ledeer_data.GetActors();
        }


        //Método para eliminar actor,
        //Elimina  el actor si se ha establecido el atributo Id,
        //En caso de que el atributo Id no sea inicializado
        //Se elimina el actor de acuerdo al atributo Name,
        //Si ningúno de los atributos ha sido definido no sé elimina.
        public int delActor() //regresa 0 si es agregado
        {
            if (Arena.ValidateVal(Id))
                return ledeer_data.DelActor(Id);
            else
                if (Arena.ValidateVal(Name))
                    return ledeer_data.DelActor(Name);
            return -1; //No es insertado
        }

        public int updateActor()//regresa diferente de 0 si es actualizado
        {
            if (Arena.ValidateVal(Id) && Arena.ValidateVal(Name))
                return ledeer_data.updateActor(Id, Name);
            return -1;
        }
    }

}