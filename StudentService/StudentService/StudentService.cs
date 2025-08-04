using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Logging;
using StudentTask.Database.Contexts;
using StudentTask.Database.Entities;
using StudentTask.Services.StudentService.Dto;
using System.Text.Json;

namespace StudentTask.Services.StudentService;

    public class StudentService : IStudentService
    {

        private readonly StudentContext _dbContext;
        private readonly IMapper _mapper;
        private readonly IDistributedCache _cache;
        private readonly  ILogger<StudentService> _logger;
        public StudentService(StudentContext dbContext, IMapper mapper, IDistributedCache cache, ILogger<StudentService> logger) 
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _cache = cache;
            _logger = logger;
        }

        public async Task<IList<GetStudentDto>> GetAllStudents()
        {
        _logger.LogInformation("fetching data for students: from cache.");
        var cachedData = await _cache.GetStringAsync("students");

        if (!string.IsNullOrEmpty(cachedData))
        {
            _logger.LogInformation("cache hit for key: students.");
            var students = JsonSerializer.Deserialize<List<StudentModel>>(cachedData)!;
            return students.Select(s => _mapper.Map<GetStudentDto>(s)).ToList();
        }


        _logger.LogInformation("cache miss. fetching from database.");
        var studentList = await _dbContext.Students.ToListAsync();

        var options = new DistributedCacheEntryOptions
        {
            AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(60),
            SlidingExpiration = TimeSpan.FromMinutes(30)
        };

        var serializedData = JsonSerializer.Serialize(studentList);
        await _cache.SetStringAsync("students", serializedData, options);


        return studentList.Select(s => _mapper.Map<GetStudentDto>(s)).ToList();
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
        _logger.LogInformation("invalidating cache for students: from cache.");
        _cache.Remove("students");

        return _mapper.Map<GetStudentDto>(existingStudent);
        }

        public async Task<GetStudentDto> AddStudent(AddStudentDto dto)
        {
            var student = _mapper.Map<StudentModel>(dto);
            _dbContext.Students.Add(student);
            await _dbContext.SaveChangesAsync();

        _logger.LogInformation("invalidating cache for students: from cache.");
         _cache.Remove("students");

            return _mapper.Map<GetStudentDto>(student);
        }

        public async Task DeleteStudentById(int id)
        {
            var existingStudent = await _dbContext.Students.FindAsync(id)?? throw new KeyNotFoundException($"There is no student with this Id {id}.");
            _dbContext.Students.Remove(existingStudent);
            await _dbContext.SaveChangesAsync();
        _logger.LogInformation("invalidating cache for students: from cache.");
        _cache.Remove("students");
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


