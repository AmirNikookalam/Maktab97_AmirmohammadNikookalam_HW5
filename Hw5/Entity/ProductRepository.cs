using Hw5.Domain;
using Hw5.Interface;
using Hw5.services;
using System.Security.Cryptography;

namespace Hw5.Entity
{
    public class ProductRepository : IProductRepository
    {
        public string AddProduct(Product product)
        {
            string name = product.ProductName;
            bool status = ProductServices.CheckProductName(product.ProductName);

            if (status)
            {
                var id = ProductServices.GiveProductId();
                int barcode = RandomNumberGenerator.GetInt32(100000000, 999999999);

                var newProduct = new Product(id, name, barcode);

                Json.SerializeObject(newProduct, "Product");

                return "product added";
            }
            return "not valid name";
        }

        public List<Product> GetProductList()
        {
            List<Product> produtList = new List<Product>();

            var fileToJson = Json.ProductDeserialize();

            foreach (var line in fileToJson)
            {
                produtList.Add(line);
            }
            return produtList;
        }

        public string GetProductById(int id)
        {
            var JsonL = Json.ProductDeserialize();

            foreach (var line in JsonL)
            {
                if (line.ProductId == id)
                {
                    return line.ProductName;
                }
            }
            return "Your product not found";
        }
    }
}
