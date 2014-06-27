using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Text;
using System.Collections.Generic;

//Espacios del LEDEER
using LEDEERTools;
using StringTools;
using Util;
/// <summary>
/// AnalizadorLEDEER- Analizar lenguaje LEDEER
/// </summary>
public class AnalyzerLEDEER
{
        

    ///<summary>
    ///Clase para realizar análisis léxico
    ///</summary>
    public class LexicalAnalyzer{

        private string sentences;
        
        private List<string> symbol;
        private List<string> word_reser;

        private List<string> symbolb;
        private List<string> word_reserb;

        private const string cod_return = "|######|";
        private const string cod_line = "|&&&&&&|";

        //Simbolos que abren y cierran
        //Comentarios
        private const string comment_op = "000011";
        private const string comment_cl = "000012";

        //Comillas
        private const string quote_op = "000008";
        private const string quote_cl = "000088"; 

        //llaves
        private const string key_op = "000006";
        private const string key_cl = "000007";

        //paréntesis
        private const string parent_op = "000004";
        private const string parent_cl = "000005";

        //Code para string
        private const string string_cod = "000019";

        //Tablas de símbolos
        private List<Symbol> table_symbol;
        private List<Symbol> table_symbol_cod;
        
        //Cadenas
        private List<string> strings;

        //Métodos get, set
        private List<string> Symbols{
            get { return Util.Util.Clone(symbolb);}
        }
        private List<string> ReservedWords
        {
            get { return Util.Util.Clone(word_reserb); }
        }

        //Regresa cadenas de las sentencias
        public List<string> getStrings()
        {
            return strings;
        }

        public LexicalAnalyzer()
        {
            createSymbol_Word();
        }


        ///<summary>
        ///Construir simbolos y parabra reservadas
        ///</summary>
        private void createSymbol_Word()
        {
            
            //Construir simbolos y parabra reservadas
            strings = new List<string>();
            symbol = new List<string>();
            word_reser = new List<string>();

            symbolb = new List<string>();
            word_reserb = new List<string>();

            //Construir tabla de simbolos
            table_symbol = new List<Symbol>();
            table_symbol_cod = new List<Symbol>();

            //Símbolos de LEDEER
            symbol.Add("::"); //Id=000001
            symbol.Add("->"); //Id=000002
            symbol.Add(":");  //Id=000003
            symbol.Add("(");  //Id=000004
            symbol.Add(")");  //Id=000005
            symbol.Add("{");  //Id=000006
            symbol.Add("}");  //Id=000007
            symbol.Add("\""); //Id=000008
            symbol.Add("!");  //Id=000009
            symbol.Add(";");  //Id=000010
            symbol.Add("/*"); //Id=000011
            symbol.Add("*/"); //Id=000012
            
            symbolb.Add("|" + Symbol.CODEBELONG + "|"); //:: 
            symbolb.Add("|" + Symbol.CODEEXECUT + "|"); //-> 
            symbolb.Add("|" + Symbol.CODEREFERE + "|"); //:
            symbolb.Add("|" + Symbol.CODEPARENO + "|"); //(
            symbolb.Add("|" + Symbol.CODEPARENC + "|"); //)
            symbolb.Add("|" + Symbol.CODEKEYOPE + "|"); //{
            symbolb.Add("|" + Symbol.CODEKEYCLO + "|"); //}
            symbolb.Add("|" + Symbol.CODEQUOTEO + "|"); //"
            symbolb.Add("|" + Symbol.CODENEGOPE + "|"); //!
            symbolb.Add("|" + Symbol.CODEENDLIN + "|"); //;
            symbolb.Add("|" + Symbol.CODECOMMEO + "|"); // /*
            symbolb.Add("|" + Symbol.CODECOMMEC + "|"); // */

            //El retorno de carro es ######

            //Palabras reservadas
            word_reser.Add("Arenas"); //Id=000013
            word_reser.Add("Actors"); //Id=000014
            word_reser.Add("Roles");  //Id=000015
            word_reser.Add("RolesAct");//Id=000016
            word_reser.Add("Objects"); //Id=000017
            word_reser.Add("Actions"); //Id=000018
            word_reser.Add("Exit"); //Id=000020

            //Las cadenas son tomadas con el valor: 000019

            word_reserb.Add("|" + Symbol.CODEARENAS + "|");
            word_reserb.Add("|" + Symbol.CODEACTORS + "|");
            word_reserb.Add("|" + Symbol.CODEROLESS + "|");
            word_reserb.Add("|" + Symbol.CODEROLESA + "|");
            word_reserb.Add("|" + Symbol.CODEOBJECT + "|");
            word_reserb.Add("|" + Symbol.CODEACTION + "|");
            word_reserb.Add("|" + Symbol.CODEEXITLD + "|"); 
        }

        /// <summary>
        /// Eliminar todos los comentarios de la tabla de símbolos..
        /// </summary>
        private List<Symbol> removeComments(List<Symbol> table_symbol_tmp)
        {
            List<Symbol> table_symbol_tmp1 = Util.Util.Clone(table_symbol_tmp);
            if (!object.ReferenceEquals(table_symbol_tmp1, null))
            {

                bool comment_op1 = false;
                string cod = "######";
                string val_comment = "Comment";
                int i = 0;
                while (i < table_symbol_tmp1.Count)
                {

                    switch (table_symbol_tmp1[i].Code)
                    {
                        case comment_op:
                            comment_op1 = true;
                            break;
                        case comment_cl:
                            if (comment_op1)
                            {
                                table_symbol_tmp1[i].Line = cod;
                                table_symbol_tmp1[i].Code = cod;
                                table_symbol_tmp1[i].Meaning = val_comment;//es comentario
                                comment_op1 = false;
                            }
                            break;

                        default:
                            break;

                    }

                    if (comment_op1)
                    {
                        //table_symbol_tmp.Remove(table_symbol_tmp[i]);
                        //i--;
                        table_symbol_tmp1[i].Line = cod;
                        table_symbol_tmp1[i].Code = cod;
                        table_symbol_tmp1[i].Meaning = val_comment;//es comentario

                    }
                    i++;//incrementar índice
                }
                //Elminar comentarios 
                table_symbol_tmp1 = Util.Util.removeList(table_symbol_tmp1, cod);
                //Eliminar espacios en blanco
                table_symbol_tmp1 = Util.Util.removeList(table_symbol_tmp1, " ");
            }
            return table_symbol_tmp1;
        }

        /// <summary>
        /// Determinar cadenas de tabla de símbolos,abrir y cerrar parentesis y llaves..
        /// </summary>
        private List<Symbol> setStrings(List<Symbol> table_symbol_tmp)
        {
            List<Symbol> table_symbol_tmp1 = Util.Util.Clone(table_symbol_tmp);
            if (!object.ReferenceEquals(table_symbol_tmp1, null))
            {
                //Bandera para abrir symbols
                bool quote_op1 = false;
                
                string cod = "String";
                int i = 0;
                string line = "0";

                while (i < table_symbol_tmp1.Count)
                {
                    //Comillas
                    switch(table_symbol_tmp1[i].Code)
                    {
                        case quote_op:
                                if (!quote_op1)
                                {
                                    table_symbol_tmp1[i].Meaning = cod + "O"; //Abrir string
                                    line = table_symbol_tmp1[i].Line;
                                    quote_op1 = true; //Abrir comillas
                                }
                                else
                                {
                                    quote_op1 = false;//Cerrar comillas
                                    table_symbol_tmp1[i].Meaning = cod + "C"; //Cerrar string
                                    table_symbol_tmp1[i].Code = quote_cl;
                                }
                             
                            break;
                        case parent_op:
                            //Paréntesis que abre
                            //Laves que abre
                            //Sino están abiertas las comillas
                            if (!quote_op1)
                            {
                                table_symbol_tmp1[i].Meaning = table_symbol_tmp1[i].Meaning + "O";
                            }
                            break;

                        case parent_cl:
                            //Paréntesis que cierra
                            //Sino están abiertas las comillas
                            if (!quote_op1)
                            {
                                table_symbol_tmp1[i].Meaning = table_symbol_tmp1[i].Meaning + "C"; //Cerrar paréntesis
                            }
                            break;

                        case key_op:
                            ///Llaves que abren
                            //Sino están abiertas las comillas
                            if (!quote_op1)
                            {
                                table_symbol_tmp1[i].Meaning = table_symbol_tmp1[i].Meaning + "O"; //Abrir llaves
                            }
                            break;

                        case key_cl:
                            ///Llaves que cierra
                            //Sino están abiertas las comillas
                            if (!quote_op1)
                            {
                                table_symbol_tmp1[i].Meaning = table_symbol_tmp1[i].Meaning + "C"; //Cerrar llaves
                            }
                            break;

                        default:
                             if (quote_op1) //Si están abiertas las comillas
                                if (table_symbol_tmp1[i].Line.CompareTo(line) == 0) //Si es en la misma línea
                                {
                                    strings.Add(table_symbol_tmp1[i].Code);
                                    table_symbol_tmp1[i].Code = string_cod;
                                    table_symbol_tmp1[i].Meaning = cod;//está dentro de la comilla

                                }
                                else
                                    quote_op1 = false; //Cerrar comillas

                            break;
                    }

                    i++; //iteraciones
                 }
            }
            return table_symbol_tmp1;
        }

        /// <summary>
        /// Recorrer tabla de símbolos..
        /// </summary>
        private List<Symbol> parseTable() {
            //Recorrer table para determinar comentarios,cadenas..
            //columna dos: código del símbolo

            List<Symbol> table_symbol_tmp = Util.Util.Clone(table_symbol_cod);
            table_symbol_tmp = removeComments(table_symbol_tmp);

            //Establecer cadenas
            return table_symbol_tmp;
        }


        ///<summary>
        ///Método para crear tabla de símbolos
        /// </summary>
        /// <param name="sentences"></param>
        /// <returns>string</returns>
        public List<Symbol> createTableSymbol(string xsentences)
        {
            sentences = string.Copy(xsentences);

            int i = 0;
            string sentences_tmp;
          
            sentences_tmp = string.Copy(sentences);
            for (i = 0; i < sentences_tmp.Length; i++)
            {
                //Reemplazar símbolos
                for (int j = 0; j < symbol.Count; j++)
                {
                    sentences_tmp = sentences_tmp.Replace(symbol[j],symbolb[j]);
                }

                //Reemplazar parlabras reservadas
                for (int j = 0; j < word_reser.Count; j++)
                {
                    sentences_tmp = sentences_tmp.Replace(word_reser[j], word_reserb[j]);
                }
                //Reemplazar enter:cod_return
                sentences_tmp = sentences_tmp.Replace("\n", cod_return);
                //Eliminar retorno,tab
                sentences_tmp = sentences_tmp.Replace("\r", "");
                sentences_tmp = sentences_tmp.Replace("\t", "");
            }
            
            StringTokenizer token = new StringTokenizer(sentences_tmp, "|");
            int lines = new StringTokenizer(sentences, "\n").Count;
            int row = token.Count;

            List<Symbol> table_symbol_parse = null;
            
            int xrow = 0; //ïndice para tabla
            if (sentences_tmp.CompareTo("") != 0)
            {
                int xline = 1;
                while (token.hasMoreTokens())
                {
                    string tmp = token.nextToken();

                    if (tmp.CompareTo(cod_return.Replace("|", "")) != 0&& xrow < row-(lines-1))
                    {
                        table_symbol.Add(new Symbol(Convert.ToString(xline), translatorCode(tmp), isCad(tmp)));
                        table_symbol_cod.Add(new Symbol(Convert.ToString(xline), tmp, isCad(table_symbol[xrow].Code)));
                        xrow++;
                    }else
                        xline++;

                }
                //Ver comentarios
                table_symbol_parse =  this.parseTable();
                //Ver cadenas
                table_symbol_parse = this.setStrings(table_symbol_parse);
            }

            return table_symbol_parse;
        }

        ///<summary>
        ///Método para saber si es símbolo, palabra reservada, recibe como parámetro
        ///el código del símbolo
        ///</summary>
        private string isCad(string cad){
            //Verificar símbolos
            string cad1 = translator(symbolb, symbol, cad);
            string is1 = "Undefined";

            if (cad1.CompareTo(cad) == 0)
            {
                //palabra reservadas
                cad1 = translator(word_reserb, word_reser, cad);
                if (cad1.CompareTo(cad) == 0)
                    is1 = "Undefined";
                else
                    is1 = "Word_reser";
            }else
                is1 = "Symbol";

            return is1;
        }

        ///<summary>
        ///Traducir texto a código
        /// </summary>
        /// <param name="cad"></param>
        /// <returns>string</returns>
        private string translatorCad(string cad)
        {
            //Verificar símbolos
            string cad1 = translator(symbolb, symbol, cad);

            if (cad1.CompareTo(cad) == 0)
            {
                //palabra reservadas
                cad1 = translator(word_reserb, word_reser, cad);
            }

            return cad1;
        }

        ///<summary>
        ///Traducir código al equivalente en texto
        /// </summary>
        /// <param name="cad"></param>
        /// <returns>string</returns>
        public string translatorCode(string code)
        {
            code = "|" + code + "|";

            //Verificar símbolos
            string cad1 = translator(symbol, symbolb, code);

            if (cad1.CompareTo(code) == 0)
            {
                //palabra reservadas
                cad1 = translator(word_reser, word_reserb, code);
            }
            cad1 = cad1.Replace("|","");
            return cad1;
            
        }

        ///<summary>
        ///Regresa el equivalente en valor que se encuentra en element        
        /// </summary>
        /// <param name="element"></param>
        /// <param name="element_find"></param>
        /// <returns>string</returns>
        
        private string translator(List<string> element,List<string> elementb,string val)
        {
            bool b = false; int i = 0;
            while (i < elementb.Count && !b)
            {
                if (elementb[i].CompareTo(val) == 0)
                {
                    b = true;
                    return element[i];
                }
                i++;
            }

            return val; 
        }

    }


    /// <summary>
    /// Clase para realizar el análisis sintáctico de LEDEER
    /// </summary>
    public class SyntaxAnalyzer{
        private ErrorManager em;
        
        private List<Symbol> table_symbol = null; 
        public SyntaxAnalyzer(List<Symbol> xtable_symbol){
            table_symbol = xtable_symbol;

        }

        //Métodos get,set
        public List<Symbol> SymbolsTable
        {
            get { return table_symbol; }
        }

        //Verificar tabla de símbolos
        //Crear errores para análisis léxico
        private List<Error> checkTable(){ //regresa dirente de 0 si hay error 
            em = new ErrorManager();
            List<Error> le = new List<Error>();
            for (int i = 0; i < table_symbol.Count; i++)
                if (table_symbol[i].Meaning.ToString().CompareTo("Undefined") == 0){
                    int res ;
                    if (Int32.TryParse(table_symbol[i].Line, out res))
                    {
                        Error er = em.getError(1);
                        er.Line = res;
                        er.Symbol = table_symbol[i].Code;
                        le.Add(er);
                    }
                }
            return le; //No hay error en la tabla
        }
        ///<summary>
        ///Checar sintaxis
        ///</summary>
        public ResultAnalysis checkSyntax(){ //regresa un objeto de ResultAnalysis
            
            ResultAnalysis ra = new ResultAnalysis();
            List<Error> er1 = checkTable();
            if (er1.Count == 0) //No exista error
            {
                
                //Análizar sintaxis de la tabla de símbolo
                //Crear errores para análisis sintáctico
                
                //bool iter = true;
                int index1 = 0;

                bool newline = false;
                bool error = false;


                while (index1 < table_symbol.Count)//Mientras existan tokens
                {
                    Automata automata = new Automata();//Crear automata por línea
                    newline = false;
                    error = false;
                    int line = 0;
                    if (Int32.TryParse(table_symbol[index1].Line,out line)){//Obtener la línea en entero
                        //Analizar línea
                        while (!error && !newline && index1 < table_symbol.Count)
                        {
                            if (automata.ValidateSentence(table_symbol[index1].Code, table_symbol[index1].Line) == -1)
                            {//Si hay error
                                ra.SetError(automata.CurrentState,Symbol.traslatorCode(automata.Sentence), line); //Crear un error          
                                error = true;
                            }

                            int nextline = this.getNumberLine(table_symbol, index1+1);
                            if (nextline != line)//Si el siguiente token es otra línea sale del ciclo
                                newline = true;

                            if (error && index1 < table_symbol.Count)
                            { //ir hasta la linea nueva
                                index1 = getNexLineIndex(table_symbol, index1);
                            }else
                                index1++;
                        }
                        if (!error && !automata.ValidateAutomata())//Si al terminar la linea,el automata no queda en estado de acept. se establece error
                            ra.SetError(0, Symbol.traslatorCode(table_symbol[index1-1].Code), line);

                    }else
                      index1++;
                }
            }
            else
            {
                ra.Error = er1;
            }
            return ra; 
        }


        /// <summary>
        /// Método para obtener el índice de la nueva línea
        /// </summary>
        private int getNexLineIndex(List<Symbol> table, int index)
        {            
            int numberLine = getNumberLine(table, index);
            if (numberLine != 0)
            { //Que no exista error al llamar el método getNumberLine
                //if (index < table.Count-1){ 
                //bool newline = false; //int i = index;
                while (index < table.Count - 1)//comparar con el siguiente token
                {
                    if (table[index].Line.CompareTo(table[index + 1].Line) != 0)
                        return index+1;
                    index++; //Iterar índice
                }
                index = table_symbol.Count;
            }
            return index; //regresar índice con el que se llamo la función
        }


        ///<summary>
        ///Método para obtener número de línea, regresa 0 si existe algun error
        ///</summary>
        private int getNumberLine(List<Symbol> table, int index)
        {
            if (index >= 0 && index < table.Count)
            {
                int numberLine = 0;
                if (Int32.TryParse(table[index].Line, out numberLine))
                    return numberLine;
            }
            return 0;
        }
    }
    

    //Declarar Analazadores
    private LexicalAnalyzer lexan;
    private SyntaxAnalyzer synan;
    private string sentences;

	public AnalyzerLEDEER(string xsentences)
	{
        //Set sentencias
        sentences = xsentences;
        //Construir análisis
        lexan = new LexicalAnalyzer();//Analizador léxico
        synan = new SyntaxAnalyzer(lexan.createTableSymbol(sentences)); //Crear tabla de símbolo
	}

    ///<summary>
    /// Métodos get,set
    /// </summary>
    private LexicalAnalyzer LexAnalyzer
    {
        get { return lexan; }
    }

    private SyntaxAnalyzer SynAnalyzer
    {
        get { return synan; }
    }

    //Get Symbols Table
    public List<Symbol> getSymbolsTable(){
        return synan.SymbolsTable;
    }

    /// <summary>
    /// Revisa si la sintaxis del escenario es correcta,
    /// regresa un objeto de tipo ResultAnalysis.
    /// </summary>
    /// <returns>ResultAnalysis</returns>
    public ResultAnalysis CheckSyntax()
    {
        return SynAnalyzer.checkSyntax();
    }

    /// <summary>
    /// Revisa si la sintaxis del escenario es correcta, con la sentencia que fue construido el objeto
    /// </summary>
    /// <returns></returns>
    public bool CheckSyntaxB() 
    {
       ResultAnalysis ra = SynAnalyzer.checkSyntax();
       if (ra.Error.Count == 0)
           return true;

       return false;
    }


    /// <summary>
    /// Revisa si la sintaxis del escenario es correcta, recibe como parámetro las sentencias
    /// </summary>
    /// <returns></returns>
    public bool CheckSyntaxB(string xsentences)
    {
        if (xsentences.CompareTo(String.Empty) != 0)
        {
            sentences = xsentences;
            lexan = new LexicalAnalyzer();//Analizador léxico nuevo
            synan = new SyntaxAnalyzer(lexan.createTableSymbol(sentences)); //Crear tabla de símbolo nueva

            ResultAnalysis ra = synan.checkSyntax();
            if (ra.Error.Count == 0)
                return true;

            return false;
        }
        return true;
    }

    /// <summary>
    /// Método para obtener todas las cadenas de una sentencia,
    /// para llamarlo se tiene que haber realizado el análisis LEDEER
    /// </summary>
    /// <returns></returns>
    public List<string> getStrings(){
        return lexan.getStrings();
    }

    //public ResultAnalysis executeAnalysis(string sentences){

    //}

        
}


