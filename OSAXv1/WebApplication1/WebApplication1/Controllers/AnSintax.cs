using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Controllers
{
    public class AnSintax
    {
        string[] lexems;
        string[] tokens;
        ParseTable parseT;        
        Stack<string> pila;
        int[] estadosValidos;

        public AnSintax(string[] lexems, string[] tokens)
        {
            this.lexems = lexems;
            this.tokens = tokens;
            parseT = new ParseTable();
            makeParseTable();
            estadosValidos = new int[]{5,6,14,15,16,20,22,23,24,26,27,28,29,32,33,34,36,37};
        }

        public bool analize()
        {
            char function;
            int estadoActual;
            int estadoAnterior;
            pila.Push("$");
            pila.Push("0");
            Console.WriteLine("S -> $-0");
            estadoActual = 0;
            estadoAnterior = 0;
            foreach (string lx in lexems)
            {
                estadoActual = Int32.Parse(pila.Peek());
                function = parseT.getFunction(estadoActual, lx);
                switch (function)
                {
                    case 's':
                        Console.WriteLine("S -> " + lx + " - " + estadoActual);
                        shift(parseT.getValue(1, estadoActual, lx), parseT.getValue(2, estadoActual, lx));                        
                        break;
                    case 'r':
                        reduce(parseT.getValue(1, estadoActual, lx), parseT.getValue(2, estadoActual, lx), ""+estadoAnterior);
                        break;
                    case '!':
                        return false;
                    default:
                        return false;
                }

            }
            return true;
        }

        public bool reduce(string noTerminal, string expresion, string estado)
        {
            Console.WriteLine("Reduce: " + noTerminal + " -> " + expresion);
            Console.WriteLine("---Redux process---");
            Console.WriteLine("expresion: " + expresion);
            Console.Write("pila: ");
            foreach(string s in pila) Console.Write(s);
            Console.WriteLine();

            string estadoAnterior;
            string estadoActual;
            for (int i = expresion.Length-1; i >= 0; i--)
            {
                Console.WriteLine("poping: " + pila.Peek());
                pila.Pop();
                Console.WriteLine("comparing: " + pila.Peek() + " with " + expresion[i]);
                if (pila.Peek() == expresion[i].ToString())
                {
                    Console.WriteLine("poping: " + pila.Peek());
                    pila.Pop();
                }
                else
                {
                    Console.WriteLine("" + pila.Peek() + " != " + expresion[i]);
                    return false;
                }
                    
            }            
            estadoAnterior = pila.Peek();            
            estadoActual = parseT.getValue(2, Int32.Parse(estadoAnterior), noTerminal);
            pila.Push(noTerminal);
            Console.WriteLine("Push: " + estadoActual);
            pila.Push(estadoActual);
            return true;
        }

        public void shift(string token, string state)
        {
            pila.Push(token);
            pila.Push(state);
        }

        private void makeParseTable()
        {
            parseT.addItem(new TableItem(14,"&",'r',"P",""));
            parseT.addItem(new TableItem(20, "&", 's', "&","30"));
            parseT.addItem(new TableItem(21, "&", 's', "&", "31"));
            parseT.addItem(new TableItem(28, "&", 'r', "P", "-o"));
            parseT.addItem(new TableItem(29, "&", 'r', "P", "-a"));
            parseT.addItem(new TableItem(32, "&", 's', "&", "35"));
            parseT.addItem(new TableItem(0, "(", 's', "(", "1"));
            parseT.addItem(new TableItem(10, "(", 's', "(", "1"));
            parseT.addItem(new TableItem(11, "(", 's', "(", "1"));
            parseT.addItem(new TableItem(30, "(", 's', "(", "1"));
            parseT.addItem(new TableItem(35, "(", 's', "(", "1"));
            parseT.addItem(new TableItem(18, ")", 's', ")", "27"));
            parseT.addItem(new TableItem(2, "-", 's', "-", "9"));
            parseT.addItem(new TableItem(6, "-", 'r', "A", "a"));
            parseT.addItem(new TableItem(8, "-", 's', "-", "13"));
            parseT.addItem(new TableItem(14, "-", 's', "-", "19"));
            parseT.addItem(new TableItem(27, "-", 'r', "A", "(a-o)"));
            parseT.addItem(new TableItem(7, ".", 's', ".", "12"));
            parseT.addItem(new TableItem(3, ":", 's', ":", "10"));
            parseT.addItem(new TableItem(28, ":", 'r', "P", "-o"));
            parseT.addItem(new TableItem(32, ":", 'r', "E", "m.tHv"));
            parseT.addItem(new TableItem(33, ":", 'r', "I", "A-xP&I"));
            parseT.addItem(new TableItem(34, ":", 'r', "I", "A-xP&E"));
            parseT.addItem(new TableItem(36, ":", 'r', "E", "m.tHv&E"));
            parseT.addItem(new TableItem(37, ":", 'r', "E", "m.tHv&I"));
            parseT.addItem(new TableItem(17, "<", 's', "<", "22"));
            parseT.addItem(new TableItem(17, "=", 's', "=", "23"));
            parseT.addItem(new TableItem(17, ">", 's', ">", "24"));
            parseT.addItem(new TableItem(0, "a", 's', "a", "6"));
            parseT.addItem(new TableItem(1, "a", 's', "a", "8"));
            parseT.addItem(new TableItem(10, "a", 's', "a", "6"));
            parseT.addItem(new TableItem(11, "a", 's', "a", "6"));
            parseT.addItem(new TableItem(19, "a", 's', "a", "28"));
            parseT.addItem(new TableItem(30, "a", 's', "a", "6"));
            parseT.addItem(new TableItem(35, "a", 's', "a", "6"));
            parseT.addItem(new TableItem(0, "m", 's', "m", "7"));
            parseT.addItem(new TableItem(31, "m", 's', "m", "7"));
            parseT.addItem(new TableItem(35, "m", 's', "m", "7"));
            parseT.addItem(new TableItem(13, "o", 's', "o", "18"));
            parseT.addItem(new TableItem(13, "o", 's', "o", "18"));
            parseT.addItem(new TableItem(19, "o", 's', "o", "29"));
            parseT.addItem(new TableItem(14, "P", 's', "P", "21"));//********????**********
            parseT.addItem(new TableItem(12, "t", 's', "t", "17"));
            parseT.addItem(new TableItem(22, "v", 'r', "H", "<"));
            parseT.addItem(new TableItem(23, "v", 'r', "H", "="));
            parseT.addItem(new TableItem(24, "v", 'r', "H", ">"));
            parseT.addItem(new TableItem(25, "v", 's', "v", "32"));
            parseT.addItem(new TableItem(26, "v", 'r', "H", "¬"));
            parseT.addItem(new TableItem(9, "x", 's', "x", "14"));
            parseT.addItem(new TableItem(17, "¬", 's', "¬", "26"));
            parseT.addItem(new TableItem(5, "$", 'a', "accept", "accept"));
            parseT.addItem(new TableItem(14, "$", 'r', "P", ""));
            parseT.addItem(new TableItem(15, "$", 'r', "S", "E:I"));
            parseT.addItem(new TableItem(16, "$", 'r', "S", "I:I"));
            parseT.addItem(new TableItem(20, "$", 'r', "I", "A-xP"));
            parseT.addItem(new TableItem(28, "$", 'r', "P", "-a"));
            parseT.addItem(new TableItem(29, "$", 'r', "P", "-o"));
            parseT.addItem(new TableItem(32, "$", 'r', "E", "m.tHv"));
            parseT.addItem(new TableItem(33, "$", 'r', "I", "A-xP&I"));
            parseT.addItem(new TableItem(34, "$", 'r', "I", "A-xP&E"));
            parseT.addItem(new TableItem(36, "$", 'r', "E", "m.tHv&E"));
            parseT.addItem(new TableItem(37, "$", 'r', "E", "m.tHv&I"));
            parseT.addItem(new TableItem(0, "A", '-', "2", "2"));
            parseT.addItem(new TableItem(10, "A", '-', "2", "2"));
            parseT.addItem(new TableItem(11, "A", '-', "2", "2"));
            parseT.addItem(new TableItem(30, "A", '-', "2", "2"));
            parseT.addItem(new TableItem(35, "A", '-', "2", "2"));
            parseT.addItem(new TableItem(0, "E", '-', "3", "3"));
            parseT.addItem(new TableItem(31, "E", '-', "34", "34"));
            parseT.addItem(new TableItem(35, "E", '-', "36", "36"));
            parseT.addItem(new TableItem(17, "H", '-', "25", "25"));
            parseT.addItem(new TableItem(0, "I", '-', "4", "4"));
            parseT.addItem(new TableItem(10, "I", '-', "15", "15"));
            parseT.addItem(new TableItem(11, "I", '-', "16", "16"));
            parseT.addItem(new TableItem(30, "I", '-', "33", "33"));
            parseT.addItem(new TableItem(35, "I", '-', "37", "37"));
            parseT.addItem(new TableItem(14, "P", '-', "20", "20"));
            parseT.addItem(new TableItem(0, "S", '-', "5", "5"));
        }

    }
}
