using System;
using System.Collections.Generic;
using System.Text;

namespace DeliveryManager.Domain.Interfaces
{
    public interface IUnitOfWork
    {
        void Rollback();

        void Commit();
    }
}
