using Microsoft.EntityFrameworkCore;
using ECommerceAPI.Persistance.Contexts;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace ECommerceAPI.Persistance
{
    public static class ServiceRegistration
    {

        public static void AddPersistenceServices(this IServiceCollection service)
        {
            ConfigurationManager configurationManager = new ConfigurationManager();
            configurationManager.SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../../Presentation/ECommerceAPI.API"));
            configurationManager.AddJsonFile("appsettings.json");

            service.AddDbContext<ECommerceAPIDbContext>(options => options.UseNpgsql(configurationManager.GetConnectionString("PostgreSQL")));
        }
    }
}
