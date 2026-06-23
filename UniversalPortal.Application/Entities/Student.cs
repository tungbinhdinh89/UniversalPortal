using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace UniversalPortal.Application.Entities
{
    public class Student
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(250)]
        public string FullName { get; set; } = null!;

        [Required]
        [MaxLength(250)]
        public string Email { get; set; } = null!;

        [Required]
        [MaxLength(9)]
        public string Code { get; set; } = null!;

        [MaxLength(250)]
        public string? Address { get; set; }
    }
};
