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

        txtOption.Value = Request.QueryString["option"];
        txtId.Value = Request.QueryString["id"];
        int id, option;
        if (Int32.TryParse(txtId.Value,out id)&& Int32.TryParse(txtOption.Value,out option)){
            LogicaNegocio logneg = new LogicaNegocio();

            lblName.Text = (String)(logneg.Ledeer().DefinitionLEDEER().getArena(id).Tables[0].Rows[0]["AtrName"]);
            lstActors.DataSource = logneg.Ledeer().DefinitionLEDEER().getActorsOfArena(lblName.Text).Tables[0];
            
            lstActors.DataTextField = "AtrName";
            lstActors.DataValueField = "IdActor";
            lstActors.DataBind();

            lstRoles.DataSource = logneg.Ledeer().DefinitionLEDEER().getRolesOfArena(lblName.Text).Tables[0];
            lstRoles.DataTextField = "AtrName";
            lstRoles.DataValueField = "IdRole";
            lstRoles.DataBind();

            
            lnkAdmArena.NavigateUrl = "~/frmAdminArena1.aspx?option=" + txtOption.Value + "&id=" + txtId.Value;          
            lnkDefinirArena.NavigateUrl = "~/frmDefinitions.aspx?option=" + txtOption.Value;
        }
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        new LogicaNegocio().Ledeer().DefinitionLEDEER().delRoleOfActor(lblName.Text, lstActors.SelectedItem.Text);//: == 0)
        if (new LogicaNegocio().Ledeer().DefinitionLEDEER().addRoleToActor(lblName.Text, lstActors.SelectedItem.Text, lstRoles.SelectedItem.Text) == 0)
            MessageBox.MessageBox.Show("Role asignado al actor");
        else
            MessageBox.MessageBox.Show("Role no pudo ser asignado al actor");
    }
    protected void lstArenas_SelectedIndexChanged(object sender, EventArgs e)
    {
    }
    protected void btnCancelar_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/frmAdminArena1.aspx?option=" + txtOption.Value + "&id=" + txtId.Value);
    }
    protected void btnViewRole_Click(object sender, EventArgs e)
    {
     
        string ds;
        ds = new LogicaNegocio().Ledeer().DefinitionLEDEER().getRoleOfActor(lblName.Text, lstActors.SelectedItem.Text);
        if (ds != null && ds.CompareTo(String.Empty) != 0)
            //Response.Write("<script> alert('El role de " + lstActors.SelectedItem.Text + " es " + (String)(ds.Tables[0].Rows[0]["AtrNameRole"]) + "');</script>" );
            MessageBox.MessageBox.Show("El role de " + lstActors.SelectedItem.Text + " es " + ds);
        else
            MessageBox.MessageBox.Show("El actor " + lstActors.SelectedItem.Text + " no tiene un role asignado");
            //Response.Write("<script> alert('El actor " + lstActors.SelectedItem.Text + " no tiene un role asignado');</script>");
    }
}
