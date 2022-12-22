using DeliveryManager.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DeliveryManager.Domain.Entities
{
    public class Food : IAggregateRoot
    {
       
        public decimal Price { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Url { get; set; }

        public int FoodId { get; set; }
    }
}
