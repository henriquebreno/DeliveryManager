using DeliveryManager.Application.Dtos.Address;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DeliveryManager.Application.Dtos.Order
{
    public class OrderAddressDto : ClientAddressDto
    {
        [JsonIgnore]
        public override long AddressId { get; set; }
    }
}
