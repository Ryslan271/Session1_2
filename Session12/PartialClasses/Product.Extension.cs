using System.Collections.Generic;
using System.Linq;
using System.Windows.Media;

namespace Session12
{
    public partial class Product
    {
        private static BrushConverter _brushConverter = new BrushConverter();
        public int QuantityOrder { get; set; }
        public int PurchasePrice { get; set; }
        public int TotalPriceOrder
        {
            get => PurchasePrice * QuantityOrder;
        }
        public Brush BrushColorCount
        {
            get 
            { 
                if (this.Quantity <= 0)
                    return (SolidColorBrush)_brushConverter.ConvertFrom($"#ffccd5");

                return null;
            }
        }
    }
}
