using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Hw5.services
{
    public static class ProductServices
    {
        public static bool CheckProductName(string productName)
        {
            string regexPattern = "[A-Z][a-z]{3,5}[_][0-9]{3}";

            bool status = Regex.IsMatch(productName, regexPattern);

            if (status)
            {
                return true;
            }
            return false;
        }
        public static int GiveProductId()
        {
            int id = 1;
            var fileTOJson = Json.ProductDeserialize();

            foreach (var line in fileTOJson)
            {
                if (line.ProductId == id)
                {
                    id++;
                }
                else
                {
                    return id;
                }
            }
            return id;
        }
    }
}
