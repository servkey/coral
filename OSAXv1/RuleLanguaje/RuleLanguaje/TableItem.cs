using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RuleLanguaje
{
    class TableItem
    {
        /*
         * estado -lexema: entradas de la tabla parse
         * function - tipo de funcion
         * valor 1 : para funcion = 's'(switch)
         *      token leido
         * para función = 'r' (redux)
         *      no Terminal(parte izquierda de la regla)
         * valor2 : para funcion = 's'
         *      estado de llegada
         * para función = 'r'
         *      expresión(parte derecha de la regla)
         */
        public int estado;
        public string lexema;
        public char funcion;
        public string valor1;
        public string valor2;

        public TableItem()
        {
            estado = 0;
            lexema = "$";
            funcion = 's';
            valor1 = "$";
            valor2 = "0";
        }

        public TableItem(int estadoo, string cadenaa, char funcionn, string valor11, string valor22)
        {
            estado = estadoo;
            lexema = cadenaa;
            funcion = funcionn;
            valor1 = valor11;
            valor2 = valor22;
        }
    }
}
