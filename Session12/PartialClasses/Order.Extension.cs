using System.Collections.ObjectModel;
using System.Linq;

namespace Session12
{
    public partial class Order
    {
        public string InProcessing // Статус в обработке
        {
            get => this.OrderStatusID == 1 ? "Новый" : "В обработке";
        }

        public int Quantity
        {
            get => this.Order_Product.Sum(x => x.Quantity);
        }

        public ObservableCollection<Order_Product> Order_Products
        {
            get => new ObservableCollection<Order_Product>(this.Order_Product);
        }

        public decimal TotalCost
        {
            get => this.Order_Product.Sum(x => x.Quantity * x.PurchasePrice);
        }
    }
}
