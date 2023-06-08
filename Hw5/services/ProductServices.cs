using System.Text.RegularExpressions;

namespace Hw5.services
{
    public static class ProductServices
    {
        public static bool CheckProductName(string productName)
        {

            bool status = Regex.IsMatch(productName, @"^[A-Z]+([a-z]{3})+.+_+([\d]){3}$");
            if (status)
                return true;
            else
                return false;
        }
        public static int GiveProductId()
        {
            int id = 1;
            var JsonL = Json.ProductDeserialize();

            foreach (var line in JsonL)
            {
                if (line.ProductId == id)
                    id++;
            }
            return id;
        }
    }
}
