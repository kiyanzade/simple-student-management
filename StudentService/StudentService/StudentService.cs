using AutoMapper;
using Microsoft.EntityFrameworkCore;
using StudentTask.Database.Contexts;
using StudentTask.Database.Entities;
using StudentTask.Services.StudentService.Dto;

namespace StudentTask.Services.StudentService;

    public class StudentService : IStudentService
    {

        private readonly StudentContext _dbContext;
        private readonly IMapper _mapper;
        public StudentService(StudentContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<IList<GetStudentDto>> GetAllStudents()
        {
            var students = await _dbContext.Students.ToListAsync();
            return students.Select(student => _mapper.Map<GetStudentDto>(student)).ToList();
        }

        public async Task<GetStudentDto?> GetStudentById(int id)
        {
            var student = await _dbContext.Students.FindAsync(id);
            if (student is null) return null;
            var dto = _mapper.Map<GetStudentDto>(student);
            return dto;
        }

        public async Task<GetStudentDto> EditStudentById(int id, EditStudentDto dto)
        {
            var existingStudent = await _dbContext.Students.FindAsync(id)?? throw new KeyNotFoundException($"There is no student with this Id {id}.");
            UpdateStudentFields(existingStudent, dto);
            await _dbContext.SaveChangesAsync();

            return _mapper.Map<GetStudentDto>(existingStudent);
        }

        public async Task<GetStudentDto> AddStudent(AddStudentDto dto)
        {
            var student = _mapper.Map<StudentModel>(dto);
            _dbContext.Students.Add(student);
            await _dbContext.SaveChangesAsync();

            return _mapper.Map<GetStudentDto>(student);
        }

        public async Task DeleteStudentById(int id)
        {
            var existingStudent = await _dbContext.Students.FindAsync(id)?? throw new KeyNotFoundException($"There is no student with this Id {id}.");
            _dbContext.Students.Remove(existingStudent);
            await _dbContext.SaveChangesAsync();
        }

        private void UpdateStudentFields(StudentModel existingStudent, EditStudentDto dto)
    {
        if (!string.IsNullOrEmpty(dto.FullName))
        {
            existingStudent.FullName = dto.FullName;
        }
        if (!string.IsNullOrEmpty(dto.NationalCode))
        {
            existingStudent.NationalCode = dto.NationalCode;
        }
       
        if (dto.BirthDate != null)
        {
            existingStudent.BirthDate = dto.BirthDate.Value;
        }
    }


}


