using System.Collections.ObjectModel;
using System.Windows;

namespace Session12.Pages
{
    public partial class MakeOrderPage
    {
        public ObservableCollection<Product> Produtcs
        {
            get { return (ObservableCollection<Product>)GetValue(ProdutcsProperty); }
            set { SetValue(ProdutcsProperty, value); }
        }

        public static readonly DependencyProperty ProdutcsProperty =
            DependencyProperty.Register("Produtcs", typeof(ObservableCollection<Product>), typeof(MakeOrderPage));



        public Order CurrentOrder
        {
            get { return (Order)GetValue(CurrentOrderProperty); }
            set { SetValue(CurrentOrderProperty, value); }
        }

        public static readonly DependencyProperty CurrentOrderProperty =
            DependencyProperty.Register("CurrentOrder", typeof(Order), typeof(MakeOrderPage));
    }
}
