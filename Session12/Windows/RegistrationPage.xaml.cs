using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;

namespace Session12.Windows
{
    /// <summary>
    /// Логика взаимодействия для RegistrationPage.xaml
    /// </summary>
    public partial class RegistrationPage : Window
    {
        public RegistrationPage() => InitializeComponent();

        #region Методы

        private (string, bool) ValidatePassword(string password)
        {
            if (password.Length < 6)
                return ("Пароль должен быть не менее 6 символов", false);
            if (!password.Any(c => Char.IsUpper(c)))
                return ("В пароле должна быть хотя бы одна прописная буква", false);
            if (!Regex.IsMatch(password, @"\d"))
                return ("В пароле должна быть хотя бы одна цифра", false);
            if (!Regex.IsMatch(password, @"[!@#$%^]"))
                return ("В пароле должен быть хотя бы одний из символов ! @ # $ % ^", false);
            return ("", true);
        }

        private User newUser() =>
            new User()
            {
                Email = EmailBox.Text.Trim(),
                FirstName = LastnameBox.Text.Trim(),
                LastName = NameBox.Text.Trim(),
                Login = LoginBox.Text.Trim(),
                Password = PasswordBox.Password.Trim(),
                PhoneNumber = PhoneBox.Text.Trim(),
                Patronymic = PhynimicBox.Text.Trim(),
                GenderID = Convert.ToInt32((GenderBox.SelectedItem as ComboBoxItem).Tag),
                RoleID = 4
            };

        private bool ValidateChangesData() =>
                NameBox.Text.Trim() == "" ||
                LastnameBox.Text.Trim() == "" ||
                PhynimicBox.Text.Trim() == "" ||
                PhoneBox.Text.Trim() == "" ||
                EmailBox.Text.Trim() == "" ||
                LoginBox.Text.Trim() == "" ||
                PasswordBox.Password.Trim() == "";
        #endregion

        #region Обработчики
        private void ButtonRegistClick(object sender, RoutedEventArgs e)
        {
            if (ValidateChangesData())
            {
                MessageBox.Show("Поля не должны оставаться пустыми", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            User user = App.db.User.Local.FirstOrDefault(x => x.Login == LoginBox.Text.Trim() ||
                                                         x.PhoneNumber == PhoneBox.Text.Trim() ||
                                                         x.Email == EmailBox.Text.Trim());

            if (user != null)
            {
                MessageBox.Show("Такой пользователь уже есть", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            (string message, bool flag) = ValidatePassword(PasswordBox.Password.Trim());

            if (flag == false)
            {
                MessageBox.Show(message, "Уведомление", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            User userNew = newUser();

            App.db.User.Local.Add(userNew);

            App.User = userNew;

            App.db.SaveChanges();

            new MainWindow().Show();
            Close();
        }


        private void GoToLoginPagePage_Click(object sender, RoutedEventArgs e)
        {
            new LoginPage().Show();
            Hide();
        }
        #endregion
    }
}
