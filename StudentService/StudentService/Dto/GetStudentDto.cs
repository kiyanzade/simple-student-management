using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentTask.Services.StudentService.Dto
{
    public class GetStudentDto
    {
        public int Id { get; set; }

        public string FullName { get; set; }

        public string NationalCode { get; set; }

        public DateOnly BirthDate { get; set; }
    }
}
