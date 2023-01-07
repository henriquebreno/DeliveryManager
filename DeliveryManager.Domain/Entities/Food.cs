using DeliveryManager.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DeliveryManager.Domain.Entities
{
    public class Food :Entity, IAggregateRoot
    {

        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Url { get; set; }

        public override void Validate()
        {
            throw new NotImplementedException();
        }
    }
}
