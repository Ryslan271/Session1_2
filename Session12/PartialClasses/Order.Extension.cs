using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Session12
{
    public partial class Order
    {
        public int Quantity 
        {
            get => this.Order_Product.Sum(x => x.Quantity);
        }

        public ObservableCollection<Order_Product> Order_Products
        {
            get => new ObservableCollection<Order_Product> (Order_Product);
        }

        public decimal TotalCost
        {
            get => this.Order_Product.Sum(x => x.Quantity * x.PurchasePrice);
        }
    }
}
