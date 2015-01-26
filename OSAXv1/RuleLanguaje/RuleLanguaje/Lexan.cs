using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace RuleLanguaje
{
    class Lexan
    {
        /*public const char ACTOR = 'a';
        public const char OBJECT = 'o';
        public const char TASK = 'x';
        public const char ELEMENT = 'm';
        public const char VALUE = 'v';
        public const char ATTRIBUTE = 't';*/

        public const int EXPRESION = 1001; // elemento.atributo[Operador]valor
        public const int INT1 = 1002; // actor-tarea
        public const int INT2 = 1003; // (actor-objeto)-tarea
        public const int INT3 = 1004; // actor-tarea-objeto | actor-tarea-actor
        public const int INT4 = 1005; // (actor-objeto)-tarea-objeto | (actor-objeto)-tarea-actor
        public const int ERROR = 1006; // error, no hace match con nigun tipo
        //Expresiones regulares        
        private readonly string exprx = @"\w+\.\w+[+|=|<|>][\d\.\d|\d|\w+]";
        private readonly string int1rx = @"^\w+-\w+";
        private readonly string int2rx = @"\(\w+-\w+\)-\w+";
        private readonly string int3rx = @"\w+-\w+-\w+";
        private readonly string int4rx = @"\(\w+-\w+\)-\w+-\w+";

        private DBSeeker dbvalidator;
        string result;


        /*
         * leer linea (p.e.: actor-tarea-objeto & elemento.atributo[Operador]valor & (actor-objeto)-tarea-actor : actor-tarea-objeto)
         * dividir sentencia en condición - consecuencia
         * para condicion:
         * |     dividir condición en expresiónes y/o interacciones
         * |     para cada interaccion y/o expresión:
         * |     |    evaluar con expresión regular
         * |     |    si es válido
         * |     |    |    validar nombres  y/o atributos existentes conn el modelo de dominio
         * |     |    |    si existen
         * |     |    |    |    agregar token en lista de tokens según la categoría
         * |     |    |    si no
         * |     |    |    |    enviar a rutina de error
         * |     |    si no
         * |     |    |    enviar a rutina de error
         * para consecuencia:
         * |     evaluar con expresión regular
         * |     si es válido
         * |     |    dividir consecuencia en elementos
         * |     |    por cada elemento
         * |     |    |    validar elemento con modelo de dominio
         * |     |    |    si existe
         * |     |    |    |    agregar token de categoría a lista de tokens
         * |     |    |    si no
         * |     |    |    |    enviar a rutina de error
         * |     si no
         * |     |    enviar a rutina de error
         * regresar lista de tokens
         */
        public Lexan()
        {            
            result = "";
            dbvalidator = new DBSeeker("AssaultCube"); //change to deal with any study case
        }

        public string Analize(string input)
        {
            if (!input.Contains(":"))
            {
                return "Consecuence is missing";
            }
            string condition = input.Split(':')[0];
            string consecuence = input.Split(':')[1];
            //para condición
            string[] members = condition.Split('&');            
            foreach (string m in members)
            {                                
                switch (kindOf(m))
                {
                    case EXPRESION:
                        //Console.WriteLine("\n{0} is an expression!", m);
                        if(!dbvalidator.validateExpression(m.Split(new char[]{'.'})[0],m.Split(new char[]{'.','=','>','<','!'})[1])) {result = m +" not valid" ; return result;}
                        else result += "m . t = v";                        
                        break;
                    case INT1: // is the form: a - x
                        //Console.WriteLine("\n{0} is the form: a - x ", m);
                        if (!dbvalidator.validateActor(m.Split('-')[0]) || !dbvalidator.validateTask(m.Split('-')[1])) { result = m + " not valid"; return result; }
                        else result += "a - x";
                        break;
                    case INT2://( a - o ) - x
                        //Console.WriteLine("\n{0} is the form: ( a - o ) - x ", m);
                        string aux = clean(m);
                        if (!dbvalidator.validateActor(aux.Split('-')[0]) || !dbvalidator.validateObject(aux.Split('-')[1]) || !dbvalidator.validateTask(aux.Split('-')[2])) { result = m + " not valid"; return result; }
                        else result += "( a - o ) - x";
                        break;
                    case INT3: //a - x - o
                        //Console.WriteLine("\n{0} is the form: a - x - o  OR  a - x - a ", m);
                        if (!dbvalidator.validateActor(m.Split('-')[0]) || !dbvalidator.validateTask(m.Split('-')[1])) { result = m + " not valid"; return result; }
                        else
                        {
                            if (dbvalidator.validateObject(m.Split('-')[2])) result += "a - x - o";
                            else if (dbvalidator.validateActor(m.Split('-')[2])) result += "a - x - a";
                            else result = m + " not valid";
                        }                        
                        break;
                    case INT4:
                        //Console.WriteLine("\n{0} is the form: ( a - o ) - x - o  OR  ( a - o ) - x - a ", m);
                        string aux2 = clean(m);
                        if (!dbvalidator.validateActor(aux2.Split('-')[0]) || !dbvalidator.validateObject(aux2.Split('-')[1]) || !dbvalidator.validateTask(aux2.Split('-')[2])) { result = m + " not valid"; return result; }
                        else
                        {
                            if (dbvalidator.validateObject(aux2.Split('-')[3])) result += "( a - o ) - x - o";
                            else if (dbvalidator.validateActor(aux2.Split('-')[3])) result += "( a - o ) - x - a";
                            else { result = m + " not valid"; return result; }
                        }                        
                        break;
                    default:
                        //Console.WriteLine("\n{0} is not valid!!", m);
                        result += m + " does not match with any sintactic rule";
                        return result;
                }                
                result += " & ";
            }
            result = result.TrimEnd(new char[] { '&', ' ' }) + " : ";
            
            // validar consecuencia
            members = consecuence.Split('&');
            foreach (string m in members)
            {
                switch (kindOf(m))
                {                    
                    case INT1: // is the form: a - x
                        //Console.WriteLine("\n{0} is the form: a - x ", m);
                        if (!dbvalidator.validateActor(m.Split('-')[0]) || !dbvalidator.validateTask(m.Split('-')[1])) { result = m + " not valid"; return result; }
                        else result += "a - x";
                        break;
                    case INT2://( a - o ) - x
                        //Console.WriteLine("\n{0} is the form: ( a - o ) - x ", m);
                        string aux = clean(m);
                        if (!dbvalidator.validateActor(aux.Split('-')[0]) || !dbvalidator.validateObject(aux.Split('-')[1]) || !dbvalidator.validateTask(aux.Split('-')[2])) { result = m + " not valid"; return result; }
                        else result += "( a - o ) - x";
                        break;
                    case INT3: //a - x - o
                        //Console.WriteLine("\n{0} is the form: a - x - o  OR  a - x - a ", m);
                        if (!dbvalidator.validateActor(m.Split('-')[0]) || !dbvalidator.validateTask(m.Split('-')[1])) { result = m + " not valid"; return result; }
                        else
                        {
                            if (dbvalidator.validateObject(m.Split('-')[2])) result += "a - x - o";
                            else if (dbvalidator.validateActor(m.Split('-')[2])) result += "a - x - a";
                            else result = m + " not valid";
                        }
                        break;
                    case INT4:
                        //Console.WriteLine("\n{0} is the form: ( a - o ) - x - o  OR  ( a - o ) - x - a ", m);
                        string aux2 = clean(m);
                        if (!dbvalidator.validateActor(aux2.Split('-')[0]) || !dbvalidator.validateObject(aux2.Split('-')[1]) || !dbvalidator.validateTask(aux2.Split('-')[2])) { result = m + " not valid"; return result; }
                        else
                        {
                            if (dbvalidator.validateObject(aux2.Split('-')[3])) result += "( a - o ) - x - o";
                            else if (dbvalidator.validateActor(aux2.Split('-')[3])) result += "( a - o ) - x - a";
                            else { result = m + " not valid"; return result; }
                        }
                        break;
                    default:
                        //Console.WriteLine("\n{0} is not valid!!", m);
                        result += m + " does not match with any sintactic rule";
                        return result;
                }
                result += " & ";
            }
            result = result.TrimEnd(new char[] { '&', ' ' });
            return result;            
        }

        private int kindOf(string member)
        {
            if (new Regex(exprx).Match(member).Success) return EXPRESION;
            if (new Regex(int4rx).Match(member).Success) return INT4;            
            if (new Regex(int3rx).Match(member).Success) return INT3;            
            if (new Regex(int2rx).Match(member).Success) return INT2;
            if (new Regex(int1rx).Match(member).Success) return INT1;
            return ERROR;
        }

        private string clean(string c)
        {
            return String.Join("", c.Split('(',')'));
        }
    }
}


