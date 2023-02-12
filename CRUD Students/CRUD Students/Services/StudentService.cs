using CRUD_Students.Data.StudentDbContext;
using CRUD_Students.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD_Students.Services
{
    public class StudentService
    {
        private readonly StudentDbContext _dbContext;
        public StudentService(StudentDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void AddStudent(Student student)
        {
            _dbContext.Students.Add(student);
            _dbContext.SaveChanges();
        }

        public void UpdateStudent(Student student)
        {
            var existingStudent = _dbContext.Students.Find(student.Id);
            existingStudent!.FirstName = student.FirstName;
            existingStudent.LastName = student.LastName;
            existingStudent.Age = student.Age;
            existingStudent.Email = student.Email;
            _dbContext.SaveChanges();
        }

        public void DeleteStudent(int id)
        {
            var student = _dbContext.Students.Find(id);
            _dbContext.Students.Remove(student!);
            _dbContext.SaveChanges();
        }

        public List<Student> GetAllStudents()
        {
            return _dbContext.Students.ToList();
        }

        public Student GetStudentById(int id)
        {
            return _dbContext.Students.Find(id)!;
        }
    }
}