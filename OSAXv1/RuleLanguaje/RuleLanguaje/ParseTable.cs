using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RuleLanguaje
{
    class ParseTable
    {
        /*
         * lista de entradas para la tabla
         */
        private LinkedList<TableItem> items;

        public ParseTable()
        {
            items = new LinkedList<TableItem>();
        }

        /*
         * se agrega una entrada a la tabla
         */
        public void addItem(TableItem item)
        {
            items.AddLast(item);
        }


        /*
         * devuelve el tipo de función de la entrada estado - lexema
         * 'r' : redux
         * 's' : shift
         * '-' : transición de estado
         * '!' : la entrada estado - lexema no existe
         */
        public char getFunction(int estado, string lex)
        {
            foreach (TableItem item in items)
                if (item.estado == estado && item.lexema == lex)
                    return item.funcion;
            return '!';
        }

        /*
         * Regresa los valor de la función
         *  cuando num = 1 regresa el valor 1
         *  cuando num = 2 regresa el valor 2
         */
        public string getValue(int num, int estado, string lexem)
        {
            foreach (TableItem item in items)
                if (item.estado == estado && item.lexema == lexem)
                {
                    if (num == 1) return item.valor1;
                    else if (num == 2) return item.valor2;
                    else return "null";
                }
            return "null";
        }
    }
}
