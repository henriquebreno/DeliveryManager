using DeliveryManager.Application.Dtos.Product;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DeliveryManager.Application.Dtos.Order
{
    public class OrderItemDto
    {
        [Required(ErrorMessage = "Units quantity field is required")]
        public int Units { get;  set; }

        [Required(ErrorMessage = "ProductId field is required")]
        public long ProductId { get;  set; }
    }
}
