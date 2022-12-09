using System.Collections.ObjectModel;
using System.Windows;

namespace Session12.Windows
{
    public partial class AddProductToMakeOrderPage
    {
        public ObservableCollection<Product> Products
        {
            get { return (ObservableCollection<Product>)GetValue(ProductsProperty); }
            set { SetValue(ProductsProperty, value); }
        }

        public static readonly DependencyProperty ProductsProperty =
            DependencyProperty.Register("MyProperty", typeof(ObservableCollection<Product>), typeof(AddProductToMakeOrderPage));
    }
}
