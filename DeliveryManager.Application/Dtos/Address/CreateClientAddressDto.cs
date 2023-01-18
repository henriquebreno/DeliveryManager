using System;
using System.Collections.Generic;
using System.Text;

namespace DeliveryManager.Application.Dtos.Address
{
    public class CreateClientAddressDto : ClientAddressDto
    {
        public override long AddressId { get; set; }
    }
}
