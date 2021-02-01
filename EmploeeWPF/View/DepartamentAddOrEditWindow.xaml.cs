using EmploeeWPF.Model;
using EmploeeWPF.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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
using System.Windows.Shapes;

namespace EmploeeWPF
{
    /// <summary>
    /// Логика взаимодействия для DepartamentAddOrEditWindow.xaml
    /// </summary>
    public partial class DepartamentAddOrEditWindow : Window
    {
        private int index = -1;      

        public DepartamentAddOrEditWindow()
        {
            InitializeComponent();
        }

        public DepartamentAddOrEditWindow(MainWindowViewModel collection, int index)
        {      
            InitializeComponent();
            DepartamentName.Text = collection.Departaments[index].Name;
            this.index = index;
        }

        private void onSaveBtn_Click(object sender, RoutedEventArgs e)
        {
            var model = (MainWindowViewModel)Owner.DataContext;
            
            if (DepartamentAlreadyExistIn(model))
            {
                MessageBox.Show("Такой департамент уже существует!", "Попытка добавить существующий депертамент", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }

            if (index >= 0)            
                model.Departaments[index].Name = DepartamentName.Text;
            else
                model.Departaments.Add(new Departament(DepartamentName.Text));  
            
            Close();
        }

        private void onCancelBtn_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private bool DepartamentAlreadyExistIn(MainWindowViewModel model)
        {
            foreach (var item in model.Departaments.Where(i => i.Name == DepartamentName.Text))            
                return true;
            
            return false;
        }
    }
}
