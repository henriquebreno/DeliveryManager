using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace DeliveryManager.Application.Dtos.Address
{
    public class CreateClientAddressDto : ClientAddressDto
    {
        [JsonIgnore]
        public override long AddressId { get; set; }
    }
}
