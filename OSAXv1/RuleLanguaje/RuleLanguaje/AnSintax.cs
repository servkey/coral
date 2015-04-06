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
            parseT.addItem(new TableItem(47, "&", 's', "&", "54"));
            parseT.addItem(new TableItem(51, "&", 'r', "E", "m(iH)"));
            parseT.addItem(new TableItem(52, "&", 'r', "Q", "$"));
            parseT.addItem(new TableItem(60, "&", 'r', "X", "F-t(n)Q"));
            parseT.addItem(new TableItem(62, "&", 's', "&", "54"));
            parseT.addItem(new TableItem(63, "&", 'r', "E", "m(e{*})"));
            parseT.addItem(new TableItem(68, "&", 'r', "E", "m(e{iH})"));
            parseT.addItem(new TableItem(70, "&", 'r', "X", "F-t(n,F)Q"));
            parseT.addItem(new TableItem(71, "&", 'r', "Q", ".aKv"));
            
            parseT.addItem(new TableItem(9, "(", 's', "(", "19"));
            parseT.addItem(new TableItem(23, "(", 's', "(", "31"));

            parseT.addItem(new TableItem(2, ")", 'r', "F", "E"));
            parseT.addItem(new TableItem(27, ")", 'r', "F", "[P]"));
            parseT.addItem(new TableItem(28, ")", 's', ")", "39"));
            parseT.addItem(new TableItem(30, ")", 'r', "H", "$"));
            parseT.addItem(new TableItem(39, ")", 'r', "E", "m(*)"));
            parseT.addItem(new TableItem(42, ")", 's', ")", "51"));
            parseT.addItem(new TableItem(43, ")", 's', ")", "52"));
            parseT.addItem(new TableItem(45, ")", 'r', "F", "E"));
            parseT.addItem(new TableItem(49, ")", 'r', "H", "$"));
            parseT.addItem(new TableItem(50, ")", 'r', "H", "$"));
            parseT.addItem(new TableItem(51, ")", 'r', "E", "m(iH)"));
            parseT.addItem(new TableItem(56, ")", 's', ")", "63"));
            parseT.addItem(new TableItem(58, ")", 'r', "H", ",iH"));
            parseT.addItem(new TableItem(61, ")", 's', ")", "66"));
            parseT.addItem(new TableItem(63, ")", 'r', "E", "m(e{*})"));
            parseT.addItem(new TableItem(64, ")", 's', ")", "68"));
            parseT.addItem(new TableItem(68, ")", 'r', "E", "m(e{iH})"));
                                    
            parseT.addItem(new TableItem(19, "*", 's', "*", "28"));
            parseT.addItem(new TableItem(40, "*", 's', "*", "48"));

            parseT.addItem(new TableItem(30, ",", 's', ",", "41"));
            parseT.addItem(new TableItem(43, ",", 's', ",", "53"));
            parseT.addItem(new TableItem(49, ",", 's', ",", "41"));
            parseT.addItem(new TableItem(50, ",", 's', ",", "41"));
            //
            parseT.addItem(new TableItem(2, "-", 'r', "F", "E"));
            parseT.addItem(new TableItem(3, "-", 's', "-", "13"));
            parseT.addItem(new TableItem(17, "-", 's', "-", "10"));
            parseT.addItem(new TableItem(27, "-", 'r', "F", "[P]"));
            parseT.addItem(new TableItem(39, "-", 'r', "E", "m(*)"));
            parseT.addItem(new TableItem(45, "-", 'r', "F", "E"));
            parseT.addItem(new TableItem(46, "-", 's', "-", "13"));
            parseT.addItem(new TableItem(51, "-", 'r', "E", "m(iH)"));                                    
            parseT.addItem(new TableItem(63, "-", 'r', "E", "m(e{*})"));
            parseT.addItem(new TableItem(68, "-", 'r', "E", "m(e{iH})"));

            parseT.addItem(new TableItem(2, ".", 'r', "F", "E"));
            parseT.addItem(new TableItem(3, ".", 's', ".", "14"));
            parseT.addItem(new TableItem(27, ".", 's', "F", "[P]"));
            parseT.addItem(new TableItem(39, ".", 'r', "E", "m(*)"));
            parseT.addItem(new TableItem(45, ".", 'r', "F", "E"));
            parseT.addItem(new TableItem(51, ".", 'r', "E", "m(iH)"));
            parseT.addItem(new TableItem(52, ".", 's', ".", "59"));
            parseT.addItem(new TableItem(63, ".", 'r', "E", "m(e{*})"));
            parseT.addItem(new TableItem(66, ".", 's', ".", "59"));
            parseT.addItem(new TableItem(68, "-", 'r', "E", "m(e{iH})"));
            
            parseT.addItem(new TableItem(1, ":", 'r', "M", "C"));
            parseT.addItem(new TableItem(4, ":", 'r', "L", "$"));
            parseT.addItem(new TableItem(5, ":", 'r', "M", "P"));
            parseT.addItem(new TableItem(7, ":", 'r', "M", "X"));
            parseT.addItem(new TableItem(16, ":", 's', ":", "26"));
            parseT.addItem(new TableItem(21, ":", 'r', "P", "EOE"));
            parseT.addItem(new TableItem(25, ":", 'r', "L", "$"));
            parseT.addItem(new TableItem(37, ":", 'r', "L", "&ML"));            
            parseT.addItem(new TableItem(39, ":", 'r', "E", "m(*)"));
            parseT.addItem(new TableItem(44, ":", 'r', "C", "F.aKv"));
            parseT.addItem(new TableItem(51, ":", 'r', "E", "m(iH)"));
            parseT.addItem(new TableItem(52, ":", 'r', "Q", "$"));
            parseT.addItem(new TableItem(60, ":", 'r', "X", "F-t(n)Q"));
            parseT.addItem(new TableItem(63, ":", 'r', "E", "m(e{*})"));
            parseT.addItem(new TableItem(66, ":", 'r', "Q", "$"));
            parseT.addItem(new TableItem(68, ":", 'r', "E", "m(e{iH})"));
            parseT.addItem(new TableItem(70, ":", 'r', "X", "F-t(n,F)Q"));
            parseT.addItem(new TableItem(72, ":", 'r', "Q", ".aKv"));

            parseT.addItem(new TableItem(24, "<", 's', "<", "32"));
            parseT.addItem(new TableItem(65, "<", 's', "<", "32"));
            
            parseT.addItem(new TableItem(24, "=", 's', "=", "33"));
            parseT.addItem(new TableItem(26, "=", 's', "=", "38"));
            parseT.addItem(new TableItem(65, "=", 's', "=", "33"));

            parseT.addItem(new TableItem(10, ">", 's', ">", "20"));
            parseT.addItem(new TableItem(12, ">", 's', ">", "22"));
            parseT.addItem(new TableItem(24, ">", 's', ">", "34"));
            parseT.addItem(new TableItem(65, ">", 's', ">", "34"));

            parseT.addItem(new TableItem(0, "[", 's', "[", "8"));
            parseT.addItem(new TableItem(15, "[", 's', "[", "8"));
            parseT.addItem(new TableItem(38, "[", 's', "[", "8"));
            parseT.addItem(new TableItem(53, "[", 's', "[", "8"));
            parseT.addItem(new TableItem(54, "[", 's', "[", "8"));

            parseT.addItem(new TableItem(18, "]", 's', "]", "27"));
            parseT.addItem(new TableItem(21, "]", 'r', "P", "EOE"));
            parseT.addItem(new TableItem(39, "]", 'r', "E", "m(*)"));
            parseT.addItem(new TableItem(51, "]", 'r', "E", "m(iH)"));
            parseT.addItem(new TableItem(63, "]", 'r', "E", "m(e{*})"));
            parseT.addItem(new TableItem(68, "]", 'r', "E", "m(e{iH})"));
            

            parseT.addItem(new TableItem(14, "a", 's', "a", "24"));
            parseT.addItem(new TableItem(59, "a", 's', "a", "65"));

            parseT.addItem(new TableItem(19, "e", 's', "e", "29"));

            parseT.addItem(new TableItem(19, "i", 's', "i", "30"));
            parseT.addItem(new TableItem(40, "i", 's', "i", "49"));
            parseT.addItem(new TableItem(41, "i", 's', "i", "50"));

            parseT.addItem(new TableItem(0, "m", 's', "m", "9"));
            parseT.addItem(new TableItem(8, "m", 's', "m", "9"));
            parseT.addItem(new TableItem(11, "m", 's', "m", "9"));
            parseT.addItem(new TableItem(15, "m", 's', "m", "9"));
            parseT.addItem(new TableItem(20, "m", 'r', "O", "->"));
            parseT.addItem(new TableItem(22, "m", 'r', "O", "~>"));
            parseT.addItem(new TableItem(38, "m", 's', "m", "9"));
            parseT.addItem(new TableItem(53, "m", 's', "m", "9"));
            parseT.addItem(new TableItem(54, "m", 's', "m", "9"));
            

            parseT.addItem(new TableItem(31, "n", 's', "n", "43"));

            parseT.addItem(new TableItem(13, "t", 's', "t", "23"));

            parseT.addItem(new TableItem(32, "v", 'r', "K", "<"));
            parseT.addItem(new TableItem(33, "v", 'r', "K", "="));
            parseT.addItem(new TableItem(34, "v", 'r', "K", ">"));
            parseT.addItem(new TableItem(35, "v", 's', "v", "44"));
            parseT.addItem(new TableItem(36, "v", 'r', "K", "¬"));
            parseT.addItem(new TableItem(69, "v", 's', "v", "71"));

            parseT.addItem(new TableItem(29, "{", 's', "{", "40"));

            parseT.addItem(new TableItem(30, "}", 'r', "H", "$"));
            parseT.addItem(new TableItem(48, "}", 's', "}", "56"));
            parseT.addItem(new TableItem(49, "}", 'r', "H", "$"));
            parseT.addItem(new TableItem(50, "}", 'r', "H", "$"));
            parseT.addItem(new TableItem(57, "}", 's', "}", "64"));
            parseT.addItem(new TableItem(58, "}", 'r', "H", ",iH"));

            parseT.addItem(new TableItem(2, "~", 's', "~", "12"));
            parseT.addItem(new TableItem(17, "~", 's', "~", "12"));
            parseT.addItem(new TableItem(39, "~", 'r', "E", "m(*)"));
            parseT.addItem(new TableItem(51, "~", 'r', "E", "m(iH)"));
            parseT.addItem(new TableItem(63, "~", 'r', "E", "m(e{*})"));
            parseT.addItem(new TableItem(68, "~", 'r', "E", "m(e{iH})"));

            parseT.addItem(new TableItem(24, "¬", 's', "¬", "36"));
            parseT.addItem(new TableItem(65, "¬", 's', "¬", "36"));
            
            parseT.addItem(new TableItem(6, "$", 'a', "accept", "accept"));
            parseT.addItem(new TableItem(47, "$", 'r', "J", "$"));
            parseT.addItem(new TableItem(52, "$", 'r', "Q", "$"));
            parseT.addItem(new TableItem(55, "$", 'r', "S", "ML:=XJ"));
            parseT.addItem(new TableItem(60, "$", 'r', "X", "F-t(n)Q"));
            parseT.addItem(new TableItem(62, "$", 'r', "J", "$"));
            parseT.addItem(new TableItem(66, "$", 'r', "Q", "$"));
            parseT.addItem(new TableItem(67, "$", 'r', "J", "&XJ"));
            parseT.addItem(new TableItem(70, ":", 'r', "X", "F-t(n,F)Q"));
            parseT.addItem(new TableItem(71, ":", 'r', "Q", ".aKv"));
            
            parseT.addItem(new TableItem(0, "C", '-', "1", "1"));
            parseT.addItem(new TableItem(15, "C", '-', "1", "1"));

            parseT.addItem(new TableItem(0, "E", '-', "2", "2"));
            parseT.addItem(new TableItem(8, "E", '-', "17", "17"));
            parseT.addItem(new TableItem(11, "E", '-', "21", "21"));
            parseT.addItem(new TableItem(15, "E", '-', "2", "2"));
            parseT.addItem(new TableItem(38, "E", '-', "45", "45"));
            parseT.addItem(new TableItem(53, "E", '-', "45", "45"));
            parseT.addItem(new TableItem(54, "E", '-', "45", "45"));

            parseT.addItem(new TableItem(0, "F", '-', "3", "3"));
            parseT.addItem(new TableItem(15, "F", '-', "3", "3"));
            parseT.addItem(new TableItem(38, "F", '-', "46", "46"));
            parseT.addItem(new TableItem(53, "F", '-', "61", "61"));
            parseT.addItem(new TableItem(54, "F", '-', "46", "46"));

            parseT.addItem(new TableItem(30, "H", '-', "42", "42"));
            parseT.addItem(new TableItem(49, "H", '-', "57", "57"));
            parseT.addItem(new TableItem(50, "H", '-', "58", "58"));

            parseT.addItem(new TableItem(47, "J", '-', "55", "55"));
            parseT.addItem(new TableItem(62, "J", '-', "67", "67"));

            parseT.addItem(new TableItem(24, "K", '-', "35", "35"));
            parseT.addItem(new TableItem(65, "K", '-', "69", "69"));

            parseT.addItem(new TableItem(4, "L", '-', "16", "16"));
            parseT.addItem(new TableItem(25, "L", '-', "37", "37"));

            parseT.addItem(new TableItem(0, "M", '-', "4", "4"));
            parseT.addItem(new TableItem(15, "M", '-', "25", "25"));

            parseT.addItem(new TableItem(2, "O", '-', "11", "11"));
            parseT.addItem(new TableItem(17, "O", '-', "11", "11"));

            parseT.addItem(new TableItem(0, "P", '-', "5", "5"));
            parseT.addItem(new TableItem(8, "P", '-', "18", "18"));
            parseT.addItem(new TableItem(15, "P", '-', "5", "5"));

            parseT.addItem(new TableItem(52, "Q", '-', "60", "60"));
            parseT.addItem(new TableItem(66, "Q", '-', "70", "70"));

            parseT.addItem(new TableItem(0, "S", '-', "6", "6"));

            parseT.addItem(new TableItem(0, "X", '-', "7", "7"));
            parseT.addItem(new TableItem(15, "X", '-', "7", "7"));
            parseT.addItem(new TableItem(38, "X", '-', "47", "47"));
            parseT.addItem(new TableItem(54, "X", '-', "62", "62"));
        }
    }
}
