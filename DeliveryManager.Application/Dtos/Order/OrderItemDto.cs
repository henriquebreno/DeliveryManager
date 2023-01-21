using DeliveryManager.Application.Dtos.Product;
using System;
using System.Collections.Generic;
using System.Text;

namespace DeliveryManager.Application.Dtos.Order
{
    public class OrderItemDto
    {
        public int Units { get;  set; }

        public long ProductId { get;  set; }
    }
}
