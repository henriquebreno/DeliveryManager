using System;
using System.Collections.Generic;
using System.Linq;
using DeliveryManager.Domain.Interfaces;
using DeliveryManager.Infra.Repositories.EF;
using Microsoft.EntityFrameworkCore;

namespace DeliveryManager.Infra.Repositories
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class , IAggregateRoot
    {
        protected Context _contexto;
        protected DbSet<TEntity> dbSet;
        
        public BaseRepository(Context context)
        {
            _contexto = context;
            dbSet = _contexto.Set<TEntity>();
        }
        public void Add(TEntity obj)
        {
            dbSet.Add(obj);
        }

        public void Delete(TEntity obj)
        {
            dbSet.Remove(obj);

        }

        public void Delete(int id)
        {
            var obj = GetById(id);
            Delete(obj);
        }

        public IEnumerable<TEntity> Get()
        {
            return dbSet.ToList();
        }

        public TEntity GetById(int id)
        {
            return dbSet.Find(id);
        }

        public void Update(TEntity obj)
        {
            _contexto.Entry(obj).State = EntityState.Modified;
        }
    }
}
