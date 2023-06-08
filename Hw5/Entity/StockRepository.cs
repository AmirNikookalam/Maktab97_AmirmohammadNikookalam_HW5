using Hw5.Domain;
using Hw5.Interface;
using Hw5.services;

namespace Hw5.Entity
{
    public class StockRepository : IStockRepository
    {
        public string BuyProduct(Stock productInStock)
        {
            string stockPath = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName + "\\Database\\StockJson.json";


            ProductRepository productRepository = new ProductRepository();
            var quantity = StockServices.CheckProductQuantity(productInStock.ProductId);

            if (quantity != 0)
            {
                var newQuantity = quantity + productInStock.ProductQuantity;
                var newProductPrice = productInStock.ProductPrice * quantity + productInStock.ProductPrice * (quantity - productInStock.ProductQuantity) / newQuantity;
                productInStock.ProductQuantity = newQuantity;
                productInStock.ProductPrice = newProductPrice;
                productInStock.Name = StockServices.FindProductName(productInStock.ProductId);
                productInStock.StockId = StockServices.GetStockId();

                var target = StockServices.FindLine(productInStock.ProductId);
                StockServices.OverWriting(target, productInStock);

                return productRepository.GetProductById(productInStock.ProductId) + "updateted";
            }
            else
            {
                productInStock.Name = StockServices.FindProductName(productInStock.ProductId);
                productInStock.StockId = StockServices.GetStockId();

                Json.SerializeObject(productInStock, "stock");

                return productRepository.GetProductById(productInStock.ProductId) + "added";
            }
        }

        public string SaleProduct(int productId, int count)
        {
            var oldQuantity = StockServices.Quantity(productId);

            if (oldQuantity > count)
            {
                int newQuantity = oldQuantity - count;
                if (newQuantity >= 0)
                {
                    var lines = Json.StockDeserialize();


                    foreach (var line in lines)
                    {
                        if (line.ProductId == productId)
                        {

                            line.ProductQuantity = newQuantity;

                            StockServices.OverWriting(productId, line);
                            return "product salded";
                        }
                    }
                    return "no product found";
                }
                else
                {
                    return "need more product!";
                }
            }
            else
            {
                return "you dont have any products ";
            }
        }

        public List<Stock> GetSalesProductList()
        {
            var lines = Json.StockDeserialize();
            List<Stock> result = new List<Stock>();

            foreach (var line in lines)
            {
                result.Add(line);
            }

            Json.SalesProductList(result);

            return result;
        }

    }
}
