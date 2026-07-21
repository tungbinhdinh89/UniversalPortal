using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace UniversalPortal.Application.MasterTenant.Entities
{
   public class MasterTenant
    {
        public Guid TenantId { get; set; }
        [Required]
        [MaxLength(100)]
        public string TenantName { get; set; } = null!;
        [Required]
        [MaxLength(50)]
        public string TenantCode { get; set; } = null!;
    }
}
