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

            
            lstObjects.DataSource = logneg.Ledeer().DefinitionLEDEER().getObjects().Tables[0];

            // lstArenas.DataMember  = "AtrName"; 
            lstObjects.DataTextField = "AtrName";
            lstObjects.DataValueField = "IdObj";
            lstObjects.DataBind();
            lstValues1.DataTextField = "AtrVal";
            lstValues1.DataValueField = "IdObj";
            lstValues1.DataSource = lstObjects.DataSource;
            lstValues1.DataBind();
            

            for (int i = 0; i < lstObjects.Items.Count; i++)
            {
                lstElements.Items.Add(lstObjects.Items[i]+  ", valor: "+  lstValues1.Items[i]);
            }


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
                lnkObject.NavigateUrl = "~/frmDefinitions.aspx?option=" + option1;
                txtElement.Value = option1;
            }
    }


    protected void Button2_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/frmDefinitions.aspx?option=" + txtElement.Value);
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        
    }
    protected void lstArenas_SelectedIndexChanged(object sender, EventArgs e)
    {
       
    }
    protected void btnUpdate_Click(object sender, EventArgs e)
    {

        Response.Redirect("~/frmShowObjects.aspx?option=" + txtElement.Value);
    }
    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/frmDefinitions.aspx?option=" + txtElement.Value);
    }
   
}
