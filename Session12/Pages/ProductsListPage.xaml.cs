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

        public int NumberPages { get; set ; }

        #endregion

        public ProductsListPage()
        {

            Products = new CollectionViewSource { Source = App.db.Product.Local }.View;

            InitializeComponent();

            #region Поиск

            NameDisSearchTb.TextChanged += (s, e) => Products.Refresh();

            Products.Filter += (obj) =>
            {
                var product = obj as Product;

                var search = NameDisSearchTb.Text;

                if (product.Title.Contains(search) || product.Description.Contains(search))
                    return true;

                return false;
            };
            #endregion

            NumberPages = Products.Cast<object>().Count();


        }
    }
}
