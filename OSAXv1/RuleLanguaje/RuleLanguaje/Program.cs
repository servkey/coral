using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RuleLanguaje
{
    class Program
    {
        static void Main(string[] args)
        {            
            string expresion;
            expresion = Console.ReadLine();

            Console.WriteLine('\n');
            Lexan lxan = new Lexan();
            String lexResult = lxan.Analize(expresion);
            Console.WriteLine(lexResult);

            string[] tokens = lexResult.Split(' ');
            foreach (string s in tokens)
                Console.WriteLine(s);
            Console.ReadKey();            
            AnSintax analisis = new AnSintax(tokens, tokens);

            if (analisis.analize()) Console.WriteLine("\nok");
            else Console.WriteLine("\nnot ok");
            Console.ReadKey();
        }
    }
}
