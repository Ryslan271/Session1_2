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

namespace Session12.Pages
{
    /// <summary>
    /// Логика взаимодействия для LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Window
    {
        #region Свойства

        private int countLog = 0;

        DispatcherTimer dispatcherTimer = new System.Windows.Threading.DispatcherTimer();

        #endregion

        public LoginPage() => InitializeComponent();

        private async void Enter_Click(object sender, RoutedEventArgs e)
        {
            if (LoginBox.Text.Trim() == "" || PasswordBox.Password.Trim() == "")
                return;

            if (countLog >= 3)
            {
                await Task.Run(() => TimerStart());
                InfoMessage.Visibility = Visibility.Visible;
                InfoMessage.Text = $"Войти можно будет только через {dispatcherTimer.Interval.Minutes}:{dispatcherTimer.Interval.Seconds}";
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

            new MainWindow().Show();
            Hide();
        }

        private void TimerStart()
        {
            dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);
            dispatcherTimer.Interval = new TimeSpan(0, 1, 0);
            dispatcherTimer.Start();
        }

        private void dispatcherTimer_Tick(object sender, EventArgs e) => countLog = 0;

        private void GoToRegistrationPage_Click(object sender, RoutedEventArgs e)
        {
            new RegistrationPage().Show();
            Close();
        }
    }
}
