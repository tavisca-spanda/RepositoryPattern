using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RepositoryPattern.Models
{
    public class StudentDetails
    {
        [Key]
        public Guid ID { get; set; }
        [Required][MaxLength(40)]
        public string FirstName { get; set; }
        [Required][MaxLength(40)]
        public string LastName { get; set; }
        [Required][MaxLength(8)]
        public string DateOfBirth { get; set; }
        
    }
}
