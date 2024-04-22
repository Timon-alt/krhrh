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
    /// Логика взаимодействия для WindowReg.xaml
    /// </summary>
    public partial class WindowReg : Window
    {
        public WindowReg()
        {
            InitializeComponent();
        }

        private void btn_reg(object sender, RoutedEventArgs e)
        {
            if (LoginBox == null || PasswordBox == null || cmbBox == null)
            {
                MessageBox.Show("Введите данные во все строки!");
            }

            else
            {
                Users_info us = new Users_info();
                us.Login = LoginBox.Text;
                us.Password = PasswordBox.Text;
                us.Role = cmbBox.Text;
                AppData.db.Users_info.Add(us);
                AppData.db.SaveChanges();
                MessageBox.Show("Вы зарегестрировались!");

                this.Close();

            }
        }
    }
}
