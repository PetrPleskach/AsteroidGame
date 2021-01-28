using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmploeeWPF.Classes
{
    abstract class Employee : IComparable<Employee>
    {
        protected static Random random = new Random();
        //Поля общие для всех работников
        protected string name;
        protected string surName;
        protected int age;
        protected string id;
        protected decimal salary;
        protected string departament;

        public string Name => name;
        public string SurName => surName;
        public int Age => age;
        public string Id => id;
        public decimal Salary => salary;
        public string Departament => departament;

        protected Employee(string name, string surName, int age, string departament)
        {
            this.name = name;
            this.surName = surName;
            this.age = age;
            this.departament = departament;
        }

        /// <summary>
        /// Абстрактный метод для расчёта зарплаты
        /// </summary>
        /// <returns></returns>
        public abstract void PaymentCalculation(decimal salary);
        /// <summary>
        /// Переопределенный метод для вывода данных о работнике
        /// </summary>
        /// <returns>Данные о работнике в виде строки</returns>
        public override string ToString() => $"{id} {name,-8} {surName,-8} {age} {salary:C2} {departament}";

        public int CompareTo(Employee otherEmployee)
        {
            if (otherEmployee == null)
                throw new ArgumentNullException(nameof(otherEmployee), $"{nameof(otherEmployee)} - cannot be null");
            return surName.CompareTo(otherEmployee.surName);
        }
    }
}
