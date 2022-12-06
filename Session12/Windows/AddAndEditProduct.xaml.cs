using Session12.Pages;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

namespace Session12.Windows
{
    /// <summary>
    /// Логика взаимодействия для AddAndEditProductPage.xaml
    /// </summary>
    public partial class AddAndEditProduct : Window
    {
        #region Свойства 

        public Product ProductEditing { get; set; }

        #endregion

        #region Dependency Properties

        public ObservableCollection<MeasureUnit> MeasureUnits
        {
            get { return (ObservableCollection<MeasureUnit>)GetValue(MeasureUnitsProperty); }
            set { SetValue(MeasureUnitsProperty, value); }
        }

        public static readonly DependencyProperty MeasureUnitsProperty =
            DependencyProperty.Register("MeasureUnits", typeof(ObservableCollection<MeasureUnit>), typeof(AddAndEditProduct));

        public ObservableCollection<SupplierCountry> SupplierCountrys
        {
            get { return (ObservableCollection<SupplierCountry>)GetValue(SupplierCountrysProperty); }
            set { SetValue(SupplierCountrysProperty, value); }
        }

        public static readonly DependencyProperty SupplierCountrysProperty =
            DependencyProperty.Register("SupplierCountrys", typeof(ObservableCollection<SupplierCountry>), typeof(AddAndEditProduct));

        #endregion

        public AddAndEditProduct(Product product)
        {
            MeasureUnits = App.db.MeasureUnit.Local;
            SupplierCountrys = new ObservableCollection<SupplierCountry> (App.db.SupplierCountry.Local.Except(product.SupplierCountry));

            ProductEditing = product;
            InitializeComponent();
        }

        private void TextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            string str = e.Text;

            if (Regex.IsMatch(str, @"[^\w-\s]|\d"))
                e.Handled = true;
        }

        private void ButtonDragLeft(object sender, RoutedEventArgs e)
        {
            if (RightListBoxCountry.SelectedItem == null)
                return;

            ProductEditing.SupplierCountry.Add(RightListBoxCountry.SelectedItem as SupplierCountry);

            LeftListBoxCountry.Items.Refresh();

            SupplierCountrys.Remove(RightListBoxCountry.SelectedItem as SupplierCountry);
        }

        private void ButtonDragRight(object sender, RoutedEventArgs e)
        {
            if (LeftListBoxCountry.SelectedItem == null)
                return;

            SupplierCountrys.Add(LeftListBoxCountry.SelectedItem as SupplierCountry);

            RightListBoxCountry.Items.Refresh();

            ProductEditing.SupplierCountry.Remove(LeftListBoxCountry.SelectedItem as SupplierCountry);

            LeftListBoxCountry.Items.Refresh();
        }

        private void Root_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            switch (MessageBox.Show("Вы действительно хотите сохранить эти маленькие данные",
                                    "Уведомлние",
                                    MessageBoxButton.YesNoCancel,
                                    MessageBoxImage.Warning))
            {
                case MessageBoxResult.Yes:
                    App.db.SaveChanges();
                    break;

                case MessageBoxResult.Cancel:
                    e.Cancel = true;
                    break;
            }
            ProductsListPage.Instance.Page();
        }
    }
}
