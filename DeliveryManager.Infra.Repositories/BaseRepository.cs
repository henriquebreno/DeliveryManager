using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using DeliveryManager.Domain.Interfaces;
using DeliveryManager.Infra.Repositories.EF;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

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

        public void Delete(long id)
        {
            var obj = GetById(id);
            Delete(obj);
        }

        public IEnumerable<TEntity> Get()
        {
            return dbSet.ToList();
        }

        public TEntity GetById(long id)
        {          
            //var includeArray = new List<string>();
            //foreach (PropertyInfo property in this.GetType().GetProperties())
            //{                             
            //    if (property.PropertyType is ICollection<object>)
            //    {
            //        includeArray.Add(property.Name);
            //    }
            //}
            //if (includeArray.Count > 0) 
            //{
            //    IncludeMultiple(includeArray.ToArray());
            //}
            return dbSet.Find(id);
        }

        public void Update(TEntity obj)
        {
            dbSet.Attach(obj);
            _contexto.Entry(obj).State = EntityState.Modified;
        }

        public IQueryable<TEntity> Include(params Expression<Func<TEntity, object>>[] includes)
        {
            IIncludableQueryable<TEntity, object> query = null;

            if (includes.Length > 0)
            {
                query = dbSet.Include(includes[0]);
            }
            for (int queryIndex = 1; queryIndex < includes.Length; ++queryIndex)
            {
                query = query.Include(includes[queryIndex]);
            }

            return query == null ? dbSet : (IQueryable<TEntity>)query;
        }


        public IQueryable<TEntity> GetAll(params Expression<Func<TEntity, object>>[] includeExpressions)
        {
            IQueryable<TEntity> set = dbSet;

            foreach (var includeExpression in includeExpressions)
            {
                set = set.Include(includeExpression);
            }
            return set;
        }

        //public TEntity ada(int ID, params string[] includes)
        //{
        //    var blog = context.Blogs
        //        .Where(x => x.BlogId == id)
        //        .IncludeMultiple(includes)
        //        .FirstOrDefault();
        //    return blog;
        //}
        //internal static IQueryable<T> IncludeMultiple<T>(this IQueryable<T> query,params string[] includes) where T : class
        //{
        //    if (includes != null)
        //    {
        //        query = includes.Aggregate(query, (current, include) => current.Include(include));
        //    }
        //    return query;
        //}

        //public TEntity GetById(int id, Func<IQueryable<TEntity>, IIncludableQueryable<TEntity, object>> includes = null)
        //{
        //    IQueryable<TEntity> queryable = dbSet;

        //    if (includes != null)
        //    {
        //        queryable = includes(queryable);
        //    }

        //    return queryable.FirstOrDefault(x => x as Entity    == id);
        //}
    }
}
