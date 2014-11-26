using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplication1.Controllers;

namespace WebApplication1
{
    public partial class RegistroCaso : System.Web.UI.Page
    {
        string name;
        string cont;
        bool ok;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                name = nombre.Text;
                cont = pass.Text;
                if (String.IsNullOrEmpty(name) || String.IsNullOrEmpty(cont))
                {
                    ok = false;
                    showAlert("Llene ambos campos de registro.");
                }else{
                    ok = true;
                }
            }
        }

        protected void registrar(object sender, EventArgs e)
        {
            if (ok)
            {
                DBM dbm = new DBM(new Connection());
                Dictionary<string,string> fieldValue = new Dictionary<string,string>();
                fieldValue.Add("nombre", name);
                fieldValue.Add("contraseña", cont);
                if (dbm.addRecord("CasosEstudio", fieldValue))
                {
                    showAlert("los datos se agregaron correctamente");
                    Server.Transfer("Login.aspx", true);
                }
            }
        }

        private void showAlert(string alerta)
        {
            System.Web.HttpContext.Current.Response.Write("<SCRIPT LANGUAGE='JavaScript'>alert('" + alerta + "')</SCRIPT>");
        }
    }
}