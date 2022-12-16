using DeliveryManager.Domain.Interfaces;
using DeliveryManager.Infra.Repositories;
using DeliveryManager.Infra.Repositories.EF;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace DeliveryManager.Infra.IoC
{
    public static class DependencyInjectionContainer
    {
        public static void AddServiceDependency(this IServiceCollection services) 
        {
            services.AddScoped<ICardapioRepository, CardapioRepository>();
            services.AddScoped<IClienteRepository, ClienteRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped(typeof(IBaseRepository<>),typeof(BaseRepository<>));
        }
    }
}
