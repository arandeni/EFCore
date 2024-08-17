using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentManagement.Models;

namespace StudentManagement.Controllers
{
    public class DepartmentController : Controller
    {
        private readonly StudentManagementContext _studentManagementContext;

        public DepartmentController(StudentManagementContext context) 
        {
            _studentManagementContext = context;
        }

        public IActionResult Index()
        {
            var departments = _studentManagementContext.Departments.ToList();
            return View(departments);
        }

        public IActionResult Create() 
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(string name)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _studentManagementContext.Departments.Add(new Department() { Name = name });
                    _studentManagementContext.SaveChanges();
                }
                catch (DbUpdateException) 
                {
                    throw;
                }
            }
            else 
            {
                return NotFound();
            }
            return View();
        }
    }
}
