using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using StudentTask.Database.Entities;

namespace StudentTask.Database.Contexts
{
    public class StudentContext(DbContextOptions<StudentContext> options) : DbContext(options)
    {
        public DbSet<StudentModel> Students { get; set; }
    }
}
