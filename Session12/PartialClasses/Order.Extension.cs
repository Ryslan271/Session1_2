using System.Collections.ObjectModel;
using System.Linq;

namespace Session12
{
    public partial class Order
    {
        public string InProcessing // Статус в обработке
        {
            get
            {
                if (this.OrderStatusID == 1)
                    return "Новый";
                else if (this.OrderStatusID == 2)
                    return "В обработке";
                else if (this.OrderStatusID == 3)
                    return "К оплате";
                else if (this.OrderStatusID == 4)
                    return "Оплачен";
                else if (this.OrderStatusID == 5)
                    return "Выполнение";
                else if (this.OrderStatusID == 6)
                    return "Готов";

                return "Отклонен";
            }
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
