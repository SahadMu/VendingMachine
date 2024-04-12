using System;
using System.Collections.Generic;

namespace VendingMachine
{
    class Program
    {
        static void Main(string[] args)
        {
            VendingMachineBrain vendingMachine = new VendingMachineBrain();

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
}
