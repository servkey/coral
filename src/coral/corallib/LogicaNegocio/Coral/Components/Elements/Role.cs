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
    /// Descripción breve de Role
    /// papeles de los actores en la arena
    /// </summary>
    public class Role : ElementMARS, IRole
    {
        //atributos privados de Role
        private AccesoDatos ledeer_data;
        public Role()
        {
            ledeer_data = new AccesoDatos();
        }

        //métodos públicos para acceder a los atributos privados
        
        //Fin métodos get y set

        //Métodos para trabajar con la capa de Acceso a Datos
        //Agregar role
        public int addRole() //regresa 0 si es agregado
        {
            if (Arena.ValidateVal(Name))
            {
                return ledeer_data.AddRole(Name);
            }
            else
                return -1;
        }

        //Método para eliminar role,
        //Elimina  el role si se ha establecido el atributo Id,
        //En caso de que el atributo Id no sea inicializado
        //Se elimina el role de acuerdo al atributo Name,
        //Si ningúno de los atributos ha sido definido no sé elimina.
        public int delRole() //regresa 0 si es agregado
        {
            if (Arena.ValidateVal(Id))
                return ledeer_data.DelRole(Id);
            else
                if (Arena.ValidateVal(Name))
                    return ledeer_data.DelRole(Name);
            return -1; //No es insertado
        }

        public int updateRole() //regresa diferente de 0 si es actualizado
        {
            if (Arena.ValidateVal(Id) && Arena.ValidateVal(Name))
                return ledeer_data.updateRole(Id, Name);
            return -1;
        }


        //Método para obtener roles
        public DataSet getRoles()
        {
            return new AccesoDatos().GetRoles();
        }

        ///<summary>
        ///Método para obtener id de un role,
        /// regresa "0" si no existe
        ///</summary>
        public string getRoleId() //regresa "" si hay error
        {
            string id = "";
            if (Arena.ValidateVal(Name))
            {
                try
                {
                    id = new AccesoDatos().GetRoleId(Name).Tables[0].Rows[0]["IdRole"].ToString();
                }
                catch
                {
                    id = "0";
                }
            }
            return id;
        }

    }
}