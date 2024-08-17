using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentManagement.Models;
using StudentManagement.ViewModels;

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
            try
            {
                var courses = _studentManagementContext.Courses.ToList();
                var departments = _studentManagementContext.Departments.ToList();
                var coursesWithDepartments = from course in courses
                                             join department in departments on course.DepartmentId equals department.Id
                                             select new CourseViewModel
                                             {
                                                 Id = course.Id,
                                                 CourseName = course.Name,
                                                 DepartmentName = department.Name
                                             };

                return View(coursesWithDepartments);
            }
            catch (Exception) 
            {
                throw;
            }
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
