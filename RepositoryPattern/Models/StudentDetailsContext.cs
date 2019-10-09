using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RepositoryPattern.Models
{
    public class StudentDetailsContext: DbContext
    {
        public StudentDetailsContext (DbContextOptions<StudentDetailsContext> options) : base(options)
        {

        }

        public DbSet<StudentDetails> StudentDetails { get; set; }

    }
}
