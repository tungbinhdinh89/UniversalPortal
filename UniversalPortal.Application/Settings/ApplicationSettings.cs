using System;
using System.Collections.Generic;
using System.Text;

namespace UniversalPortal.Application.Services
{
    public class ApplicationSetting
    {
        public const string SectionName = "ApplicationSetting";

        public string? ConnectionString { get; set; }
    }
}
