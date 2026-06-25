using Lab2_Programming.Data;
using Lab2_Programming.Models;
using Microsoft.EntityFrameworkCore;

namespace Lab2_Programming.Repositories
{
    
    public class StudentRepository : IStudentRepository
    {
        private readonly SchoolDbContext db;

        public StudentRepository(SchoolDbContext db)
        {
            this.db = db;
        }
        public IQueryable<Student> GetAllStudentsWithTeachers()
        {
            
            return db.Students.Include(student => student.Teacher);
        }
        public Student GetStudentById(int id)
        {
            return db.Students.Include(s => s.Teacher).FirstOrDefault(s => s.StudentId == id);
        }
        public void DeleteStudentById(int id)
        {
            db.Students.Where(s => s.StudentId == id).ExecuteDelete();
        }
        public void AddStudent(Student student)
        {
            db.Students.Add(student);
            db.SaveChanges();
        }
        public int GetTeacherId(string className)
        {
            var teacherId = db.Teachers.Where(t => t.TeacherClass == className).Select(t => t.TeacherId).FirstOrDefault();
            return teacherId;
            
        }
        public void UpdateStudent(Student student)
        {
            db.Students.Update(student);
            db.SaveChanges();
        }
    }
}
