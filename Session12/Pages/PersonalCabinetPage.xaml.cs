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
    /// Логика взаимодействия для PersonalCabinetPage.xaml
    /// </summary>
    public partial class PersonalCabinetPage : Page
    {
        public User user { get; set; }
        public PersonalCabinetPage()
        {
            user = App.User;
            InitializeComponent();
        }

        private void LastName_TextChanged(object sender, TextChangedEventArgs e)
        {
            EditUserInformationButton.Visibility = Visibility.Visible;
        }

        private void FirstName_TextChanged(object sender, TextChangedEventArgs e)
        {
            EditUserInformationButton.Visibility = Visibility.Visible;
        }

        private void Patronymic_TextChanged(object sender, TextChangedEventArgs e)
        {
            EditUserInformationButton.Visibility = Visibility.Visible;
        }

        private void PhoneNumber_TextChanged(object sender, TextChangedEventArgs e)
        {
            EditUserInformationButton.Visibility = Visibility.Visible;
        }

        private void Email_TextChanged(object sender, TextChangedEventArgs e)
        {
            EditUserInformationButton.Visibility = Visibility.Visible;
        }

        private void LoginBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            EditUserInformationButton.Visibility = Visibility.Visible;
        }

        private void PasswordBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            EditUserInformationButton.Visibility = Visibility.Visible;
        }

        private void EditUserInformation(object sender, RoutedEventArgs e)
        {

        }
    }
}
