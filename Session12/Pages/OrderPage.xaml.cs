using System.Linq;
using System.Net.NetworkInformation;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace Session12.Pages
{
    /// <summary>
    /// Логика взаимодействия для OrderPage.xaml
    /// </summary>
    public partial class OrderPage : Page
    {
        public User user { get; set; } = App.User;
        public OrderPage()
        {
            if (user.RoleID == 4)
                Orders = new CollectionViewSource { Source = App.db.Order.Local.Where(x =>x.User == user) }.View;
            else if (user.RoleID == 2)
                Orders = new CollectionViewSource { Source = App.db.Order.Local.Where(x => x.User1 == user || x.OrderStatusID == 1) }.View;
            else
                Orders = new CollectionViewSource { Source = App.db.Order.Local }.View;

            Orders.GroupDescriptions.Add(new PropertyGroupDescription("InProcessing"));

            InitializeComponent();
        }

        #region Методы

        private void UpdateList()
        {
            OrdersList.Items.Refresh();
            Orders.Refresh();
        }

        private void PutStatusToOrder(int IDStatus)
        {
            if (OrdersList.SelectedItem == null)
                return;

            (OrdersList.SelectedItem as Order).OrderStatusID = IDStatus;

            UpdateList();
        }
        #endregion

        #region Обработчики

        private void ButtonOperOrderClick(object sender, RoutedEventArgs e)
        {
            if (OrdersList.SelectedItem == null)
                return;

            MainWindow.Instance.MainName.Text = "Оформление заказа";
            MainWindow.Instance.OrdersListButton.IsChecked = false;
            MainWindow.Instance.MakeOrderButton.IsChecked = true;
            MainWindow.Instance.MainFrame.Navigate(new MakeOrderPage(OrdersList.SelectedItem as Order));
        }

        private void ButtonNewOrderClick(object sender, RoutedEventArgs e)
        {
            MainWindow.Instance.MainName.Text = "Оформление заказа";
            MainWindow.Instance.OrdersListButton.IsChecked = false;
            MainWindow.Instance.MakeOrderButton.IsChecked = true;
            MainWindow.Instance.MainFrame.Navigate(new MakeOrderPage());
        }

        private void ButtonApproveOrderClick(object sender, RoutedEventArgs e) 
        {
            if ((OrdersList.SelectedItem as Order).OrderStatusID != 2)
                return;

            PutStatusToOrder(3);
        }
        private void ButtonRejectClick(object sender, RoutedEventArgs e)
        {
            if ((OrdersList.SelectedItem as Order).OrderStatusID != 3)
                return;

            PutStatusToOrder(7);
        }
        private void ButtonPayClick(object sender, RoutedEventArgs e) 
        {
            if ((OrdersList.SelectedItem as Order).OrderStatusID != 3)
                return;

            PutStatusToOrder(4);
        }
        private void ButtonPerformedClick(object sender, RoutedEventArgs e)
        {
            if ((OrdersList.SelectedItem as Order).OrderStatusID != 4)
                return;

            PutStatusToOrder(5);
        }
        private void ButtonFulfilledClick(object sender, RoutedEventArgs e)
        {
            if ((OrdersList.SelectedItem as Order).OrderStatusID != 5)
                return;

            PutStatusToOrder(6);
        }
        #endregion

    }
}
