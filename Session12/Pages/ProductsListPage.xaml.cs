using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace Session12.Pages
{
    /// <summary>
    /// Логика взаимодействия для ProductsListPage.xaml
    /// </summary>
    public partial class ProductsListPage : Page
    {
        #region Свойства 

        public IList<MeasureUnit> MeasureUnits { get; set; }

        private ICollectionView productsDefault { get; set; }

        public ObservableCollection<int> NumberPages { get; set; } = new ObservableCollection<int>();

        #endregion

        #region Dependency Propertys

        public ICollectionView Products
        {
            get { return (ICollectionView)GetValue(ProductsProperty); }
            set { SetValue(ProductsProperty, value); }
        }

        public static readonly DependencyProperty ProductsProperty =
            DependencyProperty.Register("Products", typeof(ICollectionView), typeof(ProductsListPage));

        public int CountProductOnPage
        {
            get { return (int)GetValue(CountProductOnPageProperty); }
            set { SetValue(CountProductOnPageProperty, value); }
        }

        public static readonly DependencyProperty CountProductOnPageProperty =
            DependencyProperty.Register("CountProductOnPage", typeof(int), typeof(ProductsListPage));

        public int TotalPages
        {
            get { return (int)GetValue(TotalPagesProperty); }
            set { SetValue(TotalPagesProperty, value); }
        }

        public static readonly DependencyProperty TotalPagesProperty =
            DependencyProperty.Register("TotalPages", typeof(int), typeof(ProductsListPage));

        public int NumberPage
        {
            get { return (int)GetValue(NumberPageProperty); }
            set { SetValue(NumberPageProperty, value); }
        }

        public static readonly DependencyProperty NumberPageProperty =
            DependencyProperty.Register("NumberPage", typeof(int), typeof(ProductsListPage));

        #endregion

        public ProductsListPage()
        {

            MeasureUnits = App.db.MeasureUnit.Local;
            MeasureUnits.Insert(0, new MeasureUnit() { Title = "Все" });

            CountProductOnPage = 2; // количество продуктов на одной странице
            NumberPage = 1; // номер страницы
            TotalPages = 0; // максимальное количество страниц

            InitializeComponent();

            Page();

            FilterProduct.SelectionChanged += (s, e) => Page();

            NameDisSearchTb.TextChanged += (s, e) => Page();

            SortProduct.SelectionChanged += (s, e) => Page();
        }

        #region Постраничный вывод продуктов 

        #region Методы

        private void Page()
        {
            productsDefault = new CollectionViewSource { Source = App.db.Product.Local }.View;
            FilterproductsDefault();

            Products = new CollectionViewSource
            {
                Source = productsDefault.Cast<Product>()
                                        .Skip((NumberPage - 1) * CountProductOnPage)
                                        .Take(CountProductOnPage)
            }.View;

            SortedProductList();

            if (TotalPages == 0)
            {
                TotalPages = (int)Math.Ceiling(Convert.ToDouble(App.db.Product.Local.Count()) / Convert.ToDouble(CountProductOnPage));
                // максимальное количество страниц
                for (int i = 0; i < TotalPages; i++)
                    NumberPages.Add(i + 1); // количество страничек
            }
        }

        #endregion

        #region Фильтрация 

        private void FilterproductsDefault()
        {
            productsDefault.Filter = (obj) =>
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
        }
        #endregion

        #region Сортировка

        private void SortedProductList()
        {
            if ((SortProduct.SelectedItem as ComboBoxItem) == null)
                return;

            Products.SortDescriptions.Clear();

            var tag = (SortProduct.SelectedItem as ComboBoxItem).Tag;

            switch (tag)
            {
                case "AToZ":

                    Products.SortDescriptions.Add(new SortDescription
                    {
                        PropertyName = "Title",
                        Direction = ListSortDirection.Ascending
                    });
                    break;

                case "ZtoA":

                    Products.SortDescriptions.Add(new SortDescription
                    {
                        PropertyName = "Title",
                        Direction = ListSortDirection.Descending
                    });
                    break;

                case "DateAscending":

                    Products.SortDescriptions.Add(new SortDescription
                    {
                        PropertyName = "AdditionDateTime",
                        Direction = ListSortDirection.Ascending
                    });
                    break;

                case "DateDescending":

                    Products.SortDescriptions.Add(new SortDescription
                    {
                        PropertyName = "AdditionDateTime",
                        Direction = ListSortDirection.Descending
                    });
                    break;
            }

            Products.Refresh();
        }
        #endregion

        #region Обработчики кнопок переходов по страницам  
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
        #endregion

        #endregion

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            CountProductOnPage = Convert.ToInt32((NumberProductInList.SelectedItem as ComboBoxItem).Tag);
            Page();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //new Windows.AddAndEditProduct().Show();
        }
    }
}
