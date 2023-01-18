using DeliveryManager.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DeliveryManager.Domain.Interfaces
{
    public interface IProductRepository : IBaseRepository<Product>, IAggregateRoot
    {
    }
}
