using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebApplication1.Controllers;
using System.Web.Script.Serialization;
using System.Data.SqlClient;

namespace WebApplication1
{
    public partial class Actividades : System.Web.UI.Page
    {
        Dictionary<string, string> values;
        string nombre;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.IsPostBack)
                values = getValues();
        }

        protected void crearFormulario(object sender, EventArgs e)
        {
            String entrada = campos.Text;
            if (String.IsNullOrWhiteSpace(entrada))
                showAlert("Escribir número de campos");
            else
            {
                int noCampos = Int32.Parse(entrada);
                for (int i = 0; i < noCampos; i++)
                    addCampos(i);
                fillDropDown(metas, "Metas");
                fillDropDown(comunidades, "Comunidades");                
            }
        }


        private void addCampos(int numberId)
        {
            Panel divRow = new Panel();
            divRow.CssClass = "divrow";
            Label namel = new Label();
            namel.Text = "Descripción:";
            namel.CssClass = "label label-default";
            TextBox nameIn = new TextBox();
            nameIn.ID = "nombre_" + numberId;
            Label value = new Label();
            value.Text = "Tipo:";
            value.CssClass = "label label-default";
            DropDownList values = new DropDownList();
            values.ID = "valor_" + numberId;
            values.Items.Add(new ListItem("Cadena", "cadena"));
            values.Items.Add(new ListItem("Entero", "entero"));
            values.Items.Add(new ListItem("Real", "real"));
            values.Items.Add(new ListItem("Booleano", "bool"));

            divRow.Controls.Add(namel);
            divRow.Controls.Add(nameIn);
            divRow.Controls.Add(value);
            divRow.Controls.Add(values);

            this.formulario.Controls.Add(divRow);
        }

        protected void registrar(Object sender, EventArgs e)
        {
            Connection cn = new Connection();
            DBM dbcontroller = new DBM(cn);
            Dictionary<string, string> vals = new Dictionary<string, string>();
            vals.Add("atributos", toJson(values));
            vals.Add("F_ID_ME", metas.SelectedValue);
            vals.Add("F_ID_COM", comunidades.SelectedValue);
            vals.Add("nombre", nombre);
            vals.Add("ID_Caso",Session["idcaso"].ToString());
            if (dbcontroller.addRecord("Actividades", vals))
                showAlert("Los datos se agregaron correctamente.");
            else
                showAlert("Hubo problemas al agregar los datos.");
        }


        private void fillDropDown(DropDownList ddl,string table)
        {
            Connection cn = new Connection();
            DBM bdm = new DBM(cn);
            string query = "select ID,nombre from " + table + " where ID_Caso='" + Session["idcaso"].ToString() + "'";
            SqlDataReader res = bdm.readData(query);
            while (res.Read())
            {
                ListItem item = new ListItem(res.GetValue(1) + "", res.GetValue(0) + "");
                ddl.Items.Add(item);
            }
            res.Close();
            cn.closeConnection();

        }

        private Dictionary<string, string> getValues()
        {
            Dictionary<string, string> values = new Dictionary<string, string>();
            string name;
            string val;
            string entrada = this.campos.Text;
            int noCampos = Int32.Parse(entrada);
            for (int i = 0; i < noCampos; i++)
            {
                name = Request.Form["ctl00$MainContent$nombre_" + i];
                val = Request.Form["ctl00$MainContent$valor_" + i];
                if (!String.IsNullOrEmpty(name) && !String.IsNullOrEmpty(val))
                    values.Add(name, val);
            }
            nombre = nm.Text;
            return values;
        }

        private string toJson(Dictionary<string, string> map)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            string json = serializer.Serialize((object)map);
            return json;
        }

        private void showAlert(string alerta)
        {
            System.Web.HttpContext.Current.Response.Write("<SCRIPT LANGUAGE='JavaScript'>alert('" + alerta + "')</SCRIPT>");
        }
    }
}