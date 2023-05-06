using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application_v_3_.BL
{
    class Credentials
    {
        public int role;
        public string userName;
        public string password;
        public string contact;

        public Credentials(string userName, string password)
        {
            this.userName = userName;
            this.password = password;
        }

        public Credentials(int role, string userName, string password, string contact)
        {
            this.role = role;
            this.userName = userName;
            this.password = password;
            this.contact = contact;
        }
    }

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
