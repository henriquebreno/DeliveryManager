using System;
using System.Collections.Generic;
using System.Text;

namespace DeliveryManager.Domain
{
    public abstract class Entity
    {
        public long Id { get; protected set; }

        public abstract void Validate();
    }
}
