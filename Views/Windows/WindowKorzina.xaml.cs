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
using System.Collections.ObjectModel;

namespace WpfApp2.Views.Windows
{
    /// <summary>
    /// Логика взаимодействия для WindowKorzina.xaml
    /// </summary>
    public partial class WindowKorzina : Window
    {
        ObservableCollection<Korzina> Collect { get; set; }
        List<Korzina> ms = null;
        
        public WindowKorzina()
        {
            InitializeComponent();
            Random rnd = new Random();
            int value = rnd.Next(100, 999);
            Code.Content = value;
            LoadPrice();
        }

        void LoadPrice()
        {
            using (MedDataBaseEntities1 db = new MedDataBaseEntities1())
            {
                int fullPrice = 0;
                int saleCost = 0;
                int firstPrice = 0;
                foreach (Korzina item in db.Korzina)
                {
                    firstPrice += (int)item.Cost;
                    saleCost = firstPrice / 100 * (int)item.Sale;
                    fullPrice = firstPrice - saleCost;
                }
                Sum.Content = fullPrice;
            }
        }

        private void btn_exit(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
