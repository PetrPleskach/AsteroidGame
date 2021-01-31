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
        public EmployeeAddOrCreateWindow(MainWindowViewModel model)
        {
            InitializeComponent();            
            DataContext = model;
        }        

        private void onSaveButton_Click(object sender, RoutedEventArgs e)
        {
            var model = (MainWindowViewModel)DataContext;
            model.Departaments[DepartamentComboBox.SelectedIndex].Employees?.Add(new FixedPayEmploee(NameTextBox.Text, SurnameTextBox.Text, int.Parse(AgeTextBox.Text), decimal.Parse(SalaryTextBox.Text)));
        }

        private void onCancelButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
