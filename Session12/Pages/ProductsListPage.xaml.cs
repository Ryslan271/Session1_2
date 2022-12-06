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

        public IList<MeasureUnit> MeasureUnits { get; set; }

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
            Page();

            MeasureUnits = App.db.MeasureUnit.Local;
            MeasureUnits.Insert(0, new MeasureUnit() { Title = "Все" });

            InitializeComponent();

            FilterProduct.SelectionChanged += (s, e) => Products.Refresh();
            NameDisSearchTb.TextChanged += (s, e) => Products.Refresh();

            #region поиск + фильтрация

            Products.Filter += (obj) =>
            {
                var product = obj as Product;

                var tag = (FilterProduct.SelectedItem as MeasureUnit).Title;

                if (FilterProduct.SelectedIndex != 0)
                    if (product.MeasureUnit.Title != tag)
                        return false;

                var search = NameDisSearchTb.Text.ToLower().Trim();

                if (product.Title.ToLower().Contains(search) == false &&
                    product.Description.ToLower().Contains(search) == false)
                    return false;

                return true;
            };

            #endregion

            #region Сортировка

            SortProduct.SelectionChanged += (s, e) =>
            {
                if ((SortProduct.SelectedItem as ComboBoxItem) == null)
                    return;

                var tag = (SortProduct.SelectedItem as ComboBoxItem).Tag;

                switch (tag)
                {
                    case "AToZ":
                        Products.SortDescriptions.Clear();
                        Products.SortDescriptions.Add(new SortDescription
                        {
                            PropertyName = "Title",
                            Direction = ListSortDirection.Ascending
                        });
                        Products.Refresh();
                        break;

                    case "ZtoA":
                        Products.SortDescriptions.Clear();
                        Products.SortDescriptions.Add(new SortDescription
                        {
                            PropertyName = "Title",
                            Direction = ListSortDirection.Descending
                        });
                        Products.Refresh();
                        break;

                    case "DateAscending":
                        Products.SortDescriptions.Clear();
                        Products.SortDescriptions.Add(new SortDescription
                        {
                            PropertyName = "AdditionDateTime",
                            Direction = ListSortDirection.Ascending
                        });
                        Products.Refresh();
                        break;

                    case "DateDescending":
                        Products.SortDescriptions.Clear();
                        Products.SortDescriptions.Add(new SortDescription
                        {
                            PropertyName = "AdditionDateTime",
                            Direction = ListSortDirection.Descending
                        });
                        Products.Refresh();
                        break;
                }
            };

            #endregion

        }

        private int NumberPage = 1;
        private int TotalPages = 0;
        private int CountProductOnPage = 2;

        private void Page()
        {
            Products = new CollectionViewSource { Source = App.db.Product.Local.Skip((NumberPage - 1) * CountProductOnPage)
                           .Take(CountProductOnPage)}.View;

            Products.Refresh();

            TotalPages = App.db.Product.Local.Count() / CountProductOnPage;
        }

        private void ButtonClickLeftPage(object sender, RoutedEventArgs e)
        {
            if ((NumberPage - 1) <= 0)
                return;

            NumberPage--;

            Page();
        }

        private void ButtonClickRightPage(object sender, RoutedEventArgs e)
        {
            if (TotalPages <= NumberPage)
                return;

            NumberPage++;

            Page();
        }
    }
}
