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
using MessageBox;
namespace CoRaL
{
    public partial class frmCreate : System.Web.UI.Page
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
                            break;
                        case 2:
                            //Roles
                            name = "role";
                            break;
                        case 3:
                            //Roles actanciales
                            name = "role actancial";
                            break;
                        case 4:
                            //Objectos
                            name = "objeto";
                            break;
                        case 5:
                            //Actions
                            name = "funcionalidad";
                            lblName.Text = lblName.Text + " de la " + name;
                            break;
                        case 6:
                            //Arenas
                            name = "arena";
                            break;
                        default:
                            break; //Sin significado
                    }
                    lnkDefinition.Text = lnkDefinition.Text + " " + name;
                    lnkCreate.Text = lnkCreate.Text + " " + name;
                    if (option != 5)
                        lblName.Text = lblName.Text + " del " + name;

                    lnkDefinition.NavigateUrl = "~/frmDefinitions.aspx?option=" + option1;
                }

        }

        protected void Button2_Click(object sender, EventArgs e)
        {

            Response.Redirect("~/frmDefinitions.aspx?option=" + txtOption.Value);
        }
        protected void Button1_Click(object sender, EventArgs e)
        {

            int option = 0;
            if (Int32.TryParse(txtOption.Value, out option))
            {
                int res = -1;
                LogicaNegocio logneg = new LogicaNegocio();
                switch (option)
                {
                    case 1:
                        //Actores
                        res = logneg.Ledeer().DefinitionLEDEER().addActor(txtName.Text);
                        break;
                    case 2:
                        //Roles
                        res = logneg.Ledeer().DefinitionLEDEER().addRole(txtName.Text);
                        break;
                    case 3:
                        //Roles actanciales
                        res = logneg.Ledeer().DefinitionLEDEER().addRoleActancial(txtName.Text);
                        break;
                    case 4:
                        //Objectos

                        break;
                    case 5:
                        //Actions
                        res = logneg.Ledeer().DefinitionLEDEER().addAction(txtName.Text);
                        break;

                    case 6:
                        //Arenas
                        res = logneg.Ledeer().DefinitionLEDEER().addArena(txtName.Text);
                        break;

                    default:
                        break; //Sin significado
                }
                if (res == 0)
                {
                    MessageBox.MessageBox.Show("Elemento creado");
                    //Response.Write("<script>alert(' Elemento creado ')</script>");
                    Response.Redirect("~/frmDefinitions.aspx?option=" + txtOption.Value);
                }
                else
                    MessageBox.MessageBox.Show("El elemento no pudo ser creado");
                //Response.Write("<script>alert('El elemento no pudo ser creado')</script>");
            }


        }
    }

}