using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DeliveryManager.Application.Dtos.Order
{
    public class OrderDto
    {
        [Required(ErrorMessage = "BuyerId field is required")]
        public long BuyerId { get;  set; }
        public OrderAddressDto OrderAddress { get;  set; }
        public List<OrderItemDto> OrderItems { get;  set; }
        public virtual long OrderId { get; set; }
    }
}
