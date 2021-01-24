using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

//2. Дана коллекция List<T>, требуется подсчитать, сколько раз каждый элемент встречается в данной коллекции.
//а) для целых чисел;
//б) для обобщенной коллекции;
//в)* используя Linq.

namespace ConsoleTest
{

    class Lesson4_Solution2
    {
        static void /*not*/Main(string[] args)
        {
            Random random = new Random();
            const int listCount = 20;
            List<int> listInt = new List<int>();

            Console.WriteLine("Сгенерирован список целых чисел:");
            for (int i = 0; i < listCount; i++)
            {
                listInt.Add(random.Next(10));
                Console.Write(listInt[i] + " ");
            }
            Console.WriteLine();

            //а) для целых чисел;
            //б) для обобщенной коллекции;
            Console.WriteLine("Элементы подсчитаны и отсортированы:");
            var dict1 = IntListValuesCount(listInt);
            var dict2 = TListValuesCount(listInt);
            foreach (var item in dict1)
                Console.WriteLine("{0} - {1}", item.Key , item.Value);
            Console.WriteLine();

            //в)* используя Linq.
            Console.WriteLine("Тоже самое с помощью LINQ:");            
            var dict3 = listInt.OrderBy(x => x).GroupBy(x => x).ToDictionary(x => x.Key, y => y.ToList().Count);

            foreach (var item in dict3)            
                Console.WriteLine("{0} -- {1}", item.Key, item.Value);            

            Console.ReadKey();
        }


        /// <summary>
        /// Метод подсчета количества элементов для целых чисел;
        /// </summary>
        /// <param name="list">Список для посчёта</param>
        /// <returns>Словарь содержащий где: Key-элемент, Value-количество</returns>
        static Dictionary<int, int> IntListValuesCount(List<int> listInt)
        {
            var list = listInt.OrderBy(x => x);
            Dictionary<int, int> pairs = new Dictionary<int, int>(listInt.Count);
            foreach (int item in list)
                if (pairs.ContainsKey(item))
                    pairs[item]++;
                else
                    pairs.Add(item, 1);

            return pairs;
        }

        /// <summary>
        /// Метод подсчета количества элементов для обобщенной коллекции;
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="list">Список для посчёта</param>
        /// <returns>Словарь содержащий где: Key-элемент, Value-количество</returns>
        static Dictionary<T, int> TListValuesCount<T>(List<T> list)
        {            
            Dictionary<T, int> pairs = new Dictionary<T, int>();
            foreach (T item in list)
                if (pairs.ContainsKey(item))
                    pairs[item]++;
                else
                    pairs.Add(item, 1);

            return pairs;
        }        
    }
}
