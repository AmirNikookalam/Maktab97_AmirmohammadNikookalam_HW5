using Hw5.Domain;
using Newtonsoft.Json;

namespace Hw5.services
{
    public static class StockServices
    {
        private static string stockPath = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName + "\\Database\\StockJson.json";
        public static int Quantity(int productId)
        {
            var lines = Json.StockDeserialize();

            var quantity = from line in lines
                           where line.ProductId == productId
                           select line.ProductQuantity;

            return quantity.Sum();
        }
        public static int Price(int id, int count)
        {
            int price = 0;
            var JsonL = Json.StockDeserialize();

            try
            {
                foreach (var line in JsonL)
                    if (line.ProductId == id)
                        price = (line.ProductPrice * line.ProductQuantity) + (line.ProductPrice * count) / line.ProductQuantity;

                return (price);
            }
            catch
            {
                return 0;
            }

        }
        public static void OverWriting(int id, object product)
        {
            string objectToFile = JsonConvert.SerializeObject(product);
            string[] lines = File.ReadAllLines(stockPath);

            lines[id] = objectToFile;

            File.WriteAllLines(stockPath, lines);
        }
        public static int GetStockId()
        {
            int id = 1;
            var lines = Json.StockDeserialize();

            foreach (var line in lines)
                if (line.StockId == id)
                    id++;

            return id;
        }
        public static int FindLine(int id)

        {
            string[] lines = File.ReadAllLines(stockPath);

            for (int i = 0; i < lines.Length; i++)
            {
                var targetProduct = JsonConvert.DeserializeObject<Stock>(lines[i]);
                if (id == targetProduct.ProductId)
                    return i;
            }
            return 0;
        }
        public static string FindProductName(int id)
        {
            var lines = Json.ProductDeserialize();

            foreach (var line in lines)
                if (line.ProductId == id)
                    return line.ProductName;

            throw new Exception();
        }
        public static int CheckProductQuantity(int productId)
        {
            var lines = Json.StockDeserialize();

            foreach (var line in lines)
                if (line.ProductId == productId)
                    return line.ProductQuantity;

            return 0;
        }
    }
}
