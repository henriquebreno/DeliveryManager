using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DeliveryManager.Application.Dtos.Address
{
    public class UpdateClientAddressDto : ClientAddressDto
    {
        [Required(ErrorMessage = "AddressId field is required")]
        public override long AddressId { get; set; }
    }
}
