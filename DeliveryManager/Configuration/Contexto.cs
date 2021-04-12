using DeliveryManager.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DeliveryManager.Configuration
{
    public class Contexto : DbContext
    {
        public Contexto(DbContextOptions<Contexto> options) : base(options) 
        {
            Database.EnsureCreated();
        }

        public DbSet<Cliente> Cliente { get; set; } 

        public DbSet<DeliveryManager.Model.Endereco> Endereco { get; set; }

        public DbSet<DeliveryManager.Model.Cardapio> Cardapio { get; set; }
    }
}
