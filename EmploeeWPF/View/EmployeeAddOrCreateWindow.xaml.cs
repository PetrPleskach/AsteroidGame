using EmploeeWPF.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using EmploeeWPF.Model;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace EmploeeWPF
{
    /// <summary>
    /// Логика взаимодействия для EmployeeAddOrCreateWindow.xaml
    /// </summary>
    public partial class EmployeeAddOrCreateWindow : Window
    {
        /// <summary>
        /// Конструктор для добавления нового сотрудника
        /// </summary>
        /// <param name="model">Данные для контекста данных</param>
        /// <param name="departament">Текущий департамент</param>
        public EmployeeAddOrCreateWindow(MainWindowViewModel model, Departament departament)
        {
            InitializeComponent();            
            DataContext = model;
            DepartamentComboBox.SelectedIndex = model.Departaments.IndexOf(departament);
        }

        /// <summary>
        /// Конструктор для редактирования сотрудника
        /// </summary>
        /// <param name="model">Данные для контекста данных</param>
        /// <param name="departament">Текущий департамент</param>
        /// <param name="emploee">Текущий сотрудник</param>
        public EmployeeAddOrCreateWindow(MainWindowViewModel model, Departament departament, FixedPayEmploee emploee)
        {
            InitializeComponent();
            DataContext = model; //Инициализируем контекст данных
            IdTextBox.Text = emploee.Id;
            NameTextBox.Text = emploee.Name;
            SurnameTextBox.Text = emploee.Surname;
            AgeTextBox.Text = emploee.Age.ToString();
            SalaryTextBox.Text = emploee.Salary.ToString();
            DepartamentComboBox.SelectedIndex = model.Departaments.IndexOf(departament);
        }

        private void onSaveButton_Click(object sender, RoutedEventArgs e)
        {
            var model = (MainWindowViewModel)DataContext;//Приводим контекст данных к модели представления
            //Сохраняем изменения (Валидация пользовательского ввода пока не реализована)
            model.Departaments[DepartamentComboBox.SelectedIndex].Employees?.Add(new FixedPayEmploee(
                NameTextBox.Text,
                SurnameTextBox.Text,
                int.Parse(AgeTextBox.Text),
                decimal.Parse(SalaryTextBox.Text)));
        }

        private void onCancelButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
