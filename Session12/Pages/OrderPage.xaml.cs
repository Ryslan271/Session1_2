using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    /// Логика взаимодействия для OrderPage.xaml
    /// </summary>
    public partial class OrderPage : Page
    {
        public OrderPage()
        {
            Orders = new CollectionViewSource { Source = App.db.Order.Local }.View;
            Orders.GroupDescriptions.Add(new PropertyGroupDescription("InProcessing"));

            InitializeComponent();
        }

        private void ButtonOperOrderClick(object sender, RoutedEventArgs e)
        {
            MainWindow.Instance.OrdersListButton.IsChecked = true;
            MainWindow.Instance.MakeOrderButton.IsChecked = false;
            MainWindow.Instance.MainFrame.Navigate(new Pages.MakeOrderPage(OrdersList.SelectedItem as Order));
        }

        private void ButtonNewOrderClick(object sender, RoutedEventArgs e)
        {
            MainWindow.Instance.OrdersListButton.IsChecked = true;
            MainWindow.Instance.MakeOrderButton.IsChecked = false;
            MainWindow.Instance.MainFrame.Navigate(new Pages.MakeOrderPage());
        }
    }
}
