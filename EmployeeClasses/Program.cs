using System;
using System.Text;

namespace EmployeeClasses
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.Unicode;            

            FixedPayEmploee emploee = new FixedPayEmploee("Иван", "Иванов", 22, 1000);
            HourlyPayEmployee hourlyEmploee = new HourlyPayEmployee("Петр", "Петров", 33, 11);

            Console.WriteLine(emploee);
            Console.WriteLine(hourlyEmploee);

            Console.ReadKey();
        }
    }
}
