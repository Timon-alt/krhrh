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
    /// Логика взаимодействия для WindowAuth.xaml
    /// </summary>
    public partial class WindowAuth : Window
    {
        public WindowAuth()
        {
            InitializeComponent();
        }

        private void btn_click1(object sender, RoutedEventArgs e)
        {
            using (MedDataBaseEntities1 db = new MedDataBaseEntities1())
            {
                List<Users_info> users_info = (from us in db.Users_info where us.Login == LoginBox.Text && us.Password == PasswordBox.Text select us).ToList();

                // Yes == Администратор, No == Менеджер, hrthtr == Клиент xdd
                if (users_info.Count != 0)
                {
                    if (users_info[0].Role == "Yes")
                    {
                        WindowAdmin windowAdmin = new WindowAdmin();
                        windowAdmin.Show();
                        this.Close();
                        MessageBox.Show("Вы вошли как Yes");
                    }

                    if (users_info[0].Role == "No")
                    {
                        WindowManager windowAdmin = new WindowManager();
                        windowAdmin.Show();
                        this.Close();
                        MessageBox.Show("No");
                    }

                    if (users_info[0].Role == "hrthtr")
                    {
                        WindowClient windowAdmin = new WindowClient();
                        windowAdmin.Show();
                        this.Close();
                        MessageBox.Show("Вы вошли как hrthtr");
                    }
                }
                else
                {
                    MessageBox.Show("Проверьте валидность набора данных.");
                }
            }
        }

        private void btn_guest(object sender, RoutedEventArgs e)
        {
            WindowGuest windowGuest = new WindowGuest();
            windowGuest.Show();
            this.Close();
            MessageBox.Show("Вы вошли как гость");
        }

        private void btn_reg(object sender, RoutedEventArgs e)
        {
            WindowReg windowReg = new WindowReg();
            windowReg.Show();
        }
    }
}
