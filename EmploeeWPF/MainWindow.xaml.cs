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
            MessageBox.Show("Clicked");
        }
        
        private void onDepartamentAddBtn_Click(object sender, RoutedEventArgs e)
        {
            DepartamentAddOrEditWindow deptWindow = new DepartamentAddOrEditWindow();
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

        private void departamentEditBtn_Click(object sender, RoutedEventArgs e)
        {
            var model = (MainWindowViewModel)DataContext;
            if (DepartamentsBox.SelectedItem == null)
            {
                MessageBox.Show("Сначала выберите департамент!", "Департамент не выбран", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }
            DepartamentAddOrEditWindow deptWindow = new DepartamentAddOrEditWindow(model, DepartamentsBox.SelectedIndex);
            deptWindow.Owner = this;
            deptWindow.ShowDialog();            
        }
    }
}
