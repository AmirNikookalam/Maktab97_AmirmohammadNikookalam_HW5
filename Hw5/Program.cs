using Hw5.Domain;
using Hw5.Entity;

namespace Hw5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ProductRepository productRe = new ProductRepository();
            StockRepository stockRe = new StockRepository();
            Product newProduct = new Product();

            string? firstMenuInput;
            string? productmenu;
            string? addingProduct;
            string? menu;
            int productId = 0;
            int productQuantity = 0;
            int stockInProduct;
            int productPrice = 0;

            do
            {
                Console.Clear();
                Console.Write("What do you wnat to do? \n1.Product menu \n2.Stock menu \n");
                firstMenuInput = Console.ReadLine();

                if (firstMenuInput == "1")
                {
                    Console.Clear();
                    Console.Write("What do you wnat to do? \n1.Adding Product \n2.Get Product by Id \n3.Product list \n4.Exit \n");
                    menu = Console.ReadLine();

                    if (menu == "1")
                    {
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("warning: ");
                        Console.ForegroundColor = ConsoleColor.White;

                        Console.Write("For naming the product you must first start with capital letter fallow with three of four small letter one \"_\" \nand three digit\n\nProduct Name: ");
                        addingProduct = Console.ReadLine();
                        newProduct.ProductName = addingProduct;

                        var newpro = productRe.AddProduct(newProduct);
                        Console.WriteLine(newpro);
                        Thread.Sleep(2000);
                    }
                    else if (menu == "2")
                    {
                        try
                        {
                            Console.Clear();
                            Console.Write("Give me the produt id: ");
                            productId = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine();

                            var status = productRe.GetProductById(productId);

                            Console.WriteLine(status);
                            Thread.Sleep(3000);
                        }
                        catch (Exception)
                        {
                            Console.WriteLine("not valid input");
                            Thread.Sleep(1000);
                        }

                    }
                    else if (menu == "3")
                    {
                        Console.Clear();
                        var list = productRe.GetProductList();

                        if (list.Count == 0)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("you dont have any product!");
                            Console.ForegroundColor = ConsoleColor.White;

                            Thread.Sleep(2000);
                        }
                        else
                        {
                            foreach (var line in list)
                            {
                                Console.WriteLine($"Product Id: {line.ProductId} proudct name: {line.ProductName} product barcode : {line.Barcode}");
                            }
                            Console.ReadLine();
                        }
                    }
                    else
                    {
                        continue;
                    }
                }
                else if (firstMenuInput == "2")
                {
                    Console.Clear();
                    Console.WriteLine("---You are in Stock menu---");
                    Console.Write("--1.Buy product/2.sale product/3.Stock List/Exite\n-");
                    menu = Console.ReadLine();

                    if (menu == "1")
                    {
                        var list = productRe.GetProductList();

                        Console.Clear();
                        if (list.Count == 0)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("you dont have any product!");
                            Console.ForegroundColor = ConsoleColor.White;

                            Thread.Sleep(2000);
                        }
                        else
                        {
                            foreach (var line in list)
                            {
                                Console.WriteLine($"Product Id: {line.ProductId} proudct name: {line.ProductName} product barcode : {line.Barcode}\n");
                            }
                        }
                        try
                        {
                            Console.Write("Give me id of the product you want: ");
                            stockInProduct = Convert.ToInt32(Console.ReadLine());

                            Console.Write("Give me the quantity: ");
                            productQuantity = Convert.ToInt32(Console.ReadLine());

                            Console.Write("Give me product price: ");
                            productPrice = Convert.ToInt32(Console.ReadLine());

                            var buyProduct = stockRe.BuyProduct(
                                new Stock(0, "", stockInProduct, productQuantity, productPrice));

                            Console.WriteLine(buyProduct);
                            Thread.Sleep(3000);
                        }
                        catch (Exception)
                        {
                            Console.WriteLine("Error: Please give a valid input");
                            Thread.Sleep(3000);
                        }

                    }
                    else if (menu == "2")
                    {
                        Console.Clear();
                        var lines = stockRe.GetSalesProductList();
                        int stockId = 0;
                        int quantity = 0;

                        foreach (var line in lines)
                        {
                            Console.Write(line.StockId + " " + line.Name);
                        }

                        try
                        {
                            Console.WriteLine();
                            Console.Write("Give me the id of product you want to sale: ");
                            stockId = Convert.ToInt32(Console.ReadLine());
                            Console.Write("How much do you want to sale: ");
                            quantity = Convert.ToInt32(Console.ReadLine());

                            var result = stockRe.SaleProduct(stockId, quantity);
                            Console.WriteLine(result);
                        }
                        catch (Exception)
                        {
                            Console.WriteLine("not valid input");
                            Thread.Sleep(1000);
                        }

                    }
                    else if (menu == "3")
                    {
                        var lines = stockRe.GetSalesProductList();

                        foreach (var line in lines)
                        {
                            Console.WriteLine(line.Name);
                        }
                        Console.ReadLine();
                    }
                    else
                    {
                        continue;
                    }

                }
                else
                {
                    continue;
                }
            } while (true);

        }
    }
}