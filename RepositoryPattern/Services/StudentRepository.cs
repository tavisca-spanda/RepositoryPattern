using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RepositoryPattern.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RepositoryPattern.Services
{
    public class StudentRepository
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

        public StudentDetails SelectByID(string id)
        {
            return _context.StudentDetails.Find(id);
        }

        public void Insert(StudentDetails obj)
        {
            _context.StudentDetails.Add(obj);
            
        }

        public int Update(Guid id, StudentDetails studentDetails)
        {
            if (id != studentDetails.ID)
            {
                return 400;
            }

            _context.Entry(studentDetails).State = EntityState.Modified;

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StudentDetailsExists(id))
                {
                    return 404;
                }
                else
                {
                    throw;
                }
            }

            return 204;
        }

        

        public void Delete(StudentDetails studentDetails)
        {
            
            _context.StudentDetails.Remove(studentDetails);
            
        }

        public void Save(StudentDetails studentDetails)
        {

            _context.SaveChanges();
            
        }

        public bool StudentDetailsExists(Guid id)
        {
            return _context.StudentDetails.Any(e => e.ID == id);
        }


    }
}

