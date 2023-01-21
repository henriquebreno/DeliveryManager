using DeliveryManager.Domain.ValueObject;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DeliveryManager.Domain.Entities
{
    public class ProductItemOrdered :  Entity
    {
        public ProductItemOrdered()
        {
        }

        public ProductItemOrdered(decimal unitPrice, string name, string description)
        {
            UnitPrice = unitPrice;
            Name = name;
            Description = description;
        }
        public long OrderItemId { get; set; }

        [ForeignKey("OrderItemId")]
        public OrderItem OrderItem { get; private set; }


        [Column(TypeName = "decimal(18,2)")]
        public decimal UnitPrice { get; private set; }

        public string Name { get; private set; }

        public string Description { get; private set; }



        public override void Validate()
        {
            throw new NotImplementedException();
        }

        //public void UpdateProduct(Product product)
        //{
        //    Description = product.Description;
        //    Name = product.Name;
        //    Url = product.Url;
        //    Price = product.Price;
        //}

        //public bool IsValidAmount(decimal amount)
        //{
        //    return amount > 0;
        //}
    }
}
