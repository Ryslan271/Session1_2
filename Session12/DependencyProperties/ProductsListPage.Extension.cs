using System.ComponentModel;
using System.Windows;

namespace Session12.Pages
{
    public partial class ProductsListPage
    {
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
    }
}
