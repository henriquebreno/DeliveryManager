using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DeliveryManager.Application.Dtos.Client
{
    public class CreateClientDto : ClientDto
    {
        [JsonIgnore]
        public override long ClientId { get;  set; }
    }
}
