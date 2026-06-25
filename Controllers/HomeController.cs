using Lab2_Programming.Data;
using Lab2_Programming.Models;
using Lab2_Programming.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Lab2_Programming.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IStudentService _studentService;

        public HomeController(ILogger<HomeController> logger, IStudentService studentService)
        {
            _logger = logger;
            _studentService = studentService;
        }

        public IActionResult Index()
        {
            var students = _studentService.GetAllStudentsOrderByClass();
            return View(students);
        }

        [HttpPost]
        public IActionResult DeleteStudent(int id)
        {
            try
            {
                _studentService.DeleteStudent(id);
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult CreateStudent(Student student, string className)
        {
            ModelState.Remove("Teacher");
            if (!ModelState.IsValid)
            {
                var exactErrors = string.Join(" | ", ModelState.Values
                                .SelectMany(v => v.Errors)
                                .Select(e => e.ErrorMessage));
                                
                TempData["ErrorMessage"] = $"Помилка форми: {exactErrors}";
                return RedirectToAction("Index");
            }

            try
            { 
                _studentService.AddStudent(student, className);
            }
            catch (ArgumentException ex)
            {
                TempData["ErrorMessage"] = ex.Message;
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = "Сталася помилка при створенні студента. Exception: " + ex.Message;
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult UpdateStudent(Student student, string className)
        {
            ModelState.Remove("Teacher");
            if (!ModelState.IsValid)
            {
                var exactErrors = string.Join(" | ", ModelState.Values
                                .SelectMany(v => v.Errors)
                                .Select(e => e.ErrorMessage));
                TempData["ErrorMessage"] = $"Помилка форми: {exactErrors}";
                return RedirectToAction("Info", new { id = student.StudentId });
            }

            try
            {
                _studentService.UpdateStudent(student, className);
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
            }

            return RedirectToAction("Info", new { id = student.StudentId });
        }
        public IActionResult Info(int id)
        {
            var student = _studentService.GetStudentInfoById(id);

            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
