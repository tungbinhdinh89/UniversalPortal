using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using UniversalPortal.Application.Interfaces;
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
                var masterService = sp.GetRequiredService<IMasterService>();
                var tenantResolver = sp.GetRequiredService<ITenantIdResolver>();
                var tenant = masterService.GetTenantInfoAsync(tenantResolver.ResolveId()).GetAwaiter().GetResult();
                var appSettings = sp.GetRequiredService<IOptions<ApplicationSetting>>().Value;
                var connectionString = appSettings.ConnectionString.Replace("@@db", tenant.DbName) ?? null;
                options.UseSqlServer(connectionString);
            });
            return services;
        }

        // add master tenant setting
        public static IServiceCollection AddMasterTenantServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<MasterTenantSetting>(configuration.GetSection(MasterTenantSetting.SectionName));
            services.AddDbContext<MasterTenantDbContext>((sp, options) =>
            {
                var masterTenantSettings = sp.GetRequiredService<IOptions<MasterTenantSetting>>().Value;
                options.UseSqlServer(masterTenantSettings.ConnectionString);
            });
            return services;
        }
    }
}
