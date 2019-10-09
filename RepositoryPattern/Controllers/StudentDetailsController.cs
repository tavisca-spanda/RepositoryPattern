using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RepositoryPattern.Models;
using RepositoryPattern.Services;

namespace RepositoryPattern.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentDetailsController : ControllerBase
    {
        private readonly IStudentRepository _studentRepository;


        public StudentDetailsController(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        // GET: api/StudentDetails
        [HttpGet]
        public IEnumerable<StudentDetails> GetStudentDetails()
        {
            
            var studentList= _studentRepository.SelectAll();

            return studentList;


        }

        // GET: api/StudentDetails/5
        [HttpGet("{id}")]
        public async Task<ActionResult<StudentDetails>> GetStudentDetails(Guid id)
        {
            var studentDetails =  _studentRepository.SelectByID(id);

            if (studentDetails == null)
            {
                return NotFound();
            }

            return studentDetails;
        }

        // PUT: api/StudentDetails/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutStudentDetails(Guid id, StudentDetails studentDetails)
        {
            if (id != studentDetails.ID)
            {
                return BadRequest();
            }

            _studentRepository.Update(studentDetails);

            try
            {
                _studentRepository.Save();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_studentRepository.StudentDetailsExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/StudentDetails
        [HttpPost]
        public async Task<ActionResult<StudentDetails>> PostStudentDetails(StudentDetails studentDetails)
        {
            _studentRepository.Insert(studentDetails);
            _studentRepository.Save();

            return CreatedAtAction("GetStudentDetails", new { id = studentDetails.ID }, studentDetails);
        }

        // DELETE: api/StudentDetails/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<StudentDetails>> DeleteStudentDetails(Guid id)
        {
            var studentDetails =  _studentRepository.SelectByID(id);
            if (studentDetails == null)
            {
                return NotFound();
            }

            _studentRepository.Delete(studentDetails);
            _studentRepository.Save();

            return studentDetails;
        }

       
    }
}
