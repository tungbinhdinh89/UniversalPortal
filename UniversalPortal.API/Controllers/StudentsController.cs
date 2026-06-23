using Microsoft.AspNetCore.Mvc;
using UniversalPortal.Application.DTOs;
using UniversalPortal.Application.Interfaces;

namespace UniversalPortal.API.Controllers
{
        [ApiController]
        [Route("api/[controller]")] // http://localhost:5000/api/students
        public class StudentsController(IStudentService studentService) : ControllerBase
        {
            [HttpGet]
            public async Task<IActionResult> GetAllStudents()
            {
                var students = await studentService.GetStudentListAsync();
                return Ok(students);
            }

            [HttpPost]
            public async Task<IActionResult> AddStudent([FromBody] StudentDTO studentDTO)
            {
                if(!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var addedStudent = await studentService.AddStudentAsync(studentDTO);
                return CreatedAtAction(nameof(GetAllStudents), new { id = addedStudent.Id }, addedStudent);
            }
        }
}
