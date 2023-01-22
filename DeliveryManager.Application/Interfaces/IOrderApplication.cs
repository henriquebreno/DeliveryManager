using DeliveryManager.Application.Dtos.Order;
using System;
using System.Collections.Generic;
using System.Text;

namespace DeliveryManager.Application.Interfaces
{
    public interface IOrderApplication
    {
        void CreateOrder(OrderDto orderDto);

        List<OrderDto> GetAll();

        OrderDto GetOrder(long orderId);

        void DeleteOrder(long orderId);

        void UpdateOrder(OrderDto orderDto, long orderId);
    }
}
