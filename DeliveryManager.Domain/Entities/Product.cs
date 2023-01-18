using DeliveryManager.Domain.Interfaces;
using DeliveryManager.Domain.ValueObject;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DeliveryManager.Domain.Entities
{
    public class Product :Entity, IAggregateRoot
    {

		protected Product()
		{
		}

        public Product(Money price,string name,string description,string url)
        {
            Price = price;
            Name = name;
            Description = description;
            Url = url;
        }

        public Money Price { get;  set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Url { get; set; }


        public override void Validate()
        {
            throw new NotImplementedException();
        }
    }
}
