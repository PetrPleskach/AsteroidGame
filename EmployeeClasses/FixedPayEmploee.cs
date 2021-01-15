using System;
using System.Collections.Generic;
using System.Text;

namespace EmployeeClasses
{
    class FixedPayEmploee : Employee
    {        
        public FixedPayEmploee(string name, string surName, int age, decimal salary) : base(name, surName, age)
        {
            id = ("F" + age + name[^1] + surName[0] + random.Next(100, 1000)).ToUpper();
            this.salary = PaymentCalculation(salary);
        }

        protected override decimal PaymentCalculation(decimal salary) => salary;
    }
}
