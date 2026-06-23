using System;
using System.Collections.Generic;
using System.Text;

namespace UniversalPortal.Application.DTOs
{
    public class StudentDTO
    {
        public int Id { get; set; }
        public string FullName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Code { get; set; } = null!;
        public string? Address { get; set; }
    }
}
