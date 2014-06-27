using System;
using System.Data;
using System.Collections.Generic;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

/// <summary>
/// Descripción breve de ResultAnalysis
/// Para ver si la sentencia es válida el analizador regresa
/// un objeto de la clase ResultAnalysis
/// </summary>
namespace LEDEERTools
{
    /// <summary>
    ///Administrador de errores
    /// 1. Identificador inválido
    /// 2. No coinciden paréntesis
    /// 3. Comillas inválidas
    /// 4. Llaves inválidas
    /// 5. Estructura inválida        
    /// 6. Cadena inválida
    /// </summary>
    public class ErrorManager
    {
        private List<Error> erno = new List<Error>();
        public static int COUNTERROR = 8;

        private void createErrors()
        {
            //Definir errores
            erno.Add(new Error(1, "Identificador inválido")); //Indentificador inválido
            erno.Add(new Error(2, "Paréntesis inválido")); //Paréntesis inválidos
            erno.Add(new Error(3, "Comillas inválidas")); //Comillas inválidos
            erno.Add(new Error(4, "No coinciden comillas")); //Llaves inválidas
            erno.Add(new Error(5, "Estructura inválida")); //Estructura de sentencia inválida
            erno.Add(new Error(6, "Cadena inválida")); //Cadena inválida
            erno.Add(new Error(7, "Sentencia incompleta")); //Sentencia incompleta
            erno.Add(new Error(8, "Llave inválida")); //Sentencia incompleta
        }

        ///<summary>
        ///Regresa null si no existe
        ///</summary>
        public Error getError(int number){
            if (number > 0)
            {
                Error er = new Error(erno[number-1].Code,erno[number-1].Description);
                return er;
            }
            return null;
        }

        public ErrorManager()
        {
            createErrors();
        }
    }

    //Clase error
    public class Error
    {
        //Atributos
        int code = 0;
        int line = 0;
        string symbol = "";
        string description = "";

        //Métodos get, set
        public int Code
        {
            set { code = value; }
            get { return code; }
        }

        public string Symbol
        {
            set { symbol = value; }
            get { return symbol; }
        }

        public string Description
        {
            set { description = value; }
            get { return (string)description.Clone(); }
        }

        public int Line
        {
            set { line = value; }
            get { return line; }
        }


        /// <summary>
        /// Definir error
        /// </summary>
        /// <param name="xcode"></param>
        /// <param name="xdescription"></param>
        public Error(int xcode, string xdescription)
        {
            code = xcode;
            description = (string)xdescription.Clone();
        }
    }

    /// <summary>
    /// Clase que Administrar análisis
    /// </summary>
    public class ResultAnalysis
    {
        //Atributos
        private List<Error> erno = new List<Error>();
        public ResultAnalysis(){

        }

        //public void SetEror(int xold_st, int xold_sentence, int xcurrent_st, int xcurrent_sentence, int xline)
        public void SetError(int xcurrent_st, string xcurrent_sentence, int xline)
        {
            //El estado de error es el 1
            if (xcurrent_st == Symbol.CODEERROR || xcurrent_st != 9 && xcurrent_st != 8)
            {
                //Crear Administrador de errores
                ErrorManager error = new ErrorManager();
                Error error1;
                /// 1. Indentificador inválido
                /// 2. No coinciden paréntesis
                /// 3. Comillas inválidas
                /// 4. Llaves inválidas
                /// 5. Estructura inválida        
                /// 6. Cadena inválida
                /// 7. Sentencia incompleta

                switch (xcurrent_sentence)
                {
                    case Symbol.CODEPARENO:
                    case Symbol.CODEPARENC:
                        error1 = error.getError(2); //Error con paréntesis
                        break;
                    case Symbol.CODEQUOTEO:
                    case Symbol.CODEQUOTEC:
                        error1 = error.getError(3); //Error con comillas
                        break;
                    case Symbol.CODEKEYOPE:
                    case Symbol.CODEKEYCLO:
                        error1 = error.getError(8); //Error con llaves
                        break;
                    case Symbol.CODESTRING:
                        error1 = error.getError(6); //Error cadena inválida
                        break;
                    case Symbol.CODEENDLIN:
                        error1 = error.getError(7); //Error sentencia incompleta
                        break;
                    default:
                        error1 = error.getError(5); //Error estructura
                        break;
                }

                error1.Line = xline;
                error1.Symbol = xcurrent_sentence;
                erno.Add(error1);
            }
        }

        public List<Error> Error
        {
            set
            {
                    erno = value; 
            }
            get {
                if (erno == null)
                    return new List<Error>();
                
                return erno;
            }
        }
    }
 }