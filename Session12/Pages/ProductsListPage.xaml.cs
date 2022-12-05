using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Логика взаимодействия для ProductsListPage.xaml
    /// </summary>
    public partial class ProductsListPage : Page
    {
        #region Свойства 

        public ICollectionView Products { get; set; }

        #endregion

        #region Dependency Propertys

        public int CountProduct
        {
            get { return (int)GetValue(CountProductProperty); }
            set { SetValue(CountProductProperty, value); }
        }

        public static readonly DependencyProperty CountProductProperty =
            DependencyProperty.Register("CountProduct", typeof(int), typeof(ProductsListPage));

        #endregion

        public ProductsListPage()
        {

            Products = new CollectionViewSource { Source = App.db.Product.Local }.View;

            InitializeComponent();

            SearchList();
            FilterList();

            CountProduct = Products.Cast<object>().Count();
        }

        #region Поиск

        private void SearchList() 
        {

            NameDisSearchTb.TextChanged += (s, e) => Products.Refresh();

            Products.Filter += (obj) =>
            {
                var product = obj as Product;

                var search = NameDisSearchTb.Text;

                if (product.Title.Contains(search) || product.Description.Contains(search))
                    return true;

                CountProduct = Products.Cast<object>().Count();
                return false;
            };
        }

        #endregion

        #region Фильтор

        private void FilterList()
        {
            SortProduct.SelectionChanged += (s, e) =>
            {
                var tag = (SortProduct.SelectedItem as ComboBoxItem).Tag;

                switch (tag)
                {
                    case "AToZ":
                        Products.SortDescriptions.Clear();
                        Products.SortDescriptions.Add(new SortDescription
                        {
                            PropertyName = "Title",
                            Direction = ListSortDirection.Ascending,
                        });
                        break;
                    case "ZtoA":
                        Products.SortDescriptions.Clear();
                        Products.SortDescriptions.Add(new SortDescription
                        {
                            PropertyName = "Title",
                            Direction = ListSortDirection.Descending,
                        });
                        break;
                }
            };
        }

        #endregion
    }
}
