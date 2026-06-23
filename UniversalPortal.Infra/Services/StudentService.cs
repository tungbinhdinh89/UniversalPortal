using System;
using System.Collections.Generic;
using System.Text;
using UniversalPortal.Application.DTOs;
using UniversalPortal.Application.Interfaces;
using UniversalPortal.Infra.Db;
using Microsoft.EntityFrameworkCore;
using UniversalPortal.Application.Entities;

namespace UniversalPortal.Infra.Services
{
    public class StudentService(ApplicationDbContext dbContext) : IStudentService
    {
        public async Task<List<StudentDTO>> GetStudentListAsync()
        {
            var students = await dbContext.Students
                .Select(s => new StudentDTO
                {
                    Id = s.Id,
                    FullName = s.FullName,
                    Email = s.Email,
                    Code = s.Code,
                    Address = s.Address
                })
                .ToListAsync();

            return students;
        }

        public async Task<StudentDTO> GetStudentAsync(int id)
        {
            var student = await dbContext.Students
                .Where(s => s.Id == id)
                .Select(x => new StudentDTO())
                .FirstOrDefaultAsync();

            return student;
        }

        public async Task<StudentDTO> AddStudentAsync(StudentDTO studentDTO)
        {
            var newStudent = new Student
            {
                FullName = studentDTO.FullName,
                Email = studentDTO.Email,
                Code = studentDTO.Code,
                Address = studentDTO.Address
            };

            await dbContext.Students.AddAsync(newStudent);
            await dbContext.SaveChangesAsync();

            studentDTO.Id = newStudent.Id;

            return studentDTO;
        }
    }
}
