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
    /// Descripción breve de Object
    /// clase para Objetos que participan en la arena
    /// </summary>
    public class Object : ElementMARS,IObject
    {
        //atributos privados
        private string val;
        private AccesoDatos ledeer_data;
        public Object()
        {
            val = "";
            ledeer_data = new AccesoDatos();
        }

        public string Value
        {
            set { val = value; }
            get { return val; }
        }

        //Métodos para trabajar con la capa de Acceso a Datos
        //Agregar objeto
        public int addObject() //regresa 0 si es agregado
        {
            if (Arena.ValidateVal(Name) && Arena.ValidateVal(val))
            {
                return ledeer_data.AddObject(Name, val);
            }
            else
                return -1;
        }



        //Método para eliminar objeto,
        //Elimina  el escenario si se ha establecido el atributo Id,
        //En caso de que el atributo Id no sea inicializado
        //Se elimina el scenario de acuerdo al atributo Name,
        //Si ningúno de los atributos ha sido definido no sé elimina.


        public int delObject() //regresa 0 si es eliminado
        {
            if (Arena.ValidateVal(Id))
                return ledeer_data.DelObject(Id);
            else
                if (Arena.ValidateVal(Name))
                    return ledeer_data.DelObject(Name);
            return -1; //No es insertado
        }

        //Actualizar objeto
        public int updateObject() //regresa diferente de 0 si es actualizado
        {
            if (Arena.ValidateVal(Id) && Arena.ValidateVal(Name) && Arena.ValidateVal(val))
                return ledeer_data.updateObject(Id, Name, val);
            return -1;
        }

        //Método para obtener objetos
        public DataSet getObjects()
        {
            return new AccesoDatos().GetObjects();
        }

    }
}