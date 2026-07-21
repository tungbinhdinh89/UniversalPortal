using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using UniversalPortal.Application.Interfaces;

namespace UniversalPortal.Infra.Services
{
    public class TenantIdResolver : ITenantIdResolver
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private const string HeaderName = "X-Tenant-Id";

        public TenantIdResolver(IHttpContextAccessor httpContextAccessor)
            => _httpContextAccessor = httpContextAccessor;

        public Guid ResolveId()
        {
            var ctx = _httpContextAccessor.HttpContext;
            if (ctx == null)
                throw new InvalidOperationException("No active HttpContext to resolve tenant id.");

            if (!ctx.Request.Headers.TryGetValue(HeaderName, out var values) || string.IsNullOrWhiteSpace(values.FirstOrDefault()))
                throw new InvalidOperationException($"Missing or empty {HeaderName} header.");

            if (!Guid.TryParse(values.First(), out var tenantId))
                throw new InvalidOperationException("Invalid tenant id format in header.");

            return tenantId;
        }
    }
}
