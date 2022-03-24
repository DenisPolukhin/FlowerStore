using FlowStoreBackend.Logic.Profiles.User;

namespace FlowStoreBackend.API.ApplicationStart
{
    public static class ConfigureServicesAutomapper
    {
        public static IServiceCollection AddAutoMapperServices(this IServiceCollection services)
        {
            services.AddAutoMapper(config =>
            {
                config.AddProfile<UserProfile>();
            });

            return services;
        }
    }
}
