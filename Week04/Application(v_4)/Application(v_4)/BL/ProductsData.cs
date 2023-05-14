using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application_v_4_.BL
{
    class ProductsData
    {
        public string productName;
        public float price;
        public int quantity;
        public int sale;

        public ProductsData(string productName, float price, int quantity, int sale)
        {
            this.productName = productName;
            this.price = price;
            this.quantity = quantity;
            this.sale = sale;
        }
    }
}
