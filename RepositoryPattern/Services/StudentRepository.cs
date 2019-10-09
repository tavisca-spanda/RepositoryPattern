using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RepositoryPattern.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RepositoryPattern.Services
{
    public class StudentRepository : IStudentRepository
    {
        private readonly StudentDetailsContext _context;
        public StudentRepository(StudentDetailsContext _context )
        {
            this._context=_context;
        }

        public IEnumerable<StudentDetails> SelectAll()
        {
            return _context.StudentDetails.ToList();
        }

        public StudentDetails SelectByID(Guid id)
        {
            return _context.StudentDetails.Find(id);
        }

        public void Insert(StudentDetails obj)
        {
            _context.StudentDetails.Add(obj);
            
        }

        public void Update(StudentDetails studentDetails)
        {
            _context.Entry(studentDetails).State = EntityState.Modified;
        }

        

        public void Delete(StudentDetails studentDetails)
        {
            
            _context.StudentDetails.Remove(studentDetails);
            
        }

        public void Save()
        {

            _context.SaveChanges();
            
        }

        public bool StudentDetailsExists(Guid id)
        {
            return _context.StudentDetails.Any(e => e.ID == id);
        }


    }
}

