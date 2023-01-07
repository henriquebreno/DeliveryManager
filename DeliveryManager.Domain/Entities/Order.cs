using DeliveryManager.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DeliveryManager.Domain.Entities
{
    public class Order :Entity, IAggregateRoot
    {

        public override void Validate()
        {
            throw new NotImplementedException();
        }
    }
}
