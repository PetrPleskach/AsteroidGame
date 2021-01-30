using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmploeeWPF.Model
{
    class Departament
    {
        public Departament() { }
        public Departament(string name)
        {
            Name = name;
        }

        public string Name { get; set; }

        public List<FixedPayEmploee> Employees { get; set; }        
    }
}
