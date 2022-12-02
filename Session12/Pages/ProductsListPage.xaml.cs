using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Логика взаимодействия для ProductsListPage.xaml
    /// </summary>
    public partial class ProductsListPage : Page
    {
        #region DependencyPropertyes

        public ObservableCollection<Product> Products
        {
            get { return (ObservableCollection<Product>)GetValue(ProductsProperty); }
            set { SetValue(ProductsProperty, value); }
        }

        public static readonly DependencyProperty ProductsProperty =
            DependencyProperty.Register("Products", typeof(ObservableCollection<Product>), typeof(ProductsListPage));

        #endregion


        public ProductsListPage()
        {

            Products = App.db.Product.Local;

            InitializeComponent();
        }
    }
}
