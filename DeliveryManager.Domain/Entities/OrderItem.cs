using System;
using System.Collections.Generic;
using System.Text;

namespace DeliveryManager.Domain.Entities
{
    public class OrderItem : Entity
    { 
    
        public string Quantity { get; set; }

        public Product Product { get; set; }

        public override void Validate()
        {
            throw new NotImplementedException();
        }

       
    }
}
