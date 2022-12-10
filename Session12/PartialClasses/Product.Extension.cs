using System.Collections.Generic;
using System.Linq;

namespace Session12
{
    public partial class Product
    {
        public int QuantityOrder { get; set; }
        public int PurchasePrice { get; set; }
        public int TotalPriceOrder
        {
            get => PurchasePrice * QuantityOrder;
        }
    }
}
