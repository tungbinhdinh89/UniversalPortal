using System;
using System.Collections.Generic;
using System.Text;
using UniversalPortal.Application.DTOs;

namespace UniversalPortal.Application.Interfaces
{
    public interface IMasterService

    {
        Task<MasterTenantDTO> GetTenantInfoAsync(Guid tenantId);
        
    }
}
