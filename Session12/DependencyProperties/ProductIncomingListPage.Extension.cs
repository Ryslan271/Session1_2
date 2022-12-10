using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;

namespace Session12.Pages
{
    public partial class ProductIncomingListPage
    {
        public ICollectionView Order_Products
        {
            get { return (ICollectionView)GetValue(OrdersProperty); }
            set { SetValue(OrdersProperty, value); }
        }

        public static readonly DependencyProperty OrdersProperty =
            DependencyProperty.Register("Order_Products", typeof(ICollectionView), typeof(ProductIncomingListPage));
    }
}
