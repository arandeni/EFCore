using Microsoft.AspNetCore.Mvc;

namespace StudentManagement.Controllers
{
    public class DepartmentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
