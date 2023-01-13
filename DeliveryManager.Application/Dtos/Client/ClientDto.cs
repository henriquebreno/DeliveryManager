using DeliveryManager.Application.Dtos.Address;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DeliveryManager.Application.Dtos.Client
{
    public class ClientDto
    {

        [Required(ErrorMessage = "Cpf field is required")]
        public string Cpf { get; set; }

        [Required(ErrorMessage = "FirstName field is required")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "LastName field is required")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Email field is required")]
        public string Email { get; set; }

        [Required(ErrorMessage = "BirthDate field is required")]
        public string BirthDate { get; set; }

        [Required(ErrorMessage = "Cellphone field is required")]
        public string Cellphone { get; set; }
        
        public List<ClientAddressDto> ClientAddress { get; protected set; }

        public virtual long ClientId { get;  set; }
    }
}
