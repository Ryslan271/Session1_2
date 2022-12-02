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
    /// Логика взаимодействия для RegistrationPage.xaml
    /// </summary>
    public partial class RegistrationPage : Window
    {
        public RegistrationPage()
        {
            InitializeComponent();
        }

        private void ButtonRegistClick(object sender, RoutedEventArgs e)
        {
            if (NameBox.Text.Trim() == "" ||
                LastnameBox.Text.Trim() == "" ||
                PhynimicBox.Text.Trim() == "" ||
                PhoneBox.Text.Trim() == "" ||
                EmailBox.Text.Trim() == "" ||
                LoginBox.Text.Trim() == "" ||
                PasswordBox.Password.Trim() == ""
                )
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

            User newUser = new User()
            {
                Email = EmailBox.Text.Trim(),
                FirstName = LastnameBox.Text.Trim(),
                LastName = NameBox.Text.Trim(),
                Login = LoginBox.Text.Trim(),
                Password = PasswordBox.Password.Trim(),
                PhoneNumber = PhoneBox.Text.Trim(),
                Patronymic = PhynimicBox.Text.Trim(),
                GenderID = Convert.ToInt32((GenderBox.SelectedItem as ComboBoxItem).Tag),
                RoleID = 1

            };

            App.db.User.Local.Add(newUser);

            App.User = newUser;

            App.db.SaveChanges();

            new MainWindow().Show();
            Hide();
        }

        private void GoToLoginPagePage_Click(object sender, RoutedEventArgs e)
        {
            new LoginPage().Show();
            Close();
        }

    }
}
