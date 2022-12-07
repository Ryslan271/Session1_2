using Microsoft.Win32;
using Session12.Pages;
using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Session12.Windows
{
    /// <summary>
    /// Логика взаимодействия для AddAndEditProductPage.xaml
    /// </summary>
    public partial class AddAndEditProduct : Window
    {
        public AddAndEditProduct(Product product)
        {
            bool flag = App.db.Product.Local.Any(x => x == product) == false;

            if (flag) product.AdditionDateTime = DateTime.Now;

            MeasureUnits = App.db.MeasureUnit.Local;
            SupplierCountrys = new ObservableCollection<SupplierCountry>(App.db.SupplierCountry.Local.Except(product.SupplierCountry));

            ProductEditing = product;

            InitializeComponent();

            if (flag) IDStackPanel.Visibility = Visibility.Collapsed;
        }

        #region Обработка ввода в TextBox

        private void TextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            string str = e.Text;

            if (Regex.IsMatch(str, @"[^\w-\s]|\d"))
                e.Handled = true;
        }
        #endregion

        #region Страны поставщиков 

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
        #endregion

        #region Закрытие приложение

        private void Root_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (App.db.ChangeTracker.HasChanges() == false)
                return;

            switch (Ask())
            {
                case MessageBoxResult.Yes:
                    App.db.SaveChanges();
                    ProductsListPage.Instance.Page();
                    break;

                case MessageBoxResult.No:
                    foreach (var entry in App.db.ChangeTracker.Entries().Where(entry => entry.State == System.Data.Entity.EntityState.Modified))
                        entry.CurrentValues.SetValues(entry.OriginalValues);
                    ProductsListPage.Instance.Page();
                    break;
            }
        }
        #endregion

        #region Helper

        private MessageBoxResult Ask() =>
            MessageBox.Show("Вы действительно хотите сохранить эти маленькие данные",
                            "Уведомление",
                            MessageBoxButton.YesNo,
                            MessageBoxImage.Warning);

        #endregion

        #region Изменение изображение

        private void EditImageProduct(object sender, RoutedEventArgs e)
        {
            ChageImage();
        }

        private void ChageImage()
        {
            string filePath = OpenImage();

            if (filePath == null)
                return;

            byte[] photo = File.ReadAllBytes(filePath);

            if (photo.Length >= 150 * 1024)
            {
                MessageBox.Show("Картинка не должна весить больше 150 Кб");
                ChageImage();
                return;
            }

            ProductEditing.Photo = photo;
        }

        private string OpenImage()
        {
            OpenFileDialog openFileDialog = new OpenFileDialog()
            {
                Filter = "Изображения|*.png;*.jpg",
                DefaultExt = "Изображения|*.png;*.jpg",
                CheckFileExists = true,
                Multiselect = false
            };
            if (openFileDialog.ShowDialog() == true)
                return openFileDialog.FileName;
            return null;
        }
        #endregion

        #region Кнопка сохранения

        private void SaveChagesInProduct(object sender, RoutedEventArgs e)
        {
            if (App.db.ChangeTracker.HasChanges() == false &&
                ListBoxRadioBattonMeasureUnits.SelectedItem == null)
                return;

            switch (Ask())
            {
                case MessageBoxResult.Yes:
                    App.db.SaveChanges();
                    ProductsListPage.Instance.Page();
                    break;

                case MessageBoxResult.No:
                    foreach (var entry in App.db.ChangeTracker.Entries().Where(entry => entry.State == System.Data.Entity.EntityState.Modified))
                        entry.CurrentValues.SetValues(entry.OriginalValues);
                    ProductsListPage.Instance.Page();
                    break;
            }
        }
        #endregion
    }
}
