using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeClasses
{
    abstract class Employee
    {
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
        protected abstract decimal PaymentCalculation();
    }
}
