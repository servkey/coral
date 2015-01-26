using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RuleLanguaje
{
    class AnSintax
    {
        string[] lexems { get; set; }
        string[] tokens { get; set; }
        ParseTable parseT;
        Stack<string> pila;        

        public AnSintax(string[] lexems, string[] tokens)
        {
            this.lexems = lexems;
            this.tokens = tokens;
            parseT = new ParseTable();
            makeParseTable();
            pila = new Stack<string>();
        }

        public bool analize()
        {
            char function;
            int estadoActual;            
            string lx;            
            pila.Push("0");            
            int i = 1;
            lx = lexems[0];            
            while(true)
            {                                
                estadoActual = Int32.Parse(pila.Peek());
                Console.WriteLine("Estado actual: " + estadoActual);
                Console.WriteLine("Lexema actual: " + lx);
                function = parseT.getFunction(estadoActual, lx);
                switch (function)
                {
                    case 's':
                        shift(parseT.getValue(1, estadoActual, lx), parseT.getValue(2, estadoActual, lx));
                        if (i < lexems.Length) lx = lexems[i++]; else lx = "$";                        
                        break;
                    case 'r':
                        reduce(parseT.getValue(1, estadoActual, lx), parseT.getValue(2, estadoActual, lx));                        
                        break;
                    case 'a':                        
                        return true;
                    default:
                        Console.WriteLine("No entries for state: '{0}' and lexem: '{1}'", estadoActual,lx);                        
                        return false;
                }

            }            
        }

        public bool reduce(string noTerminal, string expresion)
        {
            Console.WriteLine("Reduce: " + noTerminal + " -> " + expresion);
            Console.WriteLine("---Redux process---");
            Console.WriteLine("expresion: " + expresion);
            Console.Write("pila: ");
            foreach(string s in pila) Console.Write(s);
            Console.WriteLine();
            string estadoAnterior;
            string estadoActual;
            if (expresion != "$")
            {                
                for (int i = expresion.Length - 1; i >= 0; i--)
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
            }            
            estadoAnterior = pila.Peek();            
            estadoActual = parseT.getValue(2, Int32.Parse(estadoAnterior), noTerminal);
            Console.WriteLine("Push: " + noTerminal);
            pila.Push(noTerminal);
            Console.WriteLine("Push: " + estadoActual);
            pila.Push(estadoActual);
            Console.Write("pila: ");
            foreach (string s in pila) Console.Write(s);            
            Console.WriteLine("\n---finish redx process---");
            return true;            
        }

        public void shift(string token, string state)
        {
            Console.WriteLine("S -> " + token + " - " + state);
            pila.Push(token);
            pila.Push(state);
        }
        //modiffy
        private void makeParseTable()
        {

            parseT.addItem(new TableItem(1, "&", 'r', "M", "C"));
            parseT.addItem(new TableItem(4, "&", 's', "&", "15"));
            parseT.addItem(new TableItem(5, "&", 'r', "M", "P"));
            parseT.addItem(new TableItem(7, "&", 'r', "M", "X"));
            parseT.addItem(new TableItem(21, "&", 'r', "P", "EOE"));
            parseT.addItem(new TableItem(25, "&", 's', "&", "15"));
            parseT.addItem(new TableItem(39, "&", 'r', "E", "m(*)"));
            parseT.addItem(new TableItem(44, "&", 'r', "C", "F.aKv"));
            parseT.addItem(new TableItem(49, "&", 'r', "E", "m(iH)"));
            parseT.addItem(new TableItem(50, "&", 'r', "Q", "$"));
            parseT.addItem(new TableItem(54, "&", 's', "&", "61"));
            parseT.addItem(new TableItem(59, "&", 'r', "X", "F-t(n)Q"));
            parseT.addItem(new TableItem(63, "&", 'r', "E", "m(e{*})"));
            parseT.addItem(new TableItem(66, "&", 'r', "Q", "$"));
            parseT.addItem(new TableItem(61, "&", 's', "&", "61"));
            parseT.addItem(new TableItem(68, "&", 'r', "E", "m(e{iH})"));
            parseT.addItem(new TableItem(70, "&", 'r', "X", "F-t(n,F)Q"));
            parseT.addItem(new TableItem(70, "&", 'r', "Q", ".aKv"));
            
            parseT.addItem(new TableItem(9, "(", 's', "(", "19"));
            parseT.addItem(new TableItem(23, "(", 's', "(", "31"));

            parseT.addItem(new TableItem(2, ")", 'r', "F", "E"));
            parseT.addItem(new TableItem(27, ")", 'r', "F", "[P]"));
            parseT.addItem(new TableItem(28, ")", 's', ")", "39"));
            parseT.addItem(new TableItem(30, ")", 'r', "H", "$"));
            parseT.addItem(new TableItem(39, ")", 'r', "E", "m(*)"));
            parseT.addItem(new TableItem(42, ")", 's', ")", "49"));
            parseT.addItem(new TableItem(43, ")", 's', ")", "50"));
            parseT.addItem(new TableItem(47, ")", 'r', "H", "$"));
            parseT.addItem(new TableItem(48, ")", 'r', "H", "$"));
            parseT.addItem(new TableItem(49, ")", 'r', "E", "m(iH)"));
            parseT.addItem(new TableItem(52, ")", 'r', "F", "E"));
            parseT.addItem(new TableItem(55, ")", 's', ")", "63"));
            parseT.addItem(new TableItem(52, ")", 'r', "H", ",iH"));
            parseT.addItem(new TableItem(60, ")", 's', ")", "66"));
            parseT.addItem(new TableItem(63, ")", 'r', "E", "m(e{*})"));
            parseT.addItem(new TableItem(64, ")", 's', ")", "68"));
            parseT.addItem(new TableItem(68, ")", 'r', "E", "m(e{iH})"));
            
            parseT.addItem(new TableItem(19, "*", 's', "*", "28"));
            parseT.addItem(new TableItem(40, "*", 's', "*", "46"));

            parseT.addItem(new TableItem(30, ",", 's', ",", "41"));
            parseT.addItem(new TableItem(43, ",", 's', ",", "51"));
            parseT.addItem(new TableItem(47, ",", 's', ",", "41"));
            parseT.addItem(new TableItem(48, ",", 's', ",", "41"));

            parseT.addItem(new TableItem(2, "-", 's', "-", "10"));
            parseT.addItem(new TableItem(3, "-", 's', "-", "13"));
            parseT.addItem(new TableItem(17, "-", 's', "-", "10"));
            parseT.addItem(new TableItem(27, "-", 's', "F", "[P]"));
            parseT.addItem(new TableItem(39, "-", 'r', "E", "m(*)"));
            parseT.addItem(new TableItem(49, "-", 'r', "E", "m(iH)"));
            parseT.addItem(new TableItem(52, "-", 'r', "F", "E"));
            parseT.addItem(new TableItem(53, "-", 's', "-", "13"));
            parseT.addItem(new TableItem(63, "-", 'r', "E", "m(e{*})"));
            parseT.addItem(new TableItem(68, "-", 'r', "E", "m(e{iH})"));



            /*          
            parseT.addItem(new TableItem(7, ".", 's', ".", "12"));

            parseT.addItem(new TableItem(3, ":", 's', ":", "10"));
            parseT.addItem(new TableItem(4, ":", 's', ":", "11"));
            parseT.addItem(new TableItem(14, ":", 'r', "P", "$"));
            parseT.addItem(new TableItem(20, ":", 'r', "I", "A-xP"));
            parseT.addItem(new TableItem(27, ":", 'r', "P", "-a"));
            parseT.addItem(new TableItem(28, ":", 'r', "P", "-o"));
            parseT.addItem(new TableItem(30, ":", 'r', "E", "m.tHv"));            
            parseT.addItem(new TableItem(31, ":", 'r', "I", "A-xP&E"));
            parseT.addItem(new TableItem(32, ":", 'r', "I", "A-xP&I"));
            parseT.addItem(new TableItem(34, ":", 'r', "E", "m.tHv&E"));
            parseT.addItem(new TableItem(35, ":", 'r', "E", "m.tHv&I"));

            parseT.addItem(new TableItem(17, "<", 's', "<", "21"));
            parseT.addItem(new TableItem(17, "=", 's', "=", "22"));
            parseT.addItem(new TableItem(17, ">", 's', ">", "23"));
            parseT.addItem(new TableItem(17, "¬", 's', "¬", "25"));

            parseT.addItem(new TableItem(0, "a", 's', "a", "6"));
            parseT.addItem(new TableItem(1, "a", 's', "a", "8"));
            parseT.addItem(new TableItem(10, "a", 's', "a", "6"));
            parseT.addItem(new TableItem(11, "a", 's', "a", "6"));
            parseT.addItem(new TableItem(19, "a", 's', "a", "27"));
            parseT.addItem(new TableItem(29, "a", 's', "a", "6"));
            parseT.addItem(new TableItem(33, "a", 's', "a", "6"));

            parseT.addItem(new TableItem(0, "m", 's', "m", "7"));
            parseT.addItem(new TableItem(29, "m", 's', "m", "7"));
            parseT.addItem(new TableItem(33, "m", 's', "m", "7"));

            parseT.addItem(new TableItem(13, "o", 's', "o", "18"));            
            parseT.addItem(new TableItem(19, "o", 's', "o", "28"));            

            parseT.addItem(new TableItem(12, "t", 's', "t", "17"));

            parseT.addItem(new TableItem(21, "v", 'r', "H", "<"));
            parseT.addItem(new TableItem(22, "v", 'r', "H", "="));
            parseT.addItem(new TableItem(23, "v", 'r', "H", ">"));
            parseT.addItem(new TableItem(24, "v", 's', "v", "30"));
            parseT.addItem(new TableItem(25, "v", 'r', "H", "¬"));

            parseT.addItem(new TableItem(9, "x", 's', "x", "14"));            

            parseT.addItem(new TableItem(5, "$", 'a', "accept", "accept"));
            parseT.addItem(new TableItem(14, "$", 'r', "P", "$"));
            parseT.addItem(new TableItem(15, "$", 'r', "S", "E:I"));
            parseT.addItem(new TableItem(16, "$", 'r', "S", "I:I"));
            parseT.addItem(new TableItem(20, "$", 'r', "I", "A-xP"));
            parseT.addItem(new TableItem(27, "$", 'r', "P", "-a"));
            parseT.addItem(new TableItem(28, "$", 'r', "P", "-o"));
            parseT.addItem(new TableItem(30, "$", 'r', "E", "m.tHv"));
            parseT.addItem(new TableItem(31, "$", 'r', "I", "A-xP&E"));
            parseT.addItem(new TableItem(32, "$", 'r', "I", "A-xP&I"));            
            parseT.addItem(new TableItem(34, "$", 'r', "E", "m.tHv&E"));
            parseT.addItem(new TableItem(35, "$", 'r', "E", "m.tHv&I"));

            parseT.addItem(new TableItem(0, "A", '-', "2", "2"));
            parseT.addItem(new TableItem(10, "A", '-', "2", "2"));
            parseT.addItem(new TableItem(11, "A", '-', "2", "2"));
            parseT.addItem(new TableItem(29, "A", '-', "2", "2"));
            parseT.addItem(new TableItem(33, "A", '-', "2", "2"));

            parseT.addItem(new TableItem(0, "E", '-', "3", "3"));
            parseT.addItem(new TableItem(29, "E", '-', "31", "31"));
            parseT.addItem(new TableItem(33, "E", '-', "34", "34"));

            parseT.addItem(new TableItem(17, "H", '-', "24", "24"));

            parseT.addItem(new TableItem(0, "I", '-', "4", "4"));
            parseT.addItem(new TableItem(10, "I", '-', "15", "15"));
            parseT.addItem(new TableItem(11, "I", '-', "16", "16"));
            parseT.addItem(new TableItem(29, "I", '-', "32", "32"));
            parseT.addItem(new TableItem(33, "I", '-', "35", "35"));

            parseT.addItem(new TableItem(14, "P", '-', "20", "20"));

            parseT.addItem(new TableItem(0, "S", '-', "5", "5"));*/
        }
    }
}
