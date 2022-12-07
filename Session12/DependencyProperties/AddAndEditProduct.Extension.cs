using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Session12.Windows
{
    public partial class AddAndEditProduct
    {
        public Product ProductEditing
        {
            get { return (Product)GetValue(ProductEditingProperty); }
            set { SetValue(ProductEditingProperty, value); }
        }

        public static readonly DependencyProperty ProductEditingProperty =
            DependencyProperty.Register("ProductEditing", typeof(Product), typeof(AddAndEditProduct));

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
    }
}
