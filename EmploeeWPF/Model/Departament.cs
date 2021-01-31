using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmploeeWPF.Model
{
    public class Departament: INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;        

        public Departament() { }
        public Departament(string name)
        {
            this.name = name;
        }

        private string name;

        public string Name
        { 
            get => name;
            set
            {
                name = value;
                NotifyPropertyChanged();
            }
        }

        public List<FixedPayEmploee> Employees { get; set; }

        private void NotifyPropertyChanged(string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
