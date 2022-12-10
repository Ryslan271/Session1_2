using System.Linq;
using System.Windows.Controls;
using System.Windows.Data;

namespace Session12.Pages
{
    /// <summary>
    /// Логика взаимодействия для ProductIncomingListPage.xaml
    /// </summary>
    public partial class ProductIncomingListPage : Page
    {
        public ProductIncomingListPage()
        {
            Order_Products = new CollectionViewSource { Source = App.db.Order_Product.Local.Where(x => x.Order.OrderStatusID == 6).Distinct() }.View;
            Order_Products.GroupDescriptions.Add(new PropertyGroupDescription("SupplierCountryNameGroup"));

            InitializeComponent();
        }
    }
}
