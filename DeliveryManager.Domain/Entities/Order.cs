using DeliveryManager.Domain.Interfaces;
using DeliveryManager.Domain.ValueObject;
using System;
using System.Collections.Generic;
using System.Text;

namespace DeliveryManager.Domain.Entities
{
    public class Order :Entity, IAggregateRoot
    {
        public long ClientId { get; private set; }
        public DateTimeOffset OrderDate { get; private set; }
        public Address Address { get; private set; }

        public ICollection<OrderItem> OrderItems { get; private set; }


        public override void Validate()
        {
            throw new NotImplementedException();
        }
        public Order(long buyerId, Address address)
        {
            ClientId = buyerId;
            Address = address;
            OrderDate = DateTimeOffset.Now;
            this.OrderItems = new List<OrderItem>();
        }

        public void AddOrderItem(ProductItemOrdered productItemOrdered , int units) 
        {
            var orderItem = new OrderItem(units, productItemOrdered);
            OrderItems.Add(orderItem);
        }

        public Order()
        {
                    
        }
    }
}
