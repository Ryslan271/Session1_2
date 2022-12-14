using System.Windows.Media;

namespace Session12
{
    public partial class SupplierCountry
    {
        private static BrushConverter _brushConverter = new BrushConverter();

        private Brush _brush;
        public Brush Brush
        {
            get
            {
                if (_brush == null)
                    _brush = (SolidColorBrush)_brushConverter.ConvertFrom($"#{HexColorCode}");
                return _brush;
            }
        }
    }
}
