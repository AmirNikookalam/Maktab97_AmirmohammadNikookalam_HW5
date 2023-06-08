using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hw5.Domain
{
    public class Stock
    {
        public int StockId { get; set; }
        public string? Name { get; set; }
        public int ProductId { get; set; }
        public int ProductQuantity { get; set; }
        public int ProductPrice { get; set; }

        public Stock(int stockId = 0, string name = null, int productId = 0, int productQuantity = 0, int productPrice = 0)
        {
            StockId = stockId;
            Name = name;
            ProductId = productId;
            ProductQuantity = productQuantity;
            ProductPrice = productPrice;
        }
    }
}
