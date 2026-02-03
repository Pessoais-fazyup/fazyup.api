using fazyup.api.Database;
using Microsoft.EntityFrameworkCore;

namespace fazyup.api.Shared.Ioc
{
    public static class DataInjection
    {
        public static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<FazyupDbContext>(options =>
                options.UseNpgsql(configuration.GetConnectionString("Default")));

            return services;
        }
    }
}