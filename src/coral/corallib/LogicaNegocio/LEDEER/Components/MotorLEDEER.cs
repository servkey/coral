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
using LEDEERTools;
using System.Xml;
using Util;
using StringTools;
/// <summary>
/// Summary description for MotorLEDEER
/// </summary>
public class MotorLEDEER
{
    
    //Análisis escenario
    private AnalyzerLEDEER al;
    private DefinerLEDEER def;
    public MotorLEDEER()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    /// <summary>
    /// Ejecutar una funcionalidad
    /// </summary>
    /// <param name="namearena"></param>
    /// <param name="nameaction"></param>
    /// <param name="nameuser"></param>
    /// <returns></returns>
    public bool executeScenario(string namearena, string nameaction, string nameuser){
        bool exec = false;
        if (namearena.CompareTo(String.Empty) != 0 && nameaction.CompareTo(String.Empty) != 0 && nameuser.CompareTo(String.Empty) != 0)
        {
            def = new DefinerLEDEER();

            
            string namescenario = def.getScenarioOfAction(namearena, nameaction);
            DataSet sentences = def.getSentencesOfScenario(namearena, namescenario);
            string sentencesIPre = "";
            string sentencesIPos = "";
            string sentencesFPre = "";
            string sentencesFPos = "";
            try
            {
                foreach (DataRow dr in sentences.Tables[0].Rows){
                    if (dr["AtrProcess"].ToString().CompareTo("Initialize") == 0 && dr["AtrType"].ToString().CompareTo("Precondition") == 0)
                        sentencesIPre = dr["AtrSentence"].ToString();
                    else if (dr["AtrProcess"].ToString().CompareTo("Initialize") == 0 && dr["AtrType"].ToString().CompareTo("Poscondition") == 0)
                        sentencesIPos = dr["AtrSentence"].ToString();
                    else if (dr["AtrProcess"].ToString().CompareTo("Finalize") == 0 && dr["AtrType"].ToString().CompareTo("Precondition") == 0)
                        sentencesFPre = dr["AtrSentence"].ToString();
                    else if (dr["AtrProcess"].ToString().CompareTo("Finalize") == 0 && dr["AtrType"].ToString().CompareTo("Poscondition") == 0)
                        sentencesFPos = dr["AtrSentence"].ToString();
                }

                //Revisar sintaxis
                al = new AnalyzerLEDEER(sentencesIPre);
                
                //Tablas de símbolos 
                List<Symbol> tableIPre;
                List<string> stringsIPre;
                List<Symbol> tableIPos;
                List<string> stringsIPos;
                List<Symbol> tableFPre;
                List<string> stringsFPre;
                List<Symbol> tableFPos;
                List<string> stringsFPos;

                if (al.CheckSyntaxB()){
                    tableIPre = al.getSymbolsTable();
                    stringsIPre = al.getStrings();
                    if (al.CheckSyntaxB(sentencesIPos))
                    {
                        tableIPos = al.getSymbolsTable();
                        stringsIPos = al.getStrings();
                        if (al.CheckSyntaxB(sentencesFPre))
                        {
                            //Tabla y cadenas 1 
                            tableFPre = al.getSymbolsTable();
                            stringsFPre = al.getStrings();

                            if (al.CheckSyntaxB(sentencesFPos))
                            {
                                string PATH = "C:\\inetpub\\wwwroot\\LEDEER\\" + LEDEER.path_XML;
                                string path = PATH + new LogicaNegocio().Ledeer().ExportXML(namearena, PATH);
                                List<string> table_def = new List<string>();

///                                table_def.Insert();         
                                XmlReader xml = new XmlTextReader(path);
                                Util.Util.XMLReadFile(xml, table_def);
                                

                                tableFPos = al.getSymbolsTable();
                                stringsFPos = al.getStrings();

                                if (Util.Util.ValueOnCode(table_def, Symbol.CODEACTORS, nameuser) != -1
                                    && Util.Util.ValueOnCode(table_def, Symbol.CODEACTION, nameaction) != -1    
                                )
                                {
                                    //Ejecutar
                                    //Init, Pre
                                    exec = executeSentences(stringsIPre, tableIPre, table_def, namearena,nameaction,nameuser);
                                    //Init, Pos
                                    if (exec && tableIPos.Count>0)
                                        exec = executeSentences(stringsIPos, tableIPos, table_def, namearena, nameaction,nameuser);
                                        //Fin, Pre
                                        if (exec)
                                            exec = executeSentences(stringsFPre, tableFPre, table_def, namearena,nameaction,nameuser);
                                        if (exec)
                                            //Fin, Pos
                                            exec = executeSentences(stringsFPos, tableFPos, table_def, namearena,nameaction,nameuser);
                                }
                                else
                                    exec = false;
                                return exec;
                            }
                        }
                    }
                }                
            }
            catch
            {
                ;
            }
            
        }
        return false; //No se puede ejecutar si se llega hasta aquí
    }


    /// <summary>
    /// Método para ejecutar sentencias.
    /// </summary>
    /// <param name="tableStrings"></param>
    /// <param name="tableSymbols"></param>
    /// <returns></returns>
    private bool executeSentences(List<string> tableStrings, List<Symbol> tableSymbols, List<string> table_def ,string namearena, string nameaction, string nameuser)
    {
        bool band = true;

     
        if (table_def != null)
        {

            //bool end = true;
            int indstring = 0;
            int i = 0;
            bool role = false;
            while (i < tableSymbols.Count)// && end) //Leer otra linea
            {
                
                List<string> table_var = new List<string>();

                //Comenzar con palabra reservada
                if (Symbol.IsWordReserv(tableSymbols[i].Code)) //Si es palabra reservada
                {
                    int iold;
                    
                   if (getNextOperatorB(tableSymbols, i, out iold) && getNumberOperator(tableSymbols, i) == 1)//hay operadores)//&& !endLine(tableSymbols, i))
                   {
                        fullSentence(tableSymbols,tableStrings, table_var,i,iold,indstring,out i, out indstring);
                   }
                   else
                   {
                        //Sin  operador, es definición
                        fullSentence(tableSymbols, tableStrings, table_def, i, 0, indstring, out i, out indstring);
                    }

                    //Interpretar sentencia
                 
                    if (!caseExec(table_def, table_var,namearena, nameaction, nameuser,role, out role ))
                        return false;
                    i++;
                }
                else
                    i++;
            }
            
        }
        else
            band = false;


        return band;
    }

    /// <summary>
    /// Método para obtener índice de la palabra reservada
    /// que está ante del operador.
    /// Recibe como parámetro:
    ///     Tabla de sentencias.
    ///     Índice de operador.
    /// Regresa -1 se no existe una palabra reservada.
    /// 
    /// </summary>
    /// <param name="table_var"></param>
    /// <param name="iO"></param>
    /// <returns></returns>
    private int getIndexWord(List<string> table_var, int iO)
    {
        for (int i = iO - 1; i < table_var.Count;i--)
        {
            if (Symbol.IsWordReserv(table_var[i]))
                return i;
        }
        return -1;
    }

    private bool getNextOperatorB(List<string> table_var, out int iO){
        iO = 0;
        for (int i = 0; i<table_var.Count;i++)
            if (Symbol.IsOperator(table_var[i]))
            {
                iO = i;
                return true;
            }

        return false;
    }

    private int getNextWordReserv(List<string> table_var, int i)
    {
        for (int i1 = i; i1 < table_var.Count; i1++)
        {
            if (!Symbol.IsOperator(table_var[i1]))
            {
                if (Symbol.IsWordReserv(table_var[i1]))
                    return i1;
            }
            else
                break;
        }

        return -1;
    }


    /// <summary>
    /// Método que interpreta la tabla de sentencias.
    /// Recibe como parámetros:
    ///     Tabla de definición.
    ///     Tabla de sentencias.
    ///     Nombre de la arena.
    ///     Nombre de la acción.
    ///     Nombre del actor.
    /// </summary>
    /// <param name="table_def"></param>
    /// <param name="table_var"></param>
    /// <param name="namearena"></param>
    /// <param name="nameaction"></param>
    /// <param name="nameuser"></param>
    /// <returns></returns>
    public bool caseExec(List<string> table_def, List<string> table_var,string namearena,string nameaction, string nameuser, bool role0, out bool role1)
    {
        bool band = true;
        int iO = 0;
        role1 = role0;
        if (getNextOperatorB(table_var, out iO)){
            bool exec = true;
            string role = Util.Util.getValueOfElement(table_def, Symbol.CODEROLESS, Symbol.CODEACTORS, nameuser);
            if (role != null)
            {
                int index = getIndexWord(table_var,iO);
                if (index != -1){
                    bool matchrole = false;
                    bool matchactor = false;
                    bool matchaction = false;
                    for (int i = index + 1; i < iO; i++)
                    {
                        //Comenzar con cadenas
                        if (Util.Util.ValueOnCode(table_def,table_var[index],table_var[i]) != -1){
                            if (table_var[index].CompareTo(Symbol.CODEACTORS) == 0||
                                table_var[index].CompareTo(Symbol.CODEROLESS) == 0){
                                    if (table_var[i].CompareTo(nameuser) == 0)
                                    {
                                        matchactor = true;
                                        break;
                                    }
                                    else if (table_var[i].CompareTo(role) == 0)
                                    {
                                        matchrole = true; //Coincide con role o actor
                                        break;
                                    }
                            }
                             
                        }
                    }
                    if (table_var[iO].CompareTo(Symbol.CODEEXECUT) == 0)
                    {
                        int index1 = getNextWordReserv(table_var,iO+1);
                        if (index1 != -1)
                        {
                            if (table_var[index1-1].CompareTo(Symbol.CODENEGOPE) == 0)
                                exec = false;

                            index1 = getIndexWord(table_var, table_var.Count - 1);
                            for (int i2 = index1 + 1; i2 < table_var.Count; i2++)
                                if (Util.Util.ValueOnCode(table_def, table_var[index1], table_var[i2]) != -1)
                                    if (table_var[i2].CompareTo(nameaction) == 0)
                                    {
                                        if (matchactor || matchrole)
                                        {
                                             matchaction = true;
                                            break;
                                        }
                                    }

                        }

                        if ((!matchactor && !matchrole && !matchaction && !role0) || (!exec && matchaction))
                             band = false;
                        else
                             role1 = true;
                                     

                        



                        
                    }
                }
                else
                    band = false; //No se realiza
            }
            else
                band =  false; //No se realiza
        }

        return band;
    }

    /// <summary>
    /// Método para colocar en la tabla de symbolos las sentencias separadas.
    /// </summary>
    /// <param name="tableSymbols">tabla de símbolos</param>
    /// <param name="tableStrings">tabla de cadenas</param>
    /// <param name="table_var">tabla donde los symbolos son insertados</param>
    /// <param name="i">Índice de la tabla de símbolos</param>
    /// <param name="iold">Índice del operador, si el valor es menor a 0 no hay operador</param>
    /// <param name="indstring">Índice de la tabla de cadenas</param>
    /// <param name="i1">Índice de salida para el índice de la tabla de símbolos</param>
    /// <param name="i2">Índice de salida para el índice de la tabla de cadenas</param>
    /// <returns></returns>
    private bool fullSentence(List<Symbol> tableSymbols, List<string>tableStrings, List<string> table_var, int i, int iO, int indstring,out int i1,out int i2)
    {

        bool bandC = true;
        bool bO = false;//Bandera de operador 
        
        bool def = false; //bandera para activa llenar cadenas
        int line = Convert.ToInt32(tableSymbols[i].Line);
        string word_ant = "";
        string string_ant = "";
        int iold = 0;
        List<string> vare = new List<string>();
        while (bandC && !endLine(tableSymbols, i, out iold))//line == Convert.ToInt32(tableSymbols[i].Line))
        {
            
            if (getNextWordReservB(tableSymbols, i, out iold) && !def)
            {
                //Si hay operador
                if (iO > 0 && (iold > iO || iold == iO) && !bO) //Agregar operador
                {
                    table_var.Add(tableSymbols[iO].Code);
                    bO = true;
                    word_ant = "";
                    string_ant = "";
                }

                switch (tableSymbols[iold].Code)
                {
                    case Symbol.CODEOBJECT:
                    case Symbol.CODEACTORS:
                        if (word_ant.CompareTo(Symbol.CODEARENAS) != 0 && word_ant.CompareTo(Symbol.CODEACTION) != 0 && word_ant.CompareTo(String.Empty) != 0)
                            bandC = false;
                        break;
                    case Symbol.CODEROLESA:
                    case Symbol.CODEROLESS:
                        if (word_ant.CompareTo(Symbol.CODEARENAS) != 0 && word_ant.CompareTo(Symbol.CODEACTORS) != 0 && word_ant.CompareTo(String.Empty) != 0)
                            bandC = false;
                        break;

                    case Symbol.CODEACTION:
                        if (word_ant.CompareTo(Symbol.CODEARENAS) != 0 && word_ant.CompareTo(String.Empty) != 0)
                            bandC = false;
                        break;
                    case Symbol.CODEARENAS:
                        if (word_ant.CompareTo(String.Empty) != 0)
                            bandC = false;
                        break;

                }


                if (bandC)
                {
                    //Agreagar palabra reservada 
                    //a la tabla 

                    i = iold;
                    string_ant = "";
                    word_ant = tableSymbols[i].Code;

                    if (iO > 0) //Si hay operador
                    {
                        if (IsNegWordReser(tableSymbols, i))
                            table_var.Add(Symbol.CODENEGOPE);
                        table_var.Add(tableSymbols[i].Code);

                        i++;

                        if (endLine(tableSymbols, i, out iold))
                        {
                            fullTable(table_var, word_ant);
                        }
                    }
                    else
                        Util.Util.addWord(table_var,tableSymbols[i].Code);
                    def = true;
                }

            }
            else if (getNextStringB(tableSymbols, i, out iold) && def)//hay cadenas
            {
                i = iold;
                string_ant = tableStrings[indstring];
                
                if (iO > 0 && (i > iO || i == iO) && !bO) //Agregar operador
                {
                    table_var.Add(tableSymbols[iO].Code);
                    bO = true;
                }

                List<string> st = Util.Util.parseStrings(tableStrings[indstring]);

                if (st.Count > 0)//Si hay más de una cadena
                    foreach (string st1 in st)
                        if (iO > 0)//Si hay operador 
                            table_var.Add(st1);
                        else //Sino hay operador
                            Util.Util.addVar(table_var,word_ant,st1);
                else
                    if (iO > 0)//Si hay operador
                        table_var.Add(tableStrings[indstring]);
                    else //Sino hay operador
                        if (word_ant.CompareTo(Symbol.CODEROLESS) != 0 &&
                            word_ant.CompareTo(Symbol.CODEACTORS) != 0)
                            Util.Util.addVar(table_var, word_ant, tableStrings[indstring]);
                        else
                        {
                            switch(word_ant){
                                case Symbol.CODEACTORS:
                                    findVar(table_var,word_ant,string_ant, vare);
                                    break;
                                case Symbol.CODEROLESS:
                                    foreach(string str in vare)//Asignar
                                       assingVar(table_var, Symbol.CODEACTORS, str, tableStrings[indstring]);
                                   break;
                            }

                            
                        }

                
                indstring++;
                i++;

                def = false; //Activar palabra resevada
                
            }
            else
                bandC = false;
        }

        i1 = i;
        i2 = indstring;

        return bandC;
        
    }

    private void assingVar(List<string> table_var, string code, string strF, string strR){
        string cod1 = null;
        if (code.CompareTo(Symbol.CODEACTORS) == 0)
            cod1 = find(table_var,Symbol.CODEROLESS,strF);
        
        if (cod1 != null){
            int i = table_var.IndexOf(code);
            if (i != -1)
            {
                for (int j = 0; j < table_var.Count; j++)
                {
                    string token = Util.Util.getTokenActors(table_var[j]);
                    if (token.CompareTo(strF) == 0)
                    {
                            table_var[j] = cod1 + "," + token;
                            return;
                    }
                    else if (Symbol.IsWordReserv(table_var[j]))
                            return;
                }
            }
               
        }
        return;
    }

    private string find(List<string> table_var, string code, string var)
    {
        int i = table_var.IndexOf(code);
        if (code.CompareTo(Symbol.CODEACTORS) == 0)
        {

            if (i != -1)
            {
                for (int j = i + 1; j < table_var.Count; j++)
                {
                    if (Util.Util.getTokenActors(table_var[j]).CompareTo(var) == 0)
                    {
                        return new StringTokenizer(table_var[j],",").NextToken;;
                    }
                    else if (Symbol.IsWordReserv(table_var[j]))
                        return null;
                }
            }
        }
        else //compara tal cual
        {
            if (i != -1)
            {
                for (int j = i + 1; j < table_var.Count; j++)
                {
                    if (table_var[j].CompareTo(var) == 0)
                        return table_var[j];
                    else if (Symbol.IsWordReserv(table_var[j]))
                        return null;
                }
            }
        }

        return null;
    }

    private void findVar(List<string> table_var,string code, string string_ant, List<string> ida){
        string_ant = string_ant.ToUpper();
        try
        {
            StringTokenizer str = new StringTokenizer(string_ant, ",");
            while (str.HasMoreTokens)
            {
                string cmp = str.NextToken;
                if (find(table_var, code, cmp) != null)
                     ida.Add(cmp);
                
            }            
        }
        catch
        {
        }
    }
    
    /// <summary>
    /// Método que regresa verdadero si la palabra reservada es negada
    /// recibe como parámetros:
    ///     Índice de la palabra reservada, tabla de símbolos.
    /// </summary>
    /// <param name="table"></param>
    /// <param name="i"></param>
    /// <returns></returns>
    private bool IsNegWordReser(List<Symbol> table, int i){

        try{
            for (int j = i-1;j<table.Count;j--)
            {
                if (!Symbol.IsOperator(table[j].Code))
                {
                    if (!Symbol.IsWordReserv(table[j].Code) && !Symbol.IsString(table[j].Code) && table[j].Code.CompareTo(Symbol.CODENEGOPE) == 0)
                        return true;
                }
                else
                    return false;
            }

        }
        catch
        {
        }

        return false;
    }

    /// <summary>
    /// Método para agregar cadena a las palabras reservadas
    /// </summary>
    /// <param name="tableSymbols"></param>
    /// <param name="i"></param>
    private void fullTable(List<string> table_var, string code)
    {
        switch (code)
        {
            case Symbol.CODEARENAS:
            case Symbol.CODEACTION:
            case Symbol.CODEACTORS:
            case Symbol.CODEROLESS:
            case Symbol.CODEOBJECT:
            case Symbol.CODEROLESA:
                table_var.Add("*");
                break;
        }
    }

    /// <summary>
    /// Método que regresa verdadero si el elemento existe en la table <List>
    /// </summary>
    /// <param name="table"></param>
    /// <param name="code"></param>
    /// <returns></returns>

    private bool existTable(List<string> table, string code)
    {
        try{
            for (int i = 0; i < table.Count; i++)
                if (table[i].CompareTo(code) == 0)
                    return true;
        }catch{
        }

        return false;
    }

    /// <summary>
    /// Método para ver si la línea ha terminado.
    /// </summary>
    /// <param name="tableSymbols"></param>
    /// <param name="i"></param>
    /// <returns></returns>
    public bool endLine(List<Symbol> tableSymbols, int i, out int old)
    {
        old = i;
        try
        {

            for (int j = i+1; j < tableSymbols.Count; j++)
            {
                int line = Convert.ToInt32(tableSymbols[j-1].Line);
                old = j + 1;
                if (Convert.ToInt32(tableSymbols[j].Line) == line && tableSymbols[j].Code.CompareTo(Symbol.CODEENDLIN) != 0)
                {
                    if ((Symbol.IsString(tableSymbols[j].Code) ||
                        Symbol.IsWordReserv(tableSymbols[j].Code)))
                        return false;

                }
                else
                    break;
            }
        }
        catch
        {
        }

        return true;
    }


    /// <summary>
    /// Método para ver si hay cadenas en el operando
    /// </summary>
    /// <param name="tableSymbols"></param>
    /// <param name="i"></param>
    /// <returns></returns>
    public bool getNextStringB(List<Symbol> tableSymbols, int i,out int i1){
        i1 = getNextString(tableSymbols, i);

        if (i1 != i)
            return true;
        return false;
    }

    /// <summary>
    /// Método que regresa el índice de la
    /// siguiente palabra reservada
    /// si regresa el mismo índice
    /// ya no ya palabra en el enunciado.
    /// </summary>
    /// <param name="table"></param>
    /// <param name="index"></param>
    /// <returns></returns>
    public int getNextWordReserv(List<Symbol> table, int index)
    {
        try
        {
            int i = index;
            bool b = true;
            while (i < table.Count && b && !Symbol.IsOperator(table[i].Code)){
                if (Symbol.IsWordReserv(table[i].Code))
                    return i;
                i++;
            }
        }
        catch
        {
        }
        return index;
    }

    


    /// <summary>
    /// Método que regresa el índice de la
    /// siguiente palabra reservada
    /// si regresa verdadero si hay siguiente
    /// y si regresa falso no hay palabra en el enunciado.
    /// </summary>
    /// <param name="table"></param>
    /// <param name="index"></param>
    /// <returns></returns>
    public bool getNextWordReservB(List<Symbol> table, int index, out int index1)
    {
        index1 = index;
        try
        {  
            while (index < table.Count)// && !Symbol.IsOperator(table[index].Code))
            {
                if (Symbol.IsWordReserv(table[index].Code))
                {
                    index1 = index;
                    return true;
                }
                index++;
            }
        }
        catch
        {
        }
        return false;
    }

    


    /// <summary>
    /// Método que regresa el índice de la siguiente cadena,
    /// si regresa el mismo índice significa que no hay una cadena para 
    /// la palabra reservada
    /// </summary>
    /// <param name="table"></param>
    /// <param name="index"></param>
    /// <returns></returns>
    public int getNextString(List<Symbol> table, int index)
    {
        try
        {
            int i = index;

         //   if (table[index].Code.CompareTo(Symbol.CODEREFERE)==0)
                while (i < table.Count && !Symbol.IsOperator(table[i].Code))
                {
                    if (Symbol.IsString(table[i].Code))
                        return i;
                    i++;
                }
        }
        catch
        {
        }
        return index;
    }

    /// <summary>
    /// Método para obetener el índicedel operador
    /// </summary>
    /// <param name="table"></param>
    /// <param name="index"></param>
    /// <returns></returns>
    public int getNextOperator(List<Symbol> table, int index)
    {
        try
        {
            int i = index;
            
             while (i < table.Count)
             {
                    if (Symbol.IsOperator(table[i].Code))
                        return i;
                    i++;
             }
        }
        catch
        {
        }
        return index;
    }

    /// <summary>
    /// Método que regresa verdadero si hay aperador por delante del índice.
    /// </summary>
    /// <param name="table"></param>
    /// <param name="index"></param>
    /// <returns></returns>
    public bool getNextOperatorB(List<Symbol> table, int i, out int index)
    {
        index = getNextOperator(table, i);

        if (index != i)
            return true;

        return false;
    }

    /// <summary>
    /// Método para obtener el numero de openrandos desde
    /// el índice hasta el fin de linea
    /// </summary>
    /// <param name="table"></param>
    /// <param name="i"></param>
    /// <returns></returns>
    public int getNumberOperator(List<Symbol> table, int i)
    {
        int tmp,count = 0;
         
        try{
            
            while (!endLine(table, i,out tmp) && i< table.Count)
            {
                if (Symbol.IsOperator(table[i].Code))
                    count++;

                i++;
            }
        }catch{
        }
        return count;
    }
    

}
