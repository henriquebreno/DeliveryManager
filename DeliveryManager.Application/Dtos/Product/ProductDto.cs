using System;
using System.Collections.Generic;
using System.Text;

namespace DeliveryManager.Application.Dtos.Product
{
    public class ProductDto
    {
        public Money Price { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Url { get; set; }

        public virtual long ProductId { get; set; }

    }
}
