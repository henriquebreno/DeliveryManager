using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DeliveryManager.Application.Dtos.Product
{
    public class UpdateProductDto : ProductDto
    {
        [Required(ErrorMessage = "ProductId field is required")]
        public override long ProductId { get; set; }
    }
}
