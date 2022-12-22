using DeliveryManager.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DeliveryManager.Infra.Repositories.EF
{
    public class UnitOfWork : IUnitOfWork
    {
        private DbContext _dbContext;

        public UnitOfWork(DbContext context) 
        {
            _dbContext = context;
        }
        public void Commit()
        {
            _dbContext.SaveChanges();
        }

        public void Rollback()
        {
            //
        }
    }
}
