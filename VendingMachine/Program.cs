using System;
using System.Collections.Generic;

namespace VendingMachine
{
    class Program
    {
        static void Main(string[] args)
        {
            VendingMachine vendingMachine = new VendingMachine();

            Console.WriteLine("Welcome to the Vending Machine!");
            Console.WriteLine("Menu:");
            Console.WriteLine("1. View available products");
            Console.WriteLine("2. Insert coin");
            Console.WriteLine("3. Purchase product");
            Console.WriteLine("4. Exit");

            bool exit = false;
            while (!exit)
            {
                Console.Write("Select an option: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        vendingMachine.DisplayProducts();
                        break;
                    case "2":
                        Console.Write("Enter coin amount: ");
                        double amount = Convert.ToDouble(Console.ReadLine());
                        vendingMachine.InsertCoin(amount);
                        break;
                    case "3":
                        Console.Write("Enter product code: ");
                        string code = Console.ReadLine();
                        vendingMachine.PurchaseProduct(code);
                        break;
                    case "4":
                        exit = true;
                        Console.WriteLine("Exiting...");
                        break;
                    default:
                        Console.WriteLine("Invalid option! Please try again.");
                        break;
                }
            }
        }
    }

    class Product
    {
        public string Code { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
    }

    class VendingMachine
    {
        private List<Product> products;
        private double userBalance;
        private double machineFloat;

        public VendingMachine()
        {
            // Initialize vending machine with some products
            products = new List<Product>()
            {
                new Product() { Code = "A1", Description = "Coke", Price = 1.5, Quantity = 10 },
                new Product() { Code = "B1", Description = "Fanta", Price = 1.5, Quantity = 8 },
                new Product() { Code = "C1", Description = "Sweet", Price = 2.0, Quantity = 15 },
                new Product() { Code = "D1", Description = "Irn Bru", Price = 1.2, Quantity = 10 },
                new Product() { Code = "E1", Description = "Water", Price = 1.0, Quantity = 10 }
            };

            // Initialize machine float
            machineFloat = 10.0; // Starting float amount
        }

        public void DisplayProducts()
        {
            Console.WriteLine("Available Products:");
            Console.WriteLine("Code \tDescription \tPrice \tQuantity");
            foreach (var product in products)
            {
                Console.WriteLine($"{product.Code}\t{product.Description}\t\t£{product.Price}\t{product.Quantity}");
            }
        }

        public void InsertCoin(double amount)
        {
            userBalance += amount;
            Console.WriteLine($"Inserted {amount} coins. Your balance: £{userBalance}");
        }

        public void PurchaseProduct(string code)
        {
            Product product = products.Find(p => p.Code == code);
            if (product != null)
            {
                if (userBalance >= product.Price && product.Quantity > 0)
                {
                    Console.WriteLine($"Dispensing {product.Description}...");
                    product.Quantity--;

                    // Deduct the product price from the user balance
                    userBalance -= product.Price;

                    // Check for change
                    double change = userBalance;
                    if (change > 0)
                    {
                        if (machineFloat >= change)
                        {
                            Console.WriteLine($"Your change: £{change}");
                            machineFloat -= change;
                            userBalance = 0; // Reset user balance after giving change
                        }
                        else
                        {
                            Console.WriteLine("Sorry, insufficient change available. Please try another product.");
                            userBalance += product.Price; // Add back the deducted amount to user balance
                        }
                    }
                }
                else
                {
                    if (product.Quantity <= 0)
                    {
                        Console.WriteLine("Sorry, this product is out of stock.");
                    }
                    else
                    {
                        Console.WriteLine("Insufficient balance.");
                    }
                }
            }
            else
            {
                Console.WriteLine("Invalid product code.");
            }
        }
    }
}
