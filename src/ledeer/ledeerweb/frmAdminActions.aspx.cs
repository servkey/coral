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
            LoadOptions();
        }
    }


    protected void LoadOptions()
    {
        try
        {
            txtOption.Value = Request.QueryString["option"];
            txtId.Value = Request.QueryString["id"];
            int id, option;
            if (Int32.TryParse(txtId.Value, out id) && Int32.TryParse(txtOption.Value, out option))
            {
                LogicaNegocio logneg = new LogicaNegocio();

                lblName.Text = (String)(logneg.Ledeer().DefinitionLEDEER().getArena(id).Tables[0].Rows[0]["AtrName"]);
                lstActions.DataSource = logneg.Ledeer().DefinitionLEDEER().getActionsOfArena(lblName.Text).Tables[0];

                lstActions.DataTextField = "AtrName";
                lstActions.DataValueField = "IdAction";
                lstActions.DataBind();


                lnkAdmArena.NavigateUrl = "~/frmAdminArena1.aspx?option=" + txtOption.Value + "&id=" + txtId.Value;
                lnkDefinirArena.NavigateUrl = "~/frmDefinitions.aspx?option=" + txtOption.Value;
                lnkAdminAction.NavigateUrl = "~/frmAdminActions.aspx?option=" + txtOption.Value + "&id=" + txtId.Value;
            }
        }catch{
        }
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        //Ir a escenario, sino existe se crea
        LogicaNegocio logneg = new LogicaNegocio();
        string ds = logneg.Ledeer().DefinitionLEDEER().getScenarioOfAction(lblName.Text, lstActions.SelectedItem.Text);
        if (ds.CompareTo(String.Empty) != 0)
             Response.Redirect("~/frmAdminActions2.aspx?option=" + txtOption.Value + "&id=" + txtId.Value +"&action="+ lstActions.SelectedItem.Text+"&ids="+ ds);     
        else
             Response.Redirect("~/frmCreateScenario.aspx?option=" + txtOption.Value + "&id=" + txtId.Value + "&action=" + lstActions.SelectedItem.Text);     
    }
    protected void lstArenas_SelectedIndexChanged(object sender, EventArgs e)
    {
    }
    protected void btnCancelar_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/frmAdminArena1.aspx?option=" + txtOption.Value + "&id=" + txtId.Value);
    }
  
}
