using DatingApp.Interfaces.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace DatingApp.Repositories.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddRepositoryScopes(this IServiceCollection services)
        {
            services.AddScoped<IValueRepo, ValuesRepository>();
            services.AddScoped<IAuthRepository, AuthRepository>();
            services.AddScoped<IDatingRepository, DatingRepository>();
        }
    }
}
