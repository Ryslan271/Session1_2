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

namespace Session12.Pages
{
    /// <summary>
    /// Логика взаимодействия для LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Page
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        private void Enter_Click(object sender, RoutedEventArgs e)
        {
            var user = App.db.User.Local.FirstOrDefault(x => x.Login == LoginBox.Text.Trim() && x.Password == PasswordBox.Password.Trim());
            
            if (user == null)
            {
                MessageBox.Show("Такой пользователь не зарегистрирован");
                return;
            }

            App.User = user;

            MainWindow.Instance.MainFrame.Navigate();
        }
    }
}
