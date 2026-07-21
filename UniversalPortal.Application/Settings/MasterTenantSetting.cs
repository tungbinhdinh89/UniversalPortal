using System;
using System.Collections.Generic;
using System.Text;

namespace UniversalPortal.Application.Services
{
    public class MasterTenantSetting
    {
        public const string SectionName = "MasterTenantSetting";

        public string? ConnectionString { get; set; }
    }
}
