using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentManagement.Models;
using System.Diagnostics;

namespace StudentManagement.Controllers
{
    public class UserController : Controller
    {
        private readonly ILogger<UserController> _logger;
        private readonly StudentManagementContext _studentManagementContext;

        public UserController(ILogger<UserController> logger, StudentManagementContext context)
        {
            _logger = logger;
            _studentManagementContext = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Create() 
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(string userEmail, string password)
        {
            if (!ModelState.IsValid)
            {
                return NotFound();
            }
            else 
            {
                try
                {
                    _studentManagementContext.Users.Add(new User() { UserEmail = userEmail, Password = password, RoleId = 1});
                    _studentManagementContext.SaveChanges();
                }
                catch (DbUpdateException) 
                {
                    throw;
                }
            }
            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
