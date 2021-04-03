using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace HRM.ERP.Data.Helpers
{
    public static class ServicesExtensionHelper
    {
        public static IServiceCollection RegisterDataServices(this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(d =>
                d.UseSqlite(configuration.GetConnectionString("ERPDatabase")));
            // options.UseSqlite(Configuration.GetConnectionString("WebApiDatabase"));
            services.AddAutoMapper(typeof(ServicesExtensionHelper));

            return services;
        }
    }
}
