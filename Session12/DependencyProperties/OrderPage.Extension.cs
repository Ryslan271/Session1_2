using System.ComponentModel;
using System.Windows;

namespace Session12.Pages
{
    public partial class OrderPage
    {
        public ICollectionView Orders
        {
            get { return (ICollectionView)GetValue(OrdersProperty); }
            set { SetValue(OrdersProperty, value); }
        }

        public static readonly DependencyProperty OrdersProperty =
            DependencyProperty.Register("Orders", typeof(ICollectionView), typeof(OrderPage));
    }
}
