using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DeliveryManager.Application.Dtos.Product
{
    public class MoneyDto
    {
        [Required(ErrorMessage = "Amount field is required")]
        [DisplayFormat(DataFormatString = "{0:C0}")]
        public decimal Amount { get; set; }


    }
}
