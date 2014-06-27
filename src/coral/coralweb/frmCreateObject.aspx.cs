using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
namespace CoRaL
{
    public partial class frmCreateObject : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack && !IsCallback)
            {
                LoadOption();
            }


        }

        protected void LoadOption()
        {
            string option1 = Request.QueryString["option"];

            int option;

            if (option1 != null)
                if (Int32.TryParse(option1, out option))
                {
                    lnkDefinition.NavigateUrl = "~/frmDefinitions.aspx?option=" + option1;
                    txtElement.Value = option1;
                }
        }


        protected void Button2_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/frmDefinitions.aspx?option=" + txtElement.Value);
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            //Response.Write(txtName.Text + "  " + txtValue.Text);
            //new AccesoDatos().AddObject("objecto", "objeto");

            if (new LogicaNegocio().Ledeer().DefinitionLEDEER().addObject(txtName.Text, txtValue.Text) == 0)
            {
                MessageBox.MessageBox.Show("Objeto creado");
                //Response.Write("<script>alert('Objeto creado')</script>");
                Response.Redirect("~/frmDefinitions.aspx?option=" + txtElement.Value);
            }
            else
                MessageBox.MessageBox.Show("El objeto no pudo ser creado");
            //Response.Write("<script>alert('El objeto no pudo ser creado')</script>");

        }
    }

}