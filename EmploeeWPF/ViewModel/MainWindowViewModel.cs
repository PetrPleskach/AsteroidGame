using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmploeeWPF.Model;

namespace EmploeeWPF.ViewModel
{
    public class MainWindowViewModel
    {
        public ObservableCollection<Departament> Departaments { get; set; }

        public MainWindowViewModel()
        {
            var departaments = Enumerable.Range(1, 10).Select(i => new Departament
            {
                Name = $"Dept - {i}",
                Employees = NewEmployees() 
            }).ToList();

            Departaments = new ObservableCollection<Departament>(departaments);
        }

        private ObservableCollection<FixedPayEmploee> NewEmployees()
        {
            int j = 1;
            var rndEmployes = Enumerable.Range(1, 10).Select(k => new FixedPayEmploee($"Name{j}", $"Surname{j}", 22 + j++, j * 5m)).ToList();
            var emp = new ObservableCollection<FixedPayEmploee>(rndEmployes);
            return emp;
        }
    }
}
