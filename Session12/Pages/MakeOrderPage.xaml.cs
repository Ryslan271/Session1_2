    using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Session12.Pages
{
    /// <summary>
    /// Логика взаимодействия для MakeOrderPage.xaml
    /// </summary>
    public partial class MakeOrderPage : Page
    {
        public User user { get; set; } = App.User;
        public static MakeOrderPage Instance { get; set; }
        public MakeOrderPage(Order _order = null)
        {
            if (user.RoleID == 2) // если тот кто создает или смотрит Менеджер
            {
                CurrentOrder = _order ?? new Order()
                {
                    DateTime = DateTime.Now,
                    OrderStatusID = 2,
                    User1 = user
                };

                if (_order != null && _order.User1 == null)
                {
                    _order.User1 = user;
                    _order.OrderStatusID = 2;
                }

                Customers = new ObservableCollection<User>( App.db.User.Local.Where(x => x.RoleID == 4) );
            }
            else
            {
                CurrentOrder = _order ?? new Order()
                {
                    DateTime = DateTime.Now,
                    OrderStatusID = 1,
                    User = user
                };

                if (_order != null)
                {
                    _order.User1 = user;
                    _order.OrderStatusID = 1;
                }
            }


            InitializeComponent();

            VisibilitiButtonDueToStatus();

            Instance = this;
        }

        #region Методы

        private void VisibilitiButtonDueToStatus()
        {
            if (CurrentOrder.OrderStatusID != 6)
                return;

            DeleteProductButton.Visibility = Visibility.Collapsed;
            AddProductButton.Visibility = Visibility.Collapsed;
            SaveOrderButton.Visibility = Visibility.Collapsed;
        }

        private bool AskDelete() =>
            MessageBox.Show("Вы действительно хотите удалить выбранную запись", "Уведомление", MessageBoxButton.YesNo) == MessageBoxResult.Yes;

        public static bool AskSave() =>
           MessageBox.Show("Вы действительно хотите сохранить эти данные", "Уведомление", MessageBoxButton.YesNo) == MessageBoxResult.Yes;
        #endregion

        #region Обработчики

        private void ButtonDeleteClick(object sender, RoutedEventArgs e)
        {
            if (ProductListMake.SelectedItem == null ||
                AskDelete() == false)
                return;

            CurrentOrder.Order_Product.Remove(ProductListMake.SelectedItem as Order_Product);
            ProductListMake.Items.Refresh();
            App.db.SaveChanges();
        }

        private void ButtonSaveProductClick(object sender, RoutedEventArgs e)
        {
            if (AskSave() == false &&
                CurrentOrder.User == null &&
                CurrentOrder.User1 == null)
            {
                MessageBox.Show("Пожалуйста, убедитесь, что поле заказчика заполнено");
                return;
            }

            App.db.SaveChanges();

            MainWindow.Instance.OrdersListButton.IsChecked = true;
            MainWindow.Instance.MakeOrderButton.IsChecked = false;
            MainWindow.Instance.MainFrame.Navigate(new Pages.OrderPage());
        }
        private void ButtonAddProductClick(object sender, RoutedEventArgs e) =>
            new Windows.AddProductToMakeOrderPage().ShowDialog();
        #endregion

        private void ComboBoxSelectedCustomer(object sender, SelectionChangedEventArgs e)
        {
            if (CustomersComboBox.SelectedItem == null)
                return;

            CurrentOrder.User = CustomersComboBox.SelectedItem as User;
        }
    }
}
