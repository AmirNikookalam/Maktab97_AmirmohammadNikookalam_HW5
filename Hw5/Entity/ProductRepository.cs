﻿using Hw5.Domain;
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

                return "Product succussfully added";
            }
            return "Error: Please give a valid name";
        }

        public List<Product> GetProductList()
        {
            List<Product> produtList = new List<Product>();

            var JsonL = Json.ProductDeserialize();

            foreach (var line in JsonL)
                produtList.Add(line);

            return produtList;
        }

        public string GetProductById(int id)
        {
            var JsonL = Json.ProductDeserialize();

            foreach (var line in JsonL)
                if (line.ProductId == id)
                    return line.ProductName;

            return "Error: Your product not found";
        }
    }
}
