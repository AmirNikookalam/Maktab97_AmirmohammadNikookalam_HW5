using Hw5.Domain;
using Hw5.Entity;

namespace Hw5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ProductRepository productRepository = new ProductRepository();
            StockRepository stockRepository = new StockRepository();
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

                        Console.Write("Give me the product name: ");
                        addingProduct = Console.ReadLine();
                        newProduct.ProductName = addingProduct;

                        var newProject = productRepository.AddProduct(newProduct);
                        Console.WriteLine(newProject);
                        Thread.Sleep(3000);
                    }
                    else if (menu == "2")
                    {
                        try
                        {
                            Console.Clear();
                            Console.Write("Give me the produt id: ");
                            productId = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine();

                            var status = productRepository.GetProductById(productId);

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
                        var list = productRepository.GetProductList();

                        if (list.Count == 0)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Error: You dont have any product");
                            Console.ForegroundColor = ConsoleColor.White;

                            Thread.Sleep(3000);
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
                    Console.Write("What do you want to do? \n1.Buy product \n2.sale product \n3.Stock List \n4.Exit \n");
                    menu = Console.ReadLine();

                    if (menu == "1")
                    {
                        var list = productRepository.GetProductList();

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

                            var buyProduct = stockRepository.BuyProduct(
                                new Stock(0, null, stockInProduct, productQuantity, productPrice));

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
                        var lines = stockRepository.GetSalesProductList();
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

                            var result = stockRepository.SaleProduct(stockId, quantity);
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
                        var lines = stockRepository.GetSalesProductList();

                        foreach (var line in lines)
                            Console.WriteLine(line.Name);

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