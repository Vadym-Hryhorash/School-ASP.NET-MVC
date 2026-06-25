using Lab2_Programming.Models;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Lab2_Programming.Repositories
{
    public interface IStudentRepository
    {
        IQueryable<Student> GetAllStudentsWithTeachers();
        Student GetStudentById(int id);
        void DeleteStudentById(int id);
        void AddStudent(Student student);
        int GetTeacherId(string className);
        void UpdateStudent(Student student);
    }
}
