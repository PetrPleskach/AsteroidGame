using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmploeeWPF.Model;

namespace EmploeeWPF.ViewModel
{
    class MainWindowViewModel
    {
        public ObservableCollection<Departament> Departaments { get; set; }

        public MainWindowViewModel()
        {
            var j = 1;
            var departaments = Enumerable.Range(1, 10).Select(i => new Departament
            {
                Name = $"Dept - {i}",
                Employees = Enumerable.Range(1, 10).Select(k => new FixedPayEmploee($"Name{j}", $"Surname{j}", 22 + j++, j * 5m)).ToList()
            }).ToList();

            Departaments = new ObservableCollection<Departament>(departaments);
        }

        public void AddNewDepartament()
        {
            var dept = new Departament() { Name = $"Dept - {Departaments.Count + 1}" };
            Departaments.Add(dept);            
        }
    }
}
