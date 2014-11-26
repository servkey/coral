using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplication1.Controllers;
using System.Data.SqlClient;

namespace WebApplication1
{
    public partial class Login : System.Web.UI.Page
    {
        string caseValue;
        string password;
        bool ok;
        protected void Page_Load(object sender, EventArgs e)
        {
            ok = false;
            fillDropDown(casos);
            if (this.IsPostBack)
            {
                caseValue = casos.SelectedValue;
                password = pass.Text;
                if (!String.IsNullOrEmpty(password) && !String.IsNullOrEmpty(caseValue))
                    ok = true;
                else
                    showAlert("Ambos campos deben de estar llenos");
            }

        }

        protected void loggear(object sender, EventArgs e)
        {
            if (ok)
            {
                Connection cn = new Connection();
                DBM mdb = new DBM(cn);
                SqlDataReader res = mdb.readData("select * from CasosEstudio where ID='" + caseValue + "' and contraseña='" + password + "'");
                if (!res.HasRows)
                {
                    showAlert("Contraseña incorrecta, inténtelo de nuevo.");
                }
                else
                {
                    Session["idcaso"] = caseValue;
                    Server.Transfer("Home.aspx", true);
                }
            }
        }

        private void fillDropDown(DropDownList ddl)
        {
            Connection cn = new Connection();
            DBM bdm = new DBM(cn);
            string query = "select ID,nombre from CasosEstudio";
            SqlDataReader res = bdm.readData(query);
            while (res.Read())
            {
                ListItem item = new ListItem(res.GetValue(1) + "", res.GetValue(0) + "");
                ddl.Items.Add(item);
            }
            res.Close();
            cn.closeConnection();

        }

        private void showAlert(string alerta)
        {
            System.Web.HttpContext.Current.Response.Write("<SCRIPT LANGUAGE='JavaScript'>alert('" + alerta + "')</SCRIPT>");
        }
    }
}