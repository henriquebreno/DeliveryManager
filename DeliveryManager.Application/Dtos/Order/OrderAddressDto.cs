using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DeliveryManager.Application.Dtos.Order
{
    public class OrderAddressDto
    {
        [Required(ErrorMessage = "Street field is required")]
        public String Street { get; set; }
        [Required(ErrorMessage = "City field is required")]
        public String City { get; set; }
        [Required(ErrorMessage = "State field is required")]
        public String State { get; set; }
        [Required(ErrorMessage = "Country field is required")]
        public String Country { get; set; }
        [Required(ErrorMessage = "ZipCode field is required")]
        public String ZipCode { get; set; }
    }
}
