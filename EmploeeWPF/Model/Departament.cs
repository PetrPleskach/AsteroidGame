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
            Employees = new ObservableCollection<FixedPayEmploee>();
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

        public ObservableCollection<FixedPayEmploee> Employees { get; set; }

        private void NotifyPropertyChanged(string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
