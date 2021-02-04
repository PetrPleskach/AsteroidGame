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
        private FixedPayEmploee emploeeToEdit; // Ссылка на сотрудника для редактирования
        Departament departamentToChange; // Ссылка на департамент для изменения

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
            Title = "Создание сотрудника";
            CancelButton.Visibility = Visibility.Hidden;
        }

        /// <summary>
        /// Конструктор для редактирования сотрудника
        /// </summary>
        /// <param name="model">Данные для контекста данных</param>
        /// <param name="departament">Текущий департамент</param>
        /// <param name="emploee">Текущий сотрудник</param>
        public EmployeeAddOrCreateWindow(MainWindowViewModel model, Departament departament, FixedPayEmploee emploeeToEdit)
        {
            InitializeComponent();
            DataContext = model; //Инициализируем контекст данных
            this.emploeeToEdit = emploeeToEdit;
            departamentToChange = departament;
            FillEditableWindowElements(departament, emploeeToEdit);
            Title = "Редактирование сотрудника";            
        }

        private void onSaveButton_Click(object sender, RoutedEventArgs e)
        {
            var model = (MainWindowViewModel)DataContext;//Приводим контекст данных к модели представления
            if (emploeeToEdit == null)//Если поле не проинициализировано значит нужно добавить нового сотрудника
            {
                model.Departaments[DepartamentComboBox.SelectedIndex].Employees?.Add(new FixedPayEmploee(
                    NameTextBox.Text,
                    SurnameTextBox.Text,
                    int.Parse(AgeTextBox.Text),
                    decimal.Parse(SalaryTextBox.Text)));
            }
            else
            {
                var dept = (Departament)DepartamentComboBox.SelectedItem;
                if (departamentToChange.Name != dept.Name)
                {
                    departamentToChange.Employees.Remove(emploeeToEdit);//Удаляем сотрудника из текущего департамента
                    model.Departaments[DepartamentComboBox.SelectedIndex].Employees.Add(emploeeToEdit);//Добавляем его в выбранный пользователем департамент
                }

                //Присваеваем сотруднику новые параметры
                emploeeToEdit.Id = IdTextBox.Text;
                emploeeToEdit.Name = NameTextBox.Text;
                emploeeToEdit.Surname = SurnameTextBox.Text;
                emploeeToEdit.Age = int.Parse(AgeTextBox.Text);
                emploeeToEdit.Salary = decimal.Parse(SalaryTextBox.Text);
                Close();
            }
        }

        private void onCancelButton_Click(object sender, RoutedEventArgs e)
        {
            FillEditableWindowElements(departamentToChange, emploeeToEdit);
        }

        private void onExitButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        /// <summary>
        /// Метод для заполнения начальных данных в редактируемых элементах окна
        /// </summary>
        /// <param name="departament"></param>
        /// <param name="emploee"></param>
        private void FillEditableWindowElements(Departament departament, FixedPayEmploee emploee)
        {
            IdTextBox.Text = emploeeToEdit.Id;
            NameTextBox.Text = emploeeToEdit.Name;
            SurnameTextBox.Text = emploeeToEdit.Surname;
            AgeTextBox.Text = emploeeToEdit.Age.ToString();
            SalaryTextBox.Text = emploeeToEdit.Salary.ToString();
            DepartamentComboBox.SelectedItem = departamentToChange;
        }
    }
}
