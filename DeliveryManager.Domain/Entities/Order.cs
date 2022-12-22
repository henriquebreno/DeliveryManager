using DeliveryManager.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DeliveryManager.Domain.Entities
{
    public class Order : IAggregateRoot
    {
        public int OrderId { get; set; }


    }
}
