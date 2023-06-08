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
        private static string productPath = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName + "\\Database\\ProductJson.json" ;
        private static string stockPath = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName + "\\Database\\StockJson.json";
        private static string pathToGetSalesProductList = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName + "\\Database\\GetSalesProductList.txt";
        public static string SerializeObject(object obj, string fileName)
        {
            string input = fileName.ToLower();
            string path;

            var jsonToFile = JsonConvert.SerializeObject(obj);

            if (input == "product")
            {
                path = productPath;

            }else if(input == "stock")
            {
                path = stockPath;
            }
            else 
            {
                throw new Exception("Error: Not valid");
            }

            File.AppendAllText(path, jsonToFile + Environment.NewLine);

            return $"File succesfully added to {fileName}";
        }
        public static List<Product> ProductDeserialize()
        {
            var productList = new List<Product>();
            var file = File.ReadAllLines(productPath);

            foreach (var line in file)
            {
                var newObj = JsonConvert.DeserializeObject<Product>(line);
                productList.Add(newObj);
            }

            return productList;
        }
        public static List<Stock> StockDeserialize()
        {
            var listStock = new List<Stock>();
            var file = File.ReadAllLines(stockPath);

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
