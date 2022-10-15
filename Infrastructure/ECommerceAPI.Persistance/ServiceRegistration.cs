 using Microsoft.EntityFrameworkCore;
using ECommerceAPI.Persistance.Contexts;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using ECommerceAPI.Application.Repositories;
using ECommerceAPI.Persistance.Repositories;

namespace ECommerceAPI.Persistance
{
    public static class ServiceRegistration
    {

        public static void AddPersistenceServices(this IServiceCollection service)
        {

            service.AddScoped<ICustomerReadRepository, CustomerReadRepository>();
            service.AddScoped<ICustomerWriteRepository, CustomerWriteRepository>();
            service.AddScoped<IOrderReadRepository, OrderReadRepository>();
            service.AddScoped<IOrderWriteRepository, OrderWriteRepository>();
            service.AddScoped<IProductReadRepository, ProductReadRepository>();
            service.AddScoped<IProductWriteRepository, ProductWriteRepository>();

            service.AddDbContext<ECommerceAPIDbContext>(options => options.UseNpgsql(Configuration.getConnectionString()), ServiceLifetime.Scoped);
 
        }
    }
}
