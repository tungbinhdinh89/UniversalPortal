using System;
using System.Collections.Generic;
using System.Text;
using UniversalPortal.Application.DTOs;

namespace UniversalPortal.Application.Interfaces
{
    public interface IStudentService
    {
        Task<List<StudentDTO>> GetStudentListAsync();

        Task<StudentDTO> AddStudentAsync(StudentDTO studentDTO);
    }
}
