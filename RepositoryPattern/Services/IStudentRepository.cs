using System;
using System.Collections.Generic;
using RepositoryPattern.Models;

namespace RepositoryPattern.Services
{
    public interface IStudentRepository
    {
        void Delete(StudentDetails studentDetails);
        void Insert(StudentDetails obj);
        void Save();
        IEnumerable<StudentDetails> SelectAll();
        StudentDetails SelectByID(Guid id);
        bool StudentDetailsExists(Guid id);
        void Update(StudentDetails studentDetails);
    }
}