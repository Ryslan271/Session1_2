using System;
using System.Collections.Generic;
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
    /// Логика взаимодействия для MakeOrderPage.xaml
    /// </summary>
    public partial class MakeOrderPage : Page
    {
        public static MakeOrderPage Instance { get; set; }
        public MakeOrderPage(Order _order = null)
        {
            CurrentOrder = _order;

            InitializeComponent();

            Instance = this;
        }

        #region Методы

        private bool AskDelete() =>
            MessageBox.Show("Вы действительно хотите удалить выбранную запись", "Уведомление", MessageBoxButton.YesNo) == MessageBoxResult.Yes;

        private bool AskSave() =>
           MessageBox.Show("Вы действительно хотите сохранить эти данные", "Уведомление", MessageBoxButton.YesNo) == MessageBoxResult.Yes;
        #endregion

        #region Обработчики

        private void ButtonDeleteClick(object sender, RoutedEventArgs e)
        {
            if (ProductListMake.SelectedItem == null ||
                AskDelete() == false)
                return;

            CurrentOrder.Order_Product.Remove(ProductListMake.SelectedItem as Order_Product);
            ProductListMake.Items.Refresh();
            App.db.SaveChanges();
        }

        private void ButtonSaveProductClick(object sender, RoutedEventArgs e)
        {
            if (App.db.ChangeTracker.HasChanges() == false ||
                AskSave() == false)
                return;

            App.db.SaveChanges();
        }
        private void ButtonAddProductClick(object sender, RoutedEventArgs e) => 
            new Windows.AddProductToMakeOrderPage().ShowDialog();
        #endregion
    }
} 
