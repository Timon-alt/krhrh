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
using System.Windows.Shapes;
using WpfApp2.DataBase;

namespace WpfApp2.Views.Windows
{
    /// <summary>
    /// Логика взаимодействия для WindowAdmin.xaml
    /// </summary>
    public partial class WindowAdmin : Window
    {
        public WindowAdmin()
        {
            InitializeComponent();
            var currentCatalog = MedDataBaseEntities1.GetContext().Catalog.ToList();
            dGrid.ItemsSource = currentCatalog;
        }

       // Загрузка таблицы из бд
        private void window_add(object sender, RoutedEventArgs e)
        {
            dGrid.ItemsSource = AppData.db.Catalog.ToList();
        }

        // ф-ционал кнопки "Добавить"
        private void btn_add(object sender, RoutedEventArgs e)
        {
            Catalog catalog = new Catalog();
            catalog.Name = NameBox.Text;
            catalog.Opisanie = OpisanieBox.Text;
            catalog.Image = ImageBox.Text;
            AppData.db.Catalog.Add(catalog);
            AppData.db.SaveChanges();
            System.Windows.MessageBox.Show("Запись добавлена");
            dGrid.ItemsSource = AppData.db.Catalog.ToList();
        }

        // ф-ционал кнопки "Удалить"
        private void btn_delete(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Вы действительно хотите удалить товар из каталога?", "Уведомление", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                var del = dGrid.SelectedItem as Catalog;
                AppData.db.Catalog.Remove(del);
                AppData.db.SaveChanges();
                System.Windows.MessageBox.Show("Товар удалён");
                dGrid.ItemsSource = AppData.db.Catalog.ToList();
            }
        }

        // ф-ционал кнопки "Выйти"
        private void btn_exit(object sender, RoutedEventArgs e)
        {
            WindowAuth windowAuth = new WindowAuth();
            windowAuth.Show();
            this.Close();
        }
    }

    class AppData
    {
        public static MedDataBaseEntities1 db = new MedDataBaseEntities1();
    }
}
