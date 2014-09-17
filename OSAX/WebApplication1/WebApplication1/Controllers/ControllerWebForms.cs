using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Controllers
{
    public class ControllerWebForms
    {
        System.Web.UI.Page webPage;
        public int numeroCampos { get; set; }

        public ControllerWebForms(System.Web.UI.Page webPage)
        {
            this.webPage = webPage;
        }

        public void fillForm()
        {                        
            for (int i = 0; i < numeroCampos; i++)
                addControls(i);
        }

        private void addControls(int id)
        {
            System.Web.UI.WebControls.Panel divRow = new System.Web.UI.WebControls.Panel();
            divRow.CssClass = "divrow";
            System.Web.UI.WebControls.Label namel = new System.Web.UI.WebControls.Label();
            namel.Text = "Nombre:";
            namel.CssClass = "label label-default";
            System.Web.UI.WebControls.TextBox nameIn = new System.Web.UI.WebControls.TextBox();
            nameIn.ID = "nombre_" + id;
            System.Web.UI.WebControls.Label value = new System.Web.UI.WebControls.Label();
            value.Text = "Valor:";
            value.CssClass = "label label-default";
            System.Web.UI.WebControls.DropDownList values = new System.Web.UI.WebControls.DropDownList();
            values.ID = "valor_" + id;
            values.Items.Add(new System.Web.UI.WebControls.ListItem("Cadena", "cadena"));
            values.Items.Add(new System.Web.UI.WebControls.ListItem("Entero", "entero"));
            values.Items.Add(new System.Web.UI.WebControls.ListItem("Real", "real"));
            values.Items.Add(new System.Web.UI.WebControls.ListItem("Booleano", "bool"));

            divRow.Controls.Add(namel);
            divRow.Controls.Add(nameIn);
            divRow.Controls.Add(value);
            divRow.Controls.Add(values);


            webPage.Form.FindControl("MainContent_formulario").Controls.Add(divRow);

            //showAlert("");
        }

        private string toJson(Dictionary<string, string> map)
        {
            string res = "{ ";
            foreach (KeyValuePair<string, string> pair in map)
                res += '"' + pair.Key + '"' + ':' + '"' + pair.Value + '"' + ' ';
            res += "}";
            return res;
        }

        private void showAlert(string alerta)
        {
            System.Web.HttpContext.Current.Response.Write("<SCRIPT LANGUAGE='JavaScript'>alert('" + alerta + "')</SCRIPT>");
        }
    }
}