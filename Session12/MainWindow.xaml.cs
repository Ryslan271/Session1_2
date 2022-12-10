using System.Windows;
using System.Windows.Controls;

namespace Session12
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region Свойства
        public User user { get; set; } = App.User;
        public static MainWindow Instance { get; set; }
        #endregion

        public MainWindow()
        {
            InitializeComponent();
            Instance = this;
            ParsonCabinet.IsChecked = true;
            MainFrame.Navigate(new Pages.PersonalCabinetPage());
        }

        #region Обработчики
        private void ButtonClickExit(object sender, RoutedEventArgs e)
        {
            new Windows.LoginPage().Show();
            Close();
        }

        private void OpenMainList(object sender, RoutedEventArgs e)
        {
            (sender as RadioButton).IsChecked = true;
            MainFrame.Navigate(new Pages.PersonalCabinetPage());
        }

        private void OpenProductList(object sender, RoutedEventArgs e)
        {
            (sender as RadioButton).IsChecked = true;
            MainFrame.Navigate(new Pages.ProductsListPage());
        }

        private void OpenPostavchikList(object sender, RoutedEventArgs e)
        {
            (sender as RadioButton).IsChecked = true;
            MainFrame.Navigate(new Pages.OrderPage());
        }

        private void OpenOrdersList(object sender, RoutedEventArgs e)
        {
            (sender as RadioButton).IsChecked = true;
            MainFrame.Navigate(new Pages.MakeOrderPage());
        }

        private void OpenGoinYourHouseList(object sender, RoutedEventArgs e)
        {
            (sender as RadioButton).IsChecked = true;
            MainFrame.Navigate(new Pages.ProductIncomingListPage());
        }
        #endregion

    }
}
