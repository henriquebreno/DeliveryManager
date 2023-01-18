using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DeliveryManager.Domain.Interfaces
{
    public interface IBaseRepository<TEntity> where TEntity : class, IAggregateRoot
    {
        void Add(TEntity obj);

        void Delete(TEntity obj);

        void Delete(long id);
        TEntity GetById(long id);

        IEnumerable<TEntity> Get();

        void Update(TEntity obj);

        IQueryable<TEntity> Include(params Expression<Func<TEntity, object>>[] includes);
    }
}
