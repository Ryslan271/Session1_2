using Session12.Properties;
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
using System.Windows.Threading;

namespace Session12.Windows
{
    /// <summary>
    /// Логика взаимодействия для LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Window
    {
        #region Свойства

        private int countLog = 0;

        #endregion

        public LoginPage()
        { 
            InitializeComponent();
            if (Settings.Default.Login != null)
                LoginBox.Text = Settings.Default.Login;
        }

        #region Обработчики

        private void Enter_Click(object sender, RoutedEventArgs e)
        {
            if (LoginBox.Text.Trim() == "" || PasswordBox.Password.Trim() == "")
                return;

            if (countLog >= 3)
            {
                InfoMessage.Visibility = Visibility.Visible;
                InfoMessage.Text = "Тут таймер по сути";
                return;
            }

            var user = App.db.User.Local.FirstOrDefault(x => x.Login == LoginBox.Text.Trim() && x.Password == PasswordBox.Password.Trim());
            
            if (user == null)
            {
                MessageBox.Show("Такой пользователь не зарегистрирован");
                countLog++;
                return;
            }

            App.User = user;

            if (CheckSaveLogin.IsChecked == true)
                Settings.Default.Login = LoginBox.Text.Trim();

            new MainWindow().Show();
            Close();
        }

        private void GoToRegistrationPage_Click(object sender, RoutedEventArgs e)
        {
            new RegistrationPage().Show();
            Hide();
        }
        #endregion
    }
}
