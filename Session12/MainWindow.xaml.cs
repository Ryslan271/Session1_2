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
            MainName.Text = "Личный кабинет";
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
            MainName.Text = "Личный кабинет";
            (sender as RadioButton).IsChecked = true;
            MainFrame.Navigate(new Pages.PersonalCabinetPage());
        }

        private void OpenProductList(object sender, RoutedEventArgs e)
        {
            MainName.Text = "Список продуктов";
            (sender as RadioButton).IsChecked = true;
            MainFrame.Navigate(new Pages.ProductsListPage());
        }

        private void OpenPostavchikList(object sender, RoutedEventArgs e)
        {
            MainName.Text = "Список заказов";
            (sender as RadioButton).IsChecked = true;
            MainFrame.Navigate(new Pages.OrderPage());
        }

        private void OpenOrdersList(object sender, RoutedEventArgs e)
        {
            MainName.Text = "Оформление заказа";
            (sender as RadioButton).IsChecked = true;
            MainFrame.Navigate(new Pages.MakeOrderPage());
        }

        private void OpenGoinYourHouseList(object sender, RoutedEventArgs e)
        {
            MainName.Text = "Поступление продуктов";
            (sender as RadioButton).IsChecked = true;
            MainFrame.Navigate(new Pages.ProductIncomingListPage());
        }
        #endregion

    }
}
