using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentTask.Services.StudentService.Dto
{
    public record AddStudentDto
    {
        [Required] 
        public string FullName { get; set; }
        [Required]
        public string NationalCode { get; set; }
        [Required]
        public DateOnly BirthDate { get; set; }
    }
}
