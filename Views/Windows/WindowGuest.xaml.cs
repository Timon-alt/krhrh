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
    /// Логика взаимодействия для WindowGuest.xaml
    /// </summary>
    public partial class WindowGuest : Window
    {
        public WindowGuest()
        {
            InitializeComponent();
            var currentCatalog = MedDataBaseEntities1.GetContext().Catalog.ToList();
            ListCatal.ItemsSource = currentCatalog;
        }

        // ф-ционал кнопки "Выйти"
        private void btn_exit(object sender, RoutedEventArgs e)
        {
            WindowAuth windowAuth = new WindowAuth();
            windowAuth.Show();
            this.Close();
        }
    }
}
