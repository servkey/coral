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
            LoadOption();
        }
   

    }

    protected void LoadOption()
    {
        //Recuperar variables enviadas por el método GET

        string option1 = Request.QueryString["option"];
        string id1 = Request.QueryString["id"];
        string action = Request.QueryString["action"];

        int option,id;
        
        if (Int32.TryParse(option1, out option) && Int32.TryParse(id1,out id) && action.CompareTo("")!= 0)
        {
            lblName1.Text = (String)(new LogicaNegocio().Ledeer().DefinitionLEDEER().getArena(id).Tables[0].Rows[0]["AtrName"]);     
            lnkAdminArena.NavigateUrl = "~/frmAdminArena1.aspx?option=" + txtOption.Value + "&id=" + txtId.Value;
            lnkAdminAction.NavigateUrl = "~/frmAdminActions.aspx?option=" + txtOption.Value + "&id=" + txtId.Value;
            txtId.Value = id1;
            txtOption.Value = option1;
            txtAction.Value = action;
        }
    }


    protected void Button2_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/frmAdminActions.aspx?option=" + txtOption.Value + "&id=" + txtId.Value);
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        LogicaNegocio logneg = new LogicaNegocio();
        if (logneg.Ledeer().DefinitionLEDEER().addScenarioToAction(lblName1.Text, txtAction.Value, txtName.Text, txtDescription.Text) == 0)
        {
            
            //Response.Write("<script>alert('Escenario creado')</script>");
            MessageBox.MessageBox.Show("Escenario creado");
            string ids = txtName.Text;// (logneg.Ledeer().DefinitionLEDEER().getScenarioOfAction(lblName1.Text, txtAction.Value).Tables[0].Rows[0]["AtrName"].ToString());
            Response.Redirect("~/frmAdminActions2.aspx?option=" + txtOption.Value + "&id=" + txtId.Value + "&action="+ txtAction.Value + "&ids=" + ids);
        }
        else
        {
            MessageBox.MessageBox.Show("El escenario no pudo ser creado");
           //Response.Write("<script>alert('El escenario no pudo ser creado')</script>");
            //Response.Redirect("~/frmAdminActions.aspx?option=" + txtOption.Value + "&id=" + txtId.Value);
        }
    }
}
