using System;
using System.Collections.Generic;
using System.Text;

namespace DeliveryManager.Domain.Interfaces
{
    public  interface IBaseRepository<TEntity> where TEntity : class
    {
        void Add(TEntity obj);

        void Delete(TEntity obj);

        void Delete(int id);
        TEntity GetById(int id);

        IEnumerable<TEntity> Get();

        void Update(TEntity obj);
    }
}
