using Microsoft.EntityFrameworkCore;
using UniversalPortal.Application.DTOs;
using UniversalPortal.Application.Interfaces;
using UniversalPortal.Infra.Db;

namespace UniversalPortal.Infra.Services
{
    public class MasterService(MasterTenantDbContext masterDbContext) : IMasterService
    {
        public async Task<MasterTenantDTO> GetTenantInfoAsync(Guid tenantId)
        {
            var masterTenant = await masterDbContext.MasterTenants.FirstOrDefaultAsync(t => t.TenantId == tenantId);

            if (masterTenant == null)
                throw new InvalidOperationException("Tenant not found");

            return new MasterTenantDTO
            {
                TenantName = masterTenant.TenantName,
                TenantCode = masterTenant.TenantCode,
                DbName = masterTenant.DbName
            };
        }
    }
}
