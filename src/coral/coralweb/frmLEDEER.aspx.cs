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
    public partial class frmLEDEER : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //AccesoDatos a = new AccesoDatos();
            LoadOptions();
            //a.AddArena("Proyecto LEDEER");

        }

        protected void LoadOptions()
        {
            //string idcomentario = Request.QueryString["idcomentario"];
            //Actors
            lnkActors.NavigateUrl = "frmDefinitions.aspx?option=1";
            //Roles
            lnkRoles.NavigateUrl = "frmDefinitions.aspx?option=2";
            //Roles Actanciales
            lnkRolesActanciales.NavigateUrl = "frmDefinitions.aspx?option=3";
            //Objects
            lnkObjects.NavigateUrl = "frmDefinitions.aspx?option=4";
            //Actions
            lnkActions.NavigateUrl = "frmDefinitions.aspx?option=5";
            //Arenas
            lnkArenas.NavigateUrl = "frmDefinitions.aspx?option=6";

        }
    }

}