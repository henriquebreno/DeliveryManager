using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DeliveryManager.Application.Dtos.Client
{
    public class UpdateClientDto : ClientDto
    {
        [Required(ErrorMessage = "Id field is required")]
        public override long ClientId { get; set; }
    }
}
