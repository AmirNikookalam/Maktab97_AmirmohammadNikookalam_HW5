using Hw5.Domain;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Hw5.services
{
    public static class Json
    {
        private static string pathToProduct = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName + "\\Database\\ProductJson.json" ;
        private static string pathToStock = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName + "\\Database\\StockJson.json";
        private static string pathToGetSalesProductList = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName + "\\Database\\GetSalesProductList.txt";
        public static string SerializeObject(object obj, string fileName)
        {
            string input = fileName.ToLower();
            string path;

            var jsonToFile = JsonConvert.SerializeObject(obj);

            if (input == "product")
            {
                path = pathToProduct;

            }else if(input == "stock")
            {
                path = pathToStock;
            }
            else //need workd!!!
            {
                throw new Exception("not valid!");
            }

            File.AppendAllText(path, jsonToFile + Environment.NewLine);

            return $"file succesfully adde to {fileName}";
        }
        public static List<Product> ProductDeserialize()
        {
            var listProduct = new List<Product>();
            var file = File.ReadAllLines(pathToProduct);

            foreach (var line in file)
            {
                var fileToJson = JsonConvert.DeserializeObject<Product>(line);
                listProduct.Add(fileToJson);
            }

            return listProduct;
        }
        public static List<Stock> StockDeserialize()
        {
            var listStock = new List<Stock>();
            var file = File.ReadAllLines(pathToStock);

            foreach(var line in file)
            {
                var fileToJson = JsonConvert.DeserializeObject<Stock>(line);
                listStock.Add(fileToJson);
            }

            return listStock;
        }
        public static void SalesProductList(List<Stock> stockList)
        {
            StreamWriter sw = new StreamWriter(pathToGetSalesProductList);
            
            foreach( var line in stockList)
            {
                string json = JsonConvert.SerializeObject(line);
                sw.WriteLine(json);
            }
            sw.Close();
        }
    }
}
