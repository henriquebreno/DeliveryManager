using System;
using System.Collections.Generic;
using System.Text;

namespace DeliveryManager.Application.Dtos.Product
{
    public class Money
    {
        public decimal Amount { get; set; }
        public Currency Currency { get; set; }
    }
}
