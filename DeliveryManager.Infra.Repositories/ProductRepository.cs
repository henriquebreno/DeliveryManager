using DeliveryManager.Domain.Entities;
using DeliveryManager.Domain.Interfaces;
using DeliveryManager.Infra.Repositories.EF;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;


namespace DeliveryManager.Infra.Repositories
{
    public class ProductRepository: BaseRepository<Product>,IProductRepository
    {
        public ProductRepository(Context context) : base(context)
        {
            

        }
    }
}
