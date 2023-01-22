using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DeliveryManager.Application.Dtos.Address
{
    public class ClientAddressDto
    {
        [Required(ErrorMessage = "Street field is required")]
        public String Street { get; set; }

        [RegularExpression(@"^[0-9]*$",
         ErrorMessage = "Number Address just accept numbers")]
        public String Number { get; set; }

        [Required(ErrorMessage = "Complement field is required")]
        public String Complement { get; set; }

        [Required(ErrorMessage = "District field is required")]
        public String District { get; set; }

        [Required(ErrorMessage = "City field is required")]
        public String City { get; set; }

        [Required(ErrorMessage = "State field is required")]
        public String State { get; set; }

        [Required(ErrorMessage = "ZipCode field is required")]
        public String ZipCode { get; set; }

        public virtual long AddressId { get; set; }
    }
}
