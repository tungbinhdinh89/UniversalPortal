using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using UniversalPortal.Application.Entities;
using UniversalPortal.Application.MasterTenant.Entities;

namespace UniversalPortal.Infra.Db
{
    public class MasterTenantConfiguration : IEntityTypeConfiguration<MasterTenant>
    {
        public void Configure(EntityTypeBuilder<MasterTenant> builder)
        {
            builder.HasKey(x => x.TenantId);
            builder.HasIndex(x => x.TenantName).IsUnique().HasDatabaseName("IX_Tenant_Name");
            builder.HasIndex(x => x.TenantCode).IsUnique().HasDatabaseName("IX_Tenant_Code");
            builder.HasIndex(x => x.DbName).IsUnique().HasDatabaseName("IX_Tenant_DbName");
        }
    }
}
