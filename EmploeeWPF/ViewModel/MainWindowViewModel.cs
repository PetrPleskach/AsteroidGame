using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmploeeWPF.Model;

namespace EmploeeWPF.ViewModel
{
    class MainWindowViewModel
    {
        public List<Departament> departaments { get; set; }

        public MainWindowViewModel()
        {
            var j = 1;
            departaments = Enumerable.Range(1, 10).Select(i => new Departament
            {
                Name = $"Dept - {i}",
                Employees = Enumerable.Range(1, 10).Select(k => new FixedPayEmploee($"Name{j}", $"Surname{j}", 22 + j++, j * 5m)).ToList()
            }).ToList();
        }
    }
}
