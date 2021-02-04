using EmploeeWPF.ViewModel;
using EmploeeWPF.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Collections.ObjectModel;

namespace EmploeeWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();            
        }

        private void onEmployeeAddBtn_Click(object sender, RoutedEventArgs e)
        {
            //Создаем новое окно в которое передаем контекст данных и выбранный департамент
            var empWindow = new EmployeeAddOrCreateWindow((MainWindowViewModel)DataContext, DepartamentsBox.SelectedItem as Departament);
            empWindow.Owner = this;
            empWindow.ShowDialog();
            
        }

        private void onEmployeeEditBtn_Click(object sender, RoutedEventArgs e)
        {            
            if(employesDataGrid.SelectedItem == null)//Выполняем проверку выбран ли сотрудник
            {
                MessageBox.Show("Сначала выберите сотрудника!", "Сотрудник не выбран", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }

            //Создаем новое окно куда передаем контекст данных, выбранный департамент и выбранного сотрудника
            var model = (MainWindowViewModel)DataContext;
            var empWindow = new EmployeeAddOrCreateWindow(model , DepartamentsBox.SelectedItem as Departament,  employesDataGrid.SelectedItem as FixedPayEmploee);
            empWindow.Owner = this;

            empWindow.ShowDialog();

        }

        private void onEmployeeDelBtn_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Вы уверены", "Удаление", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.No) return;
            
            var model = (MainWindowViewModel)DataContext;
            var selectedDept = model.Departaments[DepartamentsBox.SelectedIndex];

            selectedDept.Employees.Remove(employesDataGrid.SelectedItem as FixedPayEmploee);            
        }

        private void onDepartamentAddBtn_Click(object sender, RoutedEventArgs e)
        {
            //Создаем окно для добавления департамента
            var deptWindow = new DepartamentAddOrEditWindow();
            deptWindow.Owner = this;
            deptWindow.ShowDialog();
        }

        private void onDepartamentEditBtn_Click(object sender, RoutedEventArgs e)
        {
            var model = (MainWindowViewModel)DataContext;
            if (DepartamentsBox.SelectedItem == null)//Выполняем проверку выбран ли департамент
            {
                MessageBox.Show("Сначала выберите департамент!", "Департамент не выбран", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }

            //Создаем окно для редактрования департамент куда передаем контекст данных и выбранный департамент
            var deptWindow = new DepartamentAddOrEditWindow(model, DepartamentsBox.SelectedIndex);
            deptWindow.Owner = this;
            deptWindow.ShowDialog();
        }

        private void onDepartamentDelBtn_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Вы уверены", "Удаление", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.No) return; 
            
            var model = (MainWindowViewModel)DataContext;
            var selectedDept = (Departament)DepartamentsBox.SelectedItem;
            if (selectedDept == null) return;

            model.Departaments.Remove(selectedDept);            
        }
    }
}
