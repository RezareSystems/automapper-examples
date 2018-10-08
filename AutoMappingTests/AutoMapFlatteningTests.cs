using AutoMapping;
using FluentAssertions;
using Xunit;

namespace AutoMappingTests
{
    public class AutoMapFlatteningTests
    {
        [Fact]
        public void Map_FromOrderToOrderDto_ReturnExpected()
        {
            // Arrange
            var customer = new Customer
            {
                Name = "Mr Unknown"
            };

            var order = new Order
            {
                Customer = customer
            };

            var bosco = new Product
            {
                Name ="Bosco",
                //The decimal suffix is M/m since D/d was already taken by double.
                //Although it has been suggested that M stands for money, Peter Golde recalls that M was chosen simply as the next best letter in decimal.
                Price = 4.99m
            };

            var quantity = 15;
            order.AddOrderLineItem(bosco, quantity);

            var autoMapperFlatting = new AutoMapFlattening();

            // Act
            var dto = autoMapperFlatting.Map(order);

            // Assert
            dto.CustomerName.Should().Be("Mr Unknown");
            dto.Total.Should().Be(74.85m);
        }
    }
}
