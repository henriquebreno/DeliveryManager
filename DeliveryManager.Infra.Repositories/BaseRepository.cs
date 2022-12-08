using System;
using System.Collections.Generic;
using System.Linq;
using DeliveryManager.Domain.Interfaces;
using DeliveryManager.Infra.Repositories.EF;
using Microsoft.EntityFrameworkCore;

namespace DeliveryManager.Infra.Repositories
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        private Contexto _contexto;

        public BaseRepository()
        {
            //_contexto = new Contexto();
        }
        public void Add(TEntity obj)
        {
            _contexto.Set<TEntity>().Add(obj);
        }

        public void Delete(TEntity obj)
        {
            _contexto.Set<TEntity>().Remove(obj);

        }

        public void Delete(int id)
        {
            var obj = GetById(id);
            Delete(obj);
        }

        public IEnumerable<TEntity> Get()
        {
            return _contexto.Set<TEntity>().ToList();
        }

        public TEntity GetById(int id)
        {
            return _contexto.Set<TEntity>().Find(id);
        }

        public void Update(TEntity obj)
        {
            _contexto.Entry(obj).State = EntityState.Modified;
        }
    }
}
