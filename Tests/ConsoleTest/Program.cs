using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleTest
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> dict = new Dictionary<string, int>()
            {
                {"four",4 },
                {"two",2 },
                { "one",1 },
                {"three",3 },
            };
            var d = dict.OrderBy(delegate (KeyValuePair<string, int> pair) { return pair.Value; });
            foreach (var pair in d)
            {
                Console.WriteLine("{0} - {1}", pair.Key, pair.Value);
            }
            Console.WriteLine();

            //а) Свернуть обращение к OrderBy с использованием лямбда-выражения.
            Dictionary<string, int> dict1 = new Dictionary<string, int>()
            {
                {"four",4 },
                {"two",2 },
                { "one",1 },
                {"three",3 },
            };
            var d1 = dict.OrderBy(p => p.Value);
            foreach (var pair in d1)
            {
                Console.WriteLine("{0} - {1}", pair.Key, pair.Value);
            }
            Console.WriteLine();

            //Развернуть обращение к OrderBy с использованием делегата Predicate<T>.
            Dictionary<string, int> dict2 = new Dictionary<string, int>()
            { 
                {"four",4 },
                {"two",2 },
                { "one",1 },
                {"three",3 },
            };
            var d2 = dict.OrderBy(p => p.Key);
            foreach (var pair in d2)
            {
                Console.WriteLine("{0} - {1}", pair.Key, pair.Value);
            }
            Console.ReadKey();
        }
    }
}
