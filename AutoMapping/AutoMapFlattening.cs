/*
When you configure a source/destination type pair in AutoMapper, 
the configurator attempts to match properties and methods on the
source type to properties on the destination type. If for any 
property on the destination type a property, method, or a method
prefixed with “Get” does not exist on the source type, AutoMapper
splits the destination member name into individual words (by PascalCase conventions).
*/

using System.Collections.Generic;
using System.Linq;
using AutoMapper;


namespace AutoMapping
{
    public class Order
    {
        private readonly IList<OrderLineItem> _orderLineItems = new List<OrderLineItem>();

        public Customer Customer { get; set; }

        public void AddOrderLineItem(Product product, int quantity)
        {
            _orderLineItems.Add(new OrderLineItem(product, quantity));
        }

        public decimal GetTotal()
        {
            return _orderLineItems.Sum(li => li.GetTotal());
        }
    }

    public class Product
    {
        public decimal Price { get; set; }

        public string Name { get; set; }
    }

    public class Customer
    {
        public string Name { get; set; }
    }

    public class OrderLineItem
    {
        public Product Product { get; set; }

        public int Quantity { get; set; }

        public OrderLineItem(Product product, int quantity)
        {
            Product = product;
            Quantity = quantity;
        }

        public decimal GetTotal()
        {
            return Quantity * Product.Price;
        }
    }

    public class OrderDto
    {
        // Match the class "Customer" and the property "Name", so it maps the CustomerName of this class to the property "Name" of the class "Customer"
        // So when mapping from Order to OrderDto, it can mapped automatically
        public string CustomerName { get; set; }

        // The class Order has the method prefixed with "Get"      
        public decimal Total { get; set; }
    }

    public class AutoMapFlattening
    {
        public OrderDto Map(Order order)
        {
            // Configure AutoMapper
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Order, OrderDto>());
            var iMapper = config.CreateMapper();

            //Perform mapping
            OrderDto dto = iMapper.Map<Order, OrderDto>(order);

            return dto;
        }
    }
}
