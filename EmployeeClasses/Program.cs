using System;
using System.Text;

namespace EmployeeClasses
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.Unicode;
            Console.WriteLine("Hello World!");

            FixedPayEmploee emploee = new FixedPayEmploee("Иван", "Иванов", 22, 1000);

            Console.WriteLine(emploee);

            Console.ReadKey();
        }
    }
}
