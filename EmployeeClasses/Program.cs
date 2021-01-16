using System;
using System.Text;

namespace EmployeeClasses
{
    class Program
    {
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
            
            Employee[] employes = new Employee[15];
            for (int i = 0; i < employes.Length / 2; i++)
                employes[i] = new FixedPayEmploee(RandomStringGen(), RandomStringGen(), 20 + i, random.Next(11111, 55555));
            for (int i = employes.Length / 2; i < employes.Length; i++)
                employes[i] = new HourlyPayEmployee(RandomStringGen(), RandomStringGen(), 20 + i, random.Next(111, 555));

            foreach (var item in employes)            
                Console.WriteLine(item);

            Array.Sort(employes);
            Console.WriteLine();

            foreach (var item in employes)            
                Console.WriteLine(item);
            

            Console.ReadKey();
        }
    }
}
