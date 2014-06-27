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
    /// Descripción breve de RoleActancial
    /// Define role actancial de los actores 
    /// rol asignado cuando se realiza una interacción
    /// </summary>
    public class RoleActancial : ElementMARS, IRoleActancial
    {
        //Atributos privados
        private AccesoDatos ledeer_data;
        //constructor
        public RoleActancial()
        {
           ledeer_data = new AccesoDatos();
        }

     
        //Métodos para trabajar con la capa de Acceso a Datos
        //Agregar role actancial
        public int addRoleActancial() //regresa 0 si es agregado
        {
            if (Arena.ValidateVal(Name))
            {
                return ledeer_data.AddRoleAct(Name);
            }
            else
                return -1;
        }

        //Método para eliminar role ,
        //Elimina  el role actancial si se ha establecido el atributo Id,
        //En caso de que el atributo idrole no sea inicializado
        //Se elimina el role actancial de acuerdo al atributo Name,
        //Si ningúno de los atributos ha sido definido no sé elimina.
        public int delRoleActancial() //regresa 0 si es agregado
        {
            if (Arena.ValidateVal(Id))
                return ledeer_data.DelRoleActancial(Id);
            else
                if (Arena.ValidateVal(Name))
                    return ledeer_data.DelRoleActancial(Name);
            return -1; //No es insertado
        }

        public int updateRoleActancial() //regresa diferente de 0 si es actualizado
        {
            if (Arena.ValidateVal(Id) && Arena.ValidateVal(Name))
                return ledeer_data.updateRoleActancial(Id, Name);
            return -1;
        }

        //Método para obtener roles actanciales
        public DataSet getRolesActancial()
        {
            return new AccesoDatos().GetRolesActancial();
        }

    }
}