using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Text.RegularExpressions;
using System.Text;
using DataAccess;
using System.Xml;
using System.IO;
using LEDEERTools;

/// <summary>
/// Summary description for LEDEER
/// </summary>

public class LEDEER
{
    public static string path_XML = "Data/";
    public static Regex REG_USR = new Regex(@"(^[0-9a-zA-Z|_]{5,25})$"); //Expresión regular utilzadá para los datos del usuario
    public static Regex REG_MSG = new Regex(@"^[0-9a-zA-Z|\s|\n|ñ|á|é|í|ó|ú|:|.|;|<|>|?|¡|!|¿|+|}|{|,|&|||_|-]{2,250}$"); //expresión regular utilizada para los datos de un mensaje y comentario

    //Definition Components LEDEER
    private DefinerLEDEER defLEDEER;
    private MotorLEDEER motLEDEER;
    private AnalyzerLEDEER anaLEDEER;

    private Usuario usr_auth = new Usuario();

    public DefinerLEDEER DefinitionLEDEER()
    {
       defLEDEER = new DefinerLEDEER();
       return defLEDEER;

    }

    public MotorLEDEER MotorLEDEER()
    {
        motLEDEER = new MotorLEDEER();
        return motLEDEER;

    }

    public AnalyzerLEDEER AnalyzeLEDEER(String xsentences)
    {
        anaLEDEER = new AnalyzerLEDEER(xsentences);
        return anaLEDEER;

    }

    public AnalyzerLEDEER AnalyzeLEDEER()
    {
        return anaLEDEER;
    }

    public LEDEER()
    {

    } 

    public void constructorArena(){
    }
 

    private int IdSesion = 0; //Sesion no iniciada
    

    private int Sesion
    {
        get
        {
            return IdSesion;
        }
        set
        {
            IdSesion = value; //si es distinto a cero inicia sesion
        }
    }

    public string getUsuario()
    {
        if (usr_auth != null)
            return usr_auth.UsuarioMsg;
        return null;
    }

    public string getNombre()
    {
        if (usr_auth != null)
            return usr_auth.Nombre;
        return null;
    }

    public int getIdNivel()
    {
        if (usr_auth != null)
            return usr_auth.IdNivelUsuario;
        return -1;
    }

    public string getEmail()
    {
        if (usr_auth != null)
            return usr_auth.Email;
        return null;
    }


    private string getNameFile(string name)
    {
        string tmp = name;//.Clone();
        tmp = tmp.Replace(" ", "");
        Random random = new Random();
        string ch = Convert.ToString(Convert.ToInt32(1000 + random.NextDouble() * 999));

        name = String.Concat(tmp, ch, ".xml");
        
        return name;
    }


    ///<summary>
    /// Método para construir arena a un archivo XML,
    /// regresa la ruta del archivo si el valor regresado es vacio 
    /// no se creo el archivo XML
    ///</summary>
    public string ExportXML(string namearena, string pathserver)
    {
        string name = null;
        

        if (namearena.CompareTo(String.Empty) != 0 && pathserver.CompareTo(String.Empty) != 0)
        {
            
            try
            {

                bool exist = true;
                while (exist)
                {
                    name = getNameFile(namearena);

                    // Eliminar archivo si existe
                    if (!File.Exists(String.Concat(pathserver,name)))
                        exist = false;
                }
                // Crear archivo
                pathserver = String.Concat(pathserver,"//",name);
                FileStream fs = File.Create(pathserver, 1024);
                fs.Close();

                string role = "Role";//Elemento role
                string actor = "Actor";//Elemento actor
                string object1 = "Object";//Elemento objeto
                string scenario = "Scenario";//Elemento escenario
                string action = "Action";//Elemento acción
              //  string roleref = "RoleRef"; //Elemento RoleRef
              //  string roleact = "RoleActancial"; //Roles actanciales

                XmlTextWriter objEscritor = new XmlTextWriter(pathserver, Encoding.UTF8);

                objEscritor.Formatting = Formatting.Indented;
                objEscritor.WriteStartDocument();
                objEscritor.WriteStartElement("Arena"); //Abrir arena
                //Asignar atributos    
                objEscritor.WriteAttributeString("idarena", new LogicaNegocio().Ledeer().DefinitionLEDEER().getArenaId(namearena));
                objEscritor.WriteAttributeString("name", namearena);

                LogicaNegocio logneg = new LogicaNegocio();
                DataSet ds = logneg.Ledeer().DefinitionLEDEER().getRolesOfArena(namearena);//Obtener Roles

                //iniciar y llenar elemento Roles 
                objEscritor.WriteStartElement(Symbol.traslatorCode(Symbol.CODEROLESS));

                fullXML(namearena, objEscritor, ds, role, "idrole");
                //cerrar roles
                objEscritor.WriteEndElement();

                ds = logneg.Ledeer().DefinitionLEDEER().getActorsOfArena(namearena);//Obtener actores

                //iniciar y llenar elemento Actores
                objEscritor.WriteStartElement(Symbol.traslatorCode(Symbol.CODEACTORS));

                fullXML(namearena, objEscritor, ds, actor, "idactor");

                //cerrar actores
                objEscritor.WriteEndElement();

                //iniciar y llenar elemento Objects
                ds = logneg.Ledeer().DefinitionLEDEER().getObjectsOfArena(namearena);//Obtener objects
                objEscritor.WriteStartElement(Symbol.traslatorCode(Symbol.CODEOBJECT));

                fullXML(namearena, objEscritor, ds, object1, "idobj");
                //cerrar objetos

                objEscritor.WriteEndElement();

                //Escenarios
                //iniciar y llenar elemento escenario

                ds = logneg.Ledeer().DefinitionLEDEER().getScenariosOfArena(namearena);
                objEscritor.WriteStartElement("Scenarios");
                fullXML(namearena, objEscritor, ds, scenario, "idscenario");
                objEscritor.WriteEndElement(); //cerrar escenarios

                //Funcionalidades
                //iniciar y llenar elemento Actions
                ds = logneg.Ledeer().DefinitionLEDEER().getActionsOfArena(namearena);
                objEscritor.WriteStartElement(Symbol.traslatorCode(Symbol.CODEACTION));
                fullXML(namearena, objEscritor, ds, action, "idaction");
                objEscritor.WriteEndElement(); //cerrar funcionalidades

                //Cerrar arena
                objEscritor.WriteEndElement();

                //Fin archivo XML
                objEscritor.WriteEndDocument();
                //Cerrar archivo xml
                objEscritor.Close();
            }
            catch
            {
                name = null;
            }
        }                  
        return name;
    }



    ///<summary>
    /// Método para construir escenario a un archivo XML,
    /// regresa la ruta del archivo si el valor regresado es vacio 
    /// no se creo el archivo XML
    ///</summary>

    public string ExportXMLS(string namearena, string namescenario, string nameaction, string pathserver)
    {
        string name = null;
        if (namearena.CompareTo(String.Empty) != 0 && namescenario.CompareTo(String.Empty) != 0 && pathserver.CompareTo(String.Empty) != 0)
        {
            
            string path = pathserver;
            
            try
            {
                bool exist = true;
                while (exist)
                {
                    name = getNameFile(namescenario);

                    // Eliminar archivo si existe
                    if (!File.Exists(String.Concat(pathserver, name)))
                        exist = false;
                }
                // Crear archivo
                path = String.Concat(pathserver, "//", name);


                // Crear archivo
                FileStream fs = File.Create(path, 1024);
                fs.Close();

                string description = "Description";//Elemento decription
                string interaction = "Interaction";//Elemento interacción
                string initialize = "Initialize";//Elemento inicialización
                string preconditions = "PreConditions";//Elemento precondiciones
                string if1 = "IF";//Elemento if
                string posconditions = "PosConditions"; //Elemento poscondiciones
                string finalize = "Finalize"; //Elemento finalizar


                XmlTextWriter objEscritor = new XmlTextWriter(path, Encoding.UTF8);
                LogicaNegocio logneg = new LogicaNegocio(); //Construir capa de lógica

                objEscritor.Formatting = Formatting.Indented;
                objEscritor.WriteStartDocument();
                objEscritor.WriteStartElement("Scenario"); //Abrir arena
                //Obtener datos del escenari
                DataSet ds = logneg.Ledeer().DefinitionLEDEER().getScenarioData(namearena, nameaction, namescenario);//Obtener datos del escenario

                //Obtener sentencias
                DataSet ds1 = logneg.Ledeer().DefinitionLEDEER().getSentencesOfScenario(namearena, namescenario);

                //Asignar atributos    
                objEscritor.WriteAttributeString("idscenario", ds.Tables[0].Rows[0]["IdScenario"].ToString());
                objEscritor.WriteAttributeString("name", namescenario);
                //Elemento description                        
                objEscritor.WriteElementString(description, ds.Tables[0].Rows[0]["AtrDescription"].ToString());


                //iniciar y llenar elemento Interacción
                objEscritor.WriteStartElement(interaction);

                //iniciar y llenar elemento Initialize
                 objEscritor.WriteStartElement(initialize);

                //Iniciar precondition
                 objEscritor.WriteStartElement(preconditions);
                //Iniciar IF
                 objEscritor.WriteStartElement(if1);
                 //Get sentence initialize,precondition,
                 string sentence = getSentence("Initialize","Precondition",ds1);
                 objEscritor.WriteElementString("Sentence", sentence);
                 //Cerrar IF
                 objEscritor.WriteEndElement();
                //cerrar precondition
                 objEscritor.WriteEndElement();
                                
                //Iniciar poscondition
                objEscritor.WriteStartElement(posconditions);
                //Iniciar IF
                objEscritor.WriteStartElement(if1);
                //Get Sentencias
                sentence = getSentence("Initialize", "Poscondition", ds1);
                objEscritor.WriteElementString("Sentence", sentence);
                //Cerrar IF
                objEscritor.WriteEndElement();
                //cerrar precondition
                objEscritor.WriteEndElement();

                //Cerrar elemento Initialize
                objEscritor.WriteEndElement();


                //iniciar y llenar elemento Finalize
                objEscritor.WriteStartElement(finalize);

                //Iniciar precondition
                objEscritor.WriteStartElement(preconditions);
                //Iniciar IF
                objEscritor.WriteStartElement(if1);
                //Get sentence finalize,precondition,
                sentence = getSentence("Finalize", "Precondition", ds1);
                objEscritor.WriteElementString("Sentence", sentence);
                //Cerrar IF
                objEscritor.WriteEndElement();
                //cerrar precondition
                objEscritor.WriteEndElement();

                //Iniciar poscondition
                objEscritor.WriteStartElement(posconditions);
                //Iniciar IF
                objEscritor.WriteStartElement(if1);
                //Get Sentencias
                sentence = getSentence("Finalize", "Poscondition", ds1);
                objEscritor.WriteElementString("Sentence", sentence);
                
                //Cerrar IF
                objEscritor.WriteEndElement();
                //cerrar precondition
                objEscritor.WriteEndElement();

                //Cerrar elemento Finalize
                objEscritor.WriteEndElement();

                //Cerrar interacción
                objEscritor.WriteEndElement();
                //Cerrar scenario
                objEscritor.WriteEndElement();

                //Fin archivo XML
                objEscritor.WriteEndDocument();
                //Cerrar archivo xml
                objEscritor.Close();
            }
            catch
            {
                name = null;
            }
        }
        return name; //regresar ruta
    }
    /// <summary>
    /// Método para obtener sentencia de un escenario
    /// </summary>
    /// <param name="process"></param>
    /// <param name="type"></param>
    /// <param name="ds"></param>
    /// <returns></returns>
    private string getSentence(string process, string type, DataSet ds)
    {

        
        try
        {
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                if (dr["AtrProcess"].ToString().CompareTo(process) == 0 && dr["AtrType"].ToString().CompareTo(type) == 0)
                    return dr["AtrSentence"].ToString();
            }
        }
        catch
        {
        
        }
        return null;
    }


    /// <summary>
    /// Método para llenar elementos xml, con dataSet's con dos columnas, columna 1 = llave, la 2 = nombre
    /// </summary>
    /// <param name="objEscritor"></param>
    /// <param name="ds"></param>
    /// <param name="element"></param>
    /// <param name="atr1"></param>
    private void fullXML(string namearena, XmlTextWriter objEscritor, DataSet ds, string element,string atr1)
    {
        try
        {
            LogicaNegocio lg = new LogicaNegocio();
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                string name = dr[1].ToString(); //nombre en columna 1
                //Abrir elemento
                objEscritor.WriteStartElement(element);
                objEscritor.WriteAttributeString(atr1, dr[0].ToString());
                if (element.CompareTo("Actor") == 0) //Si es role
                {
                    //Agregar otro atributo
                    
                    string role = lg.Ledeer().DefinitionLEDEER().getRoleOfActor(namearena,name);
                    string id = lg.Ledeer().DefinitionLEDEER().getRoleId(role);
                    
                    objEscritor.WriteAttributeString("idrole", id);
                }else if (element.CompareTo("Object") == 0)
                    objEscritor.WriteAttributeString("value", dr[2].ToString());
                else if (element.CompareTo("Action") == 0)
                {
                    objEscritor.WriteAttributeString("idscenario",lg.Ledeer().DefinitionLEDEER().getScenarioOfActionId(namearena,name));
                }


                //Atributo nombre
                objEscritor.WriteAttributeString("name", name);

                objEscritor.WriteEndElement(); //Cerrar elemento
            }
        }
        catch
        {
        }
    }



    /*public bool AuthenticarUsuario(string xusuario, string xpassword)
    {
        //Establecer:
        //UsuarioMsg
        //Password
        Usuario tusr = new Usuario();
        tusr.UsuarioMsg = xusuario;
        tusr.Password = xpassword;

        if (tusr.AuthenticarUsuario())
            return true;
        return false;
    }*/

    /**
         Usuario = xlogin;
         Fecha = xfecha;
         Titulo = xtitulo;
         MensajeTxt = xmensaje;
         **/
    //Método que llama el procedimento almacenado AgregarComentario
    //Establecer idtema
    //Establecer  Usuario, IdTema
    //Método para agregar comentario a un tema del WebLog
    /*public bool AgregarComentario(int xidtema, string xcomentario, string UsuarioMsg)
    {
        Comentario cmt = new Comentario();
        if (cmt.GuardarComentario(xcomentario, UsuarioMsg, xidtema))
            return true;

        return false;
    }

    //establecer titulo, mensajetxt, usuario, fecha
    //Método para agregar tema al WebLog

    public bool AgregarTema(string xtitulo, string xmensajetxt, string UsuarioMsg)
    {
        Tema tema = new Tema();
        tema.Titulo = xtitulo;
        tema.MensajeTxt = xmensajetxt;
        tema.Usuario = UsuarioMsg;
        if (tema.GuardarTema())
            return true;
        return false;
    }*/

    //idtema
    //eliminar regresa distinto a cero si se puede eliminar
    /*public bool EliminarTema(int xidtema)
    {
        Tema tema = new Tema();
        tema.IdTema = xidtema;

        if (tema.EliminarTema())
            return true;

        return false;
    }

    //Eliminar Comentario
    //IdComentario
    public bool EliminarComentario(int xidcomentario)
    {
        Comentario coment = new Comentario();
        coment.IdComentario = xidcomentario;
        if (coment.EliminarComentario())
            return true;

        return false;
    }*/

    //Mostrar Tema


}


public class Usuario
{
    private string usuario; //cuenta
    private string nombre;
    private string email;
    private string password;
    private int idnivelusuario;


    public Usuario()
    {

    }

    public string UsuarioMsg
    {
        get
        {
            return usuario;
        }
        set
        {
            usuario = value;
        }
    }

    public string Nombre
    {
        get
        {
            return nombre;
        }
        set
        {
            nombre = value;
        }
    }
    public string Email
    {
        get
        {
            return email;
        }
        set
        {
            email = value;
        }
    }
    public string Password
    {
        get
        {
            return password;
        }
        set
        {
            password = value;
        }
    }

    public int IdNivelUsuario
    {
        get
        {
            return idnivelusuario;
        }
        set
        {
            idnivelusuario = value;
        }
    }

    //Establecer:
    //UsuarioMsg
    //Password

    public bool AuthenticarUsuario()
    {
        AccesoDatos datos = new AccesoDatos();
        int res = datos.AuthenticarUsuario(UsuarioMsg, Password);
        if (res == 1)
            return true;
        return false;
    }


    //Métdo que llama procedimento almacenado
    //Se establece 
    //UsuarioMsg
    //Nombre
    //Email,
    //Password
    //IdNivelUsuario

    /*public bool GuardarUsuario()
    {
        AccesoDatos datos = new AccesoDatos();
        if (UsuarioMsg != null && Nombre != null &&
                Email != null && Password != null
            )
        {
            int res = datos.AgregarUsuario(UsuarioMsg, Nombre, Email, Password);
            if (res == 0)
                return true;
        }
        return false;
    }*/


    //no se establecen datos
    /*public DataSet MostrarUsuarios()
    {
        AccesoDatos datos = new AccesoDatos();
        return datos.MostrarUsuarios();
    }*/


}
