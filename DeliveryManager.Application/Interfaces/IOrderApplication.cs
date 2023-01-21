using DeliveryManager.Application.Dtos.Order;
using System;
using System.Collections.Generic;
using System.Text;

namespace DeliveryManager.Application.Interfaces
{
    public interface IOrderApplication
    {
        void CreateProduct(OrderDto orderDto);
    }
}
