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
            services.AddScoped<IFoodRepository, FoodRepository>();
            services.AddScoped<IClientRepository, ClientRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped(typeof(IBaseRepository<>),typeof(BaseRepository<>));
        }
    }
}
