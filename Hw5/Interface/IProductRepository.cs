using Hw5.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hw5.Interface
{
    public interface IProductRepository
    {
        string AddProduct(Product product);
        List<Product> GetProductList();
        string GetProductById(int id);
    }
}
