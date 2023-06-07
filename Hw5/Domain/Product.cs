using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hw5.Domain
{
    public class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int Barcode { get; set; }
        public Product(int productId = 0, string name = "null", int barcode = 0)
        {
            ProductId = productId;
            ProductName = name;
            Barcode = barcode;
        }
    }
}
