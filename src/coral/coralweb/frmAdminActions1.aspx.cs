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
    public partial class frmAdminActions1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.RequestType == "GET" && !IsPostBack && !IsCallback)
                LoadOptions();
        }

        protected void LoadOptions()
        {
            string option1 = Request.QueryString["option"];
            string id1 = Request.QueryString["id"];
            int option;
            int id;
            LogicaNegocio logneg = new LogicaNegocio();


            if (option1 != null)
            {
                if (Int32.TryParse(option1, out option) && Int32.TryParse(id1, out id))
                {
                    //Actores
                    txtOption.Value = option1;
                    txtId.Value = id1;

                    string name = (String)(logneg.Ledeer().DefinitionLEDEER().getArena(id).Tables[0].Rows[0]["AtrName"]);
                    lblSelect.Text = name;

                    //Actors
                    lstActorsF.DataSource = logneg.Ledeer().DefinitionLEDEER().getActors().Tables[0];
                    lstActors.DataSource = logneg.Ledeer().DefinitionLEDEER().getActorsOfArena(name);

                    //Roles
                    lstActorsF.DataSource = logneg.Ledeer().DefinitionLEDEER().getRoles().Tables[0];
                    lstRoles.DataSource = logneg.Ledeer().DefinitionLEDEER().getRolesOfArena(name);




                    lnkDefinition.NavigateUrl = "~/frmDefinitions.aspx?option=" + option1;



                    lstActors.DataTextField = "AtrName";
                    lstActors.DataValueField = "IdActor";
                    lstActors.DataBind();

                    lstRoles.DataTextField = "AtrName";
                    lstRoles.DataValueField = "IdRole";
                    lstRoles.DataBind();

                    lstActorsF.DataTextField = "AtrName";
                    lstActorsF.DataValueField = "IdRole";
                    lstActorsF.DataBind();

                    lstRolesAct.DataTextField = "AtrName";
                    lstRolesAct.DataValueField = "IdRoleAct";
                    lstRoles.DataBind();

                    lstRolesActL.DataTextField = "AtrName";
                    lstRolesActL.DataValueField = "IdRoleAct";
                    lstRolesActL.DataBind();



                    lstRolesAct.DataTextField = "AtrName";
                    lstRolesAct.DataValueField = "IdRoleAct";
                    lstRolesAct.DataBind();

                    lstRolesActL.DataTextField = "AtrName";
                    lstRolesActL.DataValueField = "IdRoleAct";
                    lstRolesActL.DataBind();
                }

            }
        }

        protected void Button2_Click(object sender, EventArgs e)
        {

            Response.Redirect("~/frmDefinitions.aspx?option=" + txtOption.Value);
        }
        protected void Button1_Click(object sender, EventArgs e)
        {

        }

        protected void lstEle_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


        protected void addRole_Click(object sender, EventArgs e)
        {
        }
        protected void delRole_Click(object sender, EventArgs e)
        {
        }
        protected void btnDelRoleAct_Click(object sender, EventArgs e)
        {
        }

        protected void btnAddAction_Click(object sender, EventArgs e)
        {
        }

        protected void btnDelAction_Click(object sender, EventArgs e)
        {
        }
        protected void btnAddObject_Click(object sender, EventArgs e)
        {
        }
        protected void btnDelObject_Click(object sender, EventArgs e)
        {
        }
        protected void btnAddRoleAct_Click(object sender, EventArgs e)
        {
        }
        protected void btnAdminActors_Click(object sender, EventArgs e)
        {
            //Administrar actores
            Response.Redirect("~/frmAdminActors.aspx?option=" + txtOption.Value + "&id=" + txtId.Value);
        }
        protected void btnAdminActions_Click(object sender, EventArgs e)
        {
            //Administrar funcionalidades
            Response.Redirect("~/frmAdminActions.aspx?option=" + txtOption.Value + "&id=" + txtId.Value);
        }
    }
}