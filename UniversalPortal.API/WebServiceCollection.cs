using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using UniversalPortal.Application.DTOs;
using UniversalPortal.Application.Interfaces;
using UniversalPortal.Application.Services;
using UniversalPortal.Infra.Db;
using UniversalPortal.Infra.Services;

namespace UniversalPortal.API
{
    public static class WebServiceCollection
    {
        public static IServiceCollection AddWebServices(this IServiceCollection services, IConfiguration configuration)
        {
            // HTTP context for resolving tenant id from request headers
            services.AddHttpContextAccessor();

            // tenant resolver (reads X-Tenant-Id header)
            services.AddScoped<ITenantIdResolver, TenantIdResolver>();

            // application services used by web layer
            services.AddScoped<IStudentService, StudentService>();
            services.AddScoped<IMasterService, MasterService>();
            services.AddScoped<MyStore>();

            return services;
        }
    }
}
