using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using UniversalPortal.Application.MasterTenant.Entities;

namespace UniversalPortal.Infra.Db
{
    public class MasterTenantDbContext(DbContextOptions<MasterTenantDbContext> options) : DbContext(options)
    {
        public DbSet<MasterTenant> DbSet { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new MasterTenantConfiguration());
            base.OnModelCreating(modelBuilder);
        }
    }
}
