using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DeliveryManager.Application.Dtos.Order
{
    public class UpdateOrderDto : OrderDto
    {
        [Required(ErrorMessage = "OrderId field is required")]
        public override long OrderId { get; set; }
    }
}
