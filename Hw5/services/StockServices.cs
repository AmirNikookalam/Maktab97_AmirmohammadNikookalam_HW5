using Hw5.Domain;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hw5.services
{
    public static class StockServices
    {
        private static string pathToStock = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName + "\\Database\\StockJson.json";
        public static int GiveStockId()
        {
            int id = 1;
            var lines = Json.StockDeserialize();

            foreach(var line in lines)
            {
                if(line.StockId == id)
                {
                    id++;
                }
            }
            return id;
        }
        public static string FindProductName(int id)
        {
            var lines = Json.ProductDeserialize();

            foreach(var line in lines)
            {
                if(line.ProductId == id)
                {
                    return line.ProductName;
                }
            }
            throw new Exception();
        }
        public static int CheckProductQuantity(int productId)
        {
            var lines = Json.StockDeserialize();

            foreach(var line in lines)
            {
                if (line.ProductId == productId)
                {
                    return line.ProductQuantity;
                }
            }
            return 0;
        }
        public static int FindTargetLine(int id)

        {
            string[] lines = File.ReadAllLines(pathToStock);

            for (int i = 0; i < lines.Length; i++)
            {
                var specificProduct = JsonConvert.DeserializeObject<Stock>(lines[i]);
                if (id == specificProduct.ProductId)
                {
                    return i;
                }
            }
            return 0;
        }
        public static void OverWriting(int id, object product)
        {
            string objectToFile = JsonConvert.SerializeObject(product);
            string[] lines = File.ReadAllLines(pathToStock);

            lines[id] = objectToFile;

            File.WriteAllLines(pathToStock, lines);
        }
        public static int Quantity(int productId)
        {
            var lines = Json.StockDeserialize();

            var quantity = from line in lines
                    where line.ProductId == productId
                    select line.ProductQuantity;

            return quantity.Sum();
        }
        public static int Price(int id ,int cnt)
        {
            int price = 0;
            var fileToJson = Json.StockDeserialize();

            try
            {
                foreach (var line in fileToJson)
                {
                    if (line.ProductId == id)
                    {
                        price = (line.ProductPrice * line.ProductQuantity) + (line.ProductPrice * cnt) / line.ProductQuantity;
                    }
                }
                return (price);
            }
            catch
            {
                return 0;
            }
            
        }
    }
}
