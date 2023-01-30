using DeliveryManager.Application.Dtos.Address;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Text;

namespace DeliveryManager.Application.Dtos.Client
{
    public class ClientDto
    {

        [Required(ErrorMessage = "Cpf field is required")]
        public string Cpf { get; set; }

        [Required(ErrorMessage = "FirstName field is required")]
        [RegularExpression(@"^[a-zA-Z''-'\s]{1,40}$",
         ErrorMessage = "Characters are not allowed.")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "Email field is required")]
        public string Email { get; set; }

        [Required(ErrorMessage = "BirthDate field is required")]
        [RegularExpression(@"^([012]\d|30|31)/(0\d|10|11|12)/\d{4}$",
         ErrorMessage = "BirthDate pattern: dd/MM/YYYY")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public string BirthDate { get; set; }

        [Required(ErrorMessage = "Cellphone field is required")]
        [RegularExpression(@"^1\d\d(\d\d)?$|^0800 ?\d{3} ?\d{4}$|^(\(0?([1-9a-zA-Z][0-9a-zA-Z])?[1-9]\d\) ?|0?([1-9a-zA-Z][0-9a-zA-Z])?[1-9]\d[ .-]?)?(9|9[ .-])?[2-9]\d{3}[ .-]?\d{4}$",
         ErrorMessage = "Cellphone pattern: (ddd) XXXXX-XXXX")]
        public string Cellphone { get; set; }
        
        public List<ClientAddressDto> ClientAddress { get; protected set; }

        public virtual long ClientId { get;  set; }
    }
}
