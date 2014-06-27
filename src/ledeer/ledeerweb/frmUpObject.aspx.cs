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

public partial class _Default : System.Web.UI.Page
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
                LogicaNegocio logneg = new LogicaNegocio();

                lstObjects.DataSource = logneg.Ledeer().DefinitionLEDEER().getObjects().Tables[0];
                lstObjects.DataTextField = "AtrName";
                lstObjects.DataValueField = "IdObj";
                lstObjects.DataBind();
                
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
        int id;
        if (Int32.TryParse(lstObjects.SelectedItem.Value, out id))
        {
            if (new LogicaNegocio().Ledeer().DefinitionLEDEER().updateObject(id, txtName.Text, txtValue.Text) != 0)
            {
                //   Response.Write("<script>alert('Objeto modificado')</script>");
                MessageBox.MessageBox.Show("Objeto modificado");
                Response.Redirect("~/frmDefinitions.aspx?option=" + txtElement.Value);
            }
            else
                MessageBox.MessageBox.Show("El objeto no pudo ser modificado");
               // Response.Write("<script>alert('El objeto no pudo ser modificado')</script>");
            
        }
    }
    protected void lstArenas_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}
