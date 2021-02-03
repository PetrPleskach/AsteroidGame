using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeClasses
{
    class HourlyPayEmployee : Employee
    {
        public HourlyPayEmployee(string name, string surName, int age, decimal rate) : base(name, surName, age)
        {
            id = ("H" + random.Next(100, 1000));
            PaymentCalculation(rate);
        }

        public override void PaymentCalculation(decimal salary) => this.salary = 20.8m * 8 * salary;
    }
}
