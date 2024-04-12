using System;
using Xunit;
using NSubstitute;

namespace VendingMachine.Tests
{
    public class VendingMachineTests
    {
        [Fact]
        public void PurchaseProduct_WithChange_ShouldProvideChange()
        {
            // Arrange
            var product = new Product { Code = "A1", Description = "Coke", Price = 1.5, Quantity = 1 };
            var vendingMachine = new VendingMachineBrain();
            vendingMachine.InsertCoin(2.0); // Insert more than the product price

            // Act
            vendingMachine.PurchaseProduct(product.Code);

            // Assert
            Assert.Equal(0.5, vendingMachine.userBalance); // User balance should be the change provided
        }
    }
}
