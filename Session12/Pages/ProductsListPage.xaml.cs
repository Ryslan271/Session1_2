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
        public User user { get; set; } = App.User;
        public static ProductsListPage Instance { get; set; }
        public List<MeasureUnit> MeasureUnits { get; set; }
        private ICollectionView ProductsDefault { get; set; }
        public ObservableCollection<int> NumberPages { get; set; } = new ObservableCollection<int>();
        #endregion

        public ProductsListPage()
        {
            MeasureUnits = App.db.MeasureUnit.Local.ToList();
            MeasureUnits.Insert(0, new MeasureUnit() { Title = "Все" });

            CountProductOnPage = 2; // количество продуктов на одной странице
            NumberPage = 1; // номер страницы
            TotalPages = 0; // максимальное количество страниц

            InitializeComponent();

            Instance = this;

            Page();

            FilterProduct.SelectionChanged += (s, e) => Page();

            NameDisSearchTb.TextChanged += (s, e) => Page();

            SortProduct.SelectionChanged += (s, e) => Page();
        }

        #region Постраничный вывод продуктов 

        #region Методы

        public void Page()
        {
            ProductsDefault = new CollectionViewSource { Source = App.db.Product.Local }.View;
            FilterproductsDefault();

            Products = new CollectionViewSource
            {
                Source = ProductsDefault.Cast<Product>()
                                        .Skip((NumberPage - 1) * CountProductOnPage)
                                        .Take(CountProductOnPage)
            }.View;

            SortedProductList();
        }

        #endregion

        #region Фильтрация 

        private void FilterproductsDefault()
        {
            ProductsDefault.Filter = (obj) =>
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

            KnowTotalPage();
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

        #region Метод для вычисление количество страниц

        private void KnowTotalPage()
        {
            TotalPages = (int)Math.Ceiling(Convert.ToDouble(ProductsDefault.Cast<Product>().Count()) / Convert.ToDouble(CountProductOnPage));
            // максимальное количество страниц
            for (int i = 0; i < TotalPages; i++)
                NumberPages.Add(i + 1); // количество страничек
        }
        #endregion

        #endregion

        #region Обработчики

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            CountProductOnPage = Convert.ToInt32((NumberProductInList.SelectedItem as ComboBoxItem).Tag);

            Page();

            KnowTotalPage();
        }

        private void EditProduct(object sender, RoutedEventArgs e)
        {
            if (ProductList.SelectedItem == null)
                return;

            new Windows.AddAndEditProduct(ProductList.SelectedItem as Product).ShowDialog();
        }

        private void AddProdutc(object sender, RoutedEventArgs e) =>
            new Windows.AddAndEditProduct(new Product()).ShowDialog();
        #endregion
    }
}
