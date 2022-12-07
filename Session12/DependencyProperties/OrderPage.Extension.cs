using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;

namespace Session12.Pages
{
    public partial class OrderPage
    {
        public ObservableCollection<Order> Orders
        {
            get { return (ObservableCollection<Order>)GetValue(OrdersProperty); }
            set { SetValue(OrdersProperty, value); }
        }

        public static readonly DependencyProperty OrdersProperty =
            DependencyProperty.Register("Orders", typeof(ObservableCollection<Order>), typeof(OrderPage));

    }
}
