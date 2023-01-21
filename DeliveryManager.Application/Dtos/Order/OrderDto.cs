using System;
using System.Collections.Generic;
using System.Text;

namespace DeliveryManager.Application.Dtos.Order
{
    public class OrderDto
    {
        public long BuyerId { get;  set; }
        public OrderAddressDto OrderAddress { get;  set; }
        public List<OrderItemDto> OrderItems { get;  set; }
    }
}
