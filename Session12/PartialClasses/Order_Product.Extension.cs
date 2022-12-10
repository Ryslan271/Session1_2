using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Session12
{
    public partial class Order_Product
    {
        public string SupplierCountryNameGroup
        {
            get
            {
                string SupplierCountries = "";

                foreach (var item in this.Product.SupplierCountry)
                    SupplierCountries += " " + item.Title;

                return SupplierCountries;
            }
        }
    }
}
