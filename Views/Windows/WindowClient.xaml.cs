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
    /// Логика взаимодействия для WindowClient.xaml
    /// </summary>
    public partial class WindowClient : Window
    {
        public WindowClient()
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

        private void btn_click_add_korzina(object sender, RoutedEventArgs e)
        {
            var rowItem = (sender as Button).DataContext as Catalog;
            int id = rowItem.ID_Catolog;
            using (MedDataBaseEntities1 db = new MedDataBaseEntities1())
            {
                var catalog = db.Catalog.First(x => x.ID_Catolog == id);
                db.Korzina.Add(new Korzina() { Name = catalog.Name, Opisanie = catalog.Opisanie, Image = catalog.Image, ID_Catolog = catalog.ID_Catolog });
                db.SaveChanges();

                MessageBox.Show($"{catalog.Name} Добавлено в корзину!");
            }
        }

        private void btn_korzina(object sender, RoutedEventArgs e)
        {
            WindowKorzina windowKorzina = new WindowKorzina();
            windowKorzina.Show();
        }
    }
}
