using System;
using System.Collections.Generic;
using System.Text;

namespace EmploeeWPF.Model
{
    public class HourlyPayEmployee : Employee
    {
        public HourlyPayEmployee(string name, string surName, int age, decimal rate) : base(name, surName, age)
        {
            id = ("H" + age + name[^1] + surName[0] + random.Next(100, 1000)).ToUpper();
            PaymentCalculation(rate);
        }

        public override void PaymentCalculation(decimal salary) => this.salary = 20.8m * 8 * salary;
    }
}
