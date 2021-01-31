using System;
using System.Collections.Generic;
using System.Text;

namespace EmploeeWPF.Model
{
    public class FixedPayEmploee : Employee
    {        
        public FixedPayEmploee(string name, string surName, int age, decimal salary) : base(name, surName, age)
        {
            id = ("F" + random.Next(100, 1000));
            PaymentCalculation(salary);
        }

        public override void PaymentCalculation(decimal salary) => this.salary = salary;
    }
}
