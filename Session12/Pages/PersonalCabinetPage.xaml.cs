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
    /// Логика взаимодействия для PersonalCabinetPage.xaml
    /// </summary>
    public partial class PersonalCabinetPage : Page
    {
        #region Свойства

        public User _user { get; set; }

        DispatcherTimer dispatcherTimer = new DispatcherTimer();

        #endregion

        public PersonalCabinetPage()
        {
            _user = App.User;
            InitializeComponent();
        }

        #region Обработчики

        private void LastName_TextChanged(object sender, TextChangedEventArgs e) => EditUserInformationButton.Visibility = Visibility.Visible;

        private void FirstName_TextChanged(object sender, TextChangedEventArgs e) => EditUserInformationButton.Visibility = Visibility.Visible;

        private void Patronymic_TextChanged(object sender, TextChangedEventArgs e) => EditUserInformationButton.Visibility = Visibility.Visible;

        private void PhoneNumber_TextChanged(object sender, TextChangedEventArgs e) => EditUserInformationButton.Visibility = Visibility.Visible;

        private void Email_TextChanged(object sender, TextChangedEventArgs e) => EditUserInformationButton.Visibility = Visibility.Visible;

        private void LoginBox_TextChanged(object sender, TextChangedEventArgs e) => EditUserInformationButton.Visibility = Visibility.Visible;

        private void PasswordBox_TextChanged(object sender, TextChangedEventArgs e) => EditUserInformationButton.Visibility = Visibility.Visible;

        private void EditUserInformation(object sender, RoutedEventArgs e)
        {
            EditUserInformationButton.Visibility = Visibility.Hidden;
            MessageInfo.Text = "Данные обновлены";
            TimerStart();
            App.db.SaveChanges();
        }

        #endregion

        #region Таймер

        private void TimerStart()
        {
            dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);
            dispatcherTimer.Interval = new TimeSpan(0, 0, 10);
            dispatcherTimer.Start();
        }

        private void dispatcherTimer_Tick(object sender, EventArgs e) => MessageInfo.Text = "";

        #endregion
    }
}
