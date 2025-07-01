using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentTask.Database.Entities;
using StudentTask.Services.StudentService;
using StudentTask.Services.StudentService.Dto;

namespace StudentTask.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _service;

        public StudentController(IStudentService service) => _service = service;

        [HttpGet]
        public async Task<ActionResult<IList<GetStudentDto>>> GetAllStudents()
        {
            var studentList = await _service.GetAllStudents();
            return Ok(studentList);
        }

        [HttpGet("{id:int}")] 
        public async Task<ActionResult<GetStudentDto>> GetStudentById(int id)
        {
            try
            {
                var student = await _service.GetStudentById(id);
                if (student == null)
                {
                    return NotFound($"There is no student with this Id {id}.");  
                }

                return Ok(student);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost("add")]
        public async Task<ActionResult<GetStudentDto>> AddStudent([FromBody] AddStudentDto newStudent)
        {
            try
            {
               var createdStudent = await _service.AddStudent(newStudent);
               return Ok(createdStudent);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("edit/{id:int}")]
        public async Task<ActionResult<GetStudentDto>> EditStudent(int id,[FromBody] EditStudentDto newStudent)
        {
            try
            {
               var editedStudnet = await _service.EditStudentById(id, newStudent);
                return Ok(editedStudnet);
            }
            catch (Exception e)
            {
                if (e is KeyNotFoundException)
                {
                    return NotFound($"There is no student with this Id {id}.");
                }
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("delete/{id:int}")]
        public async Task<ActionResult> DeleteStudent(int id)
        {
            try
            {
                await _service.DeleteStudentById(id);
                return Ok("Student deleted successfully.");
            }
            catch (Exception e)
            {
                if (e is KeyNotFoundException)
                {
                    return NotFound($"There is no student with this Id {id}.");
                }
                return BadRequest(e.Message);
            }
        }

    }
}
