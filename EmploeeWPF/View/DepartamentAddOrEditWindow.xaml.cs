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
        private int index = -1;//Переменная для определения был ли редактирован департамент или добавлен новый

        /// <summary>
        /// Конструктор для создания департамента
        /// </summary>
        public DepartamentAddOrEditWindow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Конструктор для редактирования департамента
        /// </summary>
        /// <param name="model"></param>
        /// <param name="index"></param>
        public DepartamentAddOrEditWindow(MainWindowViewModel model, int index)
        {      
            InitializeComponent();
            DepartamentName.Text = model.Departaments[index].Name;
            this.index = index;
        }

        private void onSaveBtn_Click(object sender, RoutedEventArgs e)
        {
            var model = (MainWindowViewModel)Owner.DataContext; //Получаем ссылку на контекст данных родительской формы
            
            if (DepartamentAlreadyExistIn(model))//Проверка на существование департамента с таким же именем
            {
                MessageBox.Show("Такой департамент уже существует!", "Попытка добавить существующий депертамент", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }

            if (index >= 0) //Редактирование выбранного департамента
                model.Departaments[index].Name = DepartamentName.Text;
            else //Создание нового департамента
                model.Departaments.Add(new Departament(DepartamentName.Text));  
            
            Close();
        }

        private void onCancelBtn_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        /// <summary>
        /// Метод для проверки введенного пользователем имени департамента на существование департамента с таким же именем в списке
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        private bool DepartamentAlreadyExistIn(MainWindowViewModel model)
        {
            foreach (var item in model.Departaments.Where(i => i.Name == DepartamentName.Text))            
                return true;
            
            return false;
        }
    }
}
