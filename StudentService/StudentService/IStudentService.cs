using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudentTask.Services.StudentService.Dto;

namespace StudentTask.Services.StudentService
{
    public interface IStudentService
    {
        Task<IList<GetStudentDto>> GetAllStudents();
        Task<GetStudentDto?> GetStudentById(int id);
        Task<GetStudentDto?> EditStudentById(int id, EditStudentDto dto);
        Task<GetStudentDto> AddStudent(AddStudentDto dto);
        Task DeleteStudentById(int id);
    }
}
