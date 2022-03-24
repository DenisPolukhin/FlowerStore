using FlowStoreBackend.Logic.Interfaces;
using FlowStoreBackend.Logic.Services;

namespace FlowStoreBackend.API.ApplicationStart
{
    public static class ConfigureServicesDependencyInjection
    {
        public static IServiceCollection AddOwnServices(this IServiceCollection services)
        {
            services.AddScoped<IJwtService, JwtService>();
            services.AddScoped<IUsersService, UsersService>();

            return services;
        }
    }
}
