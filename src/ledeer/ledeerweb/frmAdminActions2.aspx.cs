using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Collections.Generic;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using StringTools;
using LEDEERTools;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        txtSentences.Attributes.Add("onMouseup", "updatePosition(txtSentences)");
        txtSentences.Attributes.Add("onMousedown", "updatePosition(txtSentences)");
        txtSentences.Attributes.Add("onkeyup", "updatePosition(txtSentences)");
        txtSentences.Attributes.Add("onkeydown", "updatePosition(txtSentences)");
        txtSentences.Attributes.Add("onFocus", "updatePosition(txtSentences)");
      

       Ajax.Utility.RegisterTypeForAjax(typeof(_Default));
       //btnCheck.Attributes.Add("onclick", "WriteMessages();");
       if (Request.RequestType == "GET" && !IsPostBack && !IsCallback)
         LoadOptions();
    }


    protected void LoadOptions()
    {
       //Cargar elementos del página

        string option1 = Request.QueryString["option"];
        string id1 = Request.QueryString["id"];
        string namescenario = Request.QueryString["ids"];
        string action = Request.QueryString["action"];
        int option;
        int id;
        
        LogicaNegocio logneg = new LogicaNegocio();
        if (Int32.TryParse(option1, out option) && Int32.TryParse(id1, out id) && namescenario.CompareTo("") != 0 && action.CompareTo("") != 0)
        {
            //Get Nombre de la arena
            lblSelect.Text = (String)(logneg.Ledeer().DefinitionLEDEER().getArena(id).Tables[0].Rows[0]["AtrName"]);
            
            int c = 0;
            DataSet ds;
            ds = logneg.Ledeer().DefinitionLEDEER().getSentencesOfScenario(lblSelect.Text, namescenario);

            if (ds != null && ds.Tables.Count>0)
                while (c < ds.Tables[0].Rows.Count)
                {
                    if (ds.Tables[0].Rows[c]["AtrProcess"].ToString().CompareTo("Initialize") == 0 && ds.Tables[0].Rows[c]["AtrType"].ToString().CompareTo("Poscondition")== 0)
                        txtSentences.Text = txtSentences.Text + (String)(ds.Tables[0].Rows[c]["AtrSentence"]);
                    c++;
                }

                
            //Actores
            txtOption.Value = option1;
            txtId.Value = id1;
            txtIdS.Value = namescenario;
            txtIdA.Value = lblSelect.Text;
            lblAction.Text = action;

            lnkDefinition.NavigateUrl = "~/frmDefinitions.aspx?option=" + option1;
            lnkAdminAction.NavigateUrl = "~/frmAdminActions.aspx?option=" + txtOption.Value + "&id=" + txtId.Value;
            lnkAdminArena.NavigateUrl = "~/frmAdminArena1.aspx?option=" + txtOption.Value + "&id=" + txtId.Value; ;

            lstActors.DataSource = logneg.Ledeer().DefinitionLEDEER().getActorsOfArena(lblSelect.Text);
            lstActors.DataTextField = "AtrName";
            lstActors.DataValueField = "IdActor";
            lstActors.DataBind();

            DataSet dsActors = (DataSet)lstActors.DataSource;
            try
            {
                if (dsActors != null && dsActors.Tables.Count > 0 && dsActors.Tables[0].Rows.Count > 0)
                    foreach (DataRow dr in dsActors.Tables[0].Rows)
                    {
                        string role = logneg.Ledeer().DefinitionLEDEER().getRoleOfActor(lblSelect.Text, dr["AtrName"].ToString());
                        if (role.CompareTo(String.Empty) == 0)
                            role = "(Sin role)";
                        dr["AtrName"] = dr["AtrName"].ToString() + "->" + role;
                    }
            }
            catch
            {
            }
            
            lstActors.DataBind();

            lstRoles.DataSource = logneg.Ledeer().DefinitionLEDEER().getRolesOfArena(lblSelect.Text);
            lstRoles.DataTextField = "AtrName";
            lstRoles.DataValueField = "IdRole";
            lstRoles.DataBind();

            lstRolesAct.DataSource = logneg.Ledeer().DefinitionLEDEER().getRolesActOfArena(lblSelect.Text);
            lstRolesAct.DataTextField = "AtrName";
            lstRolesAct.DataValueField = "IdRoleAct";
            lstRolesAct.DataBind();


            lstObjects.DataSource = logneg.Ledeer().DefinitionLEDEER().getObjectsOfArena(lblSelect.Text);
            lstObjects.DataTextField = "AtrName";
            lstObjects.DataValueField = "IdObj";
            lstObjects.DataBind();

        }
    }

    protected void Button2_Click(object sender, EventArgs e)
    {

        Response.Redirect("~/frmDefinitions.aspx?option="+txtOption.Value);
    }
    protected void lstEle_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
    
    
    protected void btnAdminActions_Click(object sender, EventArgs e)
    {
        //Administrar funcionalidades
        Response.Redirect("~/frmAdminActions.aspx?option=" + txtOption.Value + "&id=" + txtId.Value);
    }

    protected void btnSaveSentences_Click(object sender, EventArgs e)
    {
        string process = "Initialize";
        string type = "Poscondition";
        LogicaNegocio log_neg = new LogicaNegocio();
  
        if (log_neg.Ledeer().DefinitionLEDEER().addSentenceToScenario(lblSelect.Text,txtIdS.Value,txtSentences.Text,process,type)==0)
            //Exito
            type="1";
        else
            type="1";
            //Sentencia no modificada
        
        Response.Redirect("~/frmAdminActions2.aspx?option=" + txtOption.Value + "&id=" + txtId.Value+ "&action="+ lblAction.Text +"&ids="+ txtIdS.Value);
        
    }
    protected void openWindow(string ruta){
        string script = "<script>window.open('" +
                          ruta +
                          "')</script>";

        if (!ClientScript.IsStartupScriptRegistered("Arena -" + lblSelect.Text))
        {
            ClientScript.RegisterStartupScript(this.GetType(), "Arena -" + lblSelect.Text, script);
        }
    }


    protected void btnCheck_Click(object sender, EventArgs e)
    {
        LogicaNegocio lg = new LogicaNegocio();
        if (txtIdA.Value.CompareTo(String.Empty) != 0)
        {
            string ruta = lg.Ledeer().ExportXML(txtIdA.Value, Server.MapPath(LEDEER.path_XML));
            if (ruta != null)
                openWindow(LEDEER.path_XML + ruta);
            try
            {
                System.IO.File.Delete(LEDEER.path_XML +ruta);
            }catch
            {
            }
        }
    }

    [Ajax.AjaxMethod()]
    public string suma(string a)
    {
        return "1";
    }

    [Ajax.AjaxMethod()]
    public DataSet getErrors(string sentence,string nameArena, string ids)
    {
       /*Guardar scenario*/
       string process = "Initialize";
       string type = "Poscondition";
       LogicaNegocio log_neg = new LogicaNegocio();
     
       log_neg.Ledeer().DefinitionLEDEER().addSentenceToScenario(nameArena, ids,sentence , process, type);

       DataSet ds = new DataSet();

       try
       {
           ResultAnalysis rs = log_neg.Ledeer().AnalyzeLEDEER(sentence).CheckSyntax();
           DataTable table = new DataTable();
           
           table.Columns.Add("Code", System.Type.GetType("System.String"));
           table.Columns.Add("Description", System.Type.GetType("System.String"));
           table.Columns.Add("Line", System.Type.GetType("System.String"));
           table.Columns.Add("Symbol", System.Type.GetType("System.String"));
           ds.Tables.Add(table);

           foreach (Error er in rs.Error)
           {
    
               DataRow newRow = table.NewRow();
               newRow["Code"] = er.Code;
               newRow["Description"] = er.Description;
               newRow["Line"] = er.Line.ToString();
               newRow["Symbol"] = er.Symbol;
               table.Rows.Add(newRow);
           }
       }
       catch
       {
           ;
       }
        
        return ds;
    }
    protected void btnExport_Click(object sender, EventArgs e)
    {
        LogicaNegocio lg = new LogicaNegocio();
        if (txtIdA.Value.CompareTo(String.Empty) != 0 && txtIdS.Value.CompareTo(String.Empty) != 0 && lblAction.Text.CompareTo(String.Empty) != 0)
        {
            string ruta = lg.Ledeer().ExportXMLS(txtIdA.Value, txtIdS.Value, lblAction.Text, Server.MapPath(LEDEER.path_XML));
            if (ruta != null)
                openWindow(LEDEER.path_XML + ruta);
        }
    }
    protected void Button2_Click1(object sender, EventArgs e)
    {

    }
}
