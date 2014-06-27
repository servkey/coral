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
/// Contiene las reglas definidas en el an�lisis del sistema
/// </summary>
public class LogicaNegocio
{
    private LEDEER ledeer;
    
    public static Regex REG_USR = new Regex(@"(^[0-9a-zA-Z|_]{5,25})$"); //Expresi�n regular utilzad� para los datos del usuario
    public static Regex REG_MSG = new Regex(@"^[0-9a-zA-Z|\s|\n|�|�|�|�|�|�|:|.|;|<|>|?|�|!|�|+|}|{|,|&|||_|-]{2,250}$"); //expresi�n regular utilizada para los datos de un mensaje y comentario
 
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