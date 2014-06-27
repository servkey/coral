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
            LogicaNegocio logneg = new LogicaNegocio();

            lstArenas.DataSource = logneg.Ledeer().DefinitionLEDEER().getArenas().Tables[0];

            lstArenas.DataTextField = "AtrName";
            lstArenas.DataValueField = "IdArena";
            lstArenas.DataBind();
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
                lnkArena.NavigateUrl = "~/frmDefinitions.aspx?option=" + option1;
                txtElement.Value = option1;
            }
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/frmDefinitions.aspx?option=" + txtElement.Value);
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/frmAdminArena1.aspx?" + "option=" + txtElement.Value + "&id="+lstArenas.SelectedItem.Value);
    }
    protected void lstArenas_SelectedIndexChanged(object sender, EventArgs e)
    {
    
    }
    protected void btnCancelar_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/frmDefinitions.aspx?option=" + txtElement.Value);
    }
}
