using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Data.Repositories;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using MediatR;
using Infrastructure.FileService;
using Application.Aggregates.Business.Mappings;

namespace Api.Configurations
{
    public static class DependencyInjectionConfigurations
    {
        public static IServiceCollection ConfigureServicesDI(this IServiceCollection services, IConfiguration configuration, IWebHostEnvironment hostEnvironment)
        {

            // AutoMapper
            services.AddAutoMapper(Assembly.GetAssembly(typeof(MappingProfile)));

            // Register repositories
            services.AddScoped<IAddressRepository, AddressRepository>();
           

            services.AddTransient<IFileStorageService, LocalStorageService>();

            services.AddScoped<Mediator>();

            return services;
        }
    }
}