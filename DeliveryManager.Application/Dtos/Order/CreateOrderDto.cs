using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace DeliveryManager.Application.Dtos.Order
{
    public class CreateOrderDto : OrderDto
    {
        [JsonIgnore]
        public override long OrderId { get; set; }
    }
}
