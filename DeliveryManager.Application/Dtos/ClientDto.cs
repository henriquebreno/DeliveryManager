using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using System.Text;

namespace DeliveryManager.Application.Dtos
{
    public class ClientDto
    {
        [Required(ErrorMessage = "Cpf is Required")]
        [MaxLength(11, ErrorMessage = "Máximo {0} de caracteres")]
        public string Cpf { get; set; }

        [Required(ErrorMessage = "Name is Required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Cellphone is Required")]
        public string Cellphone { get; set; }

        [Required(ErrorMessage = "BirthDate is Required")]
        public string BirthDate { get; set; }

        public IEnumerable<ClientAddressDto> ClientAddress { get; set; }
        public long ClientId { get; set; }
    }
}
