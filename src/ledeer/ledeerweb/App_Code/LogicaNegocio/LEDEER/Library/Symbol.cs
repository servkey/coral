using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Collections.Generic;
using StringTools;
/// clase Symbol para la tabla parse
/// </summary>
namespace LEDEERTools
{
    //clase Symbol para la tabla de symbolos
    [Serializable]
    public class Symbol
    {
        //Codigós estáticos
        //public static
        public const string CODEBELONG = "000001"; //Pertenece
        public const string CODEEXECUT = "000002"; //Ejecutar
        public const string CODEREFERE = "000003"; //Hacer referencia  
        public const string CODEPARENO = "000004"; //Abrir paréntesis
        public const string CODEPARENC = "000005"; //Cerrar paréntesis
        public const string CODEKEYOPE = "000006"; //Abrir llave
        public const string CODEKEYCLO = "000007"; //Cerrar llave
        public const string CODEQUOTEO = "000008"; //Abrir comilla
        public const string CODEQUOTEC = "000088"; //Cerrar comilla
        public const string CODENEGOPE = "000009"; //Negación            
        public const string CODEENDLIN = "000010"; //Fin de línea            
        public const string CODECOMMEO = "000011"; //Comentario abre           
        public const string CODECOMMEC = "000012"; //Comentario cierra        
                
        //palabra reservadas 
        public const string CODEARENAS = "000013"; //Arenas
        public const string CODEACTORS = "000014"; //Actores
        public const string CODEROLESS = "000015"; //Roles
        public const string CODEROLESA = "000016"; //Roles actanciales
        public const string CODEOBJECT = "000017"; //Objetos
        public const string CODEACTION = "000018"; //Acciones
        public const string CODESTRING = "000019"; //Cadenas
        public const string CODEEXITLD = "000020"; //Exit
        public const int NUMBER = 21; //Número de códigos
        public const int CODEERROR = 1;
        //Atributos de errror
        private String line;
        private String code;
        private String meaning;

        //Métodos get, set
        public String Line
        {
            set { line = value; }
            get { return line; }
        }

        public String Code
        {
            set { code = value; }
            get { return code; }
        }

        public String Meaning
        {
            set { meaning = value; }
            get { return meaning; }
        }

        //Constructor symbol
        public Symbol(String xline, String xcode, String xmeaning)
        {
            line = xline;
            code = xcode;
            meaning = xmeaning;
        }

        public static  string[,] createTable(){
            //string[,] st = new string[2, 5];
            
            string [,]table = {
                {"000001","::"},
                {"000002","->"},
                {"000003",":"},
                {"000004","("},
                {"000005",")"},
                {"000006","{"},
                {"000007","}"},
                {"000008","\""},
                {"000088","\""},
                {"000009","!"}, 
                {"000010",";"},
                {"000011","/*"},
                {"000012","*/"},
                {"000013","Arenas"},
                {"000014","Actors"},
                {"000015","Roles"},
                {"000016","RolesAct"},
                {"000017","Objects"},
                {"000018","Actions"},
                {"000019","Strings"},
                {"000020","Exit"}};

            return table;
       }

        ///<summary>
        /// Regresa el equivalente en texto de un código
        ///</summary>
        ///
        public static string traslatorCode(string code)
        {
            string[,] str = createTable();
            int row = (str.Length / 2);

            for (int i = 0; i < row; i++)
            {
                if (str[i,0].CompareTo(code) == 0){
                    return str[i, 1];
                }
            }

            return String.Empty;//regresa el código si no se ecuentra
        }

        ///<summary>
        /// Regresa el equivalente de un código a cadena
        ///</summary>
        ///
        public static string traslatorString(string strings)
        {
            string[,] str = createTable();
            int row = (str.Length / 2);

            for (int i = 0; i < row; i++)
            {
                if (str[i, 1].CompareTo(strings) == 0)
                {
                    return str[i, 0];
                }
            }

            return String.Empty;//regresa el código si no se ecuentra
        }

        /// <summary>
        /// Método que recibe código de un símbolo
        /// y regresa verdadero si es una palabra reservada
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public static bool IsWordReserv(string code)
        {
          
               if ( code.CompareTo(CODEACTION) == 0 ||
                    code.CompareTo(CODEARENAS) == 0 ||
                    code.CompareTo(CODEOBJECT) == 0 ||
                    code.CompareTo(CODEROLESS) == 0 ||
                    code.CompareTo(CODEROLESA) == 0 ||
                    code.CompareTo(CODEACTORS) == 0 ||
                    code.CompareTo(CODEEXITLD) == 0
                )
                    return true;

            return false;//regresa falso
        }

        

        /// <summary>
        /// Método que recibe código de un símbolo
        /// y regresa verdadero si es una operador
        /// los operadores son:
        /// ::
        /// ->
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public static bool IsOperator(string code)
        {
           // string[,] str = createTable();
            //int row = (str.Length / 2);

            
                if (code.CompareTo(CODEEXECUT) == 0 ||
                    code.CompareTo(CODEBELONG) == 0
                 )
                    return true;

            return false;//regresa falso
        }

        /// <summary>
        /// Método que regresa verdadero si el código
        /// recibido como parámetro es cadena
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public static bool IsString(string code)
        {
          if (code.CompareTo(CODESTRING) == 0)
                    return true;

            return false;//regresa falso
        }

    }
}
