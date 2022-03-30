using FlowStoreBackend.Logic.Profiles;

namespace FlowStoreBackend.API.ApplicationStart
{
    public static class ConfigureServicesAutomapper
    {
        public static IServiceCollection AddAutoMapperServices(this IServiceCollection services)
        {
            services.AddAutoMapper(config =>
            {
                config.AddProfile<UserProfile>();
                config.AddProfile<ProductProfile>();
                config.AddProfile<CategoryProfile>();
            });

            return services;
        }
    }
}
