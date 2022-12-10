using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Threading;

namespace Session12.Pages
{
    /// <summary>
    /// Логика взаимодействия для PersonalCabinetPage.xaml
    /// </summary>
    public partial class PersonalCabinetPage : Page
    {
        #region Свойства

        private DispatcherTimer dispatcherTimer = new DispatcherTimer();

        #endregion

        public PersonalCabinetPage()
        {
            MainUser = App.User;
            Genders = App.db.Gender.Local;

            InitializeComponent();
        }

        #region Методы

        private bool ValidateChangesDataUser() => LastName.Text.Trim() == "" ||
                                                  FirstName.Text.Trim() == "" ||
                                                  Patronymic.Text.Trim() == "" ||
                                                  PhoneNumber.Text.Trim() == "" ||
                                                  Email.Text.Trim() == "" ||
                                                  LoginBox.Text.Trim() == "" ||
                                                  PasswordBox.Text.Trim() == "";
        #endregion


        #region Обработчики

        private void LastName_TextChanged(object sender, TextChangedEventArgs e) 
        { 
            if (EditUserInformationButton != null) EditUserInformationButton.Visibility = Visibility.Visible;
        }

        private void FirstName_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (EditUserInformationButton != null) EditUserInformationButton.Visibility = Visibility.Visible;
        }

        private void Patronymic_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (EditUserInformationButton != null) EditUserInformationButton.Visibility = Visibility.Visible;
        }

        private void PhoneNumber_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (EditUserInformationButton != null) EditUserInformationButton.Visibility = Visibility.Visible;
        }

        private void Email_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (EditUserInformationButton != null) EditUserInformationButton.Visibility = Visibility.Visible;
        }

        private void LoginBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (EditUserInformationButton != null) EditUserInformationButton.Visibility = Visibility.Visible;
        }

        private void PasswordBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (EditUserInformationButton != null) EditUserInformationButton.Visibility = Visibility.Visible;
        }

        private void ComboBoxSelectionChangedGender(object sender, SelectionChangedEventArgs e)
        {
            if (EditUserInformationButton != null) EditUserInformationButton.Visibility = Visibility.Visible;
        }

        private void EditUserInformation(object sender, RoutedEventArgs e)
        {
            if (App.db.ChangeTracker.HasChanges() == false)
                return;

            if (ValidateChangesDataUser())
            {
                MessageInfo.Text = "Какое то поле осталось пустым";
                MessageInfo.Foreground = new SolidColorBrush(Colors.Red);
            }

            EditUserInformationButton.Visibility = Visibility.Hidden;
            MessageInfo.Text = "Данные обновлены";
            MessageInfo.Foreground = new SolidColorBrush(Colors.Green);
            TimerStart();
            App.User = MainUser;
            App.db.SaveChanges();
        }
        #endregion

        #region Таймер

        private void TimerStart()
        {
            dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);
            dispatcherTimer.Interval = new TimeSpan(0, 0, 5);
            dispatcherTimer.Start();
        }

        private void dispatcherTimer_Tick(object sender, EventArgs e) => MessageInfo.Text = "";

        #endregion

    }
}
