using fazyup.api.Feature.User;

namespace fazyup.api.Shared.Ioc
{
    public static class ServicesInjection
    {
        public static IServiceCollection AddServicesInjection(
            this IServiceCollection services,
            IConfiguration configuration)
        {
            services.AddDatabase(configuration);
            services.AddAuth(configuration);

            services.AddScoped<TokenService>();

            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();

            return services;
        }
    }
}
