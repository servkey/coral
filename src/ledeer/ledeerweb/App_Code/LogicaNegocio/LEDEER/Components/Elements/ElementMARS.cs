using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

/// <summary>
/// Descripción breve de ElementMARS
/// </summary>
public class ElementMARS
{
    private int id = -1; 
    private string name = "";
	public ElementMARS()
	{
        //idroleact = -1; //id inválido
        //nameroleact = ""; //nombre inválido

		//
		// TODO: Agregar aquí la lógica del constructor
		//
	}

    public int Id
    {
        set { id = value; }
        get { return id; }
    }

    public string Name
    {
        set { name = value; }
        get { return name; }
    }
}


