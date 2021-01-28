using System;
using System.Collections.Generic;
using System.Text;

namespace EmploeeWPF.Classes
{
    /// <summary>
    /// перечислитель условий сортировки
    /// </summary>
    enum SortCriteria
    {
        Name,
        SurName,
        Age,
        Id,
        salary,
        SurName_Name,
        Name_SurName,
        Id_SurName_Name,
    }

    class EmployeeSortByCriteria : IComparer<Employee>
    {
        private SortCriteria criteria;//критерий сортировки
        public EmployeeSortByCriteria(SortCriteria criteria) //конструктор с критерием сортировки
        {
            this.criteria = criteria;
        }

        public int Compare(Employee x, Employee y)
        {
            switch (criteria)// В зависимости от вырбанного критерия сортируем элементы массива
            {
                case SortCriteria.Name:
                    return SortByName(x, y);

                case SortCriteria.SurName:
                    return SortBySurName(x, y);

                case SortCriteria.Age:
                    return SortByAge(x, y);

                case SortCriteria.Id:
                    return SortById(x, y);

                case SortCriteria.salary:
                    return SortBySalary(x, y);

                case SortCriteria.SurName_Name:
                    if (SortBySurName(x, y) == 0)
                        return SortByName(x, y);
                    return SortBySurName(x, y);

                case SortCriteria.Name_SurName:
                    if (SortByName(x, y) == 0)
                        return SortBySurName(x, y);
                    return SortByName(x, y);

                case SortCriteria.Id_SurName_Name:
                    if (SortById(x, y) == 0)
                    {
                        if (SortBySurName(x, y) == 0)
                            return SortByName(x, y);
                        return SortBySurName(x, y);
                    }
                    else
                        return SortById(x, y);

                default:
                    throw new ArgumentException(nameof(criteria), "ошибка в критерии сортировки");
            }
        }

        //Методы сортировки по критериям
        private int SortByName(Employee x, Employee y) => x.Name.CompareTo(y.Name);
        private int SortBySurName(Employee x, Employee y) => x.SurName.CompareTo(y.SurName);
        private int SortByAge(Employee x, Employee y)
        {
            if (x.Age > y.Age)
                return 1;
            if (x.Age < y.Age)
                return -1;
            return 0;
        }
        private int SortById(Employee x, Employee y) => x.Id.CompareTo(y.Id);
        private int SortBySalary(Employee x, Employee y)
        {            
            if (Math.Abs(x.Salary - y.Salary) <= 0.001m)
                return 0;
            if (x.Salary > y.Salary)
                return 1;
            return -1;
        }
    }
}
