using Session12.Pages;
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
using System.Windows.Shapes;

namespace Session12.Windows
{
    /// <summary>
    /// Логика взаимодействия для AddProductToMakeOrderPage.xaml
    /// </summary>
    public partial class AddProductToMakeOrderPage : Window
    {
        public AddProductToMakeOrderPage()
        {
            IsOrderNull();

            InitializeComponent();
        }

        #region Методы

        private void IsOrderNull()
        {
            if (MakeOrderPage.Instance.CurrentOrder == null)
            {
                Products = new ObservableCollection<Product>(App.db.Product.Local);
                return;
            }

            Products = new ObservableCollection<Product>(App.db.Product.Local.Where(product => product.Quantity > 0)
                                                    .Except(MakeOrderPage.Instance.CurrentOrder.Order_Product
                                                    .Select(orderProduct => orderProduct.Product)));
        }

        #endregion

        #region Обработчики

        private void ButtonAddProductInOrderClick(object sender, RoutedEventArgs e)
        {
            if (ProductListMake.SelectedItem == null ||
                MakeOrderPage.AskSave() == false)
                return;

            Product product = ProductListMake.SelectedItem as Product;

            if (product.QuantityOrder == 0 ||
                product.PurchasePrice == 0)
            {
                MessageBox.Show("Нельзя добавить продукт без: 'Закупаемой стоимости', 'Закупаемого количества'");
                return;
            }

            App.db.Order_Product.Local.Add(new Order_Product()
            {
                Order = MakeOrderPage.Instance.CurrentOrder,
                Product = product,
                Quantity = product.QuantityOrder,
                PurchasePrice = product.PurchasePrice
            });

            App.db.SaveChanges();

            Products.Remove(product);

            MakeOrderPage.Instance.ProductListMake.Items.Refresh();
        }
        #endregion

    }
}
