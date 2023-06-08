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
        public Product(int productId, string? productName, int barcode)
        {
            ProductId = productId;
            ProductName = productName;
            Barcode = barcode;
        }
    }
}
