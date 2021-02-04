using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmploeeWPF.Model
{
    public abstract class Employee : IComparable<Employee>, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected static Random random = new Random();
        //Поля общие для всех работников
        protected string name;
        protected string surName;
        protected int age;
        protected string id;
        protected decimal salary;

        public string Id
        {
            get => id; 
            set
            {
                if (Equals(id, value)) return;
                id = value;
                NotifyPropertyChanged();
            }
        }
        public string Name
        {
            get => name;
            set
            {
                if (Equals(name, value)) return;
                name = value;
                NotifyPropertyChanged();
            }
        }
        public string Surname
        {
            get => surName;
            set
            {
                if (Equals(surName, value)) return;
                surName = value;
                NotifyPropertyChanged();
            }
        }
        public int Age
        {
            get => age;
            set
            {
                if (age == value) return;
                age = value;
                NotifyPropertyChanged();
            }
        }
        public decimal Salary
        {
            get => salary;
            set
            {
                if (salary == value) return;
                salary = value;
                NotifyPropertyChanged();
            }
        }

        protected Employee(string name, string surName, int age)
        {
            this.name = name;
            this.surName = surName;
            this.age = age;
        }

        /// <summary>
        /// Абстрактный метод для расчёта зарплаты
        /// </summary>
        /// <returns></returns>
        public abstract void PaymentCalculation(decimal salary);
        /// <summary>
        /// Переопределенный метод для вывода данных о работнике
        /// </summary>
        /// <returns>Данные о работнике в виде строки</returns>
        public override string ToString() => $"{id} {name,-8} {surName,-8} {age} {salary:C2}";

        public int CompareTo(Employee otherEmployee)
        {
            if (otherEmployee == null)
                throw new ArgumentNullException(nameof(otherEmployee), $"{nameof(otherEmployee)} - cannot be null");
            return surName.CompareTo(otherEmployee.surName);
        }

        private void NotifyPropertyChanged(string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
