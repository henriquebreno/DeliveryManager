using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DeliveryManager.Infra.Repositories.EF
{
    public class Contexto : DbContext
    {
        public Contexto() 
        {
            Database.EnsureCreated();
        }
    }
}
