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
    public partial class frmDefinitions : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
                Options();
            //AccesoDatos a = new AccesoDatos();

        }

        protected void Options()
        {
            string option1 = Request.QueryString["option"];
            string name = "";
            int option;
            string names = "";

            if (option1 != null)
                if (Int32.TryParse(option1, out option))
                {

                    string url = "?option=" + option1;

                    string framecreate = "~/frmCreate.aspx";
                    string framedel = "~/frmDel.aspx";
                    string frameupdate = "~/frmUpdate.aspx";
                    string frameshow = "~/frmShow.aspx";

                    //Actores
                    switch (option)
                    {
                        case 1:
                            //Actores
                            name = "actor";
                            names = "actores";
                            break;
                        case 2:
                            //Roles
                            name = "role";
                            names = "roles";
                            break;
                        case 3:
                            //Roles actanciales
                            name = "role actancial";
                            names = "roles actanciales";
                            break;
                        case 4:
                            //Objectos
                            name = "objeto";
                            names = "objetos";
                            framecreate = "~/frmCreateObject.aspx";
                            framedel = "~/frmDelObject.aspx";
                            frameupdate = "~/frmUpObject.aspx";
                            frameshow = "~/frmShowObjects.aspx";

                            break;
                        case 5:
                            //Actions
                            name = "funcionalidad";
                            names = "funcionalidades";
                            break;
                        case 6:
                            //Arenas
                            lnkAdmin.Visible = true;
                            lnkAdmin.NavigateUrl = "~/frmAdminArena.aspx" + url;
                            name = "arena";
                            names = "arenas";
                            break;
                        default:
                            break; //Sin significado
                    }


                    lnkCreate.NavigateUrl = framecreate + url;
                    lnkDel.NavigateUrl = framedel + url;
                    lnkUpdate.NavigateUrl = frameupdate + url;
                    lnkShow.NavigateUrl = frameshow + url;

                    lnkDefinition.Text = lnkDefinition.Text + " " + names;
                    lnkCreate.Text = lnkCreate.Text + " " + name;
                    lnkDel.Text = lnkDel.Text + " " + name;
                    lnkUpdate.Text = lnkUpdate.Text + " " + name;
                    lnkShow.Text = lnkShow.Text + " " + name;
                }
        }
    }

}