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
using System.Text;
//using LEDEERTools;
/// <summary>
///Análisis léxico
///Clase automata empleada para el analisis  sintáctico
/// Función:
///     Se envía un token
///     Con el método 
///     ValidateSentence(token)
///     Después la función realiza la transición con
///     el método Trasition();
/// Estados de error: 
///     Estado 1;
/// Estados de aceptación:
///     Estados 8,9;
/// </summary>
namespace LEDEERTools
{
    public class Automata
    {
        /*
            Símbolos
                000001 = :: 
                000002 = -> 
                000003 = :
                000004 = (
                000005 = )
                000006 = {
                000007 = }
                000008 = " //Comilla abierta
                000088 = " //Comilla cerrada
                000009 = !
                000010 = ;
                000011 = /*
                000012 = */

        /*
            Palabras reservadas
                Arenas  = 000013
                Actors  = 000014
                Roles   = 000015
                RolesAct= 000016
                Objects = 000017
                Actions = 000018
                <str>   = 000019
                Exit    = 000020
 
         */
        
        private string sentence; //Sentencia a analizar
        private int current_st = 0; //Estado actual del autómata
        private int old_st = 0; //Estado anterior
        private string old_sentence; //Sentencia anterior
        private string line; //linea se la sentencia
        private bool final = false;
        private bool neg = false;
        private List<String> parents = new List<String>();
        //Constructor
        public Automata()
        {
            //List<Symbol> xtable
            //table_symbol = Util.Util.Clone(xtable);
        }

        //Métodos get y set
        public string Sentence
        {
            set { sentence = value; }
            get { return sentence; }
        }

        public int CurrentState
        {
            set { current_st = value; }
            get { return current_st; }
        }

        public string OldSentence
        {
            set { old_sentence = value; }
            get { return old_sentence; }
        }

        public string Line
        {
            set { line = value; }
            get { return line; }
        }


        public int OldState
        {
            set { old_st = value; }
            get { return old_st; }
        }

        private bool IsValue(string xvalue, string xcode)
        {
            if (xvalue.CompareTo(xcode) == 0)
                return true;
            return false;
        }

        //Métodos para las transiciones
        private int Transition()
        {
            switch (current_st)
            {
                case 0://Estado inicial acepta  palabras reservadas y paréntesis que abre
                case 2:

                    if (IsValue(sentence, Symbol.CODEPARENO))
                    {
                        parents.Add(Symbol.CODEPARENO);
                        current_st = 2; //Ir al estado 2
                    }
                    else if (IsValue(sentence, Symbol.CODENEGOPE) && !neg)
                    {
                        neg = true; //Activar negación
                        current_st = 2;
                    }

                    else if (IsValue(sentence, Symbol.CODEEXITLD))
                        current_st = 8; //Ir a 8

                    else if (IsWordReserv(sentence))
                        current_st = 3;
                    else //Sino ir a error
                        current_st = 1;

                    break;
                case 1: //estado de error
                    return current_st;

                case 3: //Estado de aceptación
                    if (IsValue(sentence, Symbol.CODEREFERE))
                        //Ir a estado 4
                        current_st = 4;
                    else if (IsValue(sentence, Symbol.CODEPARENC))
                    {
                        if (parents.Count > 0)
                        {
                            parents.Remove(Symbol.CODEPARENO);
                            if (parents.Count == 0)
                                //ir a estado 8
                                current_st = 8;
                        }
                        else
                            current_st = 1; //ir a estado de error
                    }
                    else if (IsValue(sentence, Symbol.CODEENDLIN) && parents.Count == 0)
                        //Ir a estado 11
                        current_st = 11;
                    else
                        //Ir a error
                        current_st = 1;
                    break;
                case 4:
                    if (IsValue(sentence, Symbol.CODEKEYOPE))
                        //Ir a estado 5
                        current_st = 5;
                    else
                        //Ir a estado de error
                        current_st = 1;
                    break;
                case 5:
                    if (IsValue(sentence, Symbol.CODEQUOTEO))
                        //Ir a estado 6
                        current_st = 6;
                    else
                        //Ir a estado de error
                        current_st = 1;
                    break;
                case 6:
                    if (IsValue(sentence, Symbol.CODESTRING))
                        //Quedar en el mismo estado
                        return current_st;
                    else if (IsValue(sentence, Symbol.CODEQUOTEC))
                        //Ir a estado 7
                        current_st = 7;
                    else
                        //Ir a estado de error
                        current_st = 1;
                    break;
                case 7:
                    if (IsValue(sentence, Symbol.CODEKEYCLO))
                        //Ir al estado 8
                        current_st = 8;
                    else
                        //Ir a estado de error
                        current_st = 1;

                    break;
                case 8://Válido
                    neg = false;
                    if (IsValue(sentence, Symbol.CODEPARENC))
                    {
                        //Quedar en el mismo estado, quitar de la lista un paréntesis abierto
                        if (parents.Count > 0)
                            parents.Remove(Symbol.CODEPARENO);
                        else
                            current_st = 1; //hay error
                    }
                    else if (IsValue(sentence, Symbol.CODEREFERE))
                        //Ir a estado 9
                        current_st = 9;
                    else if (IsValue(sentence, Symbol.CODEBELONG) || IsValue(sentence, Symbol.CODEEXECUT))
                        //Ir a estado 10
                        current_st = 10;
                    else if (IsValue(sentence, Symbol.CODEENDLIN) && parents.Count == 0)
                    {
                        current_st = 11;//Ir a estado final y de aceptación
                        final = true;
                    }
                    else
                        //Ir a estado de error
                        current_st = 1;
                    break;

                case 9: //Válido, volver a comenzar
                case 10:
                        current_st = 2; //Ir al estado 2
                        if (IsValue(sentence, Symbol.CODEPARENO))
                            parents.Add(Symbol.CODEPARENO);
                        else if (IsValue(sentence, Symbol.CODENEGOPE))
                            neg = true; //Activar negación
                        else if (IsWordReserv(sentence))
                            current_st = 3;//comenzar en 3
                        else
                            current_st = 1;//Error
                   break;

                case 11: //estado de aceptación, estado final
                    current_st = 1;//Ir a estado de error
                    break;
                default:
                    break;
            }
            return current_st;
        }

        //Verificar si el token es palabra reservada
        private bool IsWordReserv(string xsentence)
        {
            switch (xsentence)
            {
                case Symbol.CODEARENAS:
                case Symbol.CODEACTORS:
                case Symbol.CODEROLESS:
                case Symbol.CODEROLESA:
                case Symbol.CODEOBJECT:
                case Symbol.CODEACTION:
                case Symbol.CODEEXITLD:
                    return true;

                default:
                    return false;
            }
        }



        /// <summary>
        /// Válidar sentencia, regresa < 0 si hay error
        /// -1 la sentencia es inválida
        /// -2 si la sentencia a analizar esta vacia
        /// </summary>
        /// <returns></returns>
        public int ValidateSentence(string xsentence, string xline)
        {
            if (xsentence.CompareTo("") != 0)
            {
                if (CurrentState != 1)
                {
                    OldSentence = Sentence;
                    OldState = CurrentState;
                    Line = xline;
                    Sentence = xsentence;

                    return Transition();
                }
                return -1;
            }
            return -2;
        }

        /// <summary>
        /// Validar automata
        /// </summary>
        /// <returns></returns>
        public bool ValidateAutomata()
        {
            if (CurrentState == 3 || CurrentState == 8 || CurrentState == 11)
                return true;
            else
                return false;
        }
    }
}