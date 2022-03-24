using FlowStoreBackend.Database.Models;
using FlowStoreBackend.Database.Models.Entities;
using FlowStoreBackend.Logic.Validators.User;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace FlowStoreBackend.API.ApplicationStart
{
    public static class ConfigureServicesGeneral
    {
        public static IServiceCollection AddGeneralServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddControllers()
                .AddFluentValidation(conf => conf.RegisterValidatorsFromAssemblyContaining(typeof(LogInModelValidator)));
            services.AddEndpointsApiExplorer();
            services.AddDbContextFactory<DatabaseContext>(options => options.UseNpgsql(configuration
                .GetConnectionString("DefaultConnection"), opt => opt.UseNodaTime()), ServiceLifetime.Scoped);
            services.AddIdentity<User, IdentityRole<Guid>>(options =>
            {
                options.User.AllowedUserNameCharacters = null;
                options.User.RequireUniqueEmail = true;
                options.Password.RequireNonAlphanumeric = false;
            })
                .AddEntityFrameworkStores<DatabaseContext>();

            return services;
        }
    }
}
