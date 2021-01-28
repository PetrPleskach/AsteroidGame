using System;
using System.Collections.Generic;
using System.Text;

namespace EmploeeWPF.Classes
{
    class FixedPayEmploee : Employee
    {        
        public FixedPayEmploee(string name, string surName, int age, decimal salary , string departament) : base(name, surName, age, departament)
        {
            id = ("F" + age + name[^1] + surName[0] + random.Next(100, 1000)).ToUpper();
            PaymentCalculation(salary);
        }

        public override void PaymentCalculation(decimal salary) => this.salary = salary;
    }
}
