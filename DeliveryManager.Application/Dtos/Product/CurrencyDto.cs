using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DeliveryManager.Application.Dtos.Product
{
    public class CurrencyDto
    {
        [Required(ErrorMessage = "Currency Name field is required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Currency Symbol field is required")]
        public string Symbol { get; set; }
    }
}
