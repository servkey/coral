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
        if (Request.RequestType == "GET")
            LoadOptions();
    }

    protected void LoadOptions()
    {
        string option1 = Request.QueryString["option"];
        string name = "";
        int option;
        LogicaNegocio logneg = new LogicaNegocio();
        string namefieldvalue = "Id?";
        
        if (option1 != null)
            if (Int32.TryParse(option1,out option)){
            //Actores
                txtOption.Value = option1;
                switch (option)
                {
                    case 1:
                        //Actores
                        name = "actores";
                        lstElements.DataSource = logneg.Ledeer().DefinitionLEDEER().getActors().Tables[0];
                        namefieldvalue = "IdActor";

                        break;
                    case 2:
                        //Roles
                        name = "roles";
                        lstElements.DataSource = logneg.Ledeer().DefinitionLEDEER().getRoles().Tables[0];
                        namefieldvalue = "IdRole";

                        break;
                    case 3:
                        //Roles actanciales
                        name = "roles actanciales";
                        lstElements.DataSource = logneg.Ledeer().DefinitionLEDEER().getRolesActancial().Tables[0];
                        namefieldvalue = "IdRoleAct";

                        break;
                    case 4:
                        //Objectos
                        name = "objetos";
                        lstElements.DataSource = logneg.Ledeer().DefinitionLEDEER().getObjects().Tables[0];
                        namefieldvalue = "IdObject";

                        break;
                    case 5:
                        //Actions
                        name = "acciones";
                        lstElements.DataSource = logneg.Ledeer().DefinitionLEDEER().getActions().Tables[0];
                        namefieldvalue = "IdAction";

                        break;
                    case 6:
                        //Arenas
                        name = "arenas";
                        lstElements.DataSource = logneg.Ledeer().DefinitionLEDEER().getArenas().Tables[0];
                        namefieldvalue = "IdArena";

                        break;

                    default:
                        break; //Sin significado
                }
                lnkDefinition.Text = lnkDefinition.Text + " " + name;
                lnkCreate.Text = lnkCreate.Text + " " + name;
                lblSelect.Text = lblSelect.Text + " " + name;
                lnkDefinition.NavigateUrl = "~/frmDefinitions.aspx?option="+option1;

                lstElements.DataTextField = "AtrName";
                lstElements.DataValueField = namefieldvalue;
                lstElements.DataBind();

            }

    }

    protected void Button2_Click(object sender, EventArgs e)
    {

        Response.Redirect("~/frmDefinitions.aspx?option="+txtOption.Value);
    }
    protected void Button1_Click(object sender, EventArgs e)
    {

        Response.Redirect("~/frmShow.aspx?option=" + txtOption.Value);
        
    }
}
