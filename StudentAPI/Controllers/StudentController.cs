using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shared;
using StudentAPI.IServices;

namespace StudentAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _studentService;
        public StudentController(IStudentService studentService) 
        {
            _studentService = studentService;
        }

        [HttpGet]
        public async Task<ActionResult> GetStudents()
        {
            try
            {
                return Ok(await _studentService.GetStudents());
            }
            catch (Exception ex) 
            {
                return StatusCode(500, "Loi lay du lieu tu DB");
            }
            
        }
        [HttpGet("id")]
        public async Task<ActionResult<Student>> GetStudentById(int id)
        {
            try
            {
                var result = await _studentService.GetStudent(id);
                if (result == null)
                {
                    return NotFound();
                }
                else
                {
                    return result;
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Loi lay du lieu tu DB");
            }
        }

        [HttpPost]
        public async Task<ActionResult<Student>> CreateNewStudent(Student student)
        {
            try
            {
                // neeu du lieu ko co
                if (student == null)
                {
                    return BadRequest();
                }
                else
                {
                    var newStudent = await _studentService.AddStudent(student);
                    return CreatedAtAction(nameof(GetStudentById), new { id = newStudent.Id }, newStudent);
                }     
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Loi lay du lieu tu DB");
            }
        }

        [HttpDelete("id")]
        public async Task<ActionResult<Student>> DeleteStudent(int id)
        {
            try
            {
                var deletedstudent = await _studentService.DeleteStudent(id);
                if(deletedstudent == null)
                {
                    return NotFound($"Student co id {id} khong tim thay");
                }
                else
                {
                    return await _studentService.DeleteStudent(id);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Loi lay du lieu tu DB");
            }
        }

        [HttpPut]
        public async Task<ActionResult<Student>> UpdateStudent(Student student)
        {
            try
            {
                var updatedStudent = await _studentService.GetStudent(student.Id);
                if(updatedStudent == null)
                {
                    return NotFound($"Student co id {student.Id} khong tim thay");
                } 
                else
                {
                    return await _studentService.UpdateStudent(student);
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Loi lay du lieu tu DB");
            }
        }
    }
}
