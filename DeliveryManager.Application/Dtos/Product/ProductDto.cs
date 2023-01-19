using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DeliveryManager.Application.Dtos.Product
{
    public class ProductDto
    {
        [Required(ErrorMessage = "Money field is required")]
        public MoneyDto Price { get; set; }

        [Required(ErrorMessage = "Name field is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Description field is required")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Url field is required")]
        public string Url { get; set; }

        public virtual long ProductId { get; set; }

    }
}
