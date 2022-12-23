using DeliveryManager.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DeliveryManager.Infra.Repositories.EF
{
    public class UnitOfWork : IUnitOfWork
    {
        private Context _dbContext;

        public UnitOfWork(Context context) 
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
