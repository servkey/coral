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
    public partial class frmDel : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack && !IsCallback)
            {
                //if (Request.RequestType == "GET")
                    LoadOptions();
            }

        }

        protected void LoadOptions()
        {

            LogicaNegocio logneg = new LogicaNegocio();
            string namefieldvalue = "Id?";
            string option1 = Request.QueryString["option"];
            string name = "";
            int option;

            if (option1 != null)
                if (Int32.TryParse(option1, out option))
                {
                    //Actores
                    txtOption.Value = option1;
                    switch (option)
                    {
                        case 1:
                            //Actores
                            name = "actor";
                            lstElements.DataSource = logneg.Ledeer().DefinitionLEDEER().getActors().Tables[0];
                            namefieldvalue = "IdActor";
                            break;
                        case 2:
                            //Roles
                            name = "role";
                            lstElements.DataSource = logneg.Ledeer().DefinitionLEDEER().getRoles().Tables[0];
                            namefieldvalue = "IdRole";
                            break;
                        case 3:
                            //Roles actanciales
                            name = "role actancial";
                            lstElements.DataSource = logneg.Ledeer().DefinitionLEDEER().getRolesActancial().Tables[0];
                            namefieldvalue = "IdRoleAct";
                            break;
                        case 4:
                            //Objectos
                            name = "objeto";
                            lstElements.DataSource = logneg.Ledeer().DefinitionLEDEER().getObjects().Tables[0];
                            namefieldvalue = "IdObject";
                            break;
                        case 5:
                            //Actions
                            name = "acción";
                            lstElements.DataSource = logneg.Ledeer().DefinitionLEDEER().getActions().Tables[0];
                            namefieldvalue = "IdAction";
                            break;
                        case 6:
                            //Arenas
                            name = "arena";
                            lstElements.DataSource = logneg.Ledeer().DefinitionLEDEER().getArenas().Tables[0];
                            namefieldvalue = "IdArena";
                            break;
                        default:
                            break; //Sin significado
                    }
                    lnkDefinition.Text = lnkDefinition.Text + " " + name;
                    lnkCreate.Text = lnkCreate.Text + " " + name;
                    lblName.Text = lblName.Text + " del " + name;
                    lnkDefinition.NavigateUrl = "~/frmDefinitions.aspx?option=" + option1;

                    lstElements.DataTextField = "AtrName";
                    lstElements.DataValueField = namefieldvalue;
                    lstElements.DataBind();

                }

        }

        protected void Button2_Click(object sender, EventArgs e)
        {

            Response.Redirect("~/frmDefinitions.aspx?option=" + txtOption.Value);
        }
        protected void Button1_Click(object sender, EventArgs e)
        {

            int option = 0; int id;
            if (Int32.TryParse(txtOption.Value, out option) && Int32.TryParse(lstElements.SelectedItem.Value, out id))
            {
                int res = -1;
                LogicaNegocio logneg = new LogicaNegocio();
                switch (option)
                {
                    case 1:
                        //Actores
                        res = logneg.Ledeer().DefinitionLEDEER().delActor(id);
                        break;
                    case 2:
                        //Roles
                        res = logneg.Ledeer().DefinitionLEDEER().delRole(id);
                        break;
                    case 3:
                        //Roles actanciales
                        res = logneg.Ledeer().DefinitionLEDEER().delRoleActancial(id);
                        break;
                    case 4:
                        //Objectos
                        res = logneg.Ledeer().DefinitionLEDEER().delObject(id);
                        break;
                    case 5:
                        //Actions
                        res = logneg.Ledeer().DefinitionLEDEER().delAction(id);
                        break;
                    case 6:
                        res = logneg.Ledeer().DefinitionLEDEER().delArena(id);
                        break;
                    default:
                        break; //Sin significado
                }
                if (res == 0)
                {
                    MessageBox.MessageBox.Show("Elemento eliminado");
                    //Response.Write("<script>alert('Elemento eliminado ')</script>");
                    Response.Redirect("~/frmDefinitions.aspx?option=" + txtOption.Value);
                }
                else
                    //Response.Write("<script>alert('El elemento no pudo ser eliminado')</script>");
                    MessageBox.MessageBox.Show("El elemento no pudo ser eliminado");
            }

        }
    }

}