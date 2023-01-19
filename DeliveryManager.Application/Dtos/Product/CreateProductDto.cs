using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace DeliveryManager.Application.Dtos.Product
{
    public class CreateProductDto : ProductDto
    {
        [JsonIgnore]
        public override long ProductId { get; set; }
    }
}
