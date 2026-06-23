using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using UniversalPortal.Application.Services;
using UniversalPortal.Infra.Db;

namespace UniversalPortal.Infra
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddInfraServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<ApplicationSetting>(configuration.GetSection(ApplicationSetting.SectionName));
            services.AddDbContext<ApplicationDbContext>((sp, options) =>
            {
                var appSettings = sp.GetRequiredService<IOptions<ApplicationSetting>>().Value;
                options.UseSqlServer(appSettings.ConnectionString);
            });
            return services;
        }
    }
}
