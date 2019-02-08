using DatingApp.Interfaces.Services;
using Microsoft.Extensions.DependencyInjection;

namespace DatingApp.Services.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddServiceScopes(this IServiceCollection services)
        {
            services.AddScoped<IPhotoService, PhotoService>();
            services.AddScoped<IValueService, ValuesService>();
        }
    }

}
