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
using System.Runtime.Serialization;
using System.IO;
using System.Xml;
using System.Runtime.Serialization.Formatters.Binary;
using LEDEERTools;
using StringTools;
/// <summary>
/// Clase Util
/// Contiene métodos utiles para LEDEER
/// </summary>
namespace Util
{
    //clase util 
    public class Util
    {

        public Util()
        {
            //
            // TODO: Agregar aquí la lógica del constructor
            //
        }

        /// <summary>
        /// Copiar un objeto<Symbol>
        /// </summary>
        /// <returns></returns>
        
        //public static List<Symbol> Clone(List<Symbol> objsrc)
        public static T Clone<T>(T objsrc)
        {
            if (Object.ReferenceEquals(objsrc, null))
            {
                return objsrc;
            }
            //Construir stream 
            
            
            IFormatter b_formatter = new BinaryFormatter();
            Stream m_stream = new MemoryStream();

            b_formatter.Serialize(m_stream, objsrc);
            m_stream.Seek(0, SeekOrigin.Begin);
            //Deserializar espacio para nuevo objeto cash
            return (T)b_formatter.Deserialize(m_stream);
        }

        /// <summary>
        /// Método para llenar la tabla con variables definidas en la arena.
        /// </summary>
        /// <param name="path"></param>
        /// <param name="table_def"></param>
        public static void XMLReadFile(XmlReader rdr,List<string> table_def)
        {
         //    table_def1 = table_def1;
            try
            {
            
                if (rdr != null)
                {
                    string codeA = "";
                    while (rdr.Read())
                    {
                        switch (rdr.NodeType)
                        {
                            case XmlNodeType.Element:
                                if (//rdr.Name.CompareTo("Arenas") != 0 && rdr.Name.CompareTo("Arena") != 0 &&
                                     rdr.Name.CompareTo("Scenarios")!= 0 && rdr.Name.CompareTo("Scenario") !=0)
                                {
                                    string code = "";
                                    if (rdr.Name.CompareTo("Arena") != 0)
                                        code = Symbol.traslatorString(rdr.Name);
                                    else
                                        code = Symbol.CODEARENAS;

                                    if (Symbol.IsWordReserv(code))
                                    {
                                        
                                        addWord(table_def, code);
                                        codeA = code;
                                    }
                                    else
                                    {
                                        //Ledeer atributos
                                        string atr1 = "";
                                        string atr2 = "";
                                        while (rdr.MoveToNextAttribute())
                                        {
                                            if (rdr.Name.CompareTo("idrole") == 0)
                                                atr1 = rdr.Value;
                                            else if (rdr.Name.CompareTo("name") == 0)
                                                atr2 = rdr.Value;
                                        }

                                        if (codeA.CompareTo(Symbol.CODEROLESS) != 0 &&
                                            atr2.CompareTo(String.Empty) != 0 &&
                                            codeA.CompareTo(Symbol.CODEACTORS) != 0 )
                                            addVar(table_def, codeA, atr2);
                                        else if (atr1.CompareTo(String.Empty) != 0 && atr2.CompareTo(String.Empty) != 0)
                                            addVar(table_def, codeA, String.Concat(atr1, ",", atr2));
                                    }
                                }
                                
                                break;
                            case XmlNodeType.Text:
                            case XmlNodeType.CDATA:
                            case XmlNodeType.ProcessingInstruction:
                            case XmlNodeType.Comment:
                            case XmlNodeType.Document:
                            case XmlNodeType.Whitespace:
                            case XmlNodeType.SignificantWhitespace:
                            case XmlNodeType.EndElement:
                                break;
                        }
                    }
                }
            }
            catch
            {
            }
        }


        /// <summary>
        /// Método para buscar el índice de un código de símbolo
        /// en la tabla de variables, si no lo encuentra regresa -1.
        /// </summary>
        /// <param name="table"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        private static int findVar(List<string> table, string code)
        {
            for (int i = 0; i < table.Count; i++)
                if (table[i].CompareTo(code) == 0)
                    return i;
            
            return -1;
        }

        /// <summary>
        /// Agregar palabra reservada a tabla de definición.
        /// </summary>
        /// <param name="table"></param>
        /// <param name="code"></param>
        public static void addWord(List<string> table, string code)
        {
            if (findVar(table,code) == -1)
                table.Add(code);
        }

        /// <summary>
        /// Método para obtener el valor de un elemento,
        /// se envía como parámetro:
        ///     La tabla de definiciones.
        ///     El código que se desea obtener, por ejemplo: role.
        ///     El código del elemento que se desea buscar,
        ///     por ejemplo: actor, el role de un actor.
        ///     El valor a buscar.
        /// Regresa nulo si no se encuentra.
        /// </summary>
        /// <param name="table"></param>
        /// <param name="getcode"></param>
        /// <param name="findcode"></param>
        /// <param name="findval"></param>
        /// <returns></returns>
        public static string getValueOfElement(List<string> table, string getcode, string findcode, string findval ){

            int i = table.IndexOf(getcode);

            if (i != -1)
            {

                int j = table.IndexOf(findcode);
                for (int j1 = j + 1; j1 < table.Count; j1++)
                {
                    if (!Symbol.IsWordReserv(table[j1]))
                    {
                        string id = "";
                        if (getTokenActors(table[j1]).CompareTo(findval) == 0)
                        {
                            id = new StringTokenizer(table[j1], ",").NextToken;


                            for (int j2 = i + 1; j2 < table.Count; j2++)
                            {
                                if (!Symbol.IsWordReserv(table[j2]))
                                {
                                    StringTokenizer strk = new StringTokenizer(table[j2], ",");
                                    string tmp = strk.NextToken;
                                    if (tmp.CompareTo(id) == 0)
                                        return strk.NextToken;

                                }
                            }
                        }
                    }else
                        return null;

                }

            }
            return null;
        }


        /// <summary>
        /// Método que regresa -1 si el valor
        /// recibido como parámetro no está definido en la palabra reservada.
        /// </summary>
        /// <param name="table"></param>
        /// <param name="i"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static int ValueOnCode(List<string> table, string code, string value){
            int i = findVar(table, code); //Índice de la palabra reservada
            if (i != -1){
                for (int i1 = i + 1; i1 < table.Count; i1++)
                    if (!Symbol.IsWordReserv(table[i1]))
                    {
                        string val = table[i1];
                        if (code.CompareTo(Symbol.CODEACTORS) == 0 || code.CompareTo(Symbol.CODEROLESS) ==0)
                            val = getTokenActors(val);                 
                        if (val.CompareTo(value) == 0)
                            return 1;
                    }
                    else
                        return -1;
                
            }

            return -1; //No tiene el valor
        }

        /// <summary>
        /// Método para separar cadena
        /// </summary>
        /// <param name="strings"></param>
        /// <returns></returns>
        public static List<string> parseStrings(string strings)
        {
            List<string> ls = new List<string>();
            try
            {
                StringTokenizer st = new StringTokenizer(strings, ",");

                if (st.Count > 1)
                {
                    while (st.hasMoreTokens())
                    {
                        string tmp = st.nextToken();
                        ls.Add(tmp);
                    }
                }
            }
            catch
            {

            }
            return ls;
        }


        public static string getTokenActors(string value)
        {
            StringTokenizer str = new StringTokenizer(value, ",");
            str.nextToken();
            return str.nextToken();
        }

        /// <summary>
        /// Agregar valor a una variable, recibe como parámetro
        /// la tabla de variables, el código del símbolo
        /// a agregar valor y el valor.
        /// </summary>
        /// <param name="table"></param>
        /// <param name="code"></param>
        /// <param name="value"></param>
        public static void addVar(List<string> table, string code, string value)
        {
            try{
                string value1 = value;
                if (code.CompareTo(Symbol.CODEACTORS) == 0|| code.CompareTo(Symbol.CODEROLESS) == 0){
                    
                    value1 = getTokenActors(value);
                }
                //value
                
                //value = value.ToUpper();
                
                int i1 = ValueOnCode(table, code, value1);
                
                if (i1 == -1)
                {
                    addVar(table,table.IndexOf(code)+1, value);
               }   
            }catch{
            }
        }


        /// <summary>
        /// Agregar palabra reservada, recibe como parámetro
        /// la tabla de variables, la palabra reservada.
        /// </summary>
        /// <param name="table"></param>
        /// <param name="code"></param>
        private static void addVar(List<string> table, int i, string val)
        {
            table.Insert(i,val);           
        }

        /// <summary>
        /// Eliminar objeto con el código dado en el parametro code
        /// </summary>
        /// <param name="tabla_symbols"></param>
        /// <param name="code"></param>
        public static List<Symbol> removeList(List<Symbol> symbols,String code)
        {
            //Clonar objeto
            List<Symbol> symbolsb = Clone(symbols);

            //Índice
            int i = 0;
            
            while (i < symbolsb.Count)
            {
                if (symbolsb[i].Code.CompareTo(code) == 0)
                {
                    symbolsb.RemoveAt(i);
                    if (i>0)
                        i--;
                }else
                     i++;
            }
            return symbolsb;
        }
    }
}
