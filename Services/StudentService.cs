using Lab2_Programming.Models;
using Lab2_Programming.Repositories;

namespace Lab2_Programming.Services
{
    
    public class StudentService : IStudentService
    {
        private readonly IStudentRepository _studentRepository;
        public StudentService(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }
        public IEnumerable<Student> GetAllStudentsOrderByClass()
        {
            try
            {
                return _studentRepository.GetAllStudentsWithTeachers().OrderBy(c => c.LastName).ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("Не вдалось дістати дані з Бази даних!", ex);
            }
        }
        public Student GetStudentInfoById(int id)
        {
            return _studentRepository.GetStudentById(id);
        }
        public void DeleteStudent(int id)
        {
            if (id <= 0)
            {
                throw new ArgumentException("Некоректний ID учня.");
            }

            try
            {
                _studentRepository.DeleteStudentById(id);
            }
            catch (Exception ex)
            {
                throw new Exception("Не вдалося видалити учня. Помилка бази даних.", ex);
            }
        }
        public void AddStudent(Student student, string className)
        {
            int teacherId = _studentRepository.GetTeacherId(className);

            if (teacherId == 0)
            {
                throw new ArgumentException("Вчителя такого класу не знайдено!");
            }

            ValidateStudentData(student);

            student.TeacherId = teacherId;

            try
            {
                _studentRepository.AddStudent(student);
            }
            catch (Exception ex)
            {
                throw new Exception("Помилка додавання учня: проблеми з записом в Базу Даних!", ex);
            }
        }

        public void UpdateStudent(Student student, string className)
        {
            int teacherId = _studentRepository.GetTeacherId(className);

            if (teacherId == 0)
            {
                throw new ArgumentException("Вчителя такого класу не знайдено!");
            }

            ValidateStudentData(student);

            student.TeacherId = teacherId;

            try
            {
                _studentRepository.UpdateStudent(student);
            }
            catch (Exception ex)
            {
                throw new Exception("Помилка оновлення: проблеми з Базою Даних!", ex);
            }
        }
        private void ValidateStudentData(Student student)
        {
            if (student == null)
            {
                throw new ArgumentException("Помилка даних!");
            }

            if (string.IsNullOrEmpty(student.Name) || string.IsNullOrEmpty(student.LastName))
            {
                throw new ArgumentException("Ім'я та Прізвище не можуть бути пустими!");
            }

            if (student.AverageGrade > 12 || student.AverageGrade < 0)
            {
                throw new ArgumentException("Середня оцінка має бути в межах від 0 до 12 включно!");
            }

            if (student.ParentsPhone.Length != 0 && (student.ParentsPhone.Length < 13 || student.ParentsPhone.Length > 13))
            {
                throw new ArgumentException("Номер телефону батьків має бути у форматі +380XXXXXXXXX!");
            }
        }
    
    }
}
