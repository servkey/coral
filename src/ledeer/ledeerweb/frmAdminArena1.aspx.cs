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
            if (Int32.TryParse(option1, out option) && Int32.TryParse(id1,out id))
            {
                //Actores
                txtOption.Value = option1;
                txtId.Value = id1;

                DataSet ds = logneg.Ledeer().DefinitionLEDEER().getArena(id);
                string name ="";
                if (ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    name = (String)(ds.Tables[0].Rows[0]["AtrName"]);
                    lblSelect.Text = name;

                    //Actors
                    
                    lstActorsL.DataSource = logneg.Ledeer().DefinitionLEDEER().getActors().Tables[0];
                    lstActors.DataSource = logneg.Ledeer().DefinitionLEDEER().getActorsOfArena(name);

                    //Roles
                    lstRolesL.DataSource = logneg.Ledeer().DefinitionLEDEER().getRoles().Tables[0];
                    lstRoles.DataSource = logneg.Ledeer().DefinitionLEDEER().getRolesOfArena(name);


                    //Acciones
                    lstActionsL.DataSource = logneg.Ledeer().DefinitionLEDEER().getActions();
                    lstActions.DataSource = logneg.Ledeer().DefinitionLEDEER().getActionsOfArena(name);

                    //Objetos
                    lstObjectsL.DataSource = logneg.Ledeer().DefinitionLEDEER().getObjects();
                    lstObjects.DataSource = logneg.Ledeer().DefinitionLEDEER().getObjectsOfArena(name);

                    //RolesActanciales
                    lstRolesActL.DataSource = logneg.Ledeer().DefinitionLEDEER().getRolesActancial();
                    lstRolesAct.DataSource = logneg.Ledeer().DefinitionLEDEER().getRolesActOfArena(name);


                    lnkDefinition.NavigateUrl = "~/frmDefinitions.aspx?option=" + option1;


                    ///Actores
                    lstActorsL.DataTextField = "AtrName";
                    lstActorsL.DataValueField = "IdActor";
                    lstActorsL.DataBind();

                    lstActors.DataTextField = "AtrName";
                    lstActors.DataValueField = "IdActor";
                    lstActors.DataBind();

                    lstRoles.DataTextField = "AtrName";
                    lstRoles.DataValueField = "IdRole";
                    lstRoles.DataBind();

                    lstRolesL.DataTextField = "AtrName";
                    lstRolesL.DataValueField = "IdRole";
                    lstRolesL.DataBind();

                    lstRolesAct.DataTextField = "AtrName";
                    lstRolesAct.DataValueField = "IdRoleAct";
                    lstRoles.DataBind();

                    lstRolesActL.DataTextField = "AtrName";
                    lstRolesActL.DataValueField = "IdRoleAct";
                    lstRolesActL.DataBind();


                    lstActions.DataTextField = "AtrName";
                    lstActions.DataValueField = "IdAction";
                    lstActions.DataBind();

                    lstActionsL.DataTextField = "AtrName";
                    lstActionsL.DataValueField = "IdAction";
                    lstActionsL.DataBind();

                    lstObjects.DataTextField = "AtrName";
                    lstObjects.DataValueField = "IdObj";
                    lstObjects.DataBind();


                    lstObjectsL.DataTextField = "AtrName";
                    lstObjectsL.DataValueField = "IdObj";
                    lstObjectsL.DataBind();


                    lstRolesAct.DataTextField = "AtrName";
                    lstRolesAct.DataValueField = "IdRoleAct";
                    lstRolesAct.DataBind();

                    lstRolesActL.DataTextField = "AtrName";
                    lstRolesActL.DataValueField = "IdRoleAct";
                    lstRolesActL.DataBind();

                }
            }
        }
    }

    protected void Button2_Click(object sender, EventArgs e)
    {

        Response.Redirect("~/frmDefinitions.aspx?option="+txtOption.Value);
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        //Agregar actor a arena
        for (int i = 0; i < lstActorsL.Items.Count; i++)
        {
            if (lstActorsL.Items[i].Selected)
                if (new LogicaNegocio().Ledeer().DefinitionLEDEER().addActorToArena(lblSelect.Text, lstActorsL.Items[i].Text) == 0)
                {
                    Response.Write("<script>alert('Actor agregado a la arena');</script>");
                }
                else
                    Response.Write("<script>alert('El actor no pudo se agregado a la arena');</script>");
        }
        Response.Redirect("~/frmAdminArena1.aspx?option=" + txtOption.Value + "&id=" + txtId.Value);        
    }

    protected void lstEle_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    protected void Quit_Click(object sender, EventArgs e)
    {
        //Quitar actor de la arena
        for (int i = 0; i < lstActors.Items.Count; i++)
        {
            if (lstActors.Items[i].Selected)
                if (new LogicaNegocio().Ledeer().DefinitionLEDEER().delActorOfArena(lblSelect.Text, lstActors.Items[i].Text) == 0)
                {
                    Response.Write("<script>alert('Actor eliminado de la arena');</script>");
                }
                else
                    Response.Write("<script>alert('El actor no pudo ser eliminado de la arena');</script>");
        }
        Response.Redirect("~/frmAdminArena1.aspx?option=" + txtOption.Value + "&id=" + txtId.Value);        
    }

    protected void addRole_Click(object sender, EventArgs e)
    {
        //Agregar role a arena
        for (int i = 0; i < lstRolesL.Items.Count; i++)
        {
            if (lstRolesL.Items[i].Selected)
                if (new LogicaNegocio().Ledeer().DefinitionLEDEER().addRoleToArena(lblSelect.Text, lstRolesL.Items[i].Text) == 0)
                {
                    Response.Write("<script>alert('Role agregado a la arena');</script>");
                }
                else
                    Response.Write("<script>alert('El role no pudo ser agregado a la arena');</script>");
        }
        Response.Redirect("~/frmAdminArena1.aspx?option=" + txtOption.Value + "&id=" + txtId.Value);
    }
    protected void delRole_Click(object sender, EventArgs e)
    {
        //Quitar role de la arena
        for (int i = 0; i < lstActors.Items.Count; i++)
        {
            if (lstRoles.Items[i].Selected)
                if (new LogicaNegocio().Ledeer().DefinitionLEDEER().delRoleOfArena(lblSelect.Text, lstRoles.Items[i].Text) == 0)
                {
                    Response.Write("<script>alert('Role eliminado de la arena');</script>");
                }
                else
                    Response.Write("<script>alert('El role no pudo ser eliminado de la arena');</script>");
        }
        Response.Redirect("~/frmAdminArena1.aspx?option=" + txtOption.Value + "&id=" + txtId.Value);
    }
    protected void btnDelRoleAct_Click(object sender, EventArgs e)
    {
        //Quitar role actancial  de la arena
        for (int i = 0; i < lstRolesAct.Items.Count; i++)
        {
            if (lstRolesAct.Items[i].Selected)
                if (new LogicaNegocio().Ledeer().DefinitionLEDEER().delRoleActOfArena(lblSelect.Text, lstRolesAct.Items[i].Text) == 0)
                {
                    Response.Write("<script>alert('Role actancial eliminado de la arena');</script>");
                }
                else
                    Response.Write("<script>alert('El role actancial no pudo ser eliminado de la arena');</script>");
        }
        Response.Redirect("~/frmAdminArena1.aspx?option=" + txtOption.Value + "&id=" + txtId.Value);
    }

    protected void btnAddAction_Click(object sender, EventArgs e)
    {
        //Agregar acción a arena
        
        for (int i = 0; i < lstActionsL.Items.Count; i++)
        {
            if (lstActionsL.Items[i].Selected)
                if (new LogicaNegocio().Ledeer().DefinitionLEDEER().addActionToArena(lblSelect.Text, lstActionsL.Items[i].Text) == 0)
                {
                    Response.Write("<script>alert('Funcionalidad agregada a la arena');</script>");

                }
                else
                    Response.Write("<script>alert('La funcionalidad no pudo ser agregada a la arena');</script>");
        }
        Response.Redirect("~/frmAdminArena1.aspx?option=" + txtOption.Value + "&id=" + txtId.Value);
    }

    protected void btnDelAction_Click(object sender, EventArgs e)
    {
        //Quitar acción de la arena
        for (int i = 0; i < lstActions.Items.Count; i++)
        {
            if (lstActions.Items[i].Selected)
                if (new LogicaNegocio().Ledeer().DefinitionLEDEER().delActionOfArena(lblSelect.Text, lstActions.Items[i].Text) == 0)
                {
                    Response.Write("<script>alert('Funcionalidad eliminada de la arena');</script>");
                }
                else
                    Response.Write("<script>alert('La funcionalidad no pudo ser eliminada de la arena');</script>");
        }
        Response.Redirect("~/frmAdminArena1.aspx?option=" + txtOption.Value + "&id=" + txtId.Value);
        
    }
    protected void btnAddObject_Click(object sender, EventArgs e)
    {
        //Agregar objeto a la arena

        for (int i = 0; i < lstObjectsL.Items.Count; i++)
        {
            if (lstObjectsL.Items[i].Selected)
                if (new LogicaNegocio().Ledeer().DefinitionLEDEER().addObjectToArena(lblSelect.Text, lstObjectsL.Items[i].Text) == 0)
                {
                    Response.Write("<script>alert('El objeto fue agregado a la arena');</script>");
                }
                else
                    Response.Write("<script>alert('El objeto no pudo ser agregado a la arena');</script>");
        }
        Response.Redirect("~/frmAdminArena1.aspx?option=" + txtOption.Value + "&id=" + txtId.Value);
        
     
    }
    protected void btnDelObject_Click(object sender, EventArgs e)
    {
        //Quitar objeto de la arena
        for (int i = 0; i < lstObjects.Items.Count; i++)
        {
            if (lstObjects.Items[i].Selected)
                if (new LogicaNegocio().Ledeer().DefinitionLEDEER().delObjectOfArena(lblSelect.Text, lstObjects.Items[i].Text) == 0)
                {
                    Response.Write("<script>alert('Objeto eliminado de la arena');</script>");
                }
                else
                    Response.Write("<script>alert('El objeto no pudo ser eliminado de la arena');</script>");
        }
        Response.Redirect("~/frmAdminArena1.aspx?option=" + txtOption.Value + "&id=" + txtId.Value);
        
    }
    protected void btnAddRoleAct_Click(object sender, EventArgs e)
    {
        //Agregar role actancial a arena
        for (int i = 0; i < lstRolesActL.Items.Count; i++)
        {
            if (lstRolesActL.Items[i].Selected)
                if (new LogicaNegocio().Ledeer().DefinitionLEDEER().addRoleActToArena(lblSelect.Text, lstRolesActL.Items[i].Text) == 0)
                {
                    Response.Write("<script>alert('Role actancial agregado a la arena');</script>");
                }
                else
                    Response.Write("<script>alert('El role actancial no pudo se agregado a la arena');</script>");
        }
        Response.Redirect("~/frmAdminArena1.aspx?option=" + txtOption.Value + "&id=" + txtId.Value);
        

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
