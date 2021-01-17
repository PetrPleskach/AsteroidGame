using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace EmployeeClasses
{
    class Program
    {
        /// <summary>
        /// метод для генерации случайной строки
        /// </summary>
        /// <returns></returns>
        static string RandomStringGen()
        {
            Random random = new Random();
            string str = "abcdefghijklmnopqrstuvwxyz";
            StringBuilder sb = new StringBuilder(7);
            int sym;
            for (int i = 0; i < 7; i++)
            {
                sym = random.Next(0, str.Length);
                sb.Append(str[sym]);
            }
            return sb.ToString();

        }
        static void Main(string[] args)
        {
            Random random = new Random();
            Console.OutputEncoding = Encoding.Unicode;
            
            Employee[] employes = new Employee[1000];
            for (int i = 0; i < employes.Length / 2; i++)
                employes[i] = new FixedPayEmploee(RandomStringGen(), RandomStringGen(), random.Next(20, 40), random.Next(11111, 55555));
            for (int i = employes.Length / 2; i < employes.Length; i++)
                employes[i] = new HourlyPayEmployee(RandomStringGen(), RandomStringGen(), random.Next(20, 40), random.Next(111, 555));
            foreach (var item in employes)            
                Console.WriteLine(item);
            /*
            Console.WriteLine();
            EmployeeSortByCriteria byAge = new EmployeeSortByCriteria(SortCriteria.Age);
            Array.Sort(employes, byAge);
            foreach (var item in employes)            
                Console.WriteLine(item);
            */
            Console.WriteLine();
            EmployeeSortByCriteria byIdSurNameName = new EmployeeSortByCriteria(SortCriteria.Id_SurName_Name);
            Array.Sort(employes, byIdSurNameName);
            foreach (var item in employes)
                Console.WriteLine(item);

            Console.ReadKey();
        }
    }
}
