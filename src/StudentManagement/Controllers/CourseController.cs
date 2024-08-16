using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentManagement.Models;

namespace StudentManagement.Controllers
{
    public class CourseController : Controller
    {
        private readonly StudentManagementContext _studentManagementContext;

        public CourseController(StudentManagementContext context) 
        {
            _studentManagementContext = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(string name, int departmentId)
        {
            if (!ModelState.IsValid)
            {
                return NotFound();
            }
            else 
            {
                try
                {
                    _studentManagementContext.Courses.Add(new Course { Name = name, DepartmentId = departmentId });
                    _studentManagementContext.SaveChanges();
                }
                catch (DbUpdateException) 
                {
                    throw;
                }
            }
            return View();
        }
    }
}
