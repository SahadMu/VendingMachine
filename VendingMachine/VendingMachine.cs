namespace VendingMachine
{
    public class VendingMachineBrain
    {
        private List<Product> products;
        public double userBalance { get; private set; }
        private double machineFloat;

        public VendingMachineBrain()
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
                if (product.Quantity > 0 && userBalance >= product.Price)
                {
                    Console.WriteLine($"Dispensing {product.Description}...");
                    product.Quantity--;
                    userBalance -= product.Price;

                    // Provide change if necessary
                    double change = userBalance;
                    if (change > 0)
                    {
                        Console.WriteLine($"Change available: £{change}");
                        Console.WriteLine("Do you want to dispense change (1) or purchase another item (2)?");
                        string choice = Console.ReadLine();
                        switch (choice)
                        {
                            case "1":
                                Console.WriteLine($"Dispensing change: £{change}");
                                userBalance = 0;
                                break;
                            case "2":
                                Console.WriteLine("Continuing with the purchase...");
                                break;
                            default:
                                Console.WriteLine("Invalid choice. Continuing with the purchase...");
                                break;
                        }
                    }
                    Console.WriteLine($"Remaining balance: £{userBalance}");
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
