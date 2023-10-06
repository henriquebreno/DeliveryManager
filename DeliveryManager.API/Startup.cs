using AutoMapper;
using DeliveryManager.API.AutoMapper;
using DeliveryManager.API.Models.User;
using DeliveryManager.Application.Dtos;
using DeliveryManager.Infra.IoC;
using DeliveryManager.Infra.Repositories.EF;
using DeliveryManager.Infra.Repositories.Identity;
using FluentValidation;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryManager.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddIdentity<ApplicationUser, ApplicationRole>()
            .AddEntityFrameworkStores<Context>()
            .AddDefaultTokenProviders();

            services.AddDbContext<Context>
               (optionsAction: options => options.UseSqlServer
               (Configuration.GetConnectionString("DefaultConnection")));

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddValidatorsFromAssemblyContaining<Startup>();

            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new Swashbuckle.AspNetCore.Swagger.Info
                {
                    Title = "Place Info Service API",
                    Version = "v1",
                    Description = "Sample service for Learner",
                });
            });

            // Configuração de autenticação
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidIssuer = "seu-emissor",
                    ValidAudience = "sua-audiencia",
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("sua-chave-secreta"))
                };
            });

            // In production, the React files will be served from this directory
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/build";
            });

            services.AddServiceDependency();
            services.AddAutoMapper(typeof(MappingProfile));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(options => {
                    options.SwaggerEndpoint("/swagger/v1/swagger.json", "PlaceInfo Services");
                    options.DefaultModelsExpandDepth(-1); // Disable swagger schemas at bottom                
                });
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseAuthentication(); // Adicione esta linha
            app.UseHttpsRedirection();
            app.UseMvc();
        }


    }
}
