using System;
using System.Collections.Generic;
using System.Text;

namespace DeliveryManager.Domain.Interfaces
{
    public  interface IBaseRepository<TEntity> where TEntity : class,IAggregateRoot
    {
        void Add(TEntity obj);

        void Delete(TEntity obj);

        void Delete(long id);
        TEntity GetById(long id);

        IEnumerable<TEntity> Get();

        void Update(TEntity obj);
    }
}
