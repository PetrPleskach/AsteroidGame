using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeClasses
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

        protected Employee(string name, string surName, int age)
        {
            this.name = name;
            this.surName = surName;
            this.age = age;
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
        public override string ToString() => $"{id} | {name,-8} | {surName,-8} | возраст: {age}, зарплата: {salary:C2}";

        public int CompareTo(Employee otherEmployee)
        {
            if (otherEmployee == null)
                throw  new ArgumentNullException(nameof(otherEmployee), $"{nameof(otherEmployee)} - cannot be null");
            return surName.CompareTo(otherEmployee.surName);
        }
    }
}
