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
    public partial class frmDelObject : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack && !IsCallback)
            {
                LogicaNegocio logneg = new LogicaNegocio();

                lstObjectos.DataSource = logneg.Ledeer().DefinitionLEDEER().getObjects().Tables[0];

                // lstArenas.DataMember  = "AtrName"; 
                lstObjectos.DataTextField = "AtrName";
                lstObjectos.DataValueField = "IdObj";
                lstObjectos.DataBind();
                txtElement.Value = Request.QueryString["option"];
                lnkObj.NavigateUrl = "~/frmDefinitions.aspx?option=" + txtElement.Value;

            }
        }
        protected void Button2_Click(object sender, EventArgs e)
        {
            lnkObj.NavigateUrl = "~/frmDefinitions.aspx?option=" + txtElement.Value;
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            int res = 0;
            if (Int32.TryParse(lstObjectos.SelectedItem.Value, out res))
                if (new LogicaNegocio().Ledeer().DefinitionLEDEER().delObject(res) == 0)
                {
                    //Response.Write("<script>alert('Objeto eliminado');</script>");
                    MessageBox.MessageBox.Show("Objeto eliminado");
                    Response.Redirect("~/frmDefinitions.aspx?option=" + txtElement.Value);
                }
                else
                    //Response.Write("<script>alert('Objeto no eliminado');</script>");
                    MessageBox.MessageBox.Show("El Objeto no pudo ser eliminado");

        }
        protected void lstArenas_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/frmDefinitions.aspx?option=" + txtElement.Value);
        }
    }

}