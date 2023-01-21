using System;
using System.Collections.Generic;
using System.Text;

namespace DeliveryManager.Domain.Entities
{
    public class OrderItem : Entity
    { 
    
        public int Units { get;private set; }

        public ProductItemOrdered ProductItemOrdered { get;private set; }

        public virtual Order Order { get; set; }

        public override void Validate()
        {
            throw new NotImplementedException();
        }

        public OrderItem(int units, ProductItemOrdered product)
        {
            Units = units;
            ProductItemOrdered = product;
        }

        public OrderItem() { }
    }
}
