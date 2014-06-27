using System;
using System.Xml;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Text;
using DataAccess;  

//namespace BusinessLogic;


/// <summary>
/// Contiene las reglas definidas en el análisis del sistema
/// </summary>
public class LogicaNegocio
{
    private LEDEER ledeer;
    
    public static Regex REG_USR = new Regex(@"(^[0-9a-zA-Z|_]{5,25})$"); //Expresión regular utilzadá para los datos del usuario
    public static Regex REG_MSG = new Regex(@"^[0-9a-zA-Z|\s|\n|ñ|á|é|í|ó|ú|:|.|;|<|>|?|¡|!|¿|+|}|{|,|&|||_|-]{2,250}$"); //expresión regular utilizada para los datos de un mensaje y comentario
 
    public LogicaNegocio()
    {
        ledeer = new LEDEER();
        //
        // TODO: Add constructor logic here
        //
    }

    public LEDEER Ledeer()
    {
        return ledeer;
    }
}